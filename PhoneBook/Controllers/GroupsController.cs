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
    public class GroupsController : Controller
    {
        private IGroupsApiService _groupService
            = new GroupsApiService();

        // GET: Groups
        public async Task<ActionResult> Index()
        {
            var groupsList = await _groupService.GetList();
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
                GroupName = "For editing"
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