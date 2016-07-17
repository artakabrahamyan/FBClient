using System;

namespace FBClient.Models.RestAPI.Interfaces
{
    public interface IFBWebAPIInfo
    {
        /// <summary>
        /// Facebook Application ID
        /// </summary>
        string AppID { get; set; }

        /// <summary>
        /// Facebook Application Secret Key
        /// </summary>
        string AppSecretKey { get; set; }

        /// <summary>
        /// Facebook Page Id
        /// </summary>
        string PageId { get; set; }

        /// <summary>
        /// Filter for searching posted topic message
        /// </summary>
        string TopicFilter { get; set; }
    }
}
