using CetbixCVD.Language;
using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace LicenseCheckerCustomAction
{
    [RunInstaller(true)]
    public class CustomInstaller : Installer
    {
        /// <summary>
        /// NEED CHANGE LANGUAGE FOR DIFFERENT MSI!
        /// </summary>
        public static LanguageEnum Language
        {
            get
            {
                return LanguageEnum.English;
            }
        }

        public static MainLanguage MainLanguage
        {
            get
            {
                return new MainLanguage(Language);
            }
        }

        public override void Install(IDictionary stateSaver)
        {
            Debugger.Launch();
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
                                var checker = new Checker($"{mainPath}\\{Common.ActivationFileName}", MainLanguage);
                                var checkFlag = checker.CheckLicenseKeyBeforeInstall(enteredLicenseKey, $"{Common.ApiCetbixUri}/{Common.LicenseChecker}", out exMessage, () =>
                                {
                                    // Creating language setting
                                    var languageHelper = new LanguageHelper($"{mainPath}\\{Common.LanguageFileName}");
                                    languageHelper.CreateSetting(Language);
                                    // OnBeforeInstall
                                    base.OnBeforeInstall(stateSaver);
                                });
                                if (!checkFlag && !string.IsNullOrEmpty(exMessage))
                                {
                                    var message = MainLanguage.GetMessageByKey(exMessage);
                                    if (!string.IsNullOrEmpty(message))
                                    {
                                        throw new Exception(message);
                                    }
                                    else
                                    {
                                        throw new Exception($"Error in MSI [{exMessage}].");
                                    }
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
                    throw new Exception(MainLanguage.GetMessageByKey("NotEnteredLicenseKey"));
                }
            }
            else
            {
                throw new Exception(MainLanguage.GetMessageByKey("NotEnteredLicenseKey"));
            }
        }
        

        public override void Uninstall(IDictionary stateSaver)
        {
            try
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
                            // Delete activation file (.dll)
                            var activationFileName = $"{mainPath}\\{Common.ActivationFileName}";
                            if (File.Exists(activationFileName))
                            {
                                File.Delete(activationFileName);
                            }
                            // Delete language file (.dll)
                            var languageFileName = $"{mainPath}\\{Common.LanguageFileName}";
                            if (File.Exists(languageFileName))
                            {
                                File.Delete(languageFileName);
                            }
                            // Delete tmp files (.tmp)
                            var directoryInfo = new DirectoryInfo(mainPath);
                            var filesTmp = directoryInfo.GetFiles("*.tmp").ToArray();
                            for (var j = 0; j < filesTmp.Length; j++)
                            {
                                File.Delete(filesTmp[j].FullName);
                            }
                        }
                    }
                }
            }
            finally
            {
            }
            base.Uninstall(stateSaver);
        }
    }
}