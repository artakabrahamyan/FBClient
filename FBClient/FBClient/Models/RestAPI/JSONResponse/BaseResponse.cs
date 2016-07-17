using FBClient.Models.RestAPI.JSONError;
using System.Xml.Serialization;

namespace FBClient.Models.RestAPI.JSONResponse
{
    public class BaseResponse
    {
        /// <summary>
        /// Status code
        /// </summary>
        public string StatusCode { get; set; }

        /// <summary>
        /// Indicates whether the request is success or fault 
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        public ErrorDetail error { get; set; }
    }
}
