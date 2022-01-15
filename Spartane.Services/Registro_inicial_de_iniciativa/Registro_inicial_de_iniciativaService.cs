using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Registro_inicial_de_iniciativa;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Registro_inicial_de_iniciativa
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Registro_inicial_de_iniciativaService : IRegistro_inicial_de_iniciativaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa> _Registro_inicial_de_iniciativaRepository;
        #endregion

        #region Ctor
        public Registro_inicial_de_iniciativaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa> Registro_inicial_de_iniciativaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Registro_inicial_de_iniciativaRepository = Registro_inicial_de_iniciativaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Registro_inicial_de_iniciativaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa>("sp_SelAllRegistro_inicial_de_iniciativa");
        }

        public IList<Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallRegistro_inicial_de_iniciativa_Complete>("sp_SelAllComplete_Registro_inicial_de_iniciativa");
            return data.Select(m => new Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa
            {
                Clave = m.Clave
                ,Nombre_de_la_iniciativa = m.Nombre_de_la_iniciativa
                ,Iniciales = m.Iniciales
                ,Folio = m.Folio
                ,BNEA_aprobado = m.BNEA_aprobado
                ,Folio_fase = m.Folio_fase
                ,Avance_Fase = m.Avance_Fase
                ,Cronograma = m.Cronograma
                ,Avance_de_la_Iniciativa = m.Avance_de_la_Iniciativa
                ,Calificacion = m.Calificacion
                ,Estatus_Estatus_Registro_Inicial = new Core.Classes.Estatus_Registro_Inicial.Estatus_Registro_Inicial() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Registro_inicial_de_iniciativa>("sp_ListSelCount_Registro_inicial_de_iniciativa", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRegistro_inicial_de_iniciativa>("sp_ListSelAll_Registro_inicial_de_iniciativa", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa
                {
                    Clave = m.Registro_inicial_de_iniciativa_Clave,
                    Nombre_de_la_iniciativa = m.Registro_inicial_de_iniciativa_Nombre_de_la_iniciativa,
                    Iniciales = m.Registro_inicial_de_iniciativa_Iniciales,
                    Folio = m.Registro_inicial_de_iniciativa_Folio,
                    BNEA_aprobado = m.Registro_inicial_de_iniciativa_BNEA_aprobado,
                    Folio_fase = m.Registro_inicial_de_iniciativa_Folio_fase,
                    Avance_Fase = m.Registro_inicial_de_iniciativa_Avance_Fase,
                    Cronograma = m.Registro_inicial_de_iniciativa_Cronograma,
                    Avance_de_la_Iniciativa = m.Registro_inicial_de_iniciativa_Avance_de_la_Iniciativa,
                    Calificacion = m.Registro_inicial_de_iniciativa_Calificacion,
                    Estatus = m.Registro_inicial_de_iniciativa_Estatus,

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

        public IList<Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Registro_inicial_de_iniciativaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Registro_inicial_de_iniciativaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRegistro_inicial_de_iniciativa>("sp_ListSelAll_Registro_inicial_de_iniciativa", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Registro_inicial_de_iniciativaPagingModel result = null;

            if (data != null)
            {
                result = new Registro_inicial_de_iniciativaPagingModel
                {
                    Registro_inicial_de_iniciativas =
                        data.Select(m => new Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa
                {
                    Clave = m.Registro_inicial_de_iniciativa_Clave
                    ,Nombre_de_la_iniciativa = m.Registro_inicial_de_iniciativa_Nombre_de_la_iniciativa
                    ,Iniciales = m.Registro_inicial_de_iniciativa_Iniciales
                    ,Folio = m.Registro_inicial_de_iniciativa_Folio
                    ,BNEA_aprobado = m.Registro_inicial_de_iniciativa_BNEA_aprobado
                    ,Folio_fase = m.Registro_inicial_de_iniciativa_Folio_fase
                    ,Avance_Fase = m.Registro_inicial_de_iniciativa_Avance_Fase
                    ,Cronograma = m.Registro_inicial_de_iniciativa_Cronograma
                    ,Avance_de_la_Iniciativa = m.Registro_inicial_de_iniciativa_Avance_de_la_Iniciativa
                    ,Calificacion = m.Registro_inicial_de_iniciativa_Calificacion
                    ,Estatus = m.Registro_inicial_de_iniciativa_Estatus
                    ,Estatus_Estatus_Registro_Inicial = new Core.Classes.Estatus_Registro_Inicial.Estatus_Registro_Inicial() { Clave = m.Registro_inicial_de_iniciativa_Estatus.GetValueOrDefault(), Descripcion = m.Registro_inicial_de_iniciativa_Estatus_Descripcion }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Registro_inicial_de_iniciativaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa>("sp_GetRegistro_inicial_de_iniciativa", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelRegistro_inicial_de_iniciativa>("sp_DelRegistro_inicial_de_iniciativa", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreNombre_de_la_iniciativa = _dataProvider.GetParameter();
                padreNombre_de_la_iniciativa.ParameterName = "Nombre_de_la_iniciativa";
                padreNombre_de_la_iniciativa.DbType = DbType.String;
                padreNombre_de_la_iniciativa.Value = (object)entity.Nombre_de_la_iniciativa ?? DBNull.Value;
                var padreIniciales = _dataProvider.GetParameter();
                padreIniciales.ParameterName = "Iniciales";
                padreIniciales.DbType = DbType.String;
                padreIniciales.Value = (object)entity.Iniciales ?? DBNull.Value;
                var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.String;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreBNEA_aprobado = _dataProvider.GetParameter();
                padreBNEA_aprobado.ParameterName = "BNEA_aprobado";
                padreBNEA_aprobado.DbType = DbType.Currency;
                padreBNEA_aprobado.Value = (object)entity.BNEA_aprobado ?? DBNull.Value;

                var padreFolio_fase = _dataProvider.GetParameter();
                padreFolio_fase.ParameterName = "Folio_fase";
                padreFolio_fase.DbType = DbType.String;
                padreFolio_fase.Value = (object)entity.Folio_fase ?? DBNull.Value;
                var padreAvance_Fase = _dataProvider.GetParameter();
                padreAvance_Fase.ParameterName = "Avance_Fase";
                padreAvance_Fase.DbType = DbType.Decimal;
                padreAvance_Fase.Value = (object)entity.Avance_Fase ?? DBNull.Value;

                var padreCronograma = _dataProvider.GetParameter();
                padreCronograma.ParameterName = "Cronograma";
                padreCronograma.DbType = DbType.String;
                padreCronograma.Value = (object)entity.Cronograma ?? DBNull.Value;
                var padreAvance_de_la_Iniciativa = _dataProvider.GetParameter();
                padreAvance_de_la_Iniciativa.ParameterName = "Avance_de_la_Iniciativa";
                padreAvance_de_la_Iniciativa.DbType = DbType.Decimal;
                padreAvance_de_la_Iniciativa.Value = (object)entity.Avance_de_la_Iniciativa ?? DBNull.Value;

                var padreCalificacion = _dataProvider.GetParameter();
                padreCalificacion.ParameterName = "Calificacion";
                padreCalificacion.DbType = DbType.Decimal;
                padreCalificacion.Value = (object)entity.Calificacion ?? DBNull.Value;

                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsRegistro_inicial_de_iniciativa>("sp_InsRegistro_inicial_de_iniciativa" , padreNombre_de_la_iniciativa
, padreIniciales
, padreFolio
, padreBNEA_aprobado
, padreFolio_fase
, padreAvance_Fase
, padreCronograma
, padreAvance_de_la_Iniciativa
, padreCalificacion
, padreEstatus
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

        public int Update(Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdNombre_de_la_iniciativa = _dataProvider.GetParameter();
                paramUpdNombre_de_la_iniciativa.ParameterName = "Nombre_de_la_iniciativa";
                paramUpdNombre_de_la_iniciativa.DbType = DbType.String;
                paramUpdNombre_de_la_iniciativa.Value = (object)entity.Nombre_de_la_iniciativa ?? DBNull.Value;
                var paramUpdIniciales = _dataProvider.GetParameter();
                paramUpdIniciales.ParameterName = "Iniciales";
                paramUpdIniciales.DbType = DbType.String;
                paramUpdIniciales.Value = (object)entity.Iniciales ?? DBNull.Value;
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.String;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdBNEA_aprobado = _dataProvider.GetParameter();
                paramUpdBNEA_aprobado.ParameterName = "BNEA_aprobado";
                paramUpdBNEA_aprobado.DbType = DbType.Currency;
                paramUpdBNEA_aprobado.Value = (object)entity.BNEA_aprobado ?? DBNull.Value;

                var paramUpdFolio_fase = _dataProvider.GetParameter();
                paramUpdFolio_fase.ParameterName = "Folio_fase";
                paramUpdFolio_fase.DbType = DbType.String;
                paramUpdFolio_fase.Value = (object)entity.Folio_fase ?? DBNull.Value;
                var paramUpdAvance_Fase = _dataProvider.GetParameter();
                paramUpdAvance_Fase.ParameterName = "Avance_Fase";
                paramUpdAvance_Fase.DbType = DbType.Decimal;
                paramUpdAvance_Fase.Value = (object)entity.Avance_Fase ?? DBNull.Value;

                var paramUpdCronograma = _dataProvider.GetParameter();
                paramUpdCronograma.ParameterName = "Cronograma";
                paramUpdCronograma.DbType = DbType.String;
                paramUpdCronograma.Value = (object)entity.Cronograma ?? DBNull.Value;
                var paramUpdAvance_de_la_Iniciativa = _dataProvider.GetParameter();
                paramUpdAvance_de_la_Iniciativa.ParameterName = "Avance_de_la_Iniciativa";
                paramUpdAvance_de_la_Iniciativa.DbType = DbType.Decimal;
                paramUpdAvance_de_la_Iniciativa.Value = (object)entity.Avance_de_la_Iniciativa ?? DBNull.Value;

                var paramUpdCalificacion = _dataProvider.GetParameter();
                paramUpdCalificacion.ParameterName = "Calificacion";
                paramUpdCalificacion.DbType = DbType.Decimal;
                paramUpdCalificacion.Value = (object)entity.Calificacion ?? DBNull.Value;

                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRegistro_inicial_de_iniciativa>("sp_UpdRegistro_inicial_de_iniciativa" , paramUpdClave , paramUpdNombre_de_la_iniciativa , paramUpdIniciales , paramUpdFolio , paramUpdBNEA_aprobado , paramUpdFolio_fase , paramUpdAvance_Fase , paramUpdCronograma , paramUpdAvance_de_la_Iniciativa , paramUpdCalificacion , paramUpdEstatus ).FirstOrDefault();

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
		public int Update_Captura_Enlace_PMO(Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa Registro_inicial_de_iniciativaDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdNombre_de_la_iniciativa = _dataProvider.GetParameter();
                paramUpdNombre_de_la_iniciativa.ParameterName = "Nombre_de_la_iniciativa";
                paramUpdNombre_de_la_iniciativa.DbType = DbType.String;
                paramUpdNombre_de_la_iniciativa.Value = (object)entity.Nombre_de_la_iniciativa ?? DBNull.Value;
                var paramUpdIniciales = _dataProvider.GetParameter();
                paramUpdIniciales.ParameterName = "Iniciales";
                paramUpdIniciales.DbType = DbType.String;
                paramUpdIniciales.Value = (object)entity.Iniciales ?? DBNull.Value;
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.String;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdBNEA_aprobado = _dataProvider.GetParameter();
                paramUpdBNEA_aprobado.ParameterName = "BNEA_aprobado";
                paramUpdBNEA_aprobado.DbType = DbType.Currency;
                paramUpdBNEA_aprobado.Value = (object)entity.BNEA_aprobado ?? DBNull.Value;
                var paramUpdFolio_fase = _dataProvider.GetParameter();
                paramUpdFolio_fase.ParameterName = "Folio_fase";
                paramUpdFolio_fase.DbType = DbType.String;
                paramUpdFolio_fase.Value = (object)Registro_inicial_de_iniciativaDB.Folio_fase ?? DBNull.Value;
                var paramUpdAvance_Fase = _dataProvider.GetParameter();
                paramUpdAvance_Fase.ParameterName = "Avance_Fase";
                paramUpdAvance_Fase.DbType = DbType.Decimal;
                paramUpdAvance_Fase.Value = (object)Registro_inicial_de_iniciativaDB.Avance_Fase ?? DBNull.Value;
                var paramUpdCronograma = _dataProvider.GetParameter();
                paramUpdCronograma.ParameterName = "Cronograma";
                paramUpdCronograma.DbType = DbType.String;
                paramUpdCronograma.Value = (object)Registro_inicial_de_iniciativaDB.Cronograma ?? DBNull.Value;
                var paramUpdAvance_de_la_Iniciativa = _dataProvider.GetParameter();
                paramUpdAvance_de_la_Iniciativa.ParameterName = "Avance_de_la_Iniciativa";
                paramUpdAvance_de_la_Iniciativa.DbType = DbType.Decimal;
                paramUpdAvance_de_la_Iniciativa.Value = (object)Registro_inicial_de_iniciativaDB.Avance_de_la_Iniciativa ?? DBNull.Value;
                var paramUpdCalificacion = _dataProvider.GetParameter();
                paramUpdCalificacion.ParameterName = "Calificacion";
                paramUpdCalificacion.DbType = DbType.Decimal;
                paramUpdCalificacion.Value = (object)Registro_inicial_de_iniciativaDB.Calificacion ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)Registro_inicial_de_iniciativaDB.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRegistro_inicial_de_iniciativa>("sp_UpdRegistro_inicial_de_iniciativa" , paramUpdClave , paramUpdNombre_de_la_iniciativa , paramUpdIniciales , paramUpdFolio , paramUpdBNEA_aprobado , paramUpdFolio_fase , paramUpdAvance_Fase , paramUpdCronograma , paramUpdAvance_de_la_Iniciativa , paramUpdCalificacion , paramUpdEstatus ).FirstOrDefault();

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

		public int Update_Captura_Mensual_de_Usuario_Enlace_y_PMO(Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa Registro_inicial_de_iniciativaDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)Registro_inicial_de_iniciativaDB.Clave ?? DBNull.Value;
                var paramUpdNombre_de_la_iniciativa = _dataProvider.GetParameter();
                paramUpdNombre_de_la_iniciativa.ParameterName = "Nombre_de_la_iniciativa";
                paramUpdNombre_de_la_iniciativa.DbType = DbType.String;
                paramUpdNombre_de_la_iniciativa.Value = (object)Registro_inicial_de_iniciativaDB.Nombre_de_la_iniciativa ?? DBNull.Value;
                var paramUpdIniciales = _dataProvider.GetParameter();
                paramUpdIniciales.ParameterName = "Iniciales";
                paramUpdIniciales.DbType = DbType.String;
                paramUpdIniciales.Value = (object)Registro_inicial_de_iniciativaDB.Iniciales ?? DBNull.Value;
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.String;
                paramUpdFolio.Value = (object)Registro_inicial_de_iniciativaDB.Folio ?? DBNull.Value;
                var paramUpdBNEA_aprobado = _dataProvider.GetParameter();
                paramUpdBNEA_aprobado.ParameterName = "BNEA_aprobado";
                paramUpdBNEA_aprobado.DbType = DbType.Currency;
                paramUpdBNEA_aprobado.Value = (object)Registro_inicial_de_iniciativaDB.BNEA_aprobado ?? DBNull.Value;
                var paramUpdFolio_fase = _dataProvider.GetParameter();
                paramUpdFolio_fase.ParameterName = "Folio_fase";
                paramUpdFolio_fase.DbType = DbType.String;
                paramUpdFolio_fase.Value = (object)entity.Folio_fase ?? DBNull.Value;
                var paramUpdAvance_Fase = _dataProvider.GetParameter();
                paramUpdAvance_Fase.ParameterName = "Avance_Fase";
                paramUpdAvance_Fase.DbType = DbType.Decimal;
                paramUpdAvance_Fase.Value = (object)entity.Avance_Fase ?? DBNull.Value;
                var paramUpdCronograma = _dataProvider.GetParameter();
                paramUpdCronograma.ParameterName = "Cronograma";
                paramUpdCronograma.DbType = DbType.String;
                paramUpdCronograma.Value = (object)Registro_inicial_de_iniciativaDB.Cronograma ?? DBNull.Value;
                var paramUpdAvance_de_la_Iniciativa = _dataProvider.GetParameter();
                paramUpdAvance_de_la_Iniciativa.ParameterName = "Avance_de_la_Iniciativa";
                paramUpdAvance_de_la_Iniciativa.DbType = DbType.Decimal;
                paramUpdAvance_de_la_Iniciativa.Value = (object)Registro_inicial_de_iniciativaDB.Avance_de_la_Iniciativa ?? DBNull.Value;
                var paramUpdCalificacion = _dataProvider.GetParameter();
                paramUpdCalificacion.ParameterName = "Calificacion";
                paramUpdCalificacion.DbType = DbType.Decimal;
                paramUpdCalificacion.Value = (object)Registro_inicial_de_iniciativaDB.Calificacion ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)Registro_inicial_de_iniciativaDB.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRegistro_inicial_de_iniciativa>("sp_UpdRegistro_inicial_de_iniciativa" , paramUpdClave , paramUpdNombre_de_la_iniciativa , paramUpdIniciales , paramUpdFolio , paramUpdBNEA_aprobado , paramUpdFolio_fase , paramUpdAvance_Fase , paramUpdCronograma , paramUpdAvance_de_la_Iniciativa , paramUpdCalificacion , paramUpdEstatus ).FirstOrDefault();

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

		public int Update_Formulado(Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa Registro_inicial_de_iniciativaDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)Registro_inicial_de_iniciativaDB.Clave ?? DBNull.Value;
                var paramUpdNombre_de_la_iniciativa = _dataProvider.GetParameter();
                paramUpdNombre_de_la_iniciativa.ParameterName = "Nombre_de_la_iniciativa";
                paramUpdNombre_de_la_iniciativa.DbType = DbType.String;
                paramUpdNombre_de_la_iniciativa.Value = (object)Registro_inicial_de_iniciativaDB.Nombre_de_la_iniciativa ?? DBNull.Value;
                var paramUpdIniciales = _dataProvider.GetParameter();
                paramUpdIniciales.ParameterName = "Iniciales";
                paramUpdIniciales.DbType = DbType.String;
                paramUpdIniciales.Value = (object)Registro_inicial_de_iniciativaDB.Iniciales ?? DBNull.Value;
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.String;
                paramUpdFolio.Value = (object)Registro_inicial_de_iniciativaDB.Folio ?? DBNull.Value;
                var paramUpdBNEA_aprobado = _dataProvider.GetParameter();
                paramUpdBNEA_aprobado.ParameterName = "BNEA_aprobado";
                paramUpdBNEA_aprobado.DbType = DbType.Currency;
                paramUpdBNEA_aprobado.Value = (object)Registro_inicial_de_iniciativaDB.BNEA_aprobado ?? DBNull.Value;
                var paramUpdFolio_fase = _dataProvider.GetParameter();
                paramUpdFolio_fase.ParameterName = "Folio_fase";
                paramUpdFolio_fase.DbType = DbType.String;
                paramUpdFolio_fase.Value = (object)Registro_inicial_de_iniciativaDB.Folio_fase ?? DBNull.Value;
                var paramUpdAvance_Fase = _dataProvider.GetParameter();
                paramUpdAvance_Fase.ParameterName = "Avance_Fase";
                paramUpdAvance_Fase.DbType = DbType.Decimal;
                paramUpdAvance_Fase.Value = (object)Registro_inicial_de_iniciativaDB.Avance_Fase ?? DBNull.Value;
                var paramUpdCronograma = _dataProvider.GetParameter();
                paramUpdCronograma.ParameterName = "Cronograma";
                paramUpdCronograma.DbType = DbType.String;
                paramUpdCronograma.Value = (object)entity.Cronograma ?? DBNull.Value;
                var paramUpdAvance_de_la_Iniciativa = _dataProvider.GetParameter();
                paramUpdAvance_de_la_Iniciativa.ParameterName = "Avance_de_la_Iniciativa";
                paramUpdAvance_de_la_Iniciativa.DbType = DbType.Decimal;
                paramUpdAvance_de_la_Iniciativa.Value = (object)entity.Avance_de_la_Iniciativa ?? DBNull.Value;
                var paramUpdCalificacion = _dataProvider.GetParameter();
                paramUpdCalificacion.ParameterName = "Calificacion";
                paramUpdCalificacion.DbType = DbType.Decimal;
                paramUpdCalificacion.Value = (object)entity.Calificacion ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRegistro_inicial_de_iniciativa>("sp_UpdRegistro_inicial_de_iniciativa" , paramUpdClave , paramUpdNombre_de_la_iniciativa , paramUpdIniciales , paramUpdFolio , paramUpdBNEA_aprobado , paramUpdFolio_fase , paramUpdAvance_Fase , paramUpdCronograma , paramUpdAvance_de_la_Iniciativa , paramUpdCalificacion , paramUpdEstatus ).FirstOrDefault();

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

		public int Update_Responsable_de_Alineacion(Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Registro_inicial_de_iniciativa.Registro_inicial_de_iniciativa Registro_inicial_de_iniciativaDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)Registro_inicial_de_iniciativaDB.Clave ?? DBNull.Value;
                var paramUpdNombre_de_la_iniciativa = _dataProvider.GetParameter();
                paramUpdNombre_de_la_iniciativa.ParameterName = "Nombre_de_la_iniciativa";
                paramUpdNombre_de_la_iniciativa.DbType = DbType.String;
                paramUpdNombre_de_la_iniciativa.Value = (object)Registro_inicial_de_iniciativaDB.Nombre_de_la_iniciativa ?? DBNull.Value;
                var paramUpdIniciales = _dataProvider.GetParameter();
                paramUpdIniciales.ParameterName = "Iniciales";
                paramUpdIniciales.DbType = DbType.String;
                paramUpdIniciales.Value = (object)Registro_inicial_de_iniciativaDB.Iniciales ?? DBNull.Value;
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.String;
                paramUpdFolio.Value = (object)Registro_inicial_de_iniciativaDB.Folio ?? DBNull.Value;
                var paramUpdBNEA_aprobado = _dataProvider.GetParameter();
                paramUpdBNEA_aprobado.ParameterName = "BNEA_aprobado";
                paramUpdBNEA_aprobado.DbType = DbType.Currency;
                paramUpdBNEA_aprobado.Value = (object)Registro_inicial_de_iniciativaDB.BNEA_aprobado ?? DBNull.Value;
                var paramUpdFolio_fase = _dataProvider.GetParameter();
                paramUpdFolio_fase.ParameterName = "Folio_fase";
                paramUpdFolio_fase.DbType = DbType.String;
                paramUpdFolio_fase.Value = (object)Registro_inicial_de_iniciativaDB.Folio_fase ?? DBNull.Value;
                var paramUpdAvance_Fase = _dataProvider.GetParameter();
                paramUpdAvance_Fase.ParameterName = "Avance_Fase";
                paramUpdAvance_Fase.DbType = DbType.Decimal;
                paramUpdAvance_Fase.Value = (object)Registro_inicial_de_iniciativaDB.Avance_Fase ?? DBNull.Value;
                var paramUpdCronograma = _dataProvider.GetParameter();
                paramUpdCronograma.ParameterName = "Cronograma";
                paramUpdCronograma.DbType = DbType.String;
                paramUpdCronograma.Value = (object)Registro_inicial_de_iniciativaDB.Cronograma ?? DBNull.Value;
                var paramUpdAvance_de_la_Iniciativa = _dataProvider.GetParameter();
                paramUpdAvance_de_la_Iniciativa.ParameterName = "Avance_de_la_Iniciativa";
                paramUpdAvance_de_la_Iniciativa.DbType = DbType.Decimal;
                paramUpdAvance_de_la_Iniciativa.Value = (object)Registro_inicial_de_iniciativaDB.Avance_de_la_Iniciativa ?? DBNull.Value;
                var paramUpdCalificacion = _dataProvider.GetParameter();
                paramUpdCalificacion.ParameterName = "Calificacion";
                paramUpdCalificacion.DbType = DbType.Decimal;
                paramUpdCalificacion.Value = (object)Registro_inicial_de_iniciativaDB.Calificacion ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)Registro_inicial_de_iniciativaDB.Estatus ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRegistro_inicial_de_iniciativa>("sp_UpdRegistro_inicial_de_iniciativa" , paramUpdClave , paramUpdNombre_de_la_iniciativa , paramUpdIniciales , paramUpdFolio , paramUpdBNEA_aprobado , paramUpdFolio_fase , paramUpdAvance_Fase , paramUpdCronograma , paramUpdAvance_de_la_Iniciativa , paramUpdCalificacion , paramUpdEstatus ).FirstOrDefault();

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

