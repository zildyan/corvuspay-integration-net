using System;
using System.Collections.Generic;
using corvuspay_integration.hr.corvuspay.types;
using corvuspay_integration.hr.corvuspay.exceptions;

namespace corvuspay_integration.hr.corvuspay.utils
{
    public static class CorvusPayFormatUtil
    {
        public static string FormatByteToHex(byte b)
        {
            return string.Format("%02x", b & 0xff);
        }

        public static string FormatTwoDigits(int num)
        {
            return string.Format("%02x", num);
        }

        public static string FormatDecimalPoints(string num)
        {
            if (!num.Contains(","))
                return num;

            int i = num.IndexOf(",");
            if (num.IndexOf(",", i) != -1)
                throw new Exception("Multiple commas in string representation of number");
           
            return num.Replace(",", ".");
        }

        public static string FormatCartEntries(Dictionary<string, string> cartEntries)
        {
            string cartDetails = string.Empty;
            foreach (var entry in cartEntries)
            {
                cartDetails += entry.Key + "x" + entry.Value + ",";
            }

            cartDetails.Remove(cartDetails.LastIndexOf(","));

            if (cartDetails.Length > 200)
            {
                cartDetails = cartDetails.Substring(0, 197);
                cartDetails += "...";
            }
            return cartDetails;
        }

        public static string FormatRequestFields(Dictionary<CorvusPayRequestFieldType, string> requestData)
        {
            string formattedRequestFields = string.Empty;

            foreach(var entry in requestData)
            {
                formattedRequestFields += entry.Key.ToString().ToLower() + "=";
                formattedRequestFields += entry.Value + "&";
            }

            if (string.IsNullOrEmpty(formattedRequestFields))
            {
                throw new CorvusPayRuntimeExceptions.FormattedRequestFieldsEmptyException();
            }

            formattedRequestFields.Remove(formattedRequestFields.LastIndexOf("&"));
            return formattedRequestFields;
        }

        public static string FormatAllDynamicInstallments()
        {
            return "Y0299";
        }

        public static string FormatOnlyFirstInstallment()
        {
            return "Y0000";
        }

        public static string FormatOnlyOneInstallment(int installment)
        {
            if (installment <= 0)
                throw new CorvusPayRuntimeExceptions.InvalidNumberOfInstallments();
            return "N" + FormatTwoDigits(installment);
        }

        public static string FormatOneWithFirstInstallment(int installment)
        {
            if (installment <= 1)
                throw new CorvusPayRuntimeExceptions.InvalidNumberOfInstallments();
            return "Y" + FormatTwoDigits(installment);
        }

        public static string FormatDynamicInstallments(int from, int to)
        {
            if (from <= 0 || to <= 0)
                throw new CorvusPayRuntimeExceptions.InvalidNumberOfInstallments();
            return "N" + FormatTwoDigits(from) + FormatTwoDigits(to);
        }

        public static string FormatDynamicWithFirst(int from, int to)
        {
            if (from <= 1 || to <= 1)
                throw new CorvusPayRuntimeExceptions.InvalidNumberOfInstallments();
            return "Y" + FormatTwoDigits(from) + FormatTwoDigits(to);
        }
    }
}