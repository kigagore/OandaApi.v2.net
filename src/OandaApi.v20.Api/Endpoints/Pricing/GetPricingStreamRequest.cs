using System.Runtime.Serialization;

namespace OandaApi.v20.Api.Endpoints.Pricing
{
    /// <summary>
    /// http://developer.oanda.com/rest-live-v20/pricing-ep/
    /// </summary>
    public class GetPricingStreamRequest
    {
        /// <summary>
        /// Account Identifier [required]
        /// </summary>
        [IgnoreDataMember]
        public string AccountId { get; set; }
        
        /// <summary>
        /// List of Instruments to stream Prices for. [required]
        /// </summary>
        public string Instruments { get; set; }
        
        /// <summary>
        /// Flag that enables/disables the sending of a pricing snapshot when initially connecting to the stream. [default=True]
        /// </summary>
        public bool Snapshot { get; set; }
    }
}