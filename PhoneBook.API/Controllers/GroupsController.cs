using BusinessLogic.Services;
using PhoneBook.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PhoneBook.API.Controllers
{
    public class GroupsController : ApiController
    {
        private readonly IGroupService _groupService;

        public GroupsController()
        {
            _groupService = new GroupService();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var groups = _groupService.GetList();

            return Ok(groups);
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody] Group group)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _groupService.Add(group);

            return Ok();
        }


    }
}
