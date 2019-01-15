using PhoneBook.Models;
using PhoneBook.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IGroupService
    {
        List<Group> GetList();
    }

    public class GroupService : IGroupService
    {
        public List<Group> GetList()
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
            return groupsList;
        }
    }
}
