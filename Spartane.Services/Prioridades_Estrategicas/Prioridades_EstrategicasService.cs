using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Prioridades_Estrategicas;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Prioridades_Estrategicas
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Prioridades_EstrategicasService : IPrioridades_EstrategicasService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas> _Prioridades_EstrategicasRepository;
        #endregion

        #region Ctor
        public Prioridades_EstrategicasService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas> Prioridades_EstrategicasRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Prioridades_EstrategicasRepository = Prioridades_EstrategicasRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Prioridades_EstrategicasRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas>("sp_SelAllPrioridades_Estrategicas");
        }

        public IList<Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallPrioridades_Estrategicas_Complete>("sp_SelAllComplete_Prioridades_Estrategicas");
            return data.Select(m => new Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas
            {
                Clave = m.Clave
                ,Descripcion = m.Descripcion


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Prioridades_Estrategicas>("sp_ListSelCount_Prioridades_Estrategicas", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas> SelAll(bool ConRelaciones, string Where, string Order)
        {
            try
            {
                var padreWhere = _dataProvider.GetParameter();
                padreWhere.ParameterName = "Where";
                padreWhere.DbType = DbType.String;

                padreWhere.Value = Where;

                var padreOrderBy = _dataProvider.GetParameter();
                padreOrderBy.ParameterName = "Order";
                padreOrderBy.DbType = DbType.String;
                padreOrderBy.Value = Order;


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPrioridades_Estrategicas>("sp_ListSelAll_Prioridades_Estrategicas", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas
                {
                    Clave = m.Prioridades_Estrategicas_Clave,
                    Descripcion = m.Prioridades_Estrategicas_Descripcion,

                    //Id = m.Id,
                }).ToList();
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

        }

        public IList<Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Prioridades_EstrategicasRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Prioridades_EstrategicasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_EstrategicasPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            var padstartRowIndex = _dataProvider.GetParameter();
            padstartRowIndex.ParameterName = "startRowIndex";
            padstartRowIndex.DbType = DbType.Int32;
            padstartRowIndex.Value = startRowIndex;

            var padmaximumRows = _dataProvider.GetParameter();
            padmaximumRows.ParameterName = "maximumRows";
            padmaximumRows.DbType = DbType.Int32;
            padmaximumRows.Value = maximumRows;

            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var padOrder = _dataProvider.GetParameter();
            padOrder.ParameterName = "Order";
            padOrder.DbType = DbType.String;
            padOrder.Value = Order;

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllPrioridades_Estrategicas>("sp_ListSelAll_Prioridades_Estrategicas", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Prioridades_EstrategicasPagingModel result = null;

            if (data != null)
            {
                result = new Prioridades_EstrategicasPagingModel
                {
                    Prioridades_Estrategicass =
                        data.Select(m => new Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas
                {
                    Clave = m.Prioridades_Estrategicas_Clave
                    ,Descripcion = m.Prioridades_Estrategicas_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Prioridades_EstrategicasRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas>("sp_GetPrioridades_Estrategicas", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Clave";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelPrioridades_Estrategicas>("sp_DelPrioridades_Estrategicas", padreKey).FirstOrDefault();
                if (padreResult != null)
                    rta = padreResult.Result.ToString() == "1";
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

        public int Insert(Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsPrioridades_Estrategicas>("sp_InsPrioridades_Estrategicas" , padreDescripcion
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Clave);

            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

        public int Update(Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPrioridades_Estrategicas>("sp_UpdPrioridades_Estrategicas" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Clave);
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }
		public int Update_Datos_Generales(Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas Prioridades_EstrategicasDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdPrioridades_Estrategicas>("sp_UpdPrioridades_Estrategicas" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Clave);
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }


        #endregion
    }
}

