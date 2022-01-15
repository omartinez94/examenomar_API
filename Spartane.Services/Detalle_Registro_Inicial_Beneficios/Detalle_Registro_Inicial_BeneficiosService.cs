using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Registro_Inicial_Beneficios
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Registro_Inicial_BeneficiosService : IDetalle_Registro_Inicial_BeneficiosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios> _Detalle_Registro_Inicial_BeneficiosRepository;
        #endregion

        #region Ctor
        public Detalle_Registro_Inicial_BeneficiosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios> Detalle_Registro_Inicial_BeneficiosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Registro_Inicial_BeneficiosRepository = Detalle_Registro_Inicial_BeneficiosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Registro_Inicial_BeneficiosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios>("sp_SelAllDetalle_Registro_Inicial_Beneficios");
        }

        public IList<Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Registro_Inicial_Beneficios_Complete>("sp_SelAllComplete_Detalle_Registro_Inicial_Beneficios");
            return data.Select(m => new Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios
            {
                Clave = m.Clave
                ,ID_Registro_Inicial = m.ID_Registro_Inicial
                ,Beneficio_Beneficios_Cualitativos = new Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos() { Clave = m.Beneficio.GetValueOrDefault(), Descripcion = m.Beneficio_Descripcion }
                ,Rango_de_valor = m.Rango_de_valor


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Registro_Inicial_Beneficios>("sp_ListSelCount_Detalle_Registro_Inicial_Beneficios", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Registro_Inicial_Beneficios>("sp_ListSelAll_Detalle_Registro_Inicial_Beneficios", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios
                {
                    Clave = m.Detalle_Registro_Inicial_Beneficios_Clave,
                    ID_Registro_Inicial = m.Detalle_Registro_Inicial_Beneficios_ID_Registro_Inicial,
                    Beneficio = m.Detalle_Registro_Inicial_Beneficios_Beneficio,
                    Rango_de_valor = m.Detalle_Registro_Inicial_Beneficios_Rango_de_valor,

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

        public IList<Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Registro_Inicial_BeneficiosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Registro_Inicial_BeneficiosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_BeneficiosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Registro_Inicial_Beneficios>("sp_ListSelAll_Detalle_Registro_Inicial_Beneficios", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Registro_Inicial_BeneficiosPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Registro_Inicial_BeneficiosPagingModel
                {
                    Detalle_Registro_Inicial_Beneficioss =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios
                {
                    Clave = m.Detalle_Registro_Inicial_Beneficios_Clave
                    ,ID_Registro_Inicial = m.Detalle_Registro_Inicial_Beneficios_ID_Registro_Inicial
                    ,Beneficio = m.Detalle_Registro_Inicial_Beneficios_Beneficio
                    ,Beneficio_Beneficios_Cualitativos = new Core.Classes.Beneficios_Cualitativos.Beneficios_Cualitativos() { Clave = m.Detalle_Registro_Inicial_Beneficios_Beneficio.GetValueOrDefault(), Descripcion = m.Detalle_Registro_Inicial_Beneficios_Beneficio_Descripcion }
                    ,Rango_de_valor = m.Detalle_Registro_Inicial_Beneficios_Rango_de_valor

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Registro_Inicial_BeneficiosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios>("sp_GetDetalle_Registro_Inicial_Beneficios", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Registro_Inicial_Beneficios>("sp_DelDetalle_Registro_Inicial_Beneficios", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios entity)
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
                var padreBeneficio = _dataProvider.GetParameter();
                padreBeneficio.ParameterName = "Beneficio";
                padreBeneficio.DbType = DbType.Int32;
                padreBeneficio.Value = (object)entity.Beneficio ?? DBNull.Value;

                var padreRango_de_valor = _dataProvider.GetParameter();
                padreRango_de_valor.ParameterName = "Rango_de_valor";
                padreRango_de_valor.DbType = DbType.Int16;
                padreRango_de_valor.Value = (object)entity.Rango_de_valor ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Registro_Inicial_Beneficios>("sp_InsDetalle_Registro_Inicial_Beneficios" , padreID_Registro_Inicial
, padreBeneficio
, padreRango_de_valor
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

        public int Update(Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios entity)
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
                var paramUpdBeneficio = _dataProvider.GetParameter();
                paramUpdBeneficio.ParameterName = "Beneficio";
                paramUpdBeneficio.DbType = DbType.Int32;
                paramUpdBeneficio.Value = (object)entity.Beneficio ?? DBNull.Value;

                var paramUpdRango_de_valor = _dataProvider.GetParameter();
                paramUpdRango_de_valor.ParameterName = "Rango_de_valor";
                paramUpdRango_de_valor.DbType = DbType.Int16;
                paramUpdRango_de_valor.Value = (object)entity.Rango_de_valor ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Registro_Inicial_Beneficios>("sp_UpdDetalle_Registro_Inicial_Beneficios" , paramUpdClave , paramUpdID_Registro_Inicial , paramUpdBeneficio , paramUpdRango_de_valor ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Registro_Inicial_Beneficios.Detalle_Registro_Inicial_Beneficios Detalle_Registro_Inicial_BeneficiosDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdID_Registro_Inicial = _dataProvider.GetParameter();
                paramUpdID_Registro_Inicial.ParameterName = "ID_Registro_Inicial";
                paramUpdID_Registro_Inicial.DbType = DbType.Int32;
                paramUpdID_Registro_Inicial.Value = (object)entity.ID_Registro_Inicial ?? DBNull.Value;
		var paramUpdBeneficio = _dataProvider.GetParameter();
                paramUpdBeneficio.ParameterName = "Beneficio";
                paramUpdBeneficio.DbType = DbType.Int32;
                paramUpdBeneficio.Value = (object)entity.Beneficio ?? DBNull.Value;
                var paramUpdRango_de_valor = _dataProvider.GetParameter();
                paramUpdRango_de_valor.ParameterName = "Rango_de_valor";
                paramUpdRango_de_valor.DbType = DbType.Int16;
                paramUpdRango_de_valor.Value = (object)entity.Rango_de_valor ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Registro_Inicial_Beneficios>("sp_UpdDetalle_Registro_Inicial_Beneficios" , paramUpdClave , paramUpdID_Registro_Inicial , paramUpdBeneficio , paramUpdRango_de_valor ).FirstOrDefault();

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

