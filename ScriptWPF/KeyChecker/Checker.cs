using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace KeyChecker
{
    public class Checker
    {
        private string keyFilePath;

        public Checker(string keyFilePath)
        {
            this.keyFilePath = keyFilePath;
        }

        /// <summary>
        /// Makes a request to the Cetbix server and checks the availability of the key every /milliseconds/.
        /// If key is not available run /action/.
        /// </summary>
        public void StartChecking(int milliseconds, Action action)
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    if (Check())
                    {
                        await Task.Delay(milliseconds);
                    }
                    else
                    {
                        break;
                    }
                }
                action();
            });
        }

        private bool Check()
        {
            if (File.Exists(keyFilePath))
            {
                var text = File.ReadAllText(keyFilePath).Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    var encryptor = new Encryptor("bf269582-eab7-4f53-9311-12cb834076b0");
                    var activatedKey = encryptor.Decrypt(text);
                    if (!string.IsNullOrEmpty(activatedKey))
                    {
                        try
                        {
                            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://xvex.de/isms/add_ons/cetbix_vulnerability_management/activation-checker.php");
                            httpWebRequest.ContentType = "application/json";
                            httpWebRequest.Method = "POST";
                            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                            {
                                streamWriter.Write($"ActivationId={activatedKey}");
                            }
                            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                            {
                                var result = streamReader.ReadToEnd().Trim();
                                var mainFlag = Convert.ToBoolean(int.Parse(result));
                                if (mainFlag)
                                {
                                    File.Delete(keyFilePath);
                                }
                                return mainFlag;
                            }
                        }
                        catch (WebException ex)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}