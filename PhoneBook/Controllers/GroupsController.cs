using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PhoneBook.Controllers
{
    public class GroupsController : Controller
    {
        // GET: Groups
        public ActionResult Index()
        {
            var groupsList =
                new List<Group>
                {
                    new Group
                    {
                        Id = 1,
                        Name = "Family"
                    },
                    new Group
                    {
                        Id = 2,
                        Name = "Friends"
                    }
                };
            return View(groupsList);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Group model)
        {
            if (!ModelState.IsValid)
                return View(model);
            return Redirect($"http://www.google.com");
        }

        public ActionResult Update(int? id)
        {
            if (!id.HasValue)
                return RedirectToAction("Index");

            var group = new Group
            {
                Id = id.Value,
                Name = "For editing"
            };

            return View();
        }

        [HttpPost]
        public ActionResult Update(Group model)
        {
            return Redirect($"http://www.facebook.com");
        }
    }
}