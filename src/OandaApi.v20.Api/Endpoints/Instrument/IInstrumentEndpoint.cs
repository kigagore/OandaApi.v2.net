using System.Threading.Tasks;

namespace OandaApi.v20.Api.Endpoints.Instrument
{
    public interface IInstrumentEndpoint
    {
        Task<ApiResponse<GetCandlesResponse>> GetCandlesticksAsync(GetCandlesRequest request);
    }
}