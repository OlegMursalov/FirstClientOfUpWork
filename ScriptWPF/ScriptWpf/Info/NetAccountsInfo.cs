using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Script.Info
{
    public static class NetAccountsInfo
    {
        public static string MinimumPasswordAge { get; set; }
        public static string MaximumPasswordAge { get; set; }
        public static string MinimumPasswordLength { get; set; }
        public static string ComputerRole { get; set; }
        public static string AccountLockoutDuration { get; set; }
        public static string LockoutObservationWindows { get; set; }
        public static string PasswordHistory { get; set; }
        public static string LockoutThreshold { get; set; }

        static NetAccountsInfo()
        {
            try
            {
                var netAccountsCMD = new ProcessStartInfo("net", "accounts");
                netAccountsCMD.UseShellExecute = false;
                netAccountsCMD.RedirectStandardOutput = true;
                netAccountsCMD.CreateNoWindow = true;
                var process = Process.Start(netAccountsCMD);
                var output = process.StandardOutput.ReadToEnd();
                ParseNetAccountsText(output);
            }
            catch (Exception ex)
            {
            }
        }

        private static void ParseNetAccountsText(string output)
        {
            var dictionary = new Dictionary<string, string>();
            var parts = output.Split('\n');
            for (int i = 0; i < parts.Length; i++)
            {
                var arr = parts[i].Split(':');
                if (arr.Length == 2)
                {
                    if (i == 1)
                    {
                        MinimumPasswordAge = $"{arr[1].Trim()} days";
                    }
                    if (i == 2)
                    {
                        MaximumPasswordAge = $"{arr[1].Trim()} days";
                    }
                    if (i == 3)
                    {
                        MinimumPasswordLength = $"{arr[1].Trim()}";
                    }
                    if (i == 8)
                    {
                        ComputerRole = $"{arr[1].Trim()}";
                    }
                    if (i == 6)
                    {
                        AccountLockoutDuration = $"{arr[1].Trim()} min";
                    }
                    if (i == 7)
                    {
                        LockoutObservationWindows = $"{arr[1].Trim()} min";
                    }
                    if (i == 4)
                    {
                        PasswordHistory = $"{arr[1].Trim()}";
                    }
                    if (i == 5)
                    {
                        LockoutThreshold = $"{arr[1].Trim()}";
                    }
                }
            }
        }
    }
}