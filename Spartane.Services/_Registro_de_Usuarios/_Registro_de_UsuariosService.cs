using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes._Registro_de_Usuarios;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services._Registro_de_Usuarios
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class _Registro_de_UsuariosService : I_Registro_de_UsuariosService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios> __Registro_de_UsuariosRepository;
        #endregion

        #region Ctor
        public _Registro_de_UsuariosService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios> _Registro_de_UsuariosRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this.__Registro_de_UsuariosRepository = _Registro_de_UsuariosRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this.__Registro_de_UsuariosRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios>("sp_SelAll_Registro_de_Usuarios");
        }

        public IList<Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_Selall_Registro_de_Usuarios_Complete>("sp_SelAllComplete__Registro_de_Usuarios");
            return data.Select(m => new Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios
            {
                Folio = m.Folio
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_Registra.GetValueOrDefault(), Name = m.Usuario_que_Registra_Name }
                ,Nombres = m.Nombres
                ,Apellido_Paterno = m.Apellido_Paterno
                ,Apellido_Materno = m.Apellido_Materno
                ,Nombre_Completo = m.Nombre_Completo
                ,Usuario = m.Usuario
                ,Contrasena = m.Contrasena
                ,Confirmar_Contrasena = m.Confirmar_Contrasena
                ,Correo_Electronico = m.Correo_Electronico
                ,Celular = m.Celular
                ,Usuario_ID_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_ID.GetValueOrDefault(), Name = m.Usuario_ID_Name }
                ,Estatus_Estatus_de_Usuario = new Core.Classes.Estatus_de_Usuario.Estatus_de_Usuario() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }
                ,Pais_Pais = new Core.Classes.Pais.Pais() { Clave = m.Pais.GetValueOrDefault(), Nombre = m.Pais_Nombre }
                ,Estado_Estado = new Core.Classes.Estado.Estado() { Clave = m.Estado.GetValueOrDefault(), Nombre = m.Estado_Nombre }
                ,Municipio_Municipio = new Core.Classes.Municipio.Municipio() { Clave = m.Municipio.GetValueOrDefault(), Nombre = m.Municipio_Nombre }
                ,Calle = m.Calle
                ,Entre_Calle = m.Entre_Calle
                ,Y_Calle = m.Y_Calle
                ,Codigo_Postal = m.Codigo_Postal
                ,Referencias = m.Referencias
                ,Fotografia_del_domicilio = m.Fotografia_del_domicilio
                ,Domicilio_actual = m.Domicilio_actual.GetValueOrDefault()
                ,Cantidad = m.Cantidad
                ,Medida_de_tiempo_Medida_de_tiempo = new Core.Classes.Medida_de_tiempo.Medida_de_tiempo() { Clave = m.Medida_de_tiempo.GetValueOrDefault(), Descripcion = m.Medida_de_tiempo_Descripcion }
                ,Tiempo_viviendo_aqui = m.Tiempo_viviendo_aqui
                ,Fecha_de_autorizacion = m.Fecha_de_autorizacion
                ,Hora_de_autorizacion = m.Hora_de_autorizacion
                ,Usuario_que_autoriza_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m.Usuario_que_autoriza.GetValueOrDefault(), Name = m.Usuario_que_autoriza_Name }
                ,Respuesta_Respuesta = new Core.Classes.Respuesta.Respuesta() { Clave = m.Respuesta.GetValueOrDefault(), Descripcion = m.Respuesta_Descripcion }
                ,Observaciones = m.Observaciones


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount__Registro_de_Usuarios>("sp_ListSelCount__Registro_de_Usuarios", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAll_Registro_de_Usuarios>("sp_ListSelAll__Registro_de_Usuarios", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios
                {
                    Folio = m._Registro_de_Usuarios_Folio,
                    Fecha_de_Registro = m._Registro_de_Usuarios_Fecha_de_Registro,
                    Hora_de_Registro = m._Registro_de_Usuarios_Hora_de_Registro,
                    Usuario_que_Registra = m._Registro_de_Usuarios_Usuario_que_Registra,
                    Nombres = m._Registro_de_Usuarios_Nombres,
                    Apellido_Paterno = m._Registro_de_Usuarios_Apellido_Paterno,
                    Apellido_Materno = m._Registro_de_Usuarios_Apellido_Materno,
                    Nombre_Completo = m._Registro_de_Usuarios_Nombre_Completo,
                    Usuario = m._Registro_de_Usuarios_Usuario,
                    Contrasena = m._Registro_de_Usuarios_Contrasena,
                    Confirmar_Contrasena = m._Registro_de_Usuarios_Confirmar_Contrasena,
                    Correo_Electronico = m._Registro_de_Usuarios_Correo_Electronico,
                    Celular = m._Registro_de_Usuarios_Celular,
                    Usuario_ID = m._Registro_de_Usuarios_Usuario_ID,
                    Estatus = m._Registro_de_Usuarios_Estatus,
                    Pais = m._Registro_de_Usuarios_Pais,
                    Estado = m._Registro_de_Usuarios_Estado,
                    Municipio = m._Registro_de_Usuarios_Municipio,
                    Calle = m._Registro_de_Usuarios_Calle,
                    Entre_Calle = m._Registro_de_Usuarios_Entre_Calle,
                    Y_Calle = m._Registro_de_Usuarios_Y_Calle,
                    Codigo_Postal = m._Registro_de_Usuarios_Codigo_Postal,
                    Referencias = m._Registro_de_Usuarios_Referencias,
                    Fotografia_del_domicilio = m._Registro_de_Usuarios_Fotografia_del_domicilio,
                    Domicilio_actual = m._Registro_de_Usuarios_Domicilio_actual ?? false,
                    Cantidad = m._Registro_de_Usuarios_Cantidad,
                    Medida_de_tiempo = m._Registro_de_Usuarios_Medida_de_tiempo,
                    Tiempo_viviendo_aqui = m._Registro_de_Usuarios_Tiempo_viviendo_aqui,
                    Fecha_de_autorizacion = m._Registro_de_Usuarios_Fecha_de_autorizacion,
                    Hora_de_autorizacion = m._Registro_de_Usuarios_Hora_de_autorizacion,
                    Usuario_que_autoriza = m._Registro_de_Usuarios_Usuario_que_autoriza,
                    Respuesta = m._Registro_de_Usuarios_Respuesta,
                    Observaciones = m._Registro_de_Usuarios_Observaciones,

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

        public IList<Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this.__Registro_de_UsuariosRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this.__Registro_de_UsuariosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_UsuariosPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAll_Registro_de_Usuarios>("sp_ListSelAll__Registro_de_Usuarios", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            _Registro_de_UsuariosPagingModel result = null;

            if (data != null)
            {
                result = new _Registro_de_UsuariosPagingModel
                {
                    _Registro_de_Usuarioss =
                        data.Select(m => new Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios
                {
                    Folio = m._Registro_de_Usuarios_Folio
                    ,Fecha_de_Registro = m._Registro_de_Usuarios_Fecha_de_Registro
                    ,Hora_de_Registro = m._Registro_de_Usuarios_Hora_de_Registro
                    ,Usuario_que_Registra = m._Registro_de_Usuarios_Usuario_que_Registra
                    ,Usuario_que_Registra_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m._Registro_de_Usuarios_Usuario_que_Registra.GetValueOrDefault(), Name = m._Registro_de_Usuarios_Usuario_que_Registra_Name }
                    ,Nombres = m._Registro_de_Usuarios_Nombres
                    ,Apellido_Paterno = m._Registro_de_Usuarios_Apellido_Paterno
                    ,Apellido_Materno = m._Registro_de_Usuarios_Apellido_Materno
                    ,Nombre_Completo = m._Registro_de_Usuarios_Nombre_Completo
                    ,Usuario = m._Registro_de_Usuarios_Usuario
                    ,Contrasena = m._Registro_de_Usuarios_Contrasena
                    ,Confirmar_Contrasena = m._Registro_de_Usuarios_Confirmar_Contrasena
                    ,Correo_Electronico = m._Registro_de_Usuarios_Correo_Electronico
                    ,Celular = m._Registro_de_Usuarios_Celular
                    ,Usuario_ID = m._Registro_de_Usuarios_Usuario_ID
                    ,Usuario_ID_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m._Registro_de_Usuarios_Usuario_ID.GetValueOrDefault(), Name = m._Registro_de_Usuarios_Usuario_ID_Name }
                    ,Estatus = m._Registro_de_Usuarios_Estatus
                    ,Estatus_Estatus_de_Usuario = new Core.Classes.Estatus_de_Usuario.Estatus_de_Usuario() { Clave = m._Registro_de_Usuarios_Estatus.GetValueOrDefault(), Descripcion = m._Registro_de_Usuarios_Estatus_Descripcion }
                    ,Pais = m._Registro_de_Usuarios_Pais
                    ,Pais_Pais = new Core.Classes.Pais.Pais() { Clave = m._Registro_de_Usuarios_Pais.GetValueOrDefault(), Nombre = m._Registro_de_Usuarios_Pais_Nombre }
                    ,Estado = m._Registro_de_Usuarios_Estado
                    ,Estado_Estado = new Core.Classes.Estado.Estado() { Clave = m._Registro_de_Usuarios_Estado.GetValueOrDefault(), Nombre = m._Registro_de_Usuarios_Estado_Nombre }
                    ,Municipio = m._Registro_de_Usuarios_Municipio
                    ,Municipio_Municipio = new Core.Classes.Municipio.Municipio() { Clave = m._Registro_de_Usuarios_Municipio.GetValueOrDefault(), Nombre = m._Registro_de_Usuarios_Municipio_Nombre }
                    ,Calle = m._Registro_de_Usuarios_Calle
                    ,Entre_Calle = m._Registro_de_Usuarios_Entre_Calle
                    ,Y_Calle = m._Registro_de_Usuarios_Y_Calle
                    ,Codigo_Postal = m._Registro_de_Usuarios_Codigo_Postal
                    ,Referencias = m._Registro_de_Usuarios_Referencias
                    ,Fotografia_del_domicilio = m._Registro_de_Usuarios_Fotografia_del_domicilio ,Fotografia_del_domicilio_URL=m._Registro_de_Usuarios_Fotografia_del_domicilio_Nombre
                    ,Domicilio_actual = m._Registro_de_Usuarios_Domicilio_actual ?? false
                    ,Cantidad = m._Registro_de_Usuarios_Cantidad
                    ,Medida_de_tiempo = m._Registro_de_Usuarios_Medida_de_tiempo
                    ,Medida_de_tiempo_Medida_de_tiempo = new Core.Classes.Medida_de_tiempo.Medida_de_tiempo() { Clave = m._Registro_de_Usuarios_Medida_de_tiempo.GetValueOrDefault(), Descripcion = m._Registro_de_Usuarios_Medida_de_tiempo_Descripcion }
                    ,Tiempo_viviendo_aqui = m._Registro_de_Usuarios_Tiempo_viviendo_aqui
                    ,Fecha_de_autorizacion = m._Registro_de_Usuarios_Fecha_de_autorizacion
                    ,Hora_de_autorizacion = m._Registro_de_Usuarios_Hora_de_autorizacion
                    ,Usuario_que_autoriza = m._Registro_de_Usuarios_Usuario_que_autoriza
                    ,Usuario_que_autoriza_Spartan_User = new Core.Classes.Spartan_User.Spartan_User() { Id_User = m._Registro_de_Usuarios_Usuario_que_autoriza.GetValueOrDefault(), Name = m._Registro_de_Usuarios_Usuario_que_autoriza_Name }
                    ,Respuesta = m._Registro_de_Usuarios_Respuesta
                    ,Respuesta_Respuesta = new Core.Classes.Respuesta.Respuesta() { Clave = m._Registro_de_Usuarios_Respuesta.GetValueOrDefault(), Descripcion = m._Registro_de_Usuarios_Respuesta_Descripcion }
                    ,Observaciones = m._Registro_de_Usuarios_Observaciones

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this.__Registro_de_UsuariosRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios>("sp_Get_Registro_de_Usuarios", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Folio";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_Del_Registro_de_Usuarios>("sp_Del_Registro_de_Usuarios", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFecha_de_Registro = _dataProvider.GetParameter();
                padreFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                padreFecha_de_Registro.DbType = DbType.DateTime;
                padreFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;

                var padreHora_de_Registro = _dataProvider.GetParameter();
                padreHora_de_Registro.ParameterName = "Hora_de_Registro";
                padreHora_de_Registro.DbType = DbType.String;
                padreHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var padreUsuario_que_Registra = _dataProvider.GetParameter();
                padreUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                padreUsuario_que_Registra.DbType = DbType.Int32;
                padreUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;

                var padreNombres = _dataProvider.GetParameter();
                padreNombres.ParameterName = "Nombres";
                padreNombres.DbType = DbType.String;
                padreNombres.Value = (object)entity.Nombres ?? DBNull.Value;
                var padreApellido_Paterno = _dataProvider.GetParameter();
                padreApellido_Paterno.ParameterName = "Apellido_Paterno";
                padreApellido_Paterno.DbType = DbType.String;
                padreApellido_Paterno.Value = (object)entity.Apellido_Paterno ?? DBNull.Value;
                var padreApellido_Materno = _dataProvider.GetParameter();
                padreApellido_Materno.ParameterName = "Apellido_Materno";
                padreApellido_Materno.DbType = DbType.String;
                padreApellido_Materno.Value = (object)entity.Apellido_Materno ?? DBNull.Value;
                var padreNombre_Completo = _dataProvider.GetParameter();
                padreNombre_Completo.ParameterName = "Nombre_Completo";
                padreNombre_Completo.DbType = DbType.String;
                padreNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
                var padreUsuario = _dataProvider.GetParameter();
                padreUsuario.ParameterName = "Usuario";
                padreUsuario.DbType = DbType.String;
                padreUsuario.Value = (object)entity.Usuario ?? DBNull.Value;
                var padreContrasena = _dataProvider.GetParameter();
                padreContrasena.ParameterName = "Contrasena";
                padreContrasena.DbType = DbType.String;
                padreContrasena.Value = (object)entity.Contrasena ?? DBNull.Value;
                var padreConfirmar_Contrasena = _dataProvider.GetParameter();
                padreConfirmar_Contrasena.ParameterName = "Confirmar_Contrasena";
                padreConfirmar_Contrasena.DbType = DbType.String;
                padreConfirmar_Contrasena.Value = (object)entity.Confirmar_Contrasena ?? DBNull.Value;
                var padreCorreo_Electronico = _dataProvider.GetParameter();
                padreCorreo_Electronico.ParameterName = "Correo_Electronico";
                padreCorreo_Electronico.DbType = DbType.String;
                padreCorreo_Electronico.Value = (object)entity.Correo_Electronico ?? DBNull.Value;
                var padreCelular = _dataProvider.GetParameter();
                padreCelular.ParameterName = "Celular";
                padreCelular.DbType = DbType.String;
                padreCelular.Value = (object)entity.Celular ?? DBNull.Value;
                var padreUsuario_ID = _dataProvider.GetParameter();
                padreUsuario_ID.ParameterName = "Usuario_ID";
                padreUsuario_ID.DbType = DbType.Int32;
                padreUsuario_ID.Value = (object)entity.Usuario_ID ?? DBNull.Value;

                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

                var padrePais = _dataProvider.GetParameter();
                padrePais.ParameterName = "Pais";
                padrePais.DbType = DbType.Int32;
                padrePais.Value = (object)entity.Pais ?? DBNull.Value;

                var padreEstado = _dataProvider.GetParameter();
                padreEstado.ParameterName = "Estado";
                padreEstado.DbType = DbType.Int32;
                padreEstado.Value = (object)entity.Estado ?? DBNull.Value;

                var padreMunicipio = _dataProvider.GetParameter();
                padreMunicipio.ParameterName = "Municipio";
                padreMunicipio.DbType = DbType.Int32;
                padreMunicipio.Value = (object)entity.Municipio ?? DBNull.Value;

                var padreCalle = _dataProvider.GetParameter();
                padreCalle.ParameterName = "Calle";
                padreCalle.DbType = DbType.String;
                padreCalle.Value = (object)entity.Calle ?? DBNull.Value;
                var padreEntre_Calle = _dataProvider.GetParameter();
                padreEntre_Calle.ParameterName = "Entre_Calle";
                padreEntre_Calle.DbType = DbType.String;
                padreEntre_Calle.Value = (object)entity.Entre_Calle ?? DBNull.Value;
                var padreY_Calle = _dataProvider.GetParameter();
                padreY_Calle.ParameterName = "Y_Calle";
                padreY_Calle.DbType = DbType.String;
                padreY_Calle.Value = (object)entity.Y_Calle ?? DBNull.Value;
                var padreCodigo_Postal = _dataProvider.GetParameter();
                padreCodigo_Postal.ParameterName = "Codigo_Postal";
                padreCodigo_Postal.DbType = DbType.Int32;
                padreCodigo_Postal.Value = (object)entity.Codigo_Postal ?? DBNull.Value;

                var padreReferencias = _dataProvider.GetParameter();
                padreReferencias.ParameterName = "Referencias";
                padreReferencias.DbType = DbType.String;
                padreReferencias.Value = (object)entity.Referencias ?? DBNull.Value;
                var padreFotografia_del_domicilio = _dataProvider.GetParameter();
                padreFotografia_del_domicilio.ParameterName = "Fotografia_del_domicilio";
                padreFotografia_del_domicilio.DbType = DbType.Int32;
                padreFotografia_del_domicilio.Value = (object)entity.Fotografia_del_domicilio ?? DBNull.Value;

                var padreDomicilio_actual = _dataProvider.GetParameter();
                padreDomicilio_actual.ParameterName = "Domicilio_actual";
                padreDomicilio_actual.DbType = DbType.Boolean;
                padreDomicilio_actual.Value = (object)entity.Domicilio_actual ?? DBNull.Value;
                var padreCantidad = _dataProvider.GetParameter();
                padreCantidad.ParameterName = "Cantidad";
                padreCantidad.DbType = DbType.Int32;
                padreCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;

                var padreMedida_de_tiempo = _dataProvider.GetParameter();
                padreMedida_de_tiempo.ParameterName = "Medida_de_tiempo";
                padreMedida_de_tiempo.DbType = DbType.Int32;
                padreMedida_de_tiempo.Value = (object)entity.Medida_de_tiempo ?? DBNull.Value;

                var padreTiempo_viviendo_aqui = _dataProvider.GetParameter();
                padreTiempo_viviendo_aqui.ParameterName = "Tiempo_viviendo_aqui";
                padreTiempo_viviendo_aqui.DbType = DbType.String;
                padreTiempo_viviendo_aqui.Value = (object)entity.Tiempo_viviendo_aqui ?? DBNull.Value;
                var padreFecha_de_autorizacion = _dataProvider.GetParameter();
                padreFecha_de_autorizacion.ParameterName = "Fecha_de_autorizacion";
                padreFecha_de_autorizacion.DbType = DbType.DateTime;
                padreFecha_de_autorizacion.Value = (object)entity.Fecha_de_autorizacion ?? DBNull.Value;

                var padreHora_de_autorizacion = _dataProvider.GetParameter();
                padreHora_de_autorizacion.ParameterName = "Hora_de_autorizacion";
                padreHora_de_autorizacion.DbType = DbType.String;
                padreHora_de_autorizacion.Value = (object)entity.Hora_de_autorizacion ?? DBNull.Value;
                var padreUsuario_que_autoriza = _dataProvider.GetParameter();
                padreUsuario_que_autoriza.ParameterName = "Usuario_que_autoriza";
                padreUsuario_que_autoriza.DbType = DbType.Int32;
                padreUsuario_que_autoriza.Value = (object)entity.Usuario_que_autoriza ?? DBNull.Value;

                var padreRespuesta = _dataProvider.GetParameter();
                padreRespuesta.ParameterName = "Respuesta";
                padreRespuesta.DbType = DbType.Int32;
                padreRespuesta.Value = (object)entity.Respuesta ?? DBNull.Value;

                var padreObservaciones = _dataProvider.GetParameter();
                padreObservaciones.ParameterName = "Observaciones";
                padreObservaciones.DbType = DbType.String;
                padreObservaciones.Value = (object)entity.Observaciones ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_Ins_Registro_de_Usuarios>("sp_Ins_Registro_de_Usuarios" , padreFecha_de_Registro
, padreHora_de_Registro
, padreUsuario_que_Registra
, padreNombres
, padreApellido_Paterno
, padreApellido_Materno
, padreNombre_Completo
, padreUsuario
, padreContrasena
, padreConfirmar_Contrasena
, padreCorreo_Electronico
, padreCelular
, padreUsuario_ID
, padreEstatus
, padrePais
, padreEstado
, padreMunicipio
, padreCalle
, padreEntre_Calle
, padreY_Calle
, padreCodigo_Postal
, padreReferencias
, padreFotografia_del_domicilio
, padreDomicilio_actual
, padreCantidad
, padreMedida_de_tiempo
, padreTiempo_viviendo_aqui
, padreFecha_de_autorizacion
, padreHora_de_autorizacion
, padreUsuario_que_autoriza
, padreRespuesta
, padreObservaciones
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);

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

        public int Update(Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;

                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;

                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)entity.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)entity.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)entity.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
                var paramUpdUsuario = _dataProvider.GetParameter();
                paramUpdUsuario.ParameterName = "Usuario";
                paramUpdUsuario.DbType = DbType.String;
                paramUpdUsuario.Value = (object)entity.Usuario ?? DBNull.Value;
                var paramUpdContrasena = _dataProvider.GetParameter();
                paramUpdContrasena.ParameterName = "Contrasena";
                paramUpdContrasena.DbType = DbType.String;
                paramUpdContrasena.Value = (object)entity.Contrasena ?? DBNull.Value;
                var paramUpdConfirmar_Contrasena = _dataProvider.GetParameter();
                paramUpdConfirmar_Contrasena.ParameterName = "Confirmar_Contrasena";
                paramUpdConfirmar_Contrasena.DbType = DbType.String;
                paramUpdConfirmar_Contrasena.Value = (object)entity.Confirmar_Contrasena ?? DBNull.Value;
                var paramUpdCorreo_Electronico = _dataProvider.GetParameter();
                paramUpdCorreo_Electronico.ParameterName = "Correo_Electronico";
                paramUpdCorreo_Electronico.DbType = DbType.String;
                paramUpdCorreo_Electronico.Value = (object)entity.Correo_Electronico ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)entity.Celular ?? DBNull.Value;
                var paramUpdUsuario_ID = _dataProvider.GetParameter();
                paramUpdUsuario_ID.ParameterName = "Usuario_ID";
                paramUpdUsuario_ID.DbType = DbType.Int32;
                paramUpdUsuario_ID.Value = (object)entity.Usuario_ID ?? DBNull.Value;

                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

                var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)entity.Pais ?? DBNull.Value;

                var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)entity.Estado ?? DBNull.Value;

                var paramUpdMunicipio = _dataProvider.GetParameter();
                paramUpdMunicipio.ParameterName = "Municipio";
                paramUpdMunicipio.DbType = DbType.Int32;
                paramUpdMunicipio.Value = (object)entity.Municipio ?? DBNull.Value;

                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)entity.Calle ?? DBNull.Value;
                var paramUpdEntre_Calle = _dataProvider.GetParameter();
                paramUpdEntre_Calle.ParameterName = "Entre_Calle";
                paramUpdEntre_Calle.DbType = DbType.String;
                paramUpdEntre_Calle.Value = (object)entity.Entre_Calle ?? DBNull.Value;
                var paramUpdY_Calle = _dataProvider.GetParameter();
                paramUpdY_Calle.ParameterName = "Y_Calle";
                paramUpdY_Calle.DbType = DbType.String;
                paramUpdY_Calle.Value = (object)entity.Y_Calle ?? DBNull.Value;
                var paramUpdCodigo_Postal = _dataProvider.GetParameter();
                paramUpdCodigo_Postal.ParameterName = "Codigo_Postal";
                paramUpdCodigo_Postal.DbType = DbType.Int32;
                paramUpdCodigo_Postal.Value = (object)entity.Codigo_Postal ?? DBNull.Value;

                var paramUpdReferencias = _dataProvider.GetParameter();
                paramUpdReferencias.ParameterName = "Referencias";
                paramUpdReferencias.DbType = DbType.String;
                paramUpdReferencias.Value = (object)entity.Referencias ?? DBNull.Value;
                var paramUpdFotografia_del_domicilio = _dataProvider.GetParameter();
                paramUpdFotografia_del_domicilio.ParameterName = "Fotografia_del_domicilio";
                paramUpdFotografia_del_domicilio.DbType = DbType.Int32;
                paramUpdFotografia_del_domicilio.Value = (object)entity.Fotografia_del_domicilio ?? DBNull.Value;

                var paramUpdDomicilio_actual = _dataProvider.GetParameter();
                paramUpdDomicilio_actual.ParameterName = "Domicilio_actual";
                paramUpdDomicilio_actual.DbType = DbType.Boolean;
                paramUpdDomicilio_actual.Value = (object)entity.Domicilio_actual ?? DBNull.Value;
                var paramUpdCantidad = _dataProvider.GetParameter();
                paramUpdCantidad.ParameterName = "Cantidad";
                paramUpdCantidad.DbType = DbType.Int32;
                paramUpdCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;

                var paramUpdMedida_de_tiempo = _dataProvider.GetParameter();
                paramUpdMedida_de_tiempo.ParameterName = "Medida_de_tiempo";
                paramUpdMedida_de_tiempo.DbType = DbType.Int32;
                paramUpdMedida_de_tiempo.Value = (object)entity.Medida_de_tiempo ?? DBNull.Value;

                var paramUpdTiempo_viviendo_aqui = _dataProvider.GetParameter();
                paramUpdTiempo_viviendo_aqui.ParameterName = "Tiempo_viviendo_aqui";
                paramUpdTiempo_viviendo_aqui.DbType = DbType.String;
                paramUpdTiempo_viviendo_aqui.Value = (object)entity.Tiempo_viviendo_aqui ?? DBNull.Value;
                var paramUpdFecha_de_autorizacion = _dataProvider.GetParameter();
                paramUpdFecha_de_autorizacion.ParameterName = "Fecha_de_autorizacion";
                paramUpdFecha_de_autorizacion.DbType = DbType.DateTime;
                paramUpdFecha_de_autorizacion.Value = (object)entity.Fecha_de_autorizacion ?? DBNull.Value;

                var paramUpdHora_de_autorizacion = _dataProvider.GetParameter();
                paramUpdHora_de_autorizacion.ParameterName = "Hora_de_autorizacion";
                paramUpdHora_de_autorizacion.DbType = DbType.String;
                paramUpdHora_de_autorizacion.Value = (object)entity.Hora_de_autorizacion ?? DBNull.Value;
                var paramUpdUsuario_que_autoriza = _dataProvider.GetParameter();
                paramUpdUsuario_que_autoriza.ParameterName = "Usuario_que_autoriza";
                paramUpdUsuario_que_autoriza.DbType = DbType.Int32;
                paramUpdUsuario_que_autoriza.Value = (object)entity.Usuario_que_autoriza ?? DBNull.Value;

                var paramUpdRespuesta = _dataProvider.GetParameter();
                paramUpdRespuesta.ParameterName = "Respuesta";
                paramUpdRespuesta.DbType = DbType.Int32;
                paramUpdRespuesta.Value = (object)entity.Respuesta ?? DBNull.Value;

                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)entity.Observaciones ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_Upd_Registro_de_Usuarios>("sp_Upd_Registro_de_Usuarios" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdUsuario , paramUpdContrasena , paramUpdConfirmar_Contrasena , paramUpdCorreo_Electronico , paramUpdCelular , paramUpdUsuario_ID , paramUpdEstatus , paramUpdPais , paramUpdEstado , paramUpdMunicipio , paramUpdCalle , paramUpdEntre_Calle , paramUpdY_Calle , paramUpdCodigo_Postal , paramUpdReferencias , paramUpdFotografia_del_domicilio , paramUpdDomicilio_actual , paramUpdCantidad , paramUpdMedida_de_tiempo , paramUpdTiempo_viviendo_aqui , paramUpdFecha_de_autorizacion , paramUpdHora_de_autorizacion , paramUpdUsuario_que_autoriza , paramUpdRespuesta , paramUpdObservaciones ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
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
		public int Update_Datos_Generales(Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios _Registro_de_UsuariosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)entity.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)entity.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)entity.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)entity.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
                var paramUpdUsuario = _dataProvider.GetParameter();
                paramUpdUsuario.ParameterName = "Usuario";
                paramUpdUsuario.DbType = DbType.String;
                paramUpdUsuario.Value = (object)entity.Usuario ?? DBNull.Value;
                var paramUpdContrasena = _dataProvider.GetParameter();
                paramUpdContrasena.ParameterName = "Contrasena";
                paramUpdContrasena.DbType = DbType.String;
                paramUpdContrasena.Value = (object)entity.Contrasena ?? DBNull.Value;
                var paramUpdConfirmar_Contrasena = _dataProvider.GetParameter();
                paramUpdConfirmar_Contrasena.ParameterName = "Confirmar_Contrasena";
                paramUpdConfirmar_Contrasena.DbType = DbType.String;
                paramUpdConfirmar_Contrasena.Value = (object)entity.Confirmar_Contrasena ?? DBNull.Value;
                var paramUpdCorreo_Electronico = _dataProvider.GetParameter();
                paramUpdCorreo_Electronico.ParameterName = "Correo_Electronico";
                paramUpdCorreo_Electronico.DbType = DbType.String;
                paramUpdCorreo_Electronico.Value = (object)entity.Correo_Electronico ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)entity.Celular ?? DBNull.Value;
                var paramUpdUsuario_ID = _dataProvider.GetParameter();
                paramUpdUsuario_ID.ParameterName = "Usuario_ID";
                paramUpdUsuario_ID.DbType = DbType.Int32;
                paramUpdUsuario_ID.Value = (object)entity.Usuario_ID ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;
                var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)_Registro_de_UsuariosDB.Pais ?? DBNull.Value;
                var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)_Registro_de_UsuariosDB.Estado ?? DBNull.Value;
                var paramUpdMunicipio = _dataProvider.GetParameter();
                paramUpdMunicipio.ParameterName = "Municipio";
                paramUpdMunicipio.DbType = DbType.Int32;
                paramUpdMunicipio.Value = (object)_Registro_de_UsuariosDB.Municipio ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)_Registro_de_UsuariosDB.Calle ?? DBNull.Value;
                var paramUpdEntre_Calle = _dataProvider.GetParameter();
                paramUpdEntre_Calle.ParameterName = "Entre_Calle";
                paramUpdEntre_Calle.DbType = DbType.String;
                paramUpdEntre_Calle.Value = (object)_Registro_de_UsuariosDB.Entre_Calle ?? DBNull.Value;
                var paramUpdY_Calle = _dataProvider.GetParameter();
                paramUpdY_Calle.ParameterName = "Y_Calle";
                paramUpdY_Calle.DbType = DbType.String;
                paramUpdY_Calle.Value = (object)_Registro_de_UsuariosDB.Y_Calle ?? DBNull.Value;
                var paramUpdCodigo_Postal = _dataProvider.GetParameter();
                paramUpdCodigo_Postal.ParameterName = "Codigo_Postal";
                paramUpdCodigo_Postal.DbType = DbType.Int32;
                paramUpdCodigo_Postal.Value = (object)_Registro_de_UsuariosDB.Codigo_Postal ?? DBNull.Value;
                var paramUpdReferencias = _dataProvider.GetParameter();
                paramUpdReferencias.ParameterName = "Referencias";
                paramUpdReferencias.DbType = DbType.String;
                paramUpdReferencias.Value = (object)_Registro_de_UsuariosDB.Referencias ?? DBNull.Value;
                var paramUpdFotografia_del_domicilio = _dataProvider.GetParameter();
                paramUpdFotografia_del_domicilio.ParameterName = "Fotografia_del_domicilio";
                paramUpdFotografia_del_domicilio.DbType = DbType.Int32;
                paramUpdFotografia_del_domicilio.Value = (object)_Registro_de_UsuariosDB.Fotografia_del_domicilio ?? DBNull.Value;
                var paramUpdDomicilio_actual = _dataProvider.GetParameter();
                paramUpdDomicilio_actual.ParameterName = "Domicilio_actual";
                paramUpdDomicilio_actual.DbType = DbType.Boolean;
                paramUpdDomicilio_actual.Value = (object)_Registro_de_UsuariosDB.Domicilio_actual ?? DBNull.Value;
                var paramUpdCantidad = _dataProvider.GetParameter();
                paramUpdCantidad.ParameterName = "Cantidad";
                paramUpdCantidad.DbType = DbType.Int32;
                paramUpdCantidad.Value = (object)_Registro_de_UsuariosDB.Cantidad ?? DBNull.Value;
		var paramUpdMedida_de_tiempo = _dataProvider.GetParameter();
                paramUpdMedida_de_tiempo.ParameterName = "Medida_de_tiempo";
                paramUpdMedida_de_tiempo.DbType = DbType.Int32;
                paramUpdMedida_de_tiempo.Value = (object)_Registro_de_UsuariosDB.Medida_de_tiempo ?? DBNull.Value;
                var paramUpdTiempo_viviendo_aqui = _dataProvider.GetParameter();
                paramUpdTiempo_viviendo_aqui.ParameterName = "Tiempo_viviendo_aqui";
                paramUpdTiempo_viviendo_aqui.DbType = DbType.String;
                paramUpdTiempo_viviendo_aqui.Value = (object)_Registro_de_UsuariosDB.Tiempo_viviendo_aqui ?? DBNull.Value;
                var paramUpdFecha_de_autorizacion = _dataProvider.GetParameter();
                paramUpdFecha_de_autorizacion.ParameterName = "Fecha_de_autorizacion";
                paramUpdFecha_de_autorizacion.DbType = DbType.DateTime;
                paramUpdFecha_de_autorizacion.Value = (object)_Registro_de_UsuariosDB.Fecha_de_autorizacion ?? DBNull.Value;
                var paramUpdHora_de_autorizacion = _dataProvider.GetParameter();
                paramUpdHora_de_autorizacion.ParameterName = "Hora_de_autorizacion";
                paramUpdHora_de_autorizacion.DbType = DbType.String;
                paramUpdHora_de_autorizacion.Value = (object)_Registro_de_UsuariosDB.Hora_de_autorizacion ?? DBNull.Value;
                var paramUpdUsuario_que_autoriza = _dataProvider.GetParameter();
                paramUpdUsuario_que_autoriza.ParameterName = "Usuario_que_autoriza";
                paramUpdUsuario_que_autoriza.DbType = DbType.Int32;
                paramUpdUsuario_que_autoriza.Value = (object)_Registro_de_UsuariosDB.Usuario_que_autoriza ?? DBNull.Value;
		var paramUpdRespuesta = _dataProvider.GetParameter();
                paramUpdRespuesta.ParameterName = "Respuesta";
                paramUpdRespuesta.DbType = DbType.Int32;
                paramUpdRespuesta.Value = (object)_Registro_de_UsuariosDB.Respuesta ?? DBNull.Value;
                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)_Registro_de_UsuariosDB.Observaciones ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_Upd_Registro_de_Usuarios>("sp_Upd_Registro_de_Usuarios" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdUsuario , paramUpdContrasena , paramUpdConfirmar_Contrasena , paramUpdCorreo_Electronico , paramUpdCelular , paramUpdUsuario_ID , paramUpdEstatus , paramUpdPais , paramUpdEstado , paramUpdMunicipio , paramUpdCalle , paramUpdEntre_Calle , paramUpdY_Calle , paramUpdCodigo_Postal , paramUpdReferencias , paramUpdFotografia_del_domicilio , paramUpdDomicilio_actual , paramUpdCantidad , paramUpdMedida_de_tiempo , paramUpdTiempo_viviendo_aqui , paramUpdFecha_de_autorizacion , paramUpdHora_de_autorizacion , paramUpdUsuario_que_autoriza , paramUpdRespuesta , paramUpdObservaciones ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
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

		public int Update_Domicilio(Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios _Registro_de_UsuariosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)_Registro_de_UsuariosDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)_Registro_de_UsuariosDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)_Registro_de_UsuariosDB.Hora_de_Registro ?? DBNull.Value;
                var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)_Registro_de_UsuariosDB.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)_Registro_de_UsuariosDB.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)_Registro_de_UsuariosDB.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)_Registro_de_UsuariosDB.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)_Registro_de_UsuariosDB.Nombre_Completo ?? DBNull.Value;
                var paramUpdUsuario = _dataProvider.GetParameter();
                paramUpdUsuario.ParameterName = "Usuario";
                paramUpdUsuario.DbType = DbType.String;
                paramUpdUsuario.Value = (object)_Registro_de_UsuariosDB.Usuario ?? DBNull.Value;
                var paramUpdContrasena = _dataProvider.GetParameter();
                paramUpdContrasena.ParameterName = "Contrasena";
                paramUpdContrasena.DbType = DbType.String;
                paramUpdContrasena.Value = (object)_Registro_de_UsuariosDB.Contrasena ?? DBNull.Value;
                var paramUpdConfirmar_Contrasena = _dataProvider.GetParameter();
                paramUpdConfirmar_Contrasena.ParameterName = "Confirmar_Contrasena";
                paramUpdConfirmar_Contrasena.DbType = DbType.String;
                paramUpdConfirmar_Contrasena.Value = (object)_Registro_de_UsuariosDB.Confirmar_Contrasena ?? DBNull.Value;
                var paramUpdCorreo_Electronico = _dataProvider.GetParameter();
                paramUpdCorreo_Electronico.ParameterName = "Correo_Electronico";
                paramUpdCorreo_Electronico.DbType = DbType.String;
                paramUpdCorreo_Electronico.Value = (object)_Registro_de_UsuariosDB.Correo_Electronico ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)_Registro_de_UsuariosDB.Celular ?? DBNull.Value;
                var paramUpdUsuario_ID = _dataProvider.GetParameter();
                paramUpdUsuario_ID.ParameterName = "Usuario_ID";
                paramUpdUsuario_ID.DbType = DbType.Int32;
                paramUpdUsuario_ID.Value = (object)_Registro_de_UsuariosDB.Usuario_ID ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)_Registro_de_UsuariosDB.Estatus ?? DBNull.Value;
                var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)entity.Pais ?? DBNull.Value;
                var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)entity.Estado ?? DBNull.Value;
                var paramUpdMunicipio = _dataProvider.GetParameter();
                paramUpdMunicipio.ParameterName = "Municipio";
                paramUpdMunicipio.DbType = DbType.Int32;
                paramUpdMunicipio.Value = (object)entity.Municipio ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)entity.Calle ?? DBNull.Value;
                var paramUpdEntre_Calle = _dataProvider.GetParameter();
                paramUpdEntre_Calle.ParameterName = "Entre_Calle";
                paramUpdEntre_Calle.DbType = DbType.String;
                paramUpdEntre_Calle.Value = (object)entity.Entre_Calle ?? DBNull.Value;
                var paramUpdY_Calle = _dataProvider.GetParameter();
                paramUpdY_Calle.ParameterName = "Y_Calle";
                paramUpdY_Calle.DbType = DbType.String;
                paramUpdY_Calle.Value = (object)entity.Y_Calle ?? DBNull.Value;
                var paramUpdCodigo_Postal = _dataProvider.GetParameter();
                paramUpdCodigo_Postal.ParameterName = "Codigo_Postal";
                paramUpdCodigo_Postal.DbType = DbType.Int32;
                paramUpdCodigo_Postal.Value = (object)entity.Codigo_Postal ?? DBNull.Value;
                var paramUpdReferencias = _dataProvider.GetParameter();
                paramUpdReferencias.ParameterName = "Referencias";
                paramUpdReferencias.DbType = DbType.String;
                paramUpdReferencias.Value = (object)entity.Referencias ?? DBNull.Value;
                var paramUpdFotografia_del_domicilio = _dataProvider.GetParameter();
                paramUpdFotografia_del_domicilio.ParameterName = "Fotografia_del_domicilio";
                paramUpdFotografia_del_domicilio.DbType = DbType.Int32;
                paramUpdFotografia_del_domicilio.Value = (object)entity.Fotografia_del_domicilio ?? DBNull.Value;
                var paramUpdDomicilio_actual = _dataProvider.GetParameter();
                paramUpdDomicilio_actual.ParameterName = "Domicilio_actual";
                paramUpdDomicilio_actual.DbType = DbType.Boolean;
                paramUpdDomicilio_actual.Value = (object)entity.Domicilio_actual ?? DBNull.Value;
                var paramUpdCantidad = _dataProvider.GetParameter();
                paramUpdCantidad.ParameterName = "Cantidad";
                paramUpdCantidad.DbType = DbType.Int32;
                paramUpdCantidad.Value = (object)entity.Cantidad ?? DBNull.Value;
		var paramUpdMedida_de_tiempo = _dataProvider.GetParameter();
                paramUpdMedida_de_tiempo.ParameterName = "Medida_de_tiempo";
                paramUpdMedida_de_tiempo.DbType = DbType.Int32;
                paramUpdMedida_de_tiempo.Value = (object)entity.Medida_de_tiempo ?? DBNull.Value;
                var paramUpdTiempo_viviendo_aqui = _dataProvider.GetParameter();
                paramUpdTiempo_viviendo_aqui.ParameterName = "Tiempo_viviendo_aqui";
                paramUpdTiempo_viviendo_aqui.DbType = DbType.String;
                paramUpdTiempo_viviendo_aqui.Value = (object)entity.Tiempo_viviendo_aqui ?? DBNull.Value;
                var paramUpdFecha_de_autorizacion = _dataProvider.GetParameter();
                paramUpdFecha_de_autorizacion.ParameterName = "Fecha_de_autorizacion";
                paramUpdFecha_de_autorizacion.DbType = DbType.DateTime;
                paramUpdFecha_de_autorizacion.Value = (object)_Registro_de_UsuariosDB.Fecha_de_autorizacion ?? DBNull.Value;
                var paramUpdHora_de_autorizacion = _dataProvider.GetParameter();
                paramUpdHora_de_autorizacion.ParameterName = "Hora_de_autorizacion";
                paramUpdHora_de_autorizacion.DbType = DbType.String;
                paramUpdHora_de_autorizacion.Value = (object)_Registro_de_UsuariosDB.Hora_de_autorizacion ?? DBNull.Value;
                var paramUpdUsuario_que_autoriza = _dataProvider.GetParameter();
                paramUpdUsuario_que_autoriza.ParameterName = "Usuario_que_autoriza";
                paramUpdUsuario_que_autoriza.DbType = DbType.Int32;
                paramUpdUsuario_que_autoriza.Value = (object)_Registro_de_UsuariosDB.Usuario_que_autoriza ?? DBNull.Value;
		var paramUpdRespuesta = _dataProvider.GetParameter();
                paramUpdRespuesta.ParameterName = "Respuesta";
                paramUpdRespuesta.DbType = DbType.Int32;
                paramUpdRespuesta.Value = (object)_Registro_de_UsuariosDB.Respuesta ?? DBNull.Value;
                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)_Registro_de_UsuariosDB.Observaciones ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_Upd_Registro_de_Usuarios>("sp_Upd_Registro_de_Usuarios" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdUsuario , paramUpdContrasena , paramUpdConfirmar_Contrasena , paramUpdCorreo_Electronico , paramUpdCelular , paramUpdUsuario_ID , paramUpdEstatus , paramUpdPais , paramUpdEstado , paramUpdMunicipio , paramUpdCalle , paramUpdEntre_Calle , paramUpdY_Calle , paramUpdCodigo_Postal , paramUpdReferencias , paramUpdFotografia_del_domicilio , paramUpdDomicilio_actual , paramUpdCantidad , paramUpdMedida_de_tiempo , paramUpdTiempo_viviendo_aqui , paramUpdFecha_de_autorizacion , paramUpdHora_de_autorizacion , paramUpdUsuario_que_autoriza , paramUpdRespuesta , paramUpdObservaciones ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
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

		public int Update_Autorizacion(Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes._Registro_de_Usuarios._Registro_de_Usuarios _Registro_de_UsuariosDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)_Registro_de_UsuariosDB.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)_Registro_de_UsuariosDB.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)_Registro_de_UsuariosDB.Hora_de_Registro ?? DBNull.Value;
                var paramUpdUsuario_que_Registra = _dataProvider.GetParameter();
                paramUpdUsuario_que_Registra.ParameterName = "Usuario_que_Registra";
                paramUpdUsuario_que_Registra.DbType = DbType.Int32;
                paramUpdUsuario_que_Registra.Value = (object)_Registro_de_UsuariosDB.Usuario_que_Registra ?? DBNull.Value;
                var paramUpdNombres = _dataProvider.GetParameter();
                paramUpdNombres.ParameterName = "Nombres";
                paramUpdNombres.DbType = DbType.String;
                paramUpdNombres.Value = (object)_Registro_de_UsuariosDB.Nombres ?? DBNull.Value;
                var paramUpdApellido_Paterno = _dataProvider.GetParameter();
                paramUpdApellido_Paterno.ParameterName = "Apellido_Paterno";
                paramUpdApellido_Paterno.DbType = DbType.String;
                paramUpdApellido_Paterno.Value = (object)_Registro_de_UsuariosDB.Apellido_Paterno ?? DBNull.Value;
                var paramUpdApellido_Materno = _dataProvider.GetParameter();
                paramUpdApellido_Materno.ParameterName = "Apellido_Materno";
                paramUpdApellido_Materno.DbType = DbType.String;
                paramUpdApellido_Materno.Value = (object)_Registro_de_UsuariosDB.Apellido_Materno ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)_Registro_de_UsuariosDB.Nombre_Completo ?? DBNull.Value;
                var paramUpdUsuario = _dataProvider.GetParameter();
                paramUpdUsuario.ParameterName = "Usuario";
                paramUpdUsuario.DbType = DbType.String;
                paramUpdUsuario.Value = (object)_Registro_de_UsuariosDB.Usuario ?? DBNull.Value;
                var paramUpdContrasena = _dataProvider.GetParameter();
                paramUpdContrasena.ParameterName = "Contrasena";
                paramUpdContrasena.DbType = DbType.String;
                paramUpdContrasena.Value = (object)_Registro_de_UsuariosDB.Contrasena ?? DBNull.Value;
                var paramUpdConfirmar_Contrasena = _dataProvider.GetParameter();
                paramUpdConfirmar_Contrasena.ParameterName = "Confirmar_Contrasena";
                paramUpdConfirmar_Contrasena.DbType = DbType.String;
                paramUpdConfirmar_Contrasena.Value = (object)_Registro_de_UsuariosDB.Confirmar_Contrasena ?? DBNull.Value;
                var paramUpdCorreo_Electronico = _dataProvider.GetParameter();
                paramUpdCorreo_Electronico.ParameterName = "Correo_Electronico";
                paramUpdCorreo_Electronico.DbType = DbType.String;
                paramUpdCorreo_Electronico.Value = (object)_Registro_de_UsuariosDB.Correo_Electronico ?? DBNull.Value;
                var paramUpdCelular = _dataProvider.GetParameter();
                paramUpdCelular.ParameterName = "Celular";
                paramUpdCelular.DbType = DbType.String;
                paramUpdCelular.Value = (object)_Registro_de_UsuariosDB.Celular ?? DBNull.Value;
                var paramUpdUsuario_ID = _dataProvider.GetParameter();
                paramUpdUsuario_ID.ParameterName = "Usuario_ID";
                paramUpdUsuario_ID.DbType = DbType.Int32;
                paramUpdUsuario_ID.Value = (object)_Registro_de_UsuariosDB.Usuario_ID ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)_Registro_de_UsuariosDB.Estatus ?? DBNull.Value;
                var paramUpdPais = _dataProvider.GetParameter();
                paramUpdPais.ParameterName = "Pais";
                paramUpdPais.DbType = DbType.Int32;
                paramUpdPais.Value = (object)_Registro_de_UsuariosDB.Pais ?? DBNull.Value;
                var paramUpdEstado = _dataProvider.GetParameter();
                paramUpdEstado.ParameterName = "Estado";
                paramUpdEstado.DbType = DbType.Int32;
                paramUpdEstado.Value = (object)_Registro_de_UsuariosDB.Estado ?? DBNull.Value;
                var paramUpdMunicipio = _dataProvider.GetParameter();
                paramUpdMunicipio.ParameterName = "Municipio";
                paramUpdMunicipio.DbType = DbType.Int32;
                paramUpdMunicipio.Value = (object)_Registro_de_UsuariosDB.Municipio ?? DBNull.Value;
                var paramUpdCalle = _dataProvider.GetParameter();
                paramUpdCalle.ParameterName = "Calle";
                paramUpdCalle.DbType = DbType.String;
                paramUpdCalle.Value = (object)_Registro_de_UsuariosDB.Calle ?? DBNull.Value;
                var paramUpdEntre_Calle = _dataProvider.GetParameter();
                paramUpdEntre_Calle.ParameterName = "Entre_Calle";
                paramUpdEntre_Calle.DbType = DbType.String;
                paramUpdEntre_Calle.Value = (object)_Registro_de_UsuariosDB.Entre_Calle ?? DBNull.Value;
                var paramUpdY_Calle = _dataProvider.GetParameter();
                paramUpdY_Calle.ParameterName = "Y_Calle";
                paramUpdY_Calle.DbType = DbType.String;
                paramUpdY_Calle.Value = (object)_Registro_de_UsuariosDB.Y_Calle ?? DBNull.Value;
                var paramUpdCodigo_Postal = _dataProvider.GetParameter();
                paramUpdCodigo_Postal.ParameterName = "Codigo_Postal";
                paramUpdCodigo_Postal.DbType = DbType.Int32;
                paramUpdCodigo_Postal.Value = (object)_Registro_de_UsuariosDB.Codigo_Postal ?? DBNull.Value;
                var paramUpdReferencias = _dataProvider.GetParameter();
                paramUpdReferencias.ParameterName = "Referencias";
                paramUpdReferencias.DbType = DbType.String;
                paramUpdReferencias.Value = (object)_Registro_de_UsuariosDB.Referencias ?? DBNull.Value;
                var paramUpdFotografia_del_domicilio = _dataProvider.GetParameter();
                paramUpdFotografia_del_domicilio.ParameterName = "Fotografia_del_domicilio";
                paramUpdFotografia_del_domicilio.DbType = DbType.Int32;
                paramUpdFotografia_del_domicilio.Value = (object)_Registro_de_UsuariosDB.Fotografia_del_domicilio ?? DBNull.Value;
                var paramUpdDomicilio_actual = _dataProvider.GetParameter();
                paramUpdDomicilio_actual.ParameterName = "Domicilio_actual";
                paramUpdDomicilio_actual.DbType = DbType.Boolean;
                paramUpdDomicilio_actual.Value = (object)_Registro_de_UsuariosDB.Domicilio_actual ?? DBNull.Value;
                var paramUpdCantidad = _dataProvider.GetParameter();
                paramUpdCantidad.ParameterName = "Cantidad";
                paramUpdCantidad.DbType = DbType.Int32;
                paramUpdCantidad.Value = (object)_Registro_de_UsuariosDB.Cantidad ?? DBNull.Value;
		var paramUpdMedida_de_tiempo = _dataProvider.GetParameter();
                paramUpdMedida_de_tiempo.ParameterName = "Medida_de_tiempo";
                paramUpdMedida_de_tiempo.DbType = DbType.Int32;
                paramUpdMedida_de_tiempo.Value = (object)_Registro_de_UsuariosDB.Medida_de_tiempo ?? DBNull.Value;
                var paramUpdTiempo_viviendo_aqui = _dataProvider.GetParameter();
                paramUpdTiempo_viviendo_aqui.ParameterName = "Tiempo_viviendo_aqui";
                paramUpdTiempo_viviendo_aqui.DbType = DbType.String;
                paramUpdTiempo_viviendo_aqui.Value = (object)_Registro_de_UsuariosDB.Tiempo_viviendo_aqui ?? DBNull.Value;
                var paramUpdFecha_de_autorizacion = _dataProvider.GetParameter();
                paramUpdFecha_de_autorizacion.ParameterName = "Fecha_de_autorizacion";
                paramUpdFecha_de_autorizacion.DbType = DbType.DateTime;
                paramUpdFecha_de_autorizacion.Value = (object)entity.Fecha_de_autorizacion ?? DBNull.Value;
                var paramUpdHora_de_autorizacion = _dataProvider.GetParameter();
                paramUpdHora_de_autorizacion.ParameterName = "Hora_de_autorizacion";
                paramUpdHora_de_autorizacion.DbType = DbType.String;
                paramUpdHora_de_autorizacion.Value = (object)entity.Hora_de_autorizacion ?? DBNull.Value;
                var paramUpdUsuario_que_autoriza = _dataProvider.GetParameter();
                paramUpdUsuario_que_autoriza.ParameterName = "Usuario_que_autoriza";
                paramUpdUsuario_que_autoriza.DbType = DbType.Int32;
                paramUpdUsuario_que_autoriza.Value = (object)entity.Usuario_que_autoriza ?? DBNull.Value;
		var paramUpdRespuesta = _dataProvider.GetParameter();
                paramUpdRespuesta.ParameterName = "Respuesta";
                paramUpdRespuesta.DbType = DbType.Int32;
                paramUpdRespuesta.Value = (object)entity.Respuesta ?? DBNull.Value;
                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)entity.Observaciones ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_Upd_Registro_de_Usuarios>("sp_Upd_Registro_de_Usuarios" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdUsuario_que_Registra , paramUpdNombres , paramUpdApellido_Paterno , paramUpdApellido_Materno , paramUpdNombre_Completo , paramUpdUsuario , paramUpdContrasena , paramUpdConfirmar_Contrasena , paramUpdCorreo_Electronico , paramUpdCelular , paramUpdUsuario_ID , paramUpdEstatus , paramUpdPais , paramUpdEstado , paramUpdMunicipio , paramUpdCalle , paramUpdEntre_Calle , paramUpdY_Calle , paramUpdCodigo_Postal , paramUpdReferencias , paramUpdFotografia_del_domicilio , paramUpdDomicilio_actual , paramUpdCantidad , paramUpdMedida_de_tiempo , paramUpdTiempo_viviendo_aqui , paramUpdFecha_de_autorizacion , paramUpdHora_de_autorizacion , paramUpdUsuario_que_autoriza , paramUpdRespuesta , paramUpdObservaciones ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
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

