﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using Spartane.Core;

namespace Spartane.Data.EF
{
    /// <summary>
    /// Object Context
    /// </summary>
    public class TTObjectContext : DbContext, IDbContext
    {
        #region Ctor

        public TTObjectContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
            //((IObjectContextAdapter) this).ObjectContext.ContextOptions.LazyLoadingEnabled = true;
        }

        #endregion

        #region Utilities

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //dynamically load all configuration
            //System.Type configType = typeof(LanguageMap);   //any of your configuration classes here
            //var typesToRegister = Assembly.GetAssembly(configType).GetTypes()

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            //...or do it manually below. For example,
            //modelBuilder.Configurations.Add(new LanguageMap());



            base.OnModelCreating(modelBuilder);
        }


        /// <summary>
        /// Attach an entity to the context or return an already attached entity (if it was already attached)
        /// </summary>
        /// <typeparam name="TEntity">TEntity</typeparam>
        /// <param name="entity">Entity</param>
        /// <returns>Attached entity</returns>
        protected virtual TEntity AttachEntityToContext<TEntity>(TEntity entity) where TEntity : BaseEntity, new()
        {
            //little hack here until Entity Framework really supports stored procedures
            //otherwise, navigation properties of loaded entities are not loaded until an entity is attached to the context
            var alreadyAttached = Set<TEntity>().Local.FirstOrDefault(x => x.Id == entity.Id);
            if (alreadyAttached == null)
            {
                //attach new entity
                Set<TEntity>().Attach(entity);
                return entity;
            }
            else
            {
                //entity is already loaded.
                return alreadyAttached;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Create database script
        /// </summary>
        /// <returns>SQL to generate database</returns>
        public string CreateDatabaseScript()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
        }

        /// <summary>
        /// Get DbSet
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <returns>DbSet</returns>
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        /// <summary>
        /// Execute stores procedure and load a list of entities at the end
        /// </summary>
        /// <typeparam name="TEntity">Entity type</typeparam>
        /// <param name="commandText">Command text</param>
        /// <param name="parameters">Parameters</param>
        /// <returns>Entities</returns>
        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new()
        {
            List<TEntity> result = null;
            try
            {
                if (parameters != null && parameters.Length > 0)
                {
                    for (int i = 0; i <= parameters.Length - 1; i++)
                    {
                        var p = parameters[i] as DbParameter;
                        if (p == null)
                            throw new Exception("Not support parameter type");

                        commandText += i == 0 ? " " : ", ";

                        commandText += "@" + p.ParameterName;
                        if (p.Direction == ParameterDirection.InputOutput || p.Direction == ParameterDirection.Output)
                        {
                            //output parameter
                            commandText += " output";
                        }
                    }
                }

                 result = this.Database.SqlQuery<TEntity>(commandText, parameters).ToList();

            }
            catch (Exception ex)
            {
                
                throw ex;
            } //add parameters to command
            return result;

            //TODO: review this part
            //performance hack applied as described here 
            //bool acd = this.Configuration.AutoDetectChangesEnabled;
            //try
            //{
            //    this.Configuration.AutoDetectChangesEnabled = false;

            //    for (int i = 0; i < result.Count; i++)
            //        result[i] = AttachEntityToContext(result[i]);
            //}
            //finally
            //{
            //    this.Configuration.AutoDetectChangesEnabled = acd;
            //}

           
        }

        /// <summary>
        /// Creates a raw SQL query that will return elements of the given generic type.  The type can be any type that has properties that match the names of the columns returned from the query, or can be a simple primitive type. The type does not have to be an entity type. The results of this query are never tracked by the context even if the type of object returned is an entity type.
        /// </summary>
        /// <typeparam name="TElement">The type of object returned by the query.</typeparam>
        /// <param name="sql">The SQL query string.</param>
        /// <param name="parameters">The parameters to apply to the SQL query string.</param>
        /// <returns>Result</returns>
        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            return this.Database.SqlQuery<TElement>(sql, parameters);
        }

        /// <summary>
        /// Executes the given DDL/DML command against the database.
        /// </summary>
        /// <param name="sql">The command string</param>
        /// <param name="doNotEnsureTransaction">false - the transaction creation is not ensured; true - the transaction creation is ensured.</param>
        /// <param name="timeout">Timeout value, in seconds. A null value indicates that the default value of the underlying provider will be used</param>
        /// <param name="parameters">The parameters to apply to the command string.</param>
        /// <returns>The result returned by the database after executing the command.</returns>
        public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        {
            int? previousTimeout = null;
            if (timeout.HasValue)
            {
                //store previous timeout
                previousTimeout = ((IObjectContextAdapter)this).ObjectContext.CommandTimeout;
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = timeout;
            }

            var transactionalBehavior = doNotEnsureTransaction
                ? TransactionalBehavior.DoNotEnsureTransaction
                : TransactionalBehavior.EnsureTransaction;
            var result = this.Database.ExecuteSqlCommand(transactionalBehavior, sql, parameters);

            if (timeout.HasValue)
            {
                //Set previous timeout back
                ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = previousTimeout;
            }

            //return result
            return result;
        }

        /// <summary>
        /// Executes Raw SQL command against the database.
        /// </summary>
        /// <param name="query">The command string</param>
        /// <returns>The result returned by the database after executing the command.</returns>
        public DataTable ExecuteRawSql(string query)
        {
            DataTable dt = new DataTable();
            var conn = base.Database.Connection;
            var connectionState = conn.State;
            try
            {
                if (connectionState != ConnectionState.Open)
                    conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (connectionState != ConnectionState.Open)
                    conn.Close();
            }
            return dt;
        }
        public DataTable ExecuteRawSql(string query, IEnumerable<string> parameters)
        {
            if (parameters == null)
                parameters = new List<string>();

            var dt = new DataTable();
            var conn = base.Database.Connection;
            var connectionState = conn.State;
            var ctm = "0";
            int timeout;
            int.TryParse(ctm, out timeout);
            if (timeout == 0)
                timeout = 120;
            try
            {
                if (connectionState != ConnectionState.Open)
                    conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = query;
                    cmd.CommandTimeout = timeout;

                    var parameterValues = parameters as IList<string> ?? parameters.ToList();
                    for (var i = 0; i < parameterValues.Count(); i++)
                    {
                        //obtiene el valor del parametro
                        var value = parameterValues[i];
                        //crea el parametro
                        var param = cmd.CreateParameter();
                        param.Direction = ParameterDirection.Input;
                        //nombre del parámetro
                        param.ParameterName = string.Format("@p{0}", i + 1);
                        //valor del parámetro
                        param.Value = value;
                        cmd.Parameters.Add(param);
                    }

                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                //LogException(query, ex, "ExecuteRawSqlParameters");
                throw ex;
            }
            finally
            {
                if (connectionState != ConnectionState.Open)
                    conn.Close();
            }
            return dt;
        }
        #endregion
    }
}
