using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OandaApi.v20.Model;
using OandaApi.v20.Model.Account;

namespace OandaApi.v20.Api.Endpoints.Account
{
    public class AccountEndpoint : RestEndpointBase, IAccountEndpoint
    {
        private const string GetAccountsMethodUri = "/v3/accounts";
        private const string GetAccountInstrumentsEndpointFormat = "/v3/accounts/{0}/instruments";
        
        public AccountEndpoint(Func<HttpClient> httpClientResolver, OandaConfig config) : base(httpClientResolver, config)
        {
        }
        
        public Task<ApiResponse<GetAccountsResponse>> GetAccountsAsync()
        {
            var request = CreateAuthorizedRestRequest(HttpMethod.Get, GetAccountsMethodUri);
            return SendRequestAsync<GetAccountsResponse>(request);
        }

        public Task<ApiResponse<GetAccountInstrumentsResponse>> GetAccountInstrumentsAsync(string accountId)
        {
            var request = CreateAuthorizedRestRequest(HttpMethod.Get, string.Format(GetAccountInstrumentsEndpointFormat, accountId));
            return SendRequestAsync<GetAccountInstrumentsResponse>(request);
        }
    }
}