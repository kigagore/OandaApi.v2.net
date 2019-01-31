using System;
using OandaApi.v20.Model.Enum;

namespace OandaApi.v20.Model.Pricing
{
    /// <summary>
    /// http://developer.oanda.com/rest-live-v20/pricing-df/#Price
    /// </summary>
    public class PricingHeartbeat : IPricingData
    {
        public PricingDataType Type { get; set; }
        public DateTime Time { get; set; }
    }
}