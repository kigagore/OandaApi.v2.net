using System;
using System.Net.Http;
using OandaApi.v20.Api.Endpoints.Account;
using OandaApi.v20.Model;

namespace Oanda.Api.V20.Api.Tests
{
    public abstract class EndpointTestContext
    {
        protected OandaConfig OandaConfig;
        
        public EndpointTestContext()
        {
            // TODO move this to the user secrets, write howto document
            OandaConfig = new OandaConfig
            {
                RestApiUrl = new Uri("https://api-fxpractice.oanda.com"),
                StreamingApiUrl = new Uri("https://stream-fxpractice.oanda.com/"),
                AccessToken = "beb432f38462e2b2421a1e072fba1275-420b1763878c586d2cb4a887598c1b50"
            };
        }

        protected HttpClient ResolveHttpClient()
        {
            return new HttpClient();
        }
        
    }
}