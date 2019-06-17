using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Linq;

namespace Script.Info
{
    public static class AdobeInfo
    {
        public static string AdobeAcrobatReaderDC { get; set; }
        public static string AdobeRefrechManager { get; set; }

        static AdobeInfo()
        {
            AdobeAcrobatReaderDC = CheckAdobeAcrobatReaderDC();
            AdobeRefrechManager = CheckAdobeAcrobatUpdateService();
        }

        private static string CheckAdobeAcrobatReaderDC()
        {
            try
            {
                var uninstallSubKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
                foreach (var key in uninstallSubKey.GetSubKeyNames())
                {
                    var item = uninstallSubKey.OpenSubKey(key);
                    if (item != null && item.GetValueNames().Contains("DisplayName") && item.GetValueNames().Contains("DisplayVersion"))
                    {
                        var displayName = item.GetValue("DisplayName").ToString();
                        if (displayName.Contains("Adobe Acrobat Reader DC"))
                        {
                            return item.GetValue("DisplayVersion").ToString();
                        }
                    }
                }
                return "Not installed";
            }
            catch (Exception ex)
            {
                return "Unknown";
            }
        }

        public static string CheckAdobeAcrobatUpdateService()
        {
            try
            {
                var processes = Process.GetProcesses();
                for (int i = 0; i < processes.Length; i++)
                {
                    if (processes[i].ProcessName != null && processes[i].ProcessName.Equals("armsvc", StringComparison.OrdinalIgnoreCase) && processes[i].MainModule != null)
                    {
                        var versionInfo = processes[i].MainModule.FileVersionInfo;
                        if (versionInfo != null)
                        {
                            return versionInfo.FileVersion;
                        }
                    }
                }
                return "Not installed";
            }
            catch (Exception ex)
            {
                return "Unknown";
            }
        }
    }
}