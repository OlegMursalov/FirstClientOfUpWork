using Microsoft.Win32;
using System;
using System.Linq;

namespace Script.Info
{
    public static class AutorunInfo
    {
        public static string Autorun { get; set; }

        static AutorunInfo()
        {
            try
            {
                var runRegistry = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer\");
                if (runRegistry != null && runRegistry.GetValueNames().Contains("NoDriveTypeAutoRun"))
                {
                    Autorun = runRegistry.GetValue("NoDriveTypeAutoRun").ToString();
                    return;
                }
                runRegistry = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\Explorer\");
                if (runRegistry != null && runRegistry.GetValueNames().Contains("NoDriveTypeAutoRun"))
                {
                    Autorun = runRegistry.GetValue("NoDriveTypeAutoRun").ToString();
                    return;
                }
                Autorun = "Unknown";
            }
            catch (Exception ex)
            {
                Autorun = "Unknown";
            }
        }
    }
}