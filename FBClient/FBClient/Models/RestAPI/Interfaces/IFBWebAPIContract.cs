using System.Threading.Tasks;
using FBClient.Models.RestAPI.JSONRequest;
using FBClient.Models.RestAPI.JSONResponse;

namespace FBClient.Models.RestAPI.Interfaces
{
    public interface IFBWebAPIContract
    {
        Task<FBWebAPIResponse> CallWebAPIMethod(FBWebAPIRequest request);
    }
}
