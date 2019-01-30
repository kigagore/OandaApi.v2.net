using System;

namespace OandaApi.v20.Model
{
    public class OandaConfig
    {
        public string AccessToken { get; set; }

        public Uri StreamingApiUrl { get; set; }

        public Uri RestApiUrl { get; set; }
    }
}
