using Dapper;
using PhoneBook.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.DapperLayer.Repositories
{
    public class GroupRepository : BaseDapperRepository
    {
        public IEnumerable<Group> GetAll()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var groups = connection.Query<Group>("SELECT * FROM [Group]")
                    .ToList();
                return groups;
            }
        }

        public void Add(Group group)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute("INSERT INTO [Group] ([Name]) VALUES (@Name)", new { Name = group.Name });
            }
        }

        public void Delete(int Id)
        {

            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute("DELETE FROM [Group] WHERE Id = @Id", new { Id = Id });
            }

        }

        public void Update(Group group)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Execute("UPDATE [Group] SET [Name] = @Name WHERE Id = @Id", new { Id = group.Id, Name = group.Name });
            }

        }

        public IEnumerable<Group> GetById(int Id)
        {

            using (var connection = new SqlConnection(ConnectionString))
            {
                var group = connection.Query<Group>($"SELECT * FROM [Group] WHERE Id = {Id}")
                    .ToList();
                return group;
            }
        }
    }
}
