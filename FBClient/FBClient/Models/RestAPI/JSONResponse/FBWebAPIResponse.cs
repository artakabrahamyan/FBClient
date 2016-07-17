using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FBClient.Models.RestAPI.JSONResponse
{
    public class FBWebAPIResponse : BaseResponse
    {
        /// <summary>
        /// Returning message about the request process.
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// System exception message
        /// </summary>
        public string ExceptionMessage { get; set; }
    }
}
