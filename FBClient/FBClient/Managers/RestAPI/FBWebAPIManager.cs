using System.Threading.Tasks;
using FBClient.Constants.RestAPI;
using FBClient.Models.RestAPI.Interfaces;
using FBClient.Models.RestAPI.JSONRequest;
using FBClient.Models.RestAPI.JSONResponse;
using FBClient.Services.RestAPI;

namespace FBClient.Managers.RestAPI
{
    /// <summary>
    /// Manager class to prepare and request the data from WebAPI server.
    /// </summary>
    public class FBWebAPIManager : IFBWebAPIContract
    {
        private readonly IRestRequestService _restRequestService;

        public FBWebAPIManager(IRestRequestService restRequestService)
        {
            _restRequestService = restRequestService;
        }
        
        /// <summary>
        /// Call WebAPI method.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<FBWebAPIResponse> CallWebAPIMethod(FBWebAPIRequest request)
        {
            var apiUrlPath = string.Format(URLConstants.FB_GET_SAVE_INFO_ACTION_ABSOLUTE_PATH_SUFFIX, request.AppID, request.AppSecretKey, request.PageId, request.TopicFilter);
            return await _restRequestService.BuildEmptyRequest<FBWebAPIResponse>(apiUrlPath, null);
        }
    }
}
