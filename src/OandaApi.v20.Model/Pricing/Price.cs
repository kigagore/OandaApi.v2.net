using System;
using OandaApi.v20.Model.Enum;

namespace OandaApi.v20.Model.Pricing
{
    /// <summary>
    /// http://developer.oanda.com/rest-live-v20/pricing-df/#Price
    /// </summary>
    public class Price : IPricingData
    {
        public PricingDataType Type { get; set; }
        public DateTime Time { get; set; }
        
        /// <summary>
        /// the name of the instrument
        /// </summary>
        public string Instrument { get; set; }
        
        /// <summary>
        /// Flag indicating if the Price is tradeable or not
        /// </summary>
        public bool Tradeable { get; set; }
        
        /// <summary>
        /// The list of prices and liquidity available on the Instrument’s ask side.
        /// It is possible for this list to be empty if there is no ask liquidity
        /// currently available for the Instrument in the Account.
        /// </summary>
        public PriceBucket[] Bids { get; set; }
        
        /// <summary>
        /// he closeout bid Price. This Price is used when a bid is required to
        /// closeout a Position (margin closeout or manual) yet there is no bid
        /// liquidity. The closeout bid is never used to open a new position. 
        /// </summary>
        public decimal CloseoutBid { get; set; }
        
        /// <summary>
        /// he closeout ask Price. This Price is used when a ask is required to
        /// closeout a Position (margin closeout or manual) yet there is no ask
        /// liquidity. The closeout ask is never used to open a new position.
        /// </summary>
        public decimal CloseoutAsk { get; set; }
    }
}