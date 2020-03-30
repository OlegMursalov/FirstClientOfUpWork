using Script.Info;
using System;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

namespace CetbixCVD.Sender
{
    public class HttpJsonSender : ISender
    {
        private string uri;

        public HttpJsonSender(string uri)
        {
            this.uri = uri;
        }

        public bool SendData(DataOfComputer data, out string exMessage)
        {
            exMessage = string.Empty;
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(uri);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    var json = new JavaScriptSerializer().Serialize(data);
                    streamWriter.Write(json);
                }
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
                return true;
            }
            catch (Exception ex)
            {
                exMessage = ex.Message;
                return false;
            }
        }
    }
}