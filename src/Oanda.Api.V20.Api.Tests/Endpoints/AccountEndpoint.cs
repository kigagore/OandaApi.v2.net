using System.Threading.Tasks;
using OandaApi.v20.Api.Endpoints.Account;
using OandaApi.v20.Api.Endpoints.Instrument;
using Xunit;

namespace Oanda.Api.V20.Api.Tests.Endpoints
{
    public class AccountEndpoint : EndpointTestContext
    {
        private readonly OandaApi.v20.Api.Endpoints.Account.AccountEndpoint _accountEndpoint;

        private const string AccountId = "101-004-9916937-001";
            
        public AccountEndpoint() : base()
        {
            _accountEndpoint = new OandaApi.v20.Api.Endpoints.Account.AccountEndpoint(ResolveHttpClient, OandaConfig);
        }

        [Fact]
        public async Task GetAccountInstruments()
        {
            var res = await _accountEndpoint.GetAccountInstrumentsAsync(AccountId);
        }
    }
}