using PhoneBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace PhoneBook.Services
{
    public interface IGroupsApiService
    {
        Task<List<Group>> GetList();
    }

    public class GroupsApiService : IGroupsApiService
    {
        public async Task<List<Group>> GetList()
        {
            HttpClient client = new HttpClient();

            string apiEndpoint
                = Properties.Settings.Default.ApiEndpoint;

            client.BaseAddress = new Uri("http://127.0.0.149/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            List<Group> groups = new List<Group>();

            var response = await client.GetAsync("/api/groups");

            if (response.IsSuccessStatusCode)
            {
                groups = await response.Content.ReadAsAsync<List<Group>>();
            }

            return groups;

            throw new NotImplementedException();
        }
    }
}