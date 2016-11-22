using System;
using System.Web;

namespace corvuspay_integration.hr.corvuspay.utils
{
    public static class CorvusPayMiscellaneousUtil
    {
        public static string getIP(HttpContext context)
        {
            String ip = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ip))
            {
                ip = context.Request.ServerVariables["REMOTE_ADDR"];
            }
            return ip;
        }

        public static bool ValidateFields(string[] fields)
        {
            foreach (var field in fields)
            {
                if (string.IsNullOrEmpty(field))
                    return false;
            }
            return true;
        }
    }
}