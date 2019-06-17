using System;
using System.IO;

namespace Script.Info
{
    public class LapsInfo
    {
        public static string LAPSInstalled { get; set; }

        static LapsInfo()
        {
            try
            {
                if (File.Exists(@"C:\Program Files\LAPS\CSE\AdmPwd.dll") || File.Exists(@"C:\Program Files (x86)\LAPS\CSE\AdmPwd.dll") ||
                    File.Exists(@"C:\Program Files\AdmPwd\CSE\AdmPwd.dll") || File.Exists(@"C:\Program Files (x86)\AdmPwd\CSE\AdmPwd.dll"))
                {
                    LAPSInstalled = "Installed";
                }
                else
                {
                    LAPSInstalled = "Not installed";
                }
            }
            catch (Exception ex)
            {
                LAPSInstalled = "Unknown";
            }
        }
    }
}