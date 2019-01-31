using System;
using System.Net.Http;
using OandaApi.v20.Model;

namespace OandaApi.v20.Api.Endpoints
{
    public abstract class StreamingEndpointBase : EndpointBase
    {
        protected StreamingEndpointBase(Func<HttpClient> httpClientResolver, OandaConfig config) : base(httpClientResolver, config)
        {
        }
    }
}