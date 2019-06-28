using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Net;
using System.Text;

namespace LicenseCheckerCustomAction
{
    [RunInstaller(true)]
    public class CustomInstaller : Installer
    {
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }

        protected override void OnBeforeInstall(IDictionary savedState)
        {
            if (Context.Parameters.ContainsKey("EnteredLicenseKey"))
            {
                var enteredLicenseKey = Context.Parameters["EnteredLicenseKey"];
                if (!string.IsNullOrEmpty(enteredLicenseKey))
                {
                    try
                    {
                        var uuid = Common.GetUUID();
                        var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Common.TestApi}/license-checker.php");
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "POST";
                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            streamWriter.Write($"LicenseKeyValue={enteredLicenseKey};UUID={uuid}");
                        }
                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            var result = streamReader.ReadToEnd();
                            if (!string.IsNullOrEmpty(result))
                            {
                                var parts = result.Split(';');
                                if (parts.Length >= 2)
                                {
                                    if (parts[0].IndexOf("ActivationId", 0, StringComparison.CurrentCultureIgnoreCase) != -1 && parts[1].IndexOf("AmountOfMinutes", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                                    {
                                        var fragmentsOfActivationId = parts[0].Split('=');
                                        var fragmentsOfAmountOfMinutes = parts[1].Split('=');
                                        if (fragmentsOfActivationId.Length >= 2 && fragmentsOfAmountOfMinutes.Length >= 2)
                                        {
                                            var activationId = fragmentsOfActivationId[1];
                                            var amountOfMinutes = int.Parse(fragmentsOfAmountOfMinutes[1]);
                                            var lastDate = DateTime.Now.AddMinutes(amountOfMinutes);
                                            var assemblyPath = Context.Parameters["AssemblyPath"];
                                            if (!string.IsNullOrEmpty(assemblyPath))
                                            {
                                                var i = assemblyPath.LastIndexOf("\\");
                                                var path = assemblyPath.Substring(0, i);
                                                if (Directory.Exists(path))
                                                {
                                                    base.OnBeforeInstall(savedState);
                                                    using (var fstream = new FileStream($"{path}\\Cetbix.Activation.dll", FileMode.OpenOrCreate))
                                                    {
                                                        var encryptor = new Encryptor(Common.GuidForEncryptor);
                                                        var text = $"ActivationId={activationId};LastDate={lastDate}";
                                                        var encryptText = encryptor.Encrypt(text);
                                                        var array = Encoding.UTF8.GetBytes(encryptText);
                                                        fstream.Write(array, 0, array.Length);
                                                    }
                                                }
                                                else
                                                {
                                                    throw new Exception("Error in MSI [1124]");
                                                }
                                            }
                                            else
                                            {
                                                throw new Exception("Error in MSI [4435]");
                                            }
                                        }
                                    }
                                    else
                                    {
                                        throw new Exception("Error in MSI [6703]");
                                    }
                                }
                                else
                                {
                                    throw new Exception(result);
                                }
                            }
                            else
                            {
                                throw new Exception("Error in MSI [9958]");
                            }
                        }
                    }
                    catch (WebException ex)
                    {
                        throw new Exception("Check your internet connection.");
                    }
                }
                else
                {
                    throw new Exception("You have not entered a license key.");
                }
            }
            else
            {
                throw new Exception("You have not entered a license key.");
            }
        }

        public override void Rollback(IDictionary mySavedState)
        {
            base.Rollback(mySavedState);
        }
    }
}