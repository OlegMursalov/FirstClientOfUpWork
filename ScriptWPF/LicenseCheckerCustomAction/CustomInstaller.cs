using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration.Install;
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
            if (Context.Parameters != null && Context.Parameters.ContainsKey("LicenseKey"))
            {
                string licenseKey = Context.Parameters["LicenseKey"];
                if (!string.IsNullOrEmpty(licenseKey))
                {
                    using (var wb = new WebClient())
                    {
                        var data = new NameValueCollection();
                        data["LicenseKeyValue"] = licenseKey;
                        var response = wb.UploadValues("https://xvex.de/isms/add_ons/cetbix_vulnerability_management/license-checker.php", "POST", data);
                        string message = Encoding.UTF8.GetString(response);
                        if (message == "OK")
                        {
                            base.OnBeforeInstall(savedState);
                        }
                        else
                        {
                            throw new Exception(message);
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
        }
    }
}
