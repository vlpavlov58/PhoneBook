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

                string sql = "AddGroup";

                var command = new SqlCommand(sql, conn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(
                    new SqlParameter("Name", group.Name));

                command.ExecuteNonQuery();
            }
        }

        public void Delete (Group group)
        {
            using (SqlConnection conn
                = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string sql = string.Format("DELETE FROM [Group] WHERE NAME = []");

                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Remove(
                    new SqlParameter("Name", group.Name));

                cmd.ExecuteNonQuery();
            }
        }

        public int GetGroup (Group group)
        {
            using (SqlConnection conn
                = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string sql = string.Format("SELECT FROM [Group] WHERE Id = 1");

                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Remove(
                    new SqlParameter("Id", group.Id));

                cmd.ExecuteNonQuery();
            }
            return (group.Id);
        } 
    }
}
