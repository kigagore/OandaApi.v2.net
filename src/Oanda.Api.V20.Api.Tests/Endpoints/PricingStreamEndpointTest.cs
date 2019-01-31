using System.Threading;
using System.Threading.Tasks;
using OandaApi.v20.Api.Endpoints.Pricing;
using Xunit;

namespace Oanda.Api.V20.Api.Tests.Endpoints
{
    public class PricingStreamEndpointTest : EndpointTestContext
    {
        private readonly PricingStreamEndpoint _endpoint;
        
        public PricingStreamEndpointTest()
        {
            _endpoint = new PricingStreamEndpoint(ResolveHttpClient, OandaConfig);
        }

        [Fact]
        public async Task GetPricingStream()
        {
            var request = new GetPricingStreamRequest
            {
                AccountId = "101-004-9916937-001",
                Instruments = "EUR_USD"
            };
            var streamResult = await _endpoint.GetPricingStream(request);
            var counter = 0;
            var source = new CancellationTokenSource();
            if (streamResult.IsSuccess)
            {
                
                streamResult.StartDataStream(data => { counter++; }, source.Token);
            }

            await Task.Delay(4000);
            source.Cancel();
            //streamResult.Dispose();
            var a = 1;
            await Task.Delay(6000);
            var b = 2;
            
            streamResult = await _endpoint.GetPricingStream(request);
            counter = 0;
            if (streamResult.IsSuccess)
            {
                streamResult.StartDataStream(data => { counter++; });
            }

            await Task.Delay(4000);
            streamResult.Dispose();
            a = 1;
            await Task.Delay(6000);
            b = 2;
        }
    }
}