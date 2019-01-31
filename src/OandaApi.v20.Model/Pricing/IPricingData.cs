using System;
using OandaApi.v20.Model.Enum;

namespace OandaApi.v20.Model.Pricing
{
    public interface IPricingData
    {
        PricingDataType Type { get; set; }
        
        DateTime Time { get; set; }
    }
}