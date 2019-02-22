using PhoneBook.Models;
using PhoneBook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PhoneBook.Controllers
{
    public class ContactsController : Controller
    {

        private IContactsApiService _contactService
           = new ContactsApiService();
        // GET: Contacts

        public async Task<ActionResult> List()
        {

            var contactsList = await _contactService.GetList();
            return View(contactsList);


            //var contacts = new List<Contact>
            //{
            //    new Contact
            //    {
            //        Id = 1,
            //        FirstName = "John",
            //        LastName = "Snow",
            //        Position = "Lord Commander"
            //    },
            //    new Contact
            //    {
            //        Id = 2,
            //        FirstName = "John",
            //        LastName = "Doe",
            //        Position = "Anonymous"
            //    }
        }

        public ActionResult GetDetails(int id)
        {
            throw new NotImplementedException();
        }

        public ActionResult Insert()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Insert(Contact model)
        {
            throw new NotImplementedException();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Contact model)
        {
            if (!ModelState.IsValid)
                return View(model);
            return Redirect($"http://www.google.com");
        }

        public ActionResult Update(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("List");

            var contact = new Contact
            {
                Id = id.Value,
                FirstName = "For editing",
                LastName = "For editing",
                Position = "For editing"
            };

            return View();
        }

        [HttpPost]
        public ActionResult Update(Contact model)
        {
            return Redirect($"http://www.facebook.com");
        }

        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult DeleteAction(int id)
        {
            throw new NotImplementedException();
        }
    }
}