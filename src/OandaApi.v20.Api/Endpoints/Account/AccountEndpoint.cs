using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OandaApi.v20.Model;
using OandaApi.v20.Model.Account;

namespace OandaApi.v20.Api.Endpoints.Account
{
    public class AccountEndpoint : EndpointBase, IAccountEndpoint
    {
        private const string MethodUri = "/v3/accounts";
        
        public AccountEndpoint(Func<HttpClient> httpClientResolver, OandaConfig config) : base(httpClientResolver, config)
        {
        }
        
        public async Task<GetAccountsResponse> GetAccountsAsync()
        {
            var httpClient = HttpClientResolver();
            var request = CreateRequest(HttpMethod.Get, MethodUri);
            var response = await httpClient.SendAsync(request);
            var responseStr = await response.Content.ReadAsStringAsync();
            var resultObj = JsonConvert.DeserializeObject<GetAccountsResponse>(responseStr, Serializing.GetSerializerSettings());
            return resultObj;
        }
    }
}