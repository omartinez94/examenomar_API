using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Registro_Inicial_Prioridad
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Registro_Inicial_PrioridadService : IDetalle_Registro_Inicial_PrioridadService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad> _Detalle_Registro_Inicial_PrioridadRepository;
        #endregion

        #region Ctor
        public Detalle_Registro_Inicial_PrioridadService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad> Detalle_Registro_Inicial_PrioridadRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Registro_Inicial_PrioridadRepository = Detalle_Registro_Inicial_PrioridadRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Registro_Inicial_PrioridadRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad>("sp_SelAllDetalle_Registro_Inicial_Prioridad");
        }

        public IList<Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Registro_Inicial_Prioridad_Complete>("sp_SelAllComplete_Detalle_Registro_Inicial_Prioridad");
            return data.Select(m => new Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad
            {
                Clave = m.Clave
                ,ID_Registro_Inicial = m.ID_Registro_Inicial
                ,Prioridad_Estrategica_Prioridades_Estrategicas = new Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas() { Clave = m.Prioridad_Estrategica.GetValueOrDefault(), Descripcion = m.Prioridad_Estrategica_Descripcion }
                ,Archivo_1 = m.Archivo_1
                ,Archivo_2 = m.Archivo_2


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Registro_Inicial_Prioridad>("sp_ListSelCount_Detalle_Registro_Inicial_Prioridad", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Registro_Inicial_Prioridad>("sp_ListSelAll_Detalle_Registro_Inicial_Prioridad", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad
                {
                    Clave = m.Detalle_Registro_Inicial_Prioridad_Clave,
                    ID_Registro_Inicial = m.Detalle_Registro_Inicial_Prioridad_ID_Registro_Inicial,
                    Prioridad_Estrategica = m.Detalle_Registro_Inicial_Prioridad_Prioridad_Estrategica,
                    Archivo_1 = m.Detalle_Registro_Inicial_Prioridad_Archivo_1,
                    Archivo_2 = m.Detalle_Registro_Inicial_Prioridad_Archivo_2,

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

        public IList<Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Registro_Inicial_PrioridadRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Registro_Inicial_PrioridadRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_PrioridadPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Registro_Inicial_Prioridad>("sp_ListSelAll_Detalle_Registro_Inicial_Prioridad", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Registro_Inicial_PrioridadPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Registro_Inicial_PrioridadPagingModel
                {
                    Detalle_Registro_Inicial_Prioridads =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad
                {
                    Clave = m.Detalle_Registro_Inicial_Prioridad_Clave
                    ,ID_Registro_Inicial = m.Detalle_Registro_Inicial_Prioridad_ID_Registro_Inicial
                    ,Prioridad_Estrategica = m.Detalle_Registro_Inicial_Prioridad_Prioridad_Estrategica
                    ,Prioridad_Estrategica_Prioridades_Estrategicas = new Core.Classes.Prioridades_Estrategicas.Prioridades_Estrategicas() { Clave = m.Detalle_Registro_Inicial_Prioridad_Prioridad_Estrategica.GetValueOrDefault(), Descripcion = m.Detalle_Registro_Inicial_Prioridad_Prioridad_Estrategica_Descripcion }
                    ,Archivo_1 = m.Detalle_Registro_Inicial_Prioridad_Archivo_1 ,Archivo_1_URL=m.Detalle_Registro_Inicial_Prioridad_Archivo_1_Nombre
                    ,Archivo_2 = m.Detalle_Registro_Inicial_Prioridad_Archivo_2 ,Archivo_2_URL=m.Detalle_Registro_Inicial_Prioridad_Archivo_2_Nombre

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Registro_Inicial_PrioridadRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad>("sp_GetDetalle_Registro_Inicial_Prioridad", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Registro_Inicial_Prioridad>("sp_DelDetalle_Registro_Inicial_Prioridad", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad entity)
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
                var padrePrioridad_Estrategica = _dataProvider.GetParameter();
                padrePrioridad_Estrategica.ParameterName = "Prioridad_Estrategica";
                padrePrioridad_Estrategica.DbType = DbType.Int32;
                padrePrioridad_Estrategica.Value = (object)entity.Prioridad_Estrategica ?? DBNull.Value;

                var padreArchivo_1 = _dataProvider.GetParameter();
                padreArchivo_1.ParameterName = "Archivo_1";
                padreArchivo_1.DbType = DbType.Int32;
                padreArchivo_1.Value = (object)entity.Archivo_1 ?? DBNull.Value;

                var padreArchivo_2 = _dataProvider.GetParameter();
                padreArchivo_2.ParameterName = "Archivo_2";
                padreArchivo_2.DbType = DbType.Int32;
                padreArchivo_2.Value = (object)entity.Archivo_2 ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Registro_Inicial_Prioridad>("sp_InsDetalle_Registro_Inicial_Prioridad" , padreID_Registro_Inicial
, padrePrioridad_Estrategica
, padreArchivo_1
, padreArchivo_2
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

        public int Update(Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad entity)
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
                var paramUpdPrioridad_Estrategica = _dataProvider.GetParameter();
                paramUpdPrioridad_Estrategica.ParameterName = "Prioridad_Estrategica";
                paramUpdPrioridad_Estrategica.DbType = DbType.Int32;
                paramUpdPrioridad_Estrategica.Value = (object)entity.Prioridad_Estrategica ?? DBNull.Value;

                var paramUpdArchivo_1 = _dataProvider.GetParameter();
                paramUpdArchivo_1.ParameterName = "Archivo_1";
                paramUpdArchivo_1.DbType = DbType.Int32;
                paramUpdArchivo_1.Value = (object)entity.Archivo_1 ?? DBNull.Value;

                var paramUpdArchivo_2 = _dataProvider.GetParameter();
                paramUpdArchivo_2.ParameterName = "Archivo_2";
                paramUpdArchivo_2.DbType = DbType.Int32;
                paramUpdArchivo_2.Value = (object)entity.Archivo_2 ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Registro_Inicial_Prioridad>("sp_UpdDetalle_Registro_Inicial_Prioridad" , paramUpdClave , paramUpdID_Registro_Inicial , paramUpdPrioridad_Estrategica , paramUpdArchivo_1 , paramUpdArchivo_2 ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Registro_Inicial_Prioridad.Detalle_Registro_Inicial_Prioridad Detalle_Registro_Inicial_PrioridadDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdID_Registro_Inicial = _dataProvider.GetParameter();
                paramUpdID_Registro_Inicial.ParameterName = "ID_Registro_Inicial";
                paramUpdID_Registro_Inicial.DbType = DbType.Int32;
                paramUpdID_Registro_Inicial.Value = (object)entity.ID_Registro_Inicial ?? DBNull.Value;
		var paramUpdPrioridad_Estrategica = _dataProvider.GetParameter();
                paramUpdPrioridad_Estrategica.ParameterName = "Prioridad_Estrategica";
                paramUpdPrioridad_Estrategica.DbType = DbType.Int32;
                paramUpdPrioridad_Estrategica.Value = (object)entity.Prioridad_Estrategica ?? DBNull.Value;
                var paramUpdArchivo_1 = _dataProvider.GetParameter();
                paramUpdArchivo_1.ParameterName = "Archivo_1";
                paramUpdArchivo_1.DbType = DbType.Int32;
                paramUpdArchivo_1.Value = (object)entity.Archivo_1 ?? DBNull.Value;
                var paramUpdArchivo_2 = _dataProvider.GetParameter();
                paramUpdArchivo_2.ParameterName = "Archivo_2";
                paramUpdArchivo_2.DbType = DbType.Int32;
                paramUpdArchivo_2.Value = (object)entity.Archivo_2 ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Registro_Inicial_Prioridad>("sp_UpdDetalle_Registro_Inicial_Prioridad" , paramUpdClave , paramUpdID_Registro_Inicial , paramUpdPrioridad_Estrategica , paramUpdArchivo_1 , paramUpdArchivo_2 ).FirstOrDefault();

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

