﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Beneficios_Cualitativos;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Beneficios_Cualitativos
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Beneficios_CualitativosService : IBeneficios_CualitativosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos> _Beneficios_CualitativosRepository;
        #endregion

        #region Ctor
        public Beneficios_CualitativosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos> Beneficios_CualitativosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Beneficios_CualitativosRepository = Beneficios_CualitativosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Beneficios_CualitativosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos>("sp_SelAllBeneficios_Cualitativos");
        }

        public IList<Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallBeneficios_Cualitativos_Complete>("sp_SelAllComplete_Beneficios_Cualitativos");
            return data.Select(m => new Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Beneficios_Cualitativos>("sp_ListSelCount_Beneficios_Cualitativos", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllBeneficios_Cualitativos>("sp_ListSelAll_Beneficios_Cualitativos", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos
                {
                    Clave = m.Beneficios_Cualitativos_Clave,
                    Descripcion = m.Beneficios_Cualitativos_Descripcion,

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

        public IList<Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Beneficios_CualitativosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Beneficios_CualitativosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_CualitativosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllBeneficios_Cualitativos>("sp_ListSelAll_Beneficios_Cualitativos", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Beneficios_CualitativosPagingModel result = null;

            if (data != null)
            {
                result = new Beneficios_CualitativosPagingModel
                {
                    Beneficios_Cualitativoss =
                        data.Select(m => new Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos
                {
                    Clave = m.Beneficios_Cualitativos_Clave
                    ,Descripcion = m.Beneficios_Cualitativos_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Beneficios_CualitativosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos>("sp_GetBeneficios_Cualitativos", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelBeneficios_Cualitativos>("sp_DelBeneficios_Cualitativos", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsBeneficios_Cualitativos>("sp_InsBeneficios_Cualitativos" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdBeneficios_Cualitativos>("sp_UpdBeneficios_Cualitativos" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos Beneficios_CualitativosDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdBeneficios_Cualitativos>("sp_UpdBeneficios_Cualitativos" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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

