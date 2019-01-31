namespace OandaApi.v20.Model.Pricing
{
    public class PriceBucket
    {
        /// <summary>
        /// The Price offered by the PriceBucket
        /// </summary>
        public decimal Price { get; set; }
        
        /// <summary>
        /// The amount of liquidity offered by the PriceBucket
        /// </summary>
        public int Liquidity { get; set; }
    }
}