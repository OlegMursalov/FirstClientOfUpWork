using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;

namespace LicenseCheckerCustomAction
{
    [RunInstaller(true)]
    public class CustomInstaller : Installer
    {
        public override void Install(IDictionary stateSaver)
        {
            base.Install(stateSaver);
        }

        public override void Rollback(IDictionary stateSaver)
        {
            base.Rollback(stateSaver);
        }

        protected override void OnBeforeInstall(IDictionary stateSaver)
        {
            if (Context.Parameters.ContainsKey("EnteredLicenseKey"))
            {
                var enteredLicenseKey = Context.Parameters["EnteredLicenseKey"];
                if (!string.IsNullOrEmpty(enteredLicenseKey))
                {
                    if (Context.Parameters.ContainsKey("AssemblyPath"))
                    {
                        var assemblyPath = Context.Parameters["AssemblyPath"];
                        if (!string.IsNullOrEmpty(assemblyPath))
                        {
                            var i = assemblyPath.LastIndexOf("\\");
                            var mainPath = assemblyPath.Substring(0, i);
                            if (Directory.Exists(mainPath))
                            {
                                // Checking license key
                                var exMessage = string.Empty;
                                var checker = new Checker($"{mainPath}\\Cetbix.Activation.dll");
                                var checkFlag = checker.CheckLicenseKeyBeforeInstall(enteredLicenseKey, $"{Common.TestApi}/license-checker.php", out exMessage, () => { base.OnBeforeInstall(stateSaver); });
                                if (!checkFlag && !string.IsNullOrEmpty(exMessage))
                                {
                                    throw new Exception(exMessage);
                                }
                            }
                            else
                            {
                                throw new Exception("Error in MSI [0124]");
                            }
                        }
                        else
                        {
                            throw new Exception("Error in MSI [0723]");
                        }
                    }
                    else
                    {
                        throw new Exception("Error in MSI [0955]");
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
    }
}