using LicenseCheckerCustomAction;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LicenseCheckerCustomAction
{
    public class Checker
    {
        private string baseFile;

        public Checker()
        {
            this.baseFile = AppDomain.CurrentDomain.BaseDirectory + "Cetbix.Activation.dll";
        }

        /// <summary>
        /// Makes a request to the Cetbix server and checks the availability of the key every /milliseconds/.
        /// If key is not available run /action/.
        /// </summary>
        public void StartChecking(int milliseconds, Action action)
        {
            Task.Run(() =>
            {
                while (true)
                {
                    if (Check())
                    {
                        Thread.Sleep(milliseconds);
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
            if (File.Exists(baseFile))
            {
                var text = File.ReadAllText(baseFile).Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    var encryptor = new Encryptor(Common.GuidForEncryptor);
                    var decryptText = encryptor.Decrypt(text);
                    if (!string.IsNullOrEmpty(decryptText))
                    {
                        var parts = decryptText.Split(';');
                        if (parts.Length >= 2)
                        {
                            if (parts[0].IndexOf("ActivationId", 0, StringComparison.CurrentCultureIgnoreCase) != -1 && parts[1].IndexOf("LastDate", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                            {
                                var fragmentsOfActivationId = parts[0].Split('=');
                                var fragmentsOfLastDate = parts[1].Split('=');
                                if (fragmentsOfActivationId.Length >= 2 && fragmentsOfLastDate.Length >= 2)
                                {
                                    var activationId = fragmentsOfActivationId[1];
                                    var lastDateStr = fragmentsOfLastDate[1];
                                    if (!string.IsNullOrEmpty(activationId) && !string.IsNullOrEmpty(lastDateStr))
                                    {
                                        try
                                        {
                                            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Common.TestApi}/activation-checker.php");
                                            httpWebRequest.ContentType = "application/json";
                                            httpWebRequest.Method = "POST";
                                            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                                            {
                                                streamWriter.Write($"ActivationId={activationId}");
                                            }
                                            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                                            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                                            {
                                                var result = streamReader.ReadToEnd().Trim();
                                                var mainFlag = Convert.ToBoolean(int.Parse(result));
                                                return mainFlag;
                                            }
                                        }
                                        catch (WebException ex)
                                        {
                                            var lastDate = DateTime.Parse(lastDateStr);
                                            return DateTime.Now <= lastDate;
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
            else
            {
                return false;
            }
        }
    }
}