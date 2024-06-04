using Azure.Core;

using SosuPower.Entities;

using System.Net;
using System.Net.Http.Json;


namespace SosuPower.Services
{
    public abstract class ApiBase
    {
        protected Uri baseUri;

        protected ApiBase(Uri baseUri)
        {
            this.baseUri = baseUri;
        }

        protected ApiBase(string uri) : this(new Uri(uri)) { }

        protected virtual async Task<HttpResponseMessage> GetHttpAsync(string url) 
        {
            // Byg en URI for at sikre os at URL'en er korrekt.
            url = "/api/" + url;
            Uri uri = new(baseUri, url);

            // kald API'et
            using HttpClient client = new HttpClient();
            var response = await client.GetAsync(uri);

            // returner resultatet til kalderen
            return response;
        }
    }

    public class SosuService: ApiBase, ISosuService
    {
        public SosuService(Uri baseUri) : base(baseUri) { }
        public SosuService(string baseUri) : base(baseUri) { }

        public async Task<List<Assignment>> GetAssignmentsForAsync(DateTime date, Employee employee)
        {
            //GetAssignmentsForEmployeeByDate?employeeId=2&date=2024-01-01
            string url = $"Assignment/GetAssignmentsForEmployeeByDate?employeeId={employee.Id}&date={date.ToString("yyyy-MM-dd")}"; // <-- refactor action method.
            var response = await GetHttpAsync(url);
            var result = response.Content.ReadFromJsonAsAsyncEnumerable<Assignment>();
            List<Assignment> assignments = await result.ToListAsync();
            return assignments;
        }
    }

    public interface ISosuService
    {
        Task<List<Assignment>> GetAssignmentsForAsync(DateTime date, Employee employee);
    }
}