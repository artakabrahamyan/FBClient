
namespace FBClient.Constants.RestAPI
{
    /// <summary>
    /// URLConstants class declares the constants to create/generate the URL string for connecting to Facebook WebAPI.
    /// </summary>
    class URLConstants
    {
        //---
        public static string QUERY_STRING_SEPARATOR = @"?";
        public static string QUERY_PARAM_SEPARATOR = @"&";

        //---
        public static string PROTOCOL = @"http";
        public static string PROTOCOL_SEPARATOR = @"://";
        public static string URL_FOLDERPATH_SEPARATOR = @"/";

        public static string DOMAIN_NAME = @"localhost";
        //public static string DOMAIN_NAME = @"10.1.6.169";
        public static int DOMAIN_PORT = 36637;
        public static string DOMAIN_PORT_SEPARATOR = @":";
        public static float API_VERSION = 1.0F;

        //---
        public static string BASE_URL = PROTOCOL + PROTOCOL_SEPARATOR + DOMAIN_NAME + DOMAIN_PORT_SEPARATOR + DOMAIN_PORT.ToString();
        //---

        // Api
        public static string REST_URL_SUFFIX = @"/api";
        public static string REST_ABSOLUTE_PATH_SUFFIX = REST_URL_SUFFIX;
        public static string REST_URL_FULL = BASE_URL + REST_ABSOLUTE_PATH_SUFFIX;
        //---

        // FB webapi
        private static string FB_URL_SUFFIX = @"/FB";
        private static string FB_ABSOLUTE_PATH_SUFFIX = REST_ABSOLUTE_PATH_SUFFIX + FB_URL_SUFFIX;
        private static string FB_URL_FULL = BASE_URL + FB_ABSOLUTE_PATH_SUFFIX;

        public static string FB_GET_SAVE_INFO_ACTION_URL_SUFFIX = @"/getandsavecomments";
        public static string FB_GET_SAVE_INFO_ACTION_ABSOLUTE_PATH_SUFFIX = FB_ABSOLUTE_PATH_SUFFIX + FB_GET_SAVE_INFO_ACTION_URL_SUFFIX
                                                                            + URL_FOLDERPATH_SEPARATOR + @"{0}"
                                                                            + URL_FOLDERPATH_SEPARATOR + @"{1}"
                                                                            + URL_FOLDERPATH_SEPARATOR + @"{2}"
                                                                            + URL_FOLDERPATH_SEPARATOR + @"{3}";
        public static string FB_GET_SAVE_INFO_URL_FULL = BASE_URL + FB_GET_SAVE_INFO_ACTION_ABSOLUTE_PATH_SUFFIX;
    }
}
