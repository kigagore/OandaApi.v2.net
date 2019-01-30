using OandaApi.v20.Model.Enum;
using OandaApi.v20.Model.Instrument;

namespace OandaApi.v20.Api.Endpoints.Instrument
{
    /// <summary>
    /// http://developer.oanda.com/rest-live-v20/instrument-ep/
    /// </summary>
    public class GetCandlesResponse
    {
        public string Instrument { get; set; }
        
        public CandlestickGranularity Granularity { get; set; }
        
        public Candlestick[] Candles { get; set; }
    }
}