using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace OandaApi.v20.Api
{
    internal static class Serializing
    {
        public static JsonSerializerSettings GetSerializerSettings(params JsonConverter[] converters)
        {
            return new JsonSerializerSettings
            {
                ContractResolver = GetDefaultContractResolver(),
                Formatting = Formatting.Indented,
                Converters = converters
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