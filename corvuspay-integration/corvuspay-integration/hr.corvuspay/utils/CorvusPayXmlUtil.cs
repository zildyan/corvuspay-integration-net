using System.Xml.Linq;
using System.Collections.Generic;
using corvuspay_integration.hr.corvuspay.exceptions;
using corvuspay_integration.hr.corvuspay.types;
using System;
using System.Reflection;
using System.ComponentModel;

namespace corvuspay_integration.hr.corvuspay.utils
{
    public static class CorvusPayXmlUtil
    {
        public static Dictionary<string, string> ParseResponse(string response)
        {
            if (string.IsNullOrEmpty(response))
                throw new CorvusPayRuntimeExceptions.CorvusPayInvalidResponse("Response is empty.");

            var xDoc = XDocument.Parse(response);

            if (xDoc.Element("errors") != null)           
                HandleErrors(xDoc);           
            else if (xDoc.Element("order") == null)         
                throw new CorvusPayRuntimeExceptions.CorvusPayInvalidResponse("Tag order missing from response.");
            else if(xDoc.Element("order").Element("response-code") == null)
                throw new CorvusPayRuntimeExceptions.CorvusPayInvalidResponse("Tag response-code missing from response tag order.");
            else if (xDoc.Element("order").Element("response-message") == null)
                throw new CorvusPayRuntimeExceptions.CorvusPayInvalidResponse("Tag response-message missing from response tag order.");

            var responseCode = xDoc.Element("order").Element("response-code").Value;
            var responseMessage = xDoc.Element("order").Element("response-message").Value;
            var responseDescription = GetCodeDescription(responseCode);

           return new Dictionary<string, string>()
           {
               { "responseCode", responseCode },
               { "responseMessage", responseMessage },
               { "responseDescription", responseDescription }
           };         
        }

        private static bool ContainsElementNode(XDocument xDoc, string tagName)
        {
            return xDoc.Element(tagName) != null;
        }
        private static void HandleErrors(XDocument xDoc)
        {
            XElement errElement = xDoc.Element("errors");
            if (errElement.Element("description") != null)           
                throw new CorvusPayRuntimeExceptions.CorvusPayInvalidResponse("CorvusPay error: " + errElement.Element("description").Value);
            else
                throw new CorvusPayRuntimeExceptions.CorvusPayInvalidResponse("CorvusPay error undefined");
        }

        private static string GetCodeDescription(string responseCode)
        {
            var enumeration = (CorvusPayResponseCodeType)Enum.Parse(typeof(CorvusPayResponseCodeType), "CODE_" + responseCode);
            FieldInfo field = enumeration.GetType().GetField(enumeration.ToString());
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? enumeration.ToString() : attribute.Description;
        }
    }
}