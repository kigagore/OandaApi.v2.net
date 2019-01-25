using System;
using System.Net.Http;
using System.Threading.Tasks;
using OandaApi.v20.Api.Endpoints;
using OandaApi.v20.Api.Endpoints.Account;
using OandaApi.v20.Model;
using Xunit;

namespace Oanda.Api.V20.Api.Tests
{
    public class GetAccounts
    {
        private AccountEndpoint _accountEndpoint;
            
        public GetAccounts()
        {
            var config = new OandaConfig
            {
                RestApiUrl = new Uri("https://api-fxpractice.oanda.com"),
                AccessToken = "beb432f38462e2b2421a1e072fba1275-420b1763878c586d2cb4a887598c1b50"
            };
            _accountEndpoint = new AccountEndpoint(() => new HttpClient(), config);
        }
        
        [Fact]
        public async Task Test1()
        {
            var res = await _accountEndpoint.GetAccountsAsync();
        }
    }
}