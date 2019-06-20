using Script.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Script.Info
{
    public class Ram
    {
        public string Capacity { get; set; }
        public string Speed { get; set; }
        public string DeviceLocator { get; set; }
    }

    public class RamInfo
    {
        public static List<Ram> Rams { get; set; }

        static RamInfo()
        {
            Rams = new List<Ram>();
            var output = string.Empty;
            try
            {
                var baseBoardInfoCMD = new ProcessStartInfo("wmic", "memorychip get capacity, speed, deviceLocator /format:table");
                baseBoardInfoCMD.UseShellExecute = false;
                baseBoardInfoCMD.RedirectStandardOutput = true;
                baseBoardInfoCMD.CreateNoWindow = true;
                var process = Process.Start(baseBoardInfoCMD);
                output = process.StandardOutput.ReadToEnd().Trim();
            }
            catch (Exception ex)
            {
            }
            if (!string.IsNullOrEmpty(output))
            {
                var dictionary = CommonF.GetDataFromCMDOutputWithTableFormat(output);
                if (dictionary != null)
                {
                    foreach (var pair in dictionary)
                    {
                        var ram = new Ram();
                        for (int i = 0; i < pair.Key.Length; i++)
                        {
                            var column = pair.Key[i];
                            var value = pair.Value[i];
                            if (column.Equals("Capacity", StringComparison.OrdinalIgnoreCase) && value != null)
                            {
                                ram.Capacity = CommonF.DisplayBytesForHuman(Convert.ToDouble(value));
                            }
                            if (column.Equals("Speed", StringComparison.OrdinalIgnoreCase) && value != null)
                            {
                                ram.Speed = value;
                            }
                            if (column.Equals("DeviceLocator", StringComparison.OrdinalIgnoreCase) && value != null)
                            {
                                ram.DeviceLocator = value;
                            }
                        }
                        Rams.Add(ram);
                    }
                }
            }
        }
    }
}