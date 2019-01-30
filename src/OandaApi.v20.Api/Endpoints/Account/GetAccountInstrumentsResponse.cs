using OandaApi.v20.Model.Primitives;

namespace OandaApi.v20.Api.Endpoints.Account
{
    public class GetAccountInstrumentsResponse
    {
        public Model.Primitives.Instrument[] Instruments { get; set; }
        
        /// <summary>
        /// The ID of the most recent Transaction created for the Account.
        /// </summary>
        public string LastTransactionID { get; set; }
    }
}