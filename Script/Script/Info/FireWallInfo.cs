using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Script.Info
{
    public static class FireWallInfo
    {
        public static string FireWallHome { get; set; }
        public static string FireWallLAN { get; set; }
        public static string FireWallPublicNetwork { get; set; }

        static FireWallInfo()
        {
            try
            {
                var fireWallInfoCMD = new ProcessStartInfo("netsh", "advfirewall show allprofiles state");
                fireWallInfoCMD.UseShellExecute = false;
                fireWallInfoCMD.RedirectStandardOutput = true;
                fireWallInfoCMD.CreateNoWindow = true;
                var process = Process.Start(fireWallInfoCMD);
                var output = process.StandardOutput.ReadToEnd();
                ParseFireWallInfo(output);
            }
            catch (Exception ex)
            {
            }
        }

        public static void ParseFireWallInfo(string output)
        {
            var dictionary = new Dictionary<string, string>();
            var parts = output.Split('\n');
            if (parts[3].IndexOf("ein", 0, StringComparison.CurrentCultureIgnoreCase) != -1 ||
                parts[3].IndexOf("включить", 0, StringComparison.CurrentCultureIgnoreCase) != -1 ||
                parts[3].IndexOf("on", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                FireWallHome = "1";
            }
            else
            {
                FireWallHome = "0";
            }
            if (parts[7].IndexOf("ein", 0, StringComparison.CurrentCultureIgnoreCase) != -1 ||
                parts[7].IndexOf("включить", 0, StringComparison.CurrentCultureIgnoreCase) != -1 ||
                parts[7].IndexOf("on", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                FireWallLAN = "1";
            }
            else
            {
                FireWallLAN = "0";
            }
            if (parts[11].IndexOf("ein", 0, StringComparison.CurrentCultureIgnoreCase) != -1 ||
                parts[11].IndexOf("включить", 0, StringComparison.CurrentCultureIgnoreCase) != -1 ||
                parts[11].IndexOf("on", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                FireWallPublicNetwork = "1";
            }
            else
            {
                FireWallPublicNetwork = "0";
            }
        }
    }
}