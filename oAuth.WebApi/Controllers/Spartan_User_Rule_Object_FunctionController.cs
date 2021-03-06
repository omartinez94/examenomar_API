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
using Spartane.Core.Classes.Spartan_User_Rule_Object_Function;
using Spartane.Services.Spartan_User_Rule_Object_Function;

namespace Spartane.WebApi.Controllers
{
    
    public class Spartan_User_Rule_Object_FunctionController : BaseApiController
    {
        private ISpartan_User_Rule_Object_FunctionService service = null;

        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public Spartan_User_Rule_Object_FunctionController(ISpartan_User_Rule_Object_FunctionService service)
        {
            this.service = service;
        }

        //[Authorize(Roles = "Admin")]
        [Authorize]
        public HttpResponseMessage Get(int id)
        {
            var entity = this.service.GetByKey(id, false);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        //[Authorize(Roles = "Admin")]
        [Authorize]
        public HttpResponseMessage GetAll()
        {
            var entity = this.service.SelAll(false);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

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

        //[Authorize(Roles = "Admin")]
        [Authorize]
        public HttpResponseMessage GetAll(string where, string order)
        {
            var entity = this.service.SelAll(false, where, /*"Clave"*/order);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        public HttpResponseMessage Post(Spartan_User_Rule_Object_Function varSpartan_User_Rule_Object_Function)
        {
            if (ModelState.IsValid)
            {
                var data = -1;
                try
                {
                    data = this.service.Insert(varSpartan_User_Rule_Object_Function); //, globalData, dataReference);
                }
                catch (ServiceException ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(int id, Spartan_User_Rule_Object_Function varSpartan_User_Rule_Object_Function)
        {
            if (ModelState.IsValid && id == varSpartan_User_Rule_Object_Function.User_Rule_Object_Function_Id)
            {
                var data = -1;
                try
                {
                    data = this.service.Update(varSpartan_User_Rule_Object_Function);//, globalData, dataReference);
                }
                catch (ServiceException ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="SpartanUserRule">
        /// Added Parameter SpartanUserRule as required by Stored Procedure
        /// </param>
        /// <remarks>
        /// Date: (06/03/2016)
        /// Deleted code in Section A as:
        /// 1. It is overhead to delete functionality.
        /// 2. GetByKey(id,false) method calls Spsp_GetSpartan_User_Rule_Object_Function which requires 
        /// additional parameter @Spartan_User_Role.Adding this parameter would change the implementation of 
        /// GetByKey API method everywhere. Instead we should modify the sp sp_GetSpartan_User_Rule_Object_Function 
        /// to remove @Spartan_User_Role parameter.
        /// 3.sp_GetSpartan_User_Rule_Object_Function only fires "Select * from" statement which is not needed in Delete
        /// functionality.
        /// </remarks>
        /// <returns></returns>

        [HttpDelete]
        public HttpResponseMessage Delete(int id,int SpartanUserRule)
        {
            //Section - A Start
            // Deleted.
            //Spartan_User_Rule_Object_Function varSpartan_User_Rule_Object_Function = this.service.GetByKey(id, false);
            
            //if (varSpartan_User_Rule_Object_Function == null)
            //{
            //    return Request.CreateResponse(HttpStatusCode.NotFound);
            //}
            //Section - A End

            bool result = false;

            try
            {
                result = this.service.Delete(id, SpartanUserRule);//, globalData, dataReference);
            }
            catch (ServiceException ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}


