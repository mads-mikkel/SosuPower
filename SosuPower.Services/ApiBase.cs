using SosuPower.Entities;

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

        public List<Assignment> GetAssignmentsFor(DateTime date, Employee employee)
        {
            UriBuilder uriBuilder = new UriBuilder(baseUri);
            uriBuilder.Path = "Assignment/GetAssignmentsForEmployeeByDate";
            using HttpClient client = new();
            client.BaseAddress = uriBuilder.Uri;
            

                // call api here
                return default;
        }
    }

    public interface ISosuService
    {
        List<Assignment> GetAssignmentsFor(DateTime date, Employee employee);
    }
}