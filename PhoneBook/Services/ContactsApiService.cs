using PhoneBook.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace PhoneBook.Services
{
    public interface IContactsApiService
    {
        Task<List<Contact>> GetList();
    }

        public class ContactsApiService : IContactsApiService
    {

        public async Task<List<Contact>> GetList()
        {
            HttpClient client = new HttpClient();

            string apiEndpoint
                = Properties.Settings.Default.ApiEndpoint;

            client.BaseAddress = new Uri("http://127.0.0.149/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            List<Contact> contacts = new List<Contact>();

            var response = await client.GetAsync("/api/contacts");

            if (response.IsSuccessStatusCode)
            {
                contacts = await response.Content.ReadAsAsync<List<Contact>>();
            }

            return contacts;
        }
    }
}