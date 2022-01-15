using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
//using System.Web.Mvc;
using System.Web.Http;
using Spartane.WebApi.Controllers;

namespace Spartane.WebApi.Controllers
{
    [Authorize]
    public class TokenController : BaseApiController
    {
        [HttpGet]
        public HttpResponseMessage RefeshTokenMain()
        {
            return Request.CreateResponse(HttpStatusCode.OK, true);
        }
    }
}