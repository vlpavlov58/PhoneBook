using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhoneBook.API.Controllers
{
    [RoutePrefix("api/new-controller")]
    public class GroupEnhancedController : ApiController
    {
        [Route("action-route")]
        [HttpGet]
        public IHttpActionResult MyAction()
        {
            return Ok("my action");
        }

        [Route("fake-route")]
        [HttpGet]
        public IHttpActionResult FakeAction()
        {
            return Ok("fake action");
        }
    }
}
