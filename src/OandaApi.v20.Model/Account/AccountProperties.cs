namespace OandaApi.v20.Model.Account
{
    /// <summary>
    /// http://developer.oanda.com/rest-live-v20/account-df/#AccountID
    /// </summary>
    public class AccountProperties
    {
        /// <summary>
        /// The Account’s identifier
        /// “-“-delimited string with format “{siteID}-{divisionID}-{userID}-{accountNumber}”
        /// </summary>
        public string Id { get; set; }
        
        /// <summary>
        /// The Account’s associated MT4 Account ID. This field will not be present
        /// if the Account is not an MT4 account.
        /// </summary>
        public int Mt4AccountID { get; set; }
        
        /// <summary>
        /// The Account’s tags
        /// </summary>
        public string[] Tags { get; set; }
    }
}