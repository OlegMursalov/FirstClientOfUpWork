﻿using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Linq;
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
                        if (result == "OK")
                        {
                            base.OnBeforeInstall(savedState);
                        }
                        else
                        {
                            throw new Exception(result);
                        }
                    }
                }
                else
                {
                    throw new Exception("You have not entered a license key.");
                }
                /*if (Context.Parameters.ContainsKey("FileMSI"))
                {
                    var enteredLicenseKey = Context.Parameters["EnteredLicenseKey"];
                    if (!string.IsNullOrEmpty(enteredLicenseKey))
                    {
                        var fileMsi = Context.Parameters["FileMSI"];
                        var bytes = File.ReadAllBytes(fileMsi);
                        var lastBytes = bytes.Skip(bytes.Length - 30).Take(30).ToArray();
                        var key = Encoding.ASCII.GetString(lastBytes);
                        if (key != enteredLicenseKey)
                        {
                            throw new Exception("Invalid key for this installer.");
                        }
                    }
                    else
                    {
                        throw new Exception("You have not entered a license key.");
                    }
                }
                else
                {
                    throw new Exception("EDITA2 doesn't contain file.");
                }*/
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