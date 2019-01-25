using OandaApi.v20.Model.Account;

namespace OandaApi.v20.Api.Endpoints.Account
{
    public sealed class GetAccountsResponse
    {
        public AccountProperties[] Accounts { get; set; }
    }
}