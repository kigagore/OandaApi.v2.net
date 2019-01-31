using System.Threading.Tasks;
using OandaApi.v20.Model.Pricing;

namespace OandaApi.v20.Api.Endpoints.Pricing
{
    public interface IPricingStreamEndpoint
    {
        Task<StreamApiResponse<IPricingData>> GetPricingStream(GetPricingStreamRequest request);
    }
}