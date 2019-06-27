using KeyChecker;
using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;

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
                        var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://xvex.de/isms/add_ons/cetbix_vulnerability_management/license-checker.php");
                        httpWebRequest.ContentType = "application/json";
                        httpWebRequest.Method = "POST";
                        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                        {
                            streamWriter.Write($"LicenseKeyValue={enteredLicenseKey}");
                        }
                        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                        {
                            var result = streamReader.ReadToEnd();
                            if (result != null && result.IndexOf("OK", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                            {
                                var parts = result.Split(':');
                                if (parts.Length >= 2)
                                {
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
                                                var activationId = parts[1];
                                                var encryptor = new Encryptor("bf269582-eab7-4f53-9311-12cb834076b0");
                                                var text = $"ActivationId={activationId};LastDate={DateTime.Now}";
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
                                else
                                {
                                    throw new Exception("Error in MSI [5543]");
                                }
                            }
                            else
                            {
                                throw new Exception(result);
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