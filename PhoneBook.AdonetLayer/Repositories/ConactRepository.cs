using PhoneBook.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.AdonetLayer.Repositories
{
    public class ContactRepository : BaseRepository
    {
        public IEnumerable<Contact> GetAll()
        {
            var contacts = new List<Contact>();

            //connection
            using (SqlConnection conn
                = new SqlConnection(ConnectionString))
            {
                conn.Open();

                //command
                string sql = "SELECT * FROM [Contact]";

                SqlCommand command
                    = new SqlCommand(sql, conn);

                //Data retrieving
                DataTable contactsData = new DataTable();

                SqlDataAdapter dataAdapter
                    = new SqlDataAdapter(command);

                dataAdapter.Fill(contactsData);

                foreach (DataRow row in contactsData.Rows)
                {
                    contacts.Add(new Contact
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        GroupId = int.Parse(row["GroupId"].ToString()),
                        FirstName = row["FirstName"].ToString(),
                        LastName = row["LastName"].ToString(),
                        Position = row["Position"].ToString()

                    });
                }
                return contacts;
            }
        }
        public void Add(Contact contact)
        {
            using (SqlConnection conn
                = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string sql = $"INSERT INTO [Contact] ([GroupId], [FirstName], [LastName], [Position]) " +
                    $"VALUES (@GroupId, @FirstName, @LastName, @Position)";

                var command = new SqlCommand(sql, conn);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int Id)
        {
            using (SqlConnection conn
                = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string sql = $"DELETE FROM [Contact] WHERE Id = {Id}";

                var cmd = new SqlCommand(sql, conn);

                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Contact contact)
        {
            using (SqlConnection conn
                = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string sql = $"UPDATE [Contact] SET [GroupId] = {contact.GroupId}, [FirstName] = {contact.FirstName}," +
                    $"[LastName] = {contact.LastName}, [Position] = {contact.Position} WHERE Id = {contact.Id}";

                var cmd = new SqlCommand(sql, conn);

                cmd.ExecuteNonQuery();
            }
        }

        public Contact GetById(int Id)
        {
            Contact contact = new Contact();

            using (SqlConnection conn
                = new SqlConnection(ConnectionString))
            {
                conn.Open();

                string sql = $"SELECT * FROM [Contact] WHERE [Id] = {Id}";

                SqlCommand command
                    = new SqlCommand(sql, conn);

                DataTable contactsData = new DataTable();

                SqlDataAdapter dataAdapter
                    = new SqlDataAdapter(command);

                dataAdapter.Fill(contactsData);

                DataRow dataRow = contactsData.Rows[0];

                if (dataRow != null)
                {
                    contact = new Contact
                    {
                        Id = int.Parse(dataRow["Id"].ToString()),
                        GroupId = int.Parse(dataRow["GroupId"].ToString()),
                        FirstName = dataRow["FirstName"].ToString(),
                        LastName = dataRow["LastName"].ToString(),
                        Position = dataRow["Position"].ToString()
                    };

                }
                return contact;
            }
        }
    }
}
