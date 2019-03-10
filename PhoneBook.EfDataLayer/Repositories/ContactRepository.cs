using PhoneBook.EfDataLayer.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.EfDataLayer.Repositories
{
    public class ContactRepository
    {
        public IEnumerable<Contact> GetAll()
        {
            using (var ctx = new PhoneBookEntities())
            {
                return ctx.Contacts
                                .ToList();
            }
        }

    }
}
