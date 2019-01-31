using System.Net;

namespace OandaApi.v20.Api.Endpoints
{
    public class ApiError
    {       
        public string ErrorMessage { get; set; }
        
        public HttpStatusCode StatusCode { get; set; }
    }
}