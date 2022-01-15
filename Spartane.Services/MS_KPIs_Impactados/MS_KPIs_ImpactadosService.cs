using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.MS_KPIs_Impactados;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.MS_KPIs_Impactados
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class MS_KPIs_ImpactadosService : IMS_KPIs_ImpactadosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados> _MS_KPIs_ImpactadosRepository;
        #endregion

        #region Ctor
        public MS_KPIs_ImpactadosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados> MS_KPIs_ImpactadosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._MS_KPIs_ImpactadosRepository = MS_KPIs_ImpactadosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._MS_KPIs_ImpactadosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados>("sp_SelAllMS_KPIs_Impactados");
        }

        public IList<Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMS_KPIs_Impactados_Complete>("sp_SelAllComplete_MS_KPIs_Impactados");
            return data.Select(m => new Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados
            {
                Clave = m.Clave
                ,ID_Registro_Inicial = m.ID_Registro_Inicial
                ,KPI_KPIs = new Core.Classes.KPIs.KPIs() { Clave = m.KPI.GetValueOrDefault(), Descripcion = m.KPI_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_MS_KPIs_Impactados>("sp_ListSelCount_MS_KPIs_Impactados", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_KPIs_Impactados>("sp_ListSelAll_MS_KPIs_Impactados", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados
                {
                    Clave = m.MS_KPIs_Impactados_Clave,
                    ID_Registro_Inicial = m.MS_KPIs_Impactados_ID_Registro_Inicial,
                    KPI = m.MS_KPIs_Impactados_KPI,

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

        public IList<Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._MS_KPIs_ImpactadosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._MS_KPIs_ImpactadosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_ImpactadosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMS_KPIs_Impactados>("sp_ListSelAll_MS_KPIs_Impactados", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            MS_KPIs_ImpactadosPagingModel result = null;

            if (data != null)
            {
                result = new MS_KPIs_ImpactadosPagingModel
                {
                    MS_KPIs_Impactadoss =
                        data.Select(m => new Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados
                {
                    Clave = m.MS_KPIs_Impactados_Clave
                    ,ID_Registro_Inicial = m.MS_KPIs_Impactados_ID_Registro_Inicial
                    ,KPI = m.MS_KPIs_Impactados_KPI
                    ,KPI_KPIs = new Core.Classes.KPIs.KPIs() { Clave = m.MS_KPIs_Impactados_KPI.GetValueOrDefault(), Descripcion = m.MS_KPIs_Impactados_KPI_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._MS_KPIs_ImpactadosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados>("sp_GetMS_KPIs_Impactados", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMS_KPIs_Impactados>("sp_DelMS_KPIs_Impactados", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreID_Registro_Inicial = _dataProvider.GetParameter();
                padreID_Registro_Inicial.ParameterName = "ID_Registro_Inicial";
                padreID_Registro_Inicial.DbType = DbType.Int32;
                padreID_Registro_Inicial.Value = (object)entity.ID_Registro_Inicial ?? DBNull.Value;
                var padreKPI = _dataProvider.GetParameter();
                padreKPI.ParameterName = "KPI";
                padreKPI.DbType = DbType.Int32;
                padreKPI.Value = (object)entity.KPI ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMS_KPIs_Impactados>("sp_InsMS_KPIs_Impactados" , padreID_Registro_Inicial
, padreKPI
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

        public int Update(Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdID_Registro_Inicial = _dataProvider.GetParameter();
                paramUpdID_Registro_Inicial.ParameterName = "ID_Registro_Inicial";
                paramUpdID_Registro_Inicial.DbType = DbType.Int32;
                paramUpdID_Registro_Inicial.Value = (object)entity.ID_Registro_Inicial ?? DBNull.Value;
                var paramUpdKPI = _dataProvider.GetParameter();
                paramUpdKPI.ParameterName = "KPI";
                paramUpdKPI.DbType = DbType.Int32;
                paramUpdKPI.Value = (object)entity.KPI ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_KPIs_Impactados>("sp_UpdMS_KPIs_Impactados" , paramUpdClave , paramUpdID_Registro_Inicial , paramUpdKPI ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.MS_KPIs_Impactados.MS_KPIs_Impactados MS_KPIs_ImpactadosDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdID_Registro_Inicial = _dataProvider.GetParameter();
                paramUpdID_Registro_Inicial.ParameterName = "ID_Registro_Inicial";
                paramUpdID_Registro_Inicial.DbType = DbType.Int32;
                paramUpdID_Registro_Inicial.Value = (object)entity.ID_Registro_Inicial ?? DBNull.Value;
		var paramUpdKPI = _dataProvider.GetParameter();
                paramUpdKPI.ParameterName = "KPI";
                paramUpdKPI.DbType = DbType.Int32;
                paramUpdKPI.Value = (object)entity.KPI ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMS_KPIs_Impactados>("sp_UpdMS_KPIs_Impactados" , paramUpdClave , paramUpdID_Registro_Inicial , paramUpdKPI ).FirstOrDefault();

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

