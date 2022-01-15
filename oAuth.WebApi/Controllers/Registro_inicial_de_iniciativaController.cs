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
using Spartane.Core.Classes.Registro_inicial_de_iniciativa;
using Spartane.Services.Registro_inicial_de_iniciativa;
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
    
    public partial class Registro_inicial_de_iniciativaController : BaseApiController
    {
        #region Variables
        private IRegistro_inicial_de_iniciativaService service = null;
        public  static string ApiControllerUrl { get; set; }
		private ISpartan_Bitacora_SQLService serviceBitacora = null;
		private static int object_id = 47178;
        public string baseApi;
        #endregion Variables

        #region Constructor
        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public Registro_inicial_de_iniciativaController(IRegistro_inicial_de_iniciativaService service,ISpartan_Bitacora_SQLService bitacoraService)
        {
            this.service = service;
			serviceBitacora = bitacoraService;
            baseApi = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
            ApiControllerUrl = "api/Registro_inicial_de_iniciativa";
            
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
        public HttpResponseMessage Post(Registro_inicial_de_iniciativa varRegistro_inicial_de_iniciativa)
        {
            if (ModelState.IsValid)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Insert(varRegistro_inicial_de_iniciativa));
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_InsRegistro_inicial_de_iniciativa" , new JavaScriptSerializer().Serialize(varRegistro_inicial_de_iniciativa), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsRegistro_inicial_de_iniciativa", new JavaScriptSerializer().Serialize(varRegistro_inicial_de_iniciativa), true);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsRegistro_inicial_de_iniciativa",new JavaScriptSerializer().Serialize(varRegistro_inicial_de_iniciativa), false, errors.ToString());
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }

        [Authorize]
        [HttpPut]
        public HttpResponseMessage Put(int id, Registro_inicial_de_iniciativa varRegistro_inicial_de_iniciativa)
        {
            if (ModelState.IsValid && id == varRegistro_inicial_de_iniciativa.Clave)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Update(varRegistro_inicial_de_iniciativa));
					 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdRegistro_inicial_de_iniciativa", new JavaScriptSerializer().Serialize(varRegistro_inicial_de_iniciativa), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
				    var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdRegistro_inicial_de_iniciativa", new JavaScriptSerializer().Serialize(varRegistro_inicial_de_iniciativa), false, ex.Message);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
               var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
               var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdRegistro_inicial_de_iniciativa", new JavaScriptSerializer().Serialize(varRegistro_inicial_de_iniciativa), false, String.Join(",", errors.ToArray()));
               serviceBitacora.Insert(bitacora);
               return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
		
		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Captura_Enlace_PMO(Registro_inicial_de_iniciativa varRegistro_inicial_de_iniciativa_Captura_Enlace_PMO)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Captura_Enlace_PMO(varRegistro_inicial_de_iniciativa_Captura_Enlace_PMO));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varRegistro_inicial_de_iniciativa_Captura_Enlace_PMO.Clave, BitacoraHelper.TypeSql.UPDATE, "sp_UpdRegistro_inicial_de_iniciativa", new JavaScriptSerializer().Serialize(varRegistro_inicial_de_iniciativa_Captura_Enlace_PMO), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varRegistro_inicial_de_iniciativa_Captura_Enlace_PMO.Clave, BitacoraHelper.TypeSql.UPDATE, "sp_UpdRegistro_inicial_de_iniciativa", new JavaScriptSerializer().Serialize(varRegistro_inicial_de_iniciativa_Captura_Enlace_PMO), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Captura_Enlace_PMO(int id)
        {
            Registro_inicial_de_iniciativa entity = this.service.ListaSelAll(1, 1, "Registro_inicial_de_iniciativa.Clave='" + id.ToString() + "'", "").Registro_inicial_de_iniciativas.First();
            Registro_inicial_de_iniciativa result = new Registro_inicial_de_iniciativa();
			result.Clave = entity.Clave;
result.Nombre_de_la_iniciativa = entity.Nombre_de_la_iniciativa;
result.Iniciales = entity.Iniciales;
result.Folio = entity.Folio;
result.BNEA_aprobado = entity.BNEA_aprobado;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Captura_Mensual_de_Usuario_Enlace_y_PMO(Registro_inicial_de_iniciativa varRegistro_inicial_de_iniciativa_Captura_Mensual_de_Usuario_Enlace_y_PMO)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Captura_Mensual_de_Usuario_Enlace_y_PMO(varRegistro_inicial_de_iniciativa_Captura_Mensual_de_Usuario_Enlace_y_PMO));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varRegistro_inicial_de_iniciativa_Captura_Mensual_de_Usuario_Enlace_y_PMO.Clave, BitacoraHelper.TypeSql.UPDATE, "sp_UpdRegistro_inicial_de_iniciativa", new JavaScriptSerializer().Serialize(varRegistro_inicial_de_iniciativa_Captura_Mensual_de_Usuario_Enlace_y_PMO), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varRegistro_inicial_de_iniciativa_Captura_Mensual_de_Usuario_Enlace_y_PMO.Clave, BitacoraHelper.TypeSql.UPDATE, "sp_UpdRegistro_inicial_de_iniciativa", new JavaScriptSerializer().Serialize(varRegistro_inicial_de_iniciativa_Captura_Mensual_de_Usuario_Enlace_y_PMO), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Captura_Mensual_de_Usuario_Enlace_y_PMO(int id)
        {
            Registro_inicial_de_iniciativa entity = this.service.ListaSelAll(1, 1, "Registro_inicial_de_iniciativa.Clave='" + id.ToString() + "'", "").Registro_inicial_de_iniciativas.First();
            Registro_inicial_de_iniciativa result = new Registro_inicial_de_iniciativa();
			result.Clave = entity.Clave;
result.Folio_fase = entity.Folio_fase;
result.Avance_Fase = entity.Avance_Fase;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Formulado(Registro_inicial_de_iniciativa varRegistro_inicial_de_iniciativa_Formulado)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Formulado(varRegistro_inicial_de_iniciativa_Formulado));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varRegistro_inicial_de_iniciativa_Formulado.Clave, BitacoraHelper.TypeSql.UPDATE, "sp_UpdRegistro_inicial_de_iniciativa", new JavaScriptSerializer().Serialize(varRegistro_inicial_de_iniciativa_Formulado), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varRegistro_inicial_de_iniciativa_Formulado.Clave, BitacoraHelper.TypeSql.UPDATE, "sp_UpdRegistro_inicial_de_iniciativa", new JavaScriptSerializer().Serialize(varRegistro_inicial_de_iniciativa_Formulado), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Formulado(int id)
        {
            Registro_inicial_de_iniciativa entity = this.service.ListaSelAll(1, 1, "Registro_inicial_de_iniciativa.Clave='" + id.ToString() + "'", "").Registro_inicial_de_iniciativas.First();
            Registro_inicial_de_iniciativa result = new Registro_inicial_de_iniciativa();
			result.Clave = entity.Clave;
result.Cronograma = entity.Cronograma;
result.Avance_de_la_Iniciativa = entity.Avance_de_la_Iniciativa;
result.Calificacion = entity.Calificacion;
result.Estatus = entity.Estatus;
result.Estatus_Estatus_Registro_Inicial = entity.Estatus_Estatus_Registro_Inicial;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Responsable_de_Alineacion(Registro_inicial_de_iniciativa varRegistro_inicial_de_iniciativa_Responsable_de_Alineacion)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Responsable_de_Alineacion(varRegistro_inicial_de_iniciativa_Responsable_de_Alineacion));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varRegistro_inicial_de_iniciativa_Responsable_de_Alineacion.Clave, BitacoraHelper.TypeSql.UPDATE, "sp_UpdRegistro_inicial_de_iniciativa", new JavaScriptSerializer().Serialize(varRegistro_inicial_de_iniciativa_Responsable_de_Alineacion), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varRegistro_inicial_de_iniciativa_Responsable_de_Alineacion.Clave, BitacoraHelper.TypeSql.UPDATE, "sp_UpdRegistro_inicial_de_iniciativa", new JavaScriptSerializer().Serialize(varRegistro_inicial_de_iniciativa_Responsable_de_Alineacion), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Responsable_de_Alineacion(int id)
        {
            Registro_inicial_de_iniciativa entity = this.service.ListaSelAll(1, 1, "Registro_inicial_de_iniciativa.Clave='" + id.ToString() + "'", "").Registro_inicial_de_iniciativas.First();
            Registro_inicial_de_iniciativa result = new Registro_inicial_de_iniciativa();
			result.Clave = entity.Clave;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }


		
	[Authorize]
        [HttpGet]
        public HttpResponseMessage Registro_inicial_de_iniciativaGenerateID()
        {
            Registro_inicial_de_iniciativa varRegistro_inicial_de_iniciativa = new Registro_inicial_de_iniciativa();
            var data = "-1";
            try
            {
                data = Convert.ToString(this.service.Insert(varRegistro_inicial_de_iniciativa));
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_Registro_inicial_de_iniciativaGenerateID", new JavaScriptSerializer().Serialize(varRegistro_inicial_de_iniciativa), true);
                serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_Registro_inicial_de_iniciativaGenerateID", new JavaScriptSerializer().Serialize(varRegistro_inicial_de_iniciativa), true);
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }	
        [Authorize]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Registro_inicial_de_iniciativa varRegistro_inicial_de_iniciativa = this.service.GetByKey(id, false);
            bool result = false;
            if (varRegistro_inicial_de_iniciativa == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
              result=  this.service.Delete(id);//, globalData, dataReference);
			  var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelRegistro_inicial_de_iniciativa", new JavaScriptSerializer().Serialize(varRegistro_inicial_de_iniciativa), result);
              serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelRegistro_inicial_de_iniciativa", new JavaScriptSerializer().Serialize(varRegistro_inicial_de_iniciativa), result, ex.Message);
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
                var Registro_inicial_de_iniciativaDataTable = new JavaScriptSerializer().Deserialize<List<Registro_inicial_de_iniciativa>>(result);
                return Request.CreateResponse(HttpStatusCode.OK, Registro_inicial_de_iniciativaDataTable, Configuration.Formatters.JsonFormatter);
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
                var Registro_inicial_de_iniciativaResult = new JavaScriptSerializer().Deserialize<Registro_inicial_de_iniciativa>(result);
                return Request.CreateResponse(HttpStatusCode.OK, Registro_inicial_de_iniciativaResult, Configuration.Formatters.JsonFormatter);            
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
        public HttpResponseMessage PostTunnel(Registro_inicial_de_iniciativa emp,string user, string password)
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
        public HttpResponseMessage PutTunnel(Registro_inicial_de_iniciativa emp, string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);
                client.Headers["Content-Type"] = "application/json";
                var dataString = new JavaScriptSerializer().Serialize(emp);

                var result = client.UploadString(new Uri(baseApi + ApiControllerUrl + "/Put?Id=" + emp.Clave), "PUT"
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

