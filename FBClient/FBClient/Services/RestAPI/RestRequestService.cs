using System;
using System.Diagnostics;
using System.Threading.Tasks;
using FBClient.Models.RestAPI.Interfaces;
using FBClient.Models.RestAPI.JSONResponse;

namespace FBClient.Services.RestAPI
{
    public class RestRequestService : IRestRequestService
    {
        private readonly IRestClientService _restClientService;
        private readonly IErrorResponseBuilder _errorResponseBuilder;

        public RestRequestService(IRestClientService restClientService, IErrorResponseBuilder errorResponseBuilder)
        {
            _restClientService = restClientService;
            _errorResponseBuilder = errorResponseBuilder;
        }

        /// <summary>
        /// Build request for getting generic type of object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resourcePath"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public async Task<T> BuildEmptyRequest<T>(string resourcePath, string accessToken) where T : BaseResponse, new()
        {
            return await BuildRequest<T, IDisposable>(resourcePath, accessToken, null);
        }

        /// <summary>
        /// Build request with generic type of object for getting another generic type of object
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="resourcePath"></param>
        /// <param name="accessToken"></param>
        /// <param name="clientRequest"></param>
        /// <returns></returns>
        public async Task<T1> BuildRequest<T1, T2>(string resourcePath, string accessToken, T2 clientRequest) where T1 : BaseResponse, new()
        {
            var clientResponse = new T1();

            try
            {
                //Call Rest request and get result
                clientResponse = await _restClientService.Get<T1>(resourcePath, string.Empty, null);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("making request error report");
                var badRequest = Convert.ToInt32(System.Net.HttpStatusCode.BadRequest);
                clientResponse = new T1
                {
                    error = _errorResponseBuilder.BuildErrorResponse(badRequest, ex.Message),
                    Success = false,
                    StatusCode = badRequest.ToString()
                };
            }

            Debug.WriteLine("returning");
            return clientResponse;
        }
    }
}
