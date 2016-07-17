using System;
using System.Threading.Tasks;
using FBClient.Models.RestAPI.Interfaces;
using FBClient.Models.RestAPI.JSONRequest;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.IO;
using FBClient.Models.FBClient;

namespace FBClient.Services
{
    public class FBClientDispatcher : IFBClientDispatcher
    {
        IFBWebAPIContract _fbWebAPIContract;

        public FBClientDispatcher(IFBWebAPIContract fbWebAPIContract)
        {
            _fbWebAPIContract = fbWebAPIContract;
        }

        /// <summary>
        /// Send Application ID, Application Secret Key, Facebook Page ID and posted topic'c filter to WebAPI method.
        /// </summary>
        /// <param name="appId"></param>
        /// <param name="appSecretKey"></param>
        /// <param name="pageId"></param>
        /// <param name="feedFilter"></param>
        /// <returns></returns>
        public async Task<FBClientModel> CallFBWebAPI_CommentsAndSaveInXML_Method(string appId, string appSecretKey, string pageId, string topicFilter)
        {
            var result = new FBClientModel();

            // Validation of Input parameters
            if (string.IsNullOrEmpty(appId))
            {
                result.Success = false;
                result.Message = "The App ID should not be null or empty";

                return result;
            }

            if (string.IsNullOrEmpty(appSecretKey))
            {
                result.Success = false;
                result.Message = "The App Secret Key should not be null or empty";

                return result;
            }

            if (string.IsNullOrEmpty(pageId))
            {
                result.Success = false;
                result.Message = "The Page ID should not be null or empty";

                return result;
            }

            if (string.IsNullOrEmpty(topicFilter))
            {
                result.Success = false;
                result.Message = "The filter for searching posted topic should not be null or empty";

                return result;
            }

            // Create object for calling WebAPI method.
            var fbWebAPIRequest = new FBWebAPIRequest()
            {
                AppID = appId,
                AppSecretKey = appSecretKey,
                PageId = pageId,
                TopicFilter = topicFilter
            };

            //Request for calling WebAPI method
            var fbWebAPIResponse = await _fbWebAPIContract.CallWebAPIMethod(fbWebAPIRequest);

            //Validation of result
            if (fbWebAPIResponse == null)
            {
                result.Success = false;
                result.Message = "The result of WebAPI request is null.";

                return result;
            }

            if (!fbWebAPIResponse.Success)
            {
                result.Success = false;
                result.Message = string.IsNullOrEmpty(fbWebAPIResponse.ExceptionMessage) ? fbWebAPIResponse.error.message : fbWebAPIResponse.ExceptionMessage;

                return result;
            }

            if (string.IsNullOrEmpty(fbWebAPIResponse.message))
            {
                result.Success = false;
                result.Message = "The returned message should not be null or empty";

                return result;
            }

            // Everything was successful
            result.Success = true;
            result.Message = fbWebAPIResponse.message;

            return result;
        }
    }
}
