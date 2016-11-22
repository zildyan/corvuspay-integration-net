using System;
using System.Text;
using corvuspay_integration.hr.corvuspay.exceptions;
using System.Security.Cryptography;

namespace corvuspay_integration.hr.corvuspay.utils
{
    public static class CorvusPayHashUtil
    {
        private static string DELIMITER = ":";

        public static string CalculateDefaultRedirectHash(string secretKey, string orderNumber, string amount, string currencyCode)
        {
            return CalculateSha1WithDelimiter(new string[] { secretKey, orderNumber, amount, currencyCode });
        }

        public static string CalculateBestBeforeRedirectHash(string secretKey, string orderNumber, string amount, string currencyCode, string bestBefore)
        {
            return CalculateSha1WithDelimiter(new string[] { secretKey, orderNumber, amount, currencyCode, bestBefore });
        }

        public static string CalculateDiscountRedirectHash(string secretKey, string orderNumber, string amount, string discountAmount, string currencyCode)
        {
            return CalculateSha1WithDelimiter(new string[] { secretKey, orderNumber, amount, discountAmount, currencyCode });
        }

        public static string CalculateSha1WithDelimiter(string[] fields)
        {
            return CalculateSha1Internal(true, fields);
        }

        public static string CalculateSha1(string[] fields)
        {
            return CalculateSha1Internal(false, fields);
        }

        private static string CalculateSha1Internal(bool useColon, string[] fields)
        {
            if (fields == null || !CorvusPayMiscellaneousUtil.ValidateFields(fields))
                throw new CorvusPayRuntimeExceptions.Sha1CalculatingHashInvalidFieldException();

            var hashMessage = string.Empty;

            foreach (var field in fields)
            {
                hashMessage += field;
                if (useColon)
                    hashMessage += DELIMITER;
            }
           
            if (useColon)
                hashMessage.Remove(hashMessage.LastIndexOf(DELIMITER));

            return getSha1HexHash(hashMessage);
        }

        private static string getSha1HexHash(string hashMessage)
        {
            return byteArrayToHex(getSha1ByteHash(hashMessage));
        }

        private static byte[] getSha1ByteHash(string hashMessage)
        {
            var byteHash = new UTF8Encoding().GetBytes(hashMessage);
            return new SHA1CryptoServiceProvider().ComputeHash(byteHash);
        }

        private static string byteArrayToHex(byte[] hashByteArray)
        {
            StringBuilder HexHash = new StringBuilder(64);
            for (int i = 0; i < hashByteArray.Length; i++)
                HexHash.Append(String.Format("{0:X2}", hashByteArray[i]));
           return HexHash.ToString();//ToLower       
        }
    }
}