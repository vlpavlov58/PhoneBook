using PhoneBook.EfDataLayer.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.EfDataLayer.Repositories
{
    public class GroupRepository
    {
        public IEnumerable<Group> GetAll()
        {
            using (var ctx = new PhoneBookEntities())
            {
                return ctx.Groups
                                .ToList();
            }
        }

        public void Add(Group group)
        {
            using (var ctx = new PhoneBookEntities())
            {
                ctx.Groups.Add(group);

                ctx.SaveChanges();
            }
        }

        public void Delete (Group group)
        {
            using (var ctx = new PhoneBookEntities())
            {
                ctx.Groups.Remove(group);

                ctx.SaveChanges();
            }
        }

        public void Update (Group group)
        {
            using (var ctx = new PhoneBookEntities())
            {
                ctx.Groups.
            }
        }

    }
}
