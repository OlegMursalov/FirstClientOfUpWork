using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Net;
using System.Windows;

namespace LicenseCheckerCustomAction
{
    [RunInstaller(true)]
    public class CustomInstaller : Installer
    {
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
            MessageBox.Show("Install");
        }

        protected override void OnBeforeInstall(IDictionary savedState)
        {
            if (Context.Parameters != null && Context.Parameters.ContainsKey("LicenseKey"))
            {
                string licenseKey = Context.Parameters["LicenseKey"];
                if (!string.IsNullOrEmpty(licenseKey))
                {
                    var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://xvex.de/isms/add_ons/cetbix_vulnerability_management/license-checker.php");
                    httpWebRequest.ContentType = "application/json";
                    httpWebRequest.Method = "POST";
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(licenseKey);
                    }
                    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    {
                        var result = streamReader.ReadToEnd();
                        if (result == "OK")
                        {
                            base.OnBeforeInstall(savedState);
                        }
                        else
                        {
                            throw new Exception("This key has already been used.");
                        }
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
            MessageBox.Show("Rollback");
        }
    }
}
