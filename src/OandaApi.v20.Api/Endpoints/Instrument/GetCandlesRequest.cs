using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using OandaApi.v20.Model.Enum;

namespace OandaApi.v20.Api.Endpoints.Instrument
{
    public class GetCandlesRequest : RequestBase
    {   
        //ignore data member attribute to not include property to the query string in the method ToQueryString()
        //but maybe it is not good decision
        // TODO rework this approach
        [IgnoreDataMember]
        public string InstrumentName { get; set; }
        
        /// <summary>
        /// The Price component(s) to get candlestick data for.
        /// Can contain any combination of the characters “M” (midpoint candles) “B”
        /// (bid candles) and “A” (ask candles). [default=M]
        /// </summary>
        public string PriceType { get; set; }

        public CandlestickGranularity Granularity { get; set; } = CandlestickGranularity.S5;
        
        /// <summary>
        /// The number of candlesticks to return in the reponse. Count should not be specified if both
        /// the start and end parameters are provided, as the time range combined with the graularity
        /// will determine the number of candlesticks to return. [default=500, maximum=5000]
        /// </summary>
        public int? Count { get; set; } 
        
        public DateTime From { get; set; }
        
        public DateTime? To { get; set; }
        
        /// <summary>
        /// A flag that controls whether the candlestick is “smoothed” or not. A smoothed candlestick uses
        /// the previous candle’s close price as its open price, while an unsmoothed candlestick uses the
        /// first price from its time range as its open price. [default=False]
        /// </summary>
        public bool? Smooth { get; set; }
        
        /// <summary>
        /// A flag that controls whether the candlestick that is covered by the from time should be
        /// included in the results. This flag enables clients to use the timestamp of the last completed
        /// candlestick received to poll for future candlesticks but avoid receiving the previous candlestick repeatedly. [default=True]
        /// </summary>
        public bool? IncludeFirst { get; set; }
        
        /// <summary>
        /// The hour of the day (in the specified timezone) to use for granularities that have daily alignments.
        /// [default=17, minimum=0, maximum=23]
        /// </summary>
        public int? DailyAlignment { get; set; }
        
        /// <summary>
        /// The timezone to use for the dailyAlignment parameter. Candlesticks with daily alignment will be aligned to the
        /// dailyAlignment hour within the alignmentTimezone. Note that the returned times will still be represented
        /// in UTC. [default=America/New_York]
        /// </summary>
        public string AlignmentTimezone { get; set; }
        
        /// <summary>
        /// The day of the week used for granularities that have weekly alignment. [default=Friday]
        /// </summary>
        public WeeklyAlignment? WeeklyAlignment { get; set; }
    }
}