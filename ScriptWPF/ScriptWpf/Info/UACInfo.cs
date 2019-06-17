using Microsoft.Win32;
using System;
using System.Linq;

namespace Script.Info
{
    public static class UACInfo
    {
        public static string UACActivated { get; set; }

        static UACInfo()
        {
            try
            {
                var uac = Registry.LocalMachine.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Policies\System");
                if (uac != null && uac.GetValueNames().Contains("EnableLUA"))
                {
                    var value = uac.GetValue("EnableLUA");
                    if (value != null)
                    {
                        var i = int.Parse(value.ToString());
                        UACActivated = i == 1 ? "Enabled" : "Disabled";
                    }
                    else
                    {
                        UACActivated = "Unknown";
                    }
                }
                else
                {
                    UACActivated = "Unknown";
                }
            }
            catch (Exception ex)
            {
                UACActivated = "Unknown";
            }
        }
    }
}
