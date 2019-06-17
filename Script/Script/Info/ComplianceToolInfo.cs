using Microsoft.Win32;
using System;
using System.Linq;

namespace Script.Info
{
    public static class ComplianceToolInfo
    {
        public static string ComplianceToolVersion { get; set; }

        static ComplianceToolInfo()
        {
            try
            {
                var uninstallSubKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
                foreach (var key in uninstallSubKey.GetSubKeyNames())
                {
                    var item = uninstallSubKey.OpenSubKey(key);
                    if (item != null && item.GetValueNames().Contains("DisplayName") && item.GetValueNames().Contains("DisplayVersion") &&
                        item.GetValue("DisplayName").ToString().Equals("Microsoft Security Compliance Manager", StringComparison.OrdinalIgnoreCase))
                    {
                        ComplianceToolVersion = item.GetValue("DisplayVersion").ToString();
                        return;
                    }
                }
                ComplianceToolVersion = "Not installed";
            }
            catch (Exception ex)
            {
                ComplianceToolVersion = "Unknown";
            }
        }
    }
}