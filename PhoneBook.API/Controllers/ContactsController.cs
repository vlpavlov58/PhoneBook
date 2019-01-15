using BusinessLogic.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhoneBook.API.Controllers
{
    public class ContactsController : ApiController
    {
        private readonly IContactService _contactService;

        public ContactsController()
        {
            _contactService = new ContactService();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var contacts = _contactService.GetList();

            return Ok(contacts);
        }
    }
}
