using System;

namespace OandaApi.v20.Model
{
    public class OandaConfig
    {
        public string AccessToken { get; set; }

        public string StreamingApiUrl { get; set; }

        public Uri RestApiUrl { get; set; }
    }
}
