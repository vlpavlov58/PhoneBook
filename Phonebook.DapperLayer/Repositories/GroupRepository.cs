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
                connection.Query<Group>("DELETE FROM [Group] WHERE Id = @Id", new { Id = Id});
            }

        }

        public void Update(Group group)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                var groups = connection.Query<Group>("UPDATE [Group] SET [Name] = @Name WHERE Id = @Id", new { Id = group.Id, Name = group.Name });
            }

        }

        public Group GetById(int Id)
        {
            Group group = new Group();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var groups = connection.Query<Group>("SELECT * FROM [Group] WHERE Id = @Id", new { Id = group.Id })
                    .ToList();
                return group;
            }

            //using (SqlConnection conn
            //    = new SqlConnection(ConnectionString))
            //{
            //    conn.Open();

            //    string sql = $"SELECT * FROM [Group] WHERE [Id] = {Id}";

            //    SqlCommand command
            //        = new SqlCommand(sql, conn);

            //    DataTable groupsData = new DataTable();

            //    SqlDataAdapter dataAdapter
            //        = new SqlDataAdapter(command);

            //    dataAdapter.Fill(groupsData);

            //    DataRow dataRow = groupsData.Rows[0];

            //    if (dataRow != null)
            //    {
            //        group = new Group
            //        {
            //            Id = int.Parse(dataRow["Id"].ToString()),
            //            Name = dataRow["Name"].ToString()
            //        };

            //    }
            //    return group;
            }
        }
    }
}
