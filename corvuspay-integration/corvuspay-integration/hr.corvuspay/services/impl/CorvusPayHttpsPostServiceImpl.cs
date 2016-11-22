using System.IO;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using corvuspay_integration.hr.corvuspay.types;
using corvuspay_integration.hr.corvuspay.utils;

namespace corvuspay_integration.hr.corvuspay.services.impl
{
    public class CorvusPayHttpsPostServiceImpl : CorvusPayHttpsPostService
    {
        public CorvusPayHttpsPostServiceImpl() { }

        public Dictionary<string, string> ExecuteHttpsPost(string url, string absoluteCertificatePath, string password, Dictionary<CorvusPayRequestFieldType, string> requestFields)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            X509Certificate2Collection certificates = ImportCertificates(absoluteCertificatePath, password);
            byte[] output = GetOutput(requestFields);

            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = output.Length;
            foreach (var cert in certificates)
                request.ClientCertificates.Add(cert);

            var response = PostAndGetResponse(request, output);

            return CorvusPayXmlUtil.ParseResponse(response);
        }

        private X509Certificate2Collection ImportCertificates(string absoluteCertificatePath, string password)
        {
            X509Certificate2Collection certificates = new X509Certificate2Collection();
            certificates.Import(absoluteCertificatePath, password, X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet);
            return certificates;
        }

        private byte[] GetOutput(Dictionary<CorvusPayRequestFieldType, string> requestFields)
        {
            return new ASCIIEncoding().GetBytes(CorvusPayFormatUtil.FormatRequestFields(requestFields));           
        }

        private string PostAndGetResponse(HttpWebRequest request, byte[] output)
        {
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(output, 0, output.Length);
                stream.Close();
            }

            using (HttpWebResponse input = (HttpWebResponse)request.GetResponse())
            {
                var response = new StreamReader(input.GetResponseStream()).ReadToEnd();
                input.Close();
                return response;
            }      
        } 
    }
}