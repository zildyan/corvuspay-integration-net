using System;
using System.Collections.Generic;
using corvuspay_integration.hr.corvuspay.types;

namespace corvuspay_integration.hr.corvuspay.services
{
    interface CorvusPayHttpsPostService
    {
        Dictionary<string, string> ExecuteHttpsPost(string url, string absoluteCertificatePath, string password, Dictionary<CorvusPayRequestFieldType, string> requestFields);
    }
}
