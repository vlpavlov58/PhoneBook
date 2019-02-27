using BusinessLogic.Services;
using PhoneBook.Models.DataModels;
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

        [HttpGet]
        public IHttpActionResult GetById(int Id)
        {
            var contact = _contactService.GetById(Id);

            return Ok(contact);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _contactService.Add(contact);

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int Id)
        {
            _contactService.Delete(Id);

            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] Contact contact)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _contactService.Update(contact);

            return Ok();
        }

    }
}
