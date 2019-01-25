using System.Threading.Tasks;
using OandaApi.v20.Model.Account;

namespace OandaApi.v20.Api.Endpoints.Account
{
    public interface IAccountEndpoint
    {
        Task<GetAccountsResponse> GetAccountsAsync();
    }
}