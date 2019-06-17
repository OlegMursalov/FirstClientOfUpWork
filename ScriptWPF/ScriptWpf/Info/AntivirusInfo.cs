using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using Script.Common;

namespace Script.Info
{
    public static class AntivirusInfo
    {
        public static string AntivirusRunning { get; set; }
        public static string AntivirusName { get; set; }
        public static string AntivirusVersion { get; set; }
        public static string AntivirusLatestUpdate { get; set; }
        public static string AntivirusInstalled { get; set; }

        /// <summary>
        /// Get only first antivirus
        /// </summary>
        static AntivirusInfo()
        {
            try
            {
                AntivirusInstalled = "Not installed";
                var dictionary = new Dictionary<string, string>();
                var wmiData = new ManagementObjectSearcher(@"root\SecurityCenter2", "SELECT * FROM AntiVirusProduct");
                foreach (var virusChecker in wmiData.Get())
                {
                    AntivirusInstalled = "Installed";
                    AntivirusName = virusChecker["displayName"].ToString();
                    switch (virusChecker["productState"].ToString())
                    {
                        case "262144":
                            AntivirusRunning = "Disabled";
                            break;
                        case "266240":
                            AntivirusRunning = "Enabled";
                            break;
                        case "262160":
                            AntivirusRunning = "Disabled";
                            break;
                        case "266256":
                            AntivirusRunning = "Enabled";
                            break;
                        case "393216":
                            AntivirusRunning = "Disabled";
                            break;
                        case "393232":
                            AntivirusRunning = "Disabled";
                            break;
                        case "393488":
                            AntivirusRunning = "Disabled";
                            break;
                        case "397312":
                            AntivirusRunning = "Enabled";
                            break;
                        case "397328":
                            AntivirusRunning = "Enabled";
                            break;
                        // Windows Defender
                        case "393472":
                            AntivirusRunning = "Disabled";
                            break;
                        case "397584":
                            AntivirusRunning = "Enabled";
                            break;
                        case "397568":
                            AntivirusRunning = "Enabled";
                            break;
                    }
                    var pathToExe = virusChecker["pathToSignedReportingExe"].ToString();
                    var antivirusInfo = CommonF.GetInfoOfFile(pathToExe);
                    if (antivirusInfo.ContainsKey("Version"))
                    {
                        AntivirusVersion = antivirusInfo["Version"];
                    }
                    AntivirusLatestUpdate = File.GetLastWriteTime(pathToExe).ToString();
                    return;
                }
            }
            catch (Exception ex)
            {
                AntivirusInstalled = "Not installed";
            }
        }
    }
}