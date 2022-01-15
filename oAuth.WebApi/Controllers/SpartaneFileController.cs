using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
//using System.Web.Mvc;
using Spartane.Core.Classes.SpartaneFile;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.SpartaneFile;
using Spartane.WebApi.Controllers;
using System.Web.Http;

namespace Spartane.WebApi.Controllers
{
    public class SpartaneFileController : BaseApiController
    {

        private ISpartaneFileService service = null;
        public SpartaneFileController(ISpartaneFileService service)
        {
            this.service = service;
        }
        [Authorize]
        public HttpResponseMessage Post(Spartane_File varSpartaneFile)
        {
            if (ModelState.IsValid)
            {
                long data = -1;
                try
                {
                    data = this.service.Insert(varSpartaneFile);//, globalData, dataReference);
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
        public HttpResponseMessage Put(int id, Spartane_File varSpartaneFile)
        {
            if (ModelState.IsValid && id == varSpartaneFile.File_Id)
            {
                long data = -1;
                try
                {
                    data = this.service.Update(varSpartaneFile);//, globalData, dataReference);
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
            Spartane_File varSpartaneFile = this.service.GetByKey(id, false);
            bool result = false;
            if (varSpartaneFile == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
                result = this.service.Delete(id);//, globalData, dataReference);
            }
            catch (ServiceException ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var entity = this.service.GetByKey(id, false);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

    }
}