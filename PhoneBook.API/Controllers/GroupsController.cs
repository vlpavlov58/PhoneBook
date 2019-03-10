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

        //[HttpGet]
        //public IHttpActionResult GetById(int Id)
        //{
        //    var group = _groupService.GetById(Id);

        //    return Ok(group);
        //}

        //[HttpPost]
        //public IHttpActionResult Add([FromBody] Group group)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    _groupService.Add(group);

        //    return Ok();
        //}

        //[HttpDelete]
        //public IHttpActionResult Delete(int Id)
        //{
        //    _groupService.Delete(Id);

        //    return Ok();
        //}

        //[HttpPut]
        //public IHttpActionResult Update([FromBody] Group group)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    _groupService.Update(group);

        //    return Ok();
        //}
    }
}
