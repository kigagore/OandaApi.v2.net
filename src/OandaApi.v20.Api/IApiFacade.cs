using System;
using OandaApi.v20.Api.Endpoints;
using OandaApi.v20.Api.Endpoints.Account;

namespace OandaApi.v20.Api
{
    public interface IApiFacade : IDisposable
    {
        IAccountEndpoint AccountEndpoint { get; }
    }
}