using PhoneBook.Models.DataModels;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PhoneBook.AdonetLayer.Repositories
{
    public class GroupRepository : BaseRepository
    {
        public IEnumerable<Group> GetAll()
        {
            var groups = new List<Group>();

            //connection
            using (SqlConnection conn
                = new SqlConnection(ConnectionString))
            {
                conn.Open();

                //command
                string sql = "SELECT * FROM [GROUP]";

                SqlCommand command
                    = new SqlCommand(sql, conn);

                //Data retrieving
                DataTable groupsData = new DataTable();

                SqlDataAdapter dataAdapter
                    = new SqlDataAdapter(command);

                dataAdapter.Fill(groupsData);

                foreach (DataRow row in groupsData.Rows)
                {
                    groups.Add(new Group
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        Name = row["Name"].ToString()
                    });
                }
                return groups;
            }
        }
        public void Add(Group group)
        {
            using (SqlConnection conn
                = new SqlConnection(ConnectionString))
            {
                conn.Open();

                //пример использования хранимой процедуры
                string sql = "AddGroup";

                var command = new SqlCommand(sql, conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(
                    new SqlParameter("Name", group.Name));

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int Id)
        {
            using (SqlConnection conn
                = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string sql = $"DELETE FROM [Group] WHERE Id = {Id}";

                var cmd = new SqlCommand(sql, conn);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Group group)
        {
            using (SqlConnection conn
                = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string sql = $"UPDATE [Group] SET [Name] = {group.Name} WHERE Id = {group.Id}";

                var cmd = new SqlCommand(sql, conn);

                cmd.ExecuteNonQuery();
            }
        }

        public Group GetById(int Id)
        {
            Group group = new Group();
            
            using (SqlConnection conn
                = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string sql = $"SELECT * FROM [Group] WHERE [Id] = {Id}";

                SqlCommand command
                    = new SqlCommand(sql, conn);

                DataTable groupsData = new DataTable();

                SqlDataAdapter dataAdapter
                    = new SqlDataAdapter(command);

                dataAdapter.Fill(groupsData);

                DataRow dataRow = groupsData.Rows[0];

                if (dataRow != null)
                {
                    group = new Group
                    {
                        Id = int.Parse(dataRow["Id"].ToString()),
                        Name = dataRow["Name"].ToString()
                    };

                }
                return group;
            }
        }
    }
}
