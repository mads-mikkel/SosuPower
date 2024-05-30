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
    }

    public class SosuService: ApiBase, ISosuService
    {
        public SosuService(Uri baseUri) : base(baseUri) { }
        public SosuService(string baseUri) : base(baseUri) { }

        public async Task<List<Assignment>> GetAssignmentsForAsync(DateTime date, Employee employee)
        {
            UriBuilder uriBuilder = new UriBuilder(baseUri);
            uriBuilder.Path = "api/Assignment";//GetAssignmentsForEmployeeByDate";
            using HttpClient client = new();
            client.BaseAddress = uriBuilder.Uri;

            var response = await client.GetAsync("https://localhost:7006/api/Assignment"/*uriBuilder.Uri.AbsoluteUri*/);
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