using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Medida_de_tiempo;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Medida_de_tiempo
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Medida_de_tiempoService : IMedida_de_tiempoService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo> _Medida_de_tiempoRepository;
        #endregion

        #region Ctor
        public Medida_de_tiempoService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo> Medida_de_tiempoRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Medida_de_tiempoRepository = Medida_de_tiempoRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Medida_de_tiempoRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo>("sp_SelAllMedida_de_tiempo");
        }

        public IList<Core.Classes.Medida_de_tiempo.Medida_de_tiempo> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallMedida_de_tiempo_Complete>("sp_SelAllComplete_Medida_de_tiempo");
            return data.Select(m => new Core.Classes.Medida_de_tiempo.Medida_de_tiempo
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

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Medida_de_tiempo>("sp_ListSelCount_Medida_de_tiempo", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMedida_de_tiempo>("sp_ListSelAll_Medida_de_tiempo", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo
                {
                    Clave = m.Medida_de_tiempo_Clave,
                    Descripcion = m.Medida_de_tiempo_Descripcion,

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

        public IList<Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Medida_de_tiempoRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Medida_de_tiempoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempoPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllMedida_de_tiempo>("sp_ListSelAll_Medida_de_tiempo", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Medida_de_tiempoPagingModel result = null;

            if (data != null)
            {
                result = new Medida_de_tiempoPagingModel
                {
                    Medida_de_tiempos =
                        data.Select(m => new Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo
                {
                    Clave = m.Medida_de_tiempo_Clave
                    ,Descripcion = m.Medida_de_tiempo_Descripcion

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Medida_de_tiempoRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo>("sp_GetMedida_de_tiempo", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelMedida_de_tiempo>("sp_DelMedida_de_tiempo", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsMedida_de_tiempo>("sp_InsMedida_de_tiempo" , padreDescripcion
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

        public int Update(Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo entity)
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
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMedida_de_tiempo>("sp_UpdMedida_de_tiempo" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Medida_de_tiempo.Medida_de_tiempo Medida_de_tiempoDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdMedida_de_tiempo>("sp_UpdMedida_de_tiempo" , paramUpdClave , paramUpdDescripcion ).FirstOrDefault();

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

