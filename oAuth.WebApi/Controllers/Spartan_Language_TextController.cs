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
using Spartane.Core.Classes.Spartan_Language_Text;
using Spartane.Services.Spartan_Language_Text;

namespace Spartane.WebApi.Controllers
{
    
    public class Spartan_Language_TextController : BaseApiController
    {
        private ISpartan_Language_TextService service = null;

        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public Spartan_Language_TextController(ISpartan_Language_TextService service)
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

        public HttpResponseMessage Post(Spartan_Language_Text varSpartan_Language_Text)
        {
            if (ModelState.IsValid)
            {
                var data = -1;
                try
                {
                    data = this.service.Insert(varSpartan_Language_Text); //, globalData, dataReference);
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
        public HttpResponseMessage Put(int id, Spartan_Language_Text varSpartan_Language_Text)
        {
            if (ModelState.IsValid && id == varSpartan_Language_Text.Language_Text_Id)
            {
                var data = -1;
                try
                {
                    data = this.service.Update(varSpartan_Language_Text);//, globalData, dataReference);
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

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Spartan_Language_Text varSpartan_Language_Text = this.service.GetByKey(id, false);
            bool result = false;
            if (varSpartan_Language_Text == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
              result=  this.service.Delete(id);//, globalData, dataReference);
            }
            catch (ServiceException ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}


