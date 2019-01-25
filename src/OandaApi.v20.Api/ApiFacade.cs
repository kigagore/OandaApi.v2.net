using System;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using OandaApi.v20.Api.Endpoints;
using OandaApi.v20.Api.Endpoints.Account;
using OandaApi.v20.Model;

namespace OandaApi.v20.Api
{
    public class ApiFacade : IApiFacade
    {
        private readonly OandaConfig _config;
        private readonly ILogger<ApiFacade> _logger;
        private readonly HttpClient _httpClient;

        public ApiFacade(OandaConfig config, ILogger<ApiFacade> logger)
        {
            _config = config;
            _logger = logger;
            _httpClient = new HttpClient();
        }

        private void InitializeEndpoints()
        {
            AccountEndpoint = new AccountEndpoint(ResolveHttpClient, _config);
        }

        public IAccountEndpoint AccountEndpoint { get; private set; }

        private HttpClient ResolveHttpClient()
        {
            // using shared HttpClient https://aspnetmonsters.com/2016/08/2016-08-27-httpclientwrong/
            // https://blogs.msdn.microsoft.com/shacorn/2016/10/21/best-practices-for-using-httpclient-on-services/
            return _httpClient;
        }

        private void ReleaseUnmanagedResources()
        {
            _httpClient?.Dispose();
        }

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        ~ApiFacade()
        {
            ReleaseUnmanagedResources();
        }
    }
}
