using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using OandaApi.v20.Model.Enum;
using OandaApi.v20.Model.Pricing;

namespace OandaApi.v20.Api.Endpoints.Pricing
{
    public class PricingItemConverter : CustomCreationConverter<IPricingData>
    {
        public override IPricingData Create(Type objectType)
        {
            throw new NotImplementedException();
        }

        public IPricingData Create(Type objectType, JObject jObject)
        {
            var type = (PricingDataType)Enum.Parse(typeof(PricingDataType), jObject.Property("type").Value.ToString());

            switch (type)
            {
                case PricingDataType.PRICE:
                    return new Price();
                case PricingDataType.HEARTBEAT:
                    return new PricingHeartbeat();
            }

            throw new ApplicationException(String.Format("The pricing data type {0} is not supported!", type));
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load JObject from stream 
            JObject jObject = JObject.Load(reader);

            // Create target object based on JObject 
            var target = Create(objectType, jObject);

            // Populate the object properties 
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }
    }
}