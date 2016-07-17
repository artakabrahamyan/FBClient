using FBClient.Models.RestAPI.Interfaces;
using FBClient.Models.RestAPI.JSONError;

namespace FBClient.Managers.RestAPI
{
    public class ErrorResponseBuilder : IErrorResponseBuilder
    {
        /// <summary>
        /// Create an ErrorDetail object.
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="errorDescription"></param>
        /// <returns></returns>
        public ErrorDetail BuildErrorResponse(int statusCode, string errorDescription)
        {
            return new ErrorDetail
            {
                code = statusCode,
                message = errorDescription
            };
        }
    }
}
