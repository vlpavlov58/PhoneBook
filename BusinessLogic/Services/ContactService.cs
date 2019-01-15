using PhoneBook.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public interface IContactService
    {
        List<Contact> GetList();
    }

    public class ContactService : IContactService
    {
        public List<Contact> GetList()
        {
            var contacts = new List<Contact>
            {
                new Contact
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Snow",
                    Position = "Lord Commander"
                },
                new Contact
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Doe",
                    Position = "Anonymous"
                }
            };

            return contacts;
        }
    }
}
