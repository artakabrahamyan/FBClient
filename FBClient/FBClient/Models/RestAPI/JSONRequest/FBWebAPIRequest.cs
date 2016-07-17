using System;
using FBClient.Models.RestAPI.Interfaces;

namespace FBClient.Models.RestAPI.JSONRequest
{
    public class FBWebAPIRequest : BaseRequest, IFBWebAPIInfo
    {
        /// <summary>
        /// Facebook Application ID
        /// </summary>
        public string AppID { get; set; }

        /// <summary>
        /// Facebook Application Secret Key
        /// </summary>
        public string AppSecretKey { get; set; }

        /// <summary>
        /// Facebook Page Id
        /// </summary>
        public string PageId { get; set; }

        /// <summary>
        /// Filter for searching posted topic message
        /// </summary>
        public string TopicFilter { get; set; }
    }
}
