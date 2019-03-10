using PhoneBook.EfDataLayer.DataModel;
using PhoneBook.EfDataLayer.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services
{
    public interface IGroupService
    {
        List<Group> GetList();

        //IEnumerable<Group> GetById(int Id);

        //void Add(Group group);

        //void Delete(int Id);

        //void Update(Group group);
    }

    public class GroupService : IGroupService
    {
        private readonly GroupRepository _groupRepository;

        public GroupService()
        {
            _groupRepository = new GroupRepository();
        }

        public List<Group> GetList()
        {
            return _groupRepository.GetAll()
                                            .OrderBy(g => g.Name)
                                            .ToList();
        }

        //public void Add(Group group)
        //{
        //    _groupRepository.Add(group);
        //}

        //public IEnumerable<Group> GetById(int Id)
        //{
        //    return _groupRepository.GetById(Id);
        //}

        //public void Delete(int Id)
        //{
        //    _groupRepository.Delete(Id);
        //}

        //public void Update(Group group)
        //{
        //    _groupRepository.Update(group);
        //}
    }
}
