using Microsoft.Win32;
using System;
using System.Linq;

namespace Script.Info
{
    public class JavaInfo
    {
        public static string JavaVersion { get; set; }

        static JavaInfo()
        {
            try
            {
                var rk = Registry.LocalMachine;
                var subKey = rk.OpenSubKey("SOFTWARE\\JavaSoft\\Java Runtime Environment");
                if (subKey != null && subKey.GetValueNames().Contains("CurrentVersion"))
                {
                    JavaVersion = subKey.GetValue("CurrentVersion").ToString();
                }
                else
                {
                    JavaVersion = "Not installed";
                }
            }
            catch (Exception ex)
            {
                JavaVersion = "Unknown";
            }
        }
    }
}