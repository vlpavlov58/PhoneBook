using PhoneBook.EfDataLayer.DataModel;
using PhoneBook.EfDataLayer.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services
{
    public interface IContactService
    {
        List<Contact> GetList();

        //Contact GetById(int Id);

        //void Add(Contact contact);

        //void Delete(int Id);

        //void Update(Contact contact);
    }

    public class ContactService : IContactService
    {
        private readonly ContactRepository _contactRepository;

        public ContactService()
        {
            _contactRepository = new ContactRepository();
        }

        public List<Contact> GetList()
        {
            return _contactRepository.GetAll()
                                            .OrderBy(g => g.FirstName)
                                            .ToList();
        }

        //public void Add(Contact contact)
        //{
        //    _contactRepository.Add(contact);
        //}

        //public Contact GetById(int Id)
        //{
        //    return _contactRepository.GetById(Id);
        //}

        //public void Delete(int Id)
        //{
        //    _contactRepository.Delete(Id);
        //}

        //public void Update(Contact contact)
        //{
        //    _contactRepository.Update(contact);
        //}
    }
}
