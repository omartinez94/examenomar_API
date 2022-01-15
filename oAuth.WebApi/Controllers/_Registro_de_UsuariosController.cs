using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ModelBinding;
using Spartane.Core.Exceptions.Service;
using System.Web;
using Spartane.Core.Classes._Registro_de_Usuarios;
using Spartane.Services._Registro_de_Usuarios;
using System.Data;
using System.Web.Script.Serialization;
using oAuth.WebAPI.Consumer;
using oAuth.WebApi.Helpers;
using System.Configuration;
using System.Text;

using Spartane.Services.Spartan_Bitacora_SQL;
using Spartane.Core.Classes.Spartan_Bitacora_SQL;

namespace Spartane.WebApi.Controllers
{
    
    public partial class _Registro_de_UsuariosController : BaseApiController
    {
        #region Variables
        private I_Registro_de_UsuariosService service = null;
        public  static string ApiControllerUrl { get; set; }
		private ISpartan_Bitacora_SQLService serviceBitacora = null;
		private static int object_id = 47191;
        public string baseApi;
        #endregion Variables

        #region Constructor
        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public _Registro_de_UsuariosController(I_Registro_de_UsuariosService service,ISpartan_Bitacora_SQLService bitacoraService)
        {
            this.service = service;
			serviceBitacora = bitacoraService;
            baseApi = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
            ApiControllerUrl = "api/_Registro_de_Usuarios";
            
        }
        #endregion Constructor


        #region API Methods
        [Authorize]
        public HttpResponseMessage Get(int id)
        {
            var entity = this.service.GetByKey(id, false);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        public HttpResponseMessage GetAll()
        {
            var entity = this.service.SelAll(false);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        [HttpGet]
        public HttpResponseMessage ListaSelAll(int startRowIndex, int maximumRows, string where = "", string order = "")
        {
            var entity = this.service.ListaSelAll(startRowIndex, maximumRows, where, order);
            entity.RowCount = this.service.ListaSelAllCount(where);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        public HttpResponseMessage GetAllComplete()
        {
            var entity = this.service.SelAllComplete(false);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        public HttpResponseMessage GetAll(string where, string order)
        {
            var entity = this.service.SelAll(false, where, order);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        public HttpResponseMessage Post(_Registro_de_Usuarios var_Registro_de_Usuarios)
        {
            if (ModelState.IsValid)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Insert(var_Registro_de_Usuarios));
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_Ins_Registro_de_Usuarios" , new JavaScriptSerializer().Serialize(var_Registro_de_Usuarios), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_Ins_Registro_de_Usuarios", new JavaScriptSerializer().Serialize(var_Registro_de_Usuarios), true);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_Ins_Registro_de_Usuarios",new JavaScriptSerializer().Serialize(var_Registro_de_Usuarios), false, errors.ToString());
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }

        [Authorize]
        [HttpPut]
        public HttpResponseMessage Put(int id, _Registro_de_Usuarios var_Registro_de_Usuarios)
        {
            if (ModelState.IsValid && id == var_Registro_de_Usuarios.Folio)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Update(var_Registro_de_Usuarios));
					 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_Upd_Registro_de_Usuarios", new JavaScriptSerializer().Serialize(var_Registro_de_Usuarios), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
				    var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_Upd_Registro_de_Usuarios", new JavaScriptSerializer().Serialize(var_Registro_de_Usuarios), false, ex.Message);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
               var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
               var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_Upd_Registro_de_Usuarios", new JavaScriptSerializer().Serialize(var_Registro_de_Usuarios), false, String.Join(",", errors.ToArray()));
               serviceBitacora.Insert(bitacora);
               return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
		
		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_Generales(_Registro_de_Usuarios var_Registro_de_Usuarios_Datos_Generales)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_Generales(var_Registro_de_Usuarios_Datos_Generales));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, var_Registro_de_Usuarios_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_Upd_Registro_de_Usuarios", new JavaScriptSerializer().Serialize(var_Registro_de_Usuarios_Datos_Generales), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, var_Registro_de_Usuarios_Datos_Generales.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_Upd_Registro_de_Usuarios", new JavaScriptSerializer().Serialize(var_Registro_de_Usuarios_Datos_Generales), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_Generales(int id)
        {
            _Registro_de_Usuarios entity = this.service.ListaSelAll(1, 1, "_Registro_de_Usuarios.Folio='" + id.ToString() + "'", "")._Registro_de_Usuarioss.First();
            _Registro_de_Usuarios result = new _Registro_de_Usuarios();
			result.Folio = entity.Folio;
result.Fecha_de_Registro = entity.Fecha_de_Registro;
result.Hora_de_Registro = entity.Hora_de_Registro;
result.Usuario_que_Registra = entity.Usuario_que_Registra;
result.Usuario_que_Registra_Spartan_User = entity.Usuario_que_Registra_Spartan_User;
result.Nombres = entity.Nombres;
result.Apellido_Paterno = entity.Apellido_Paterno;
result.Apellido_Materno = entity.Apellido_Materno;
result.Nombre_Completo = entity.Nombre_Completo;
result.Usuario = entity.Usuario;
result.Contrasena = entity.Contrasena;
result.Confirmar_Contrasena = entity.Confirmar_Contrasena;
result.Correo_Electronico = entity.Correo_Electronico;
result.Celular = entity.Celular;
result.Usuario_ID = entity.Usuario_ID;
result.Usuario_ID_Spartan_User = entity.Usuario_ID_Spartan_User;
result.Estatus = entity.Estatus;
result.Estatus_Estatus_de_Usuario = entity.Estatus_Estatus_de_Usuario;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Domicilio(_Registro_de_Usuarios var_Registro_de_Usuarios_Domicilio)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Domicilio(var_Registro_de_Usuarios_Domicilio));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, var_Registro_de_Usuarios_Domicilio.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_Upd_Registro_de_Usuarios", new JavaScriptSerializer().Serialize(var_Registro_de_Usuarios_Domicilio), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, var_Registro_de_Usuarios_Domicilio.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_Upd_Registro_de_Usuarios", new JavaScriptSerializer().Serialize(var_Registro_de_Usuarios_Domicilio), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Domicilio(int id)
        {
            _Registro_de_Usuarios entity = this.service.ListaSelAll(1, 1, "_Registro_de_Usuarios.Folio='" + id.ToString() + "'", "")._Registro_de_Usuarioss.First();
            _Registro_de_Usuarios result = new _Registro_de_Usuarios();
			result.Folio = entity.Folio;
result.Pais = entity.Pais;
result.Pais_Pais = entity.Pais_Pais;
result.Estado = entity.Estado;
result.Estado_Estado = entity.Estado_Estado;
result.Municipio = entity.Municipio;
result.Municipio_Municipio = entity.Municipio_Municipio;
result.Calle = entity.Calle;
result.Entre_Calle = entity.Entre_Calle;
result.Y_Calle = entity.Y_Calle;
result.Codigo_Postal = entity.Codigo_Postal;
result.Referencias = entity.Referencias;
result.Fotografia_del_domicilio = entity.Fotografia_del_domicilio;
result.Fotografia_del_domicilio_Spartane_File = entity.Fotografia_del_domicilio_Spartane_File;
result.Domicilio_actual = entity.Domicilio_actual;
result.Cantidad = entity.Cantidad;
result.Medida_de_tiempo = entity.Medida_de_tiempo;
result.Medida_de_tiempo_Medida_de_tiempo = entity.Medida_de_tiempo_Medida_de_tiempo;
result.Tiempo_viviendo_aqui = entity.Tiempo_viviendo_aqui;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Autorizacion(_Registro_de_Usuarios var_Registro_de_Usuarios_Autorizacion)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Autorizacion(var_Registro_de_Usuarios_Autorizacion));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, var_Registro_de_Usuarios_Autorizacion.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_Upd_Registro_de_Usuarios", new JavaScriptSerializer().Serialize(var_Registro_de_Usuarios_Autorizacion), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, var_Registro_de_Usuarios_Autorizacion.Folio, BitacoraHelper.TypeSql.UPDATE, "sp_Upd_Registro_de_Usuarios", new JavaScriptSerializer().Serialize(var_Registro_de_Usuarios_Autorizacion), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Autorizacion(int id)
        {
            _Registro_de_Usuarios entity = this.service.ListaSelAll(1, 1, "_Registro_de_Usuarios.Folio='" + id.ToString() + "'", "")._Registro_de_Usuarioss.First();
            _Registro_de_Usuarios result = new _Registro_de_Usuarios();
			result.Folio = entity.Folio;
result.Fecha_de_autorizacion = entity.Fecha_de_autorizacion;
result.Hora_de_autorizacion = entity.Hora_de_autorizacion;
result.Usuario_que_autoriza = entity.Usuario_que_autoriza;
result.Usuario_que_autoriza_Spartan_User = entity.Usuario_que_autoriza_Spartan_User;
result.Respuesta = entity.Respuesta;
result.Respuesta_Respuesta = entity.Respuesta_Respuesta;
result.Observaciones = entity.Observaciones;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }


		
	[Authorize]
        [HttpGet]
        public HttpResponseMessage _Registro_de_UsuariosGenerateID()
        {
            _Registro_de_Usuarios var_Registro_de_Usuarios = new _Registro_de_Usuarios();
            var data = "-1";
            try
            {
                data = Convert.ToString(this.service.Insert(var_Registro_de_Usuarios));
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp__Registro_de_UsuariosGenerateID", new JavaScriptSerializer().Serialize(var_Registro_de_Usuarios), true);
                serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp__Registro_de_UsuariosGenerateID", new JavaScriptSerializer().Serialize(var_Registro_de_Usuarios), true);
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }	
        [Authorize]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            _Registro_de_Usuarios var_Registro_de_Usuarios = this.service.GetByKey(id, false);
            bool result = false;
            if (var_Registro_de_Usuarios == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
              result=  this.service.Delete(id);//, globalData, dataReference);
			  var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_Del_Registro_de_Usuarios", new JavaScriptSerializer().Serialize(var_Registro_de_Usuarios), result);
              serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_Del_Registro_de_Usuarios", new JavaScriptSerializer().Serialize(var_Registro_de_Usuarios), result, ex.Message);
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        #endregion API Methods

        #region TunnelMethod

        /// <summary>
        /// WebAPI GetALLTunnel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAllTunnel(string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);
                var result = client.DownloadString(baseApi + ApiControllerUrl + "/GetAll");
                var _Registro_de_UsuariosDataTable = new JavaScriptSerializer().Deserialize<List<_Registro_de_Usuarios>>(result);
                return Request.CreateResponse(HttpStatusCode.OK, _Registro_de_UsuariosDataTable, Configuration.Formatters.JsonFormatter);
        }

        /// <summary>
        /// WebAPI GET
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetTunnel(int id,string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);
                var result = client.DownloadString(baseApi + ApiControllerUrl + "/Get?id=" + id);
                var _Registro_de_UsuariosResult = new JavaScriptSerializer().Deserialize<_Registro_de_Usuarios>(result);
                return Request.CreateResponse(HttpStatusCode.OK, _Registro_de_UsuariosResult, Configuration.Formatters.JsonFormatter);            
        }

        /// <summary>
        /// WebAPI ListaSelAllTunnel
        /// </summary>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <param name="Where"></param>
        /// <param name="Order"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage ListaSelAllTunnel(int startRowIndex, int maximumRows, string Where, string Order,string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);
                client.Encoding = Encoding.UTF8;
                var result = client.DownloadString(baseApi + ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                        "&maximumRows=" + maximumRows +
                        (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                         (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order));
                var resp = new HttpResponseMessage(HttpStatusCode.OK);
                resp.Content = new StringContent(result, System.Text.Encoding.UTF8, "text/plain");
                return resp;
        }

        /// <summary>
        /// WebAPI PostTunnel
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage PostTunnel(_Registro_de_Usuarios emp,string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);

                client.Headers["Content-Type"] = "application/json";
                var dataString = new JavaScriptSerializer().Serialize(emp);

                var result = client.UploadString(new Uri(baseApi + ApiControllerUrl + "/Post"), "POST",
                    dataString);

                return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);            
        }

        /// <summary>
        /// WebAPI put tunnel
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage PutTunnel(_Registro_de_Usuarios emp, string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);
                client.Headers["Content-Type"] = "application/json";
                var dataString = new JavaScriptSerializer().Serialize(emp);

                var result = client.UploadString(new Uri(baseApi + ApiControllerUrl + "/Put?Id=" + emp.Folio), "PUT"
                , dataString);

                return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

        /// <summary>
        /// WebAPI Delete Tunnel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteTunnel(int id,string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);
                client.Headers["Content-Type"] = "application/json";
                var result = client.UploadString(new Uri(baseApi + ApiControllerUrl + "/Delete?id=" + id), "DELETE"
                );
                return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

        #endregion TunnelMethod

    }
}

