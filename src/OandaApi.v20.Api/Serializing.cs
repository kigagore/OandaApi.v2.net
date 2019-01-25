using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace OandaApi.v20.Api
{
    internal static class Serializing
    {
        public static JsonSerializerSettings GetSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                ContractResolver = GetDefaultContractResolver(),
                Formatting = Formatting.Indented
            };
        }

        private static DefaultContractResolver GetDefaultContractResolver()
        {
            return new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            };
        }
    }
}