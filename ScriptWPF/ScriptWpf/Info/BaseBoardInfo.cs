using Script.Common;
using System;
using System.Diagnostics;

namespace Script.Info
{
    public class BaseBoardInfo
    {
        public static string Product { get; set; }
        public static string Version { get; set; }
        public static string SerialNumber { get; set; }
        public static string Manufacturer { get; set; }

        static BaseBoardInfo()
        {
            var output = string.Empty;
            try
            {
                var baseBoardInfoCMD = new ProcessStartInfo("wmic", "baseboard get product, version, serialnumber, manufacturer /format:table");
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
                        for (int i = 0; i < pair.Key.Length; i++)
                        {
                            var column = pair.Key[i];
                            var value = pair.Value[i];
                            if (column.Equals("Product", StringComparison.OrdinalIgnoreCase))
                            {
                                Product = value;
                            }
                            else if (column.Equals("Version", StringComparison.OrdinalIgnoreCase))
                            {
                                Version = value;
                            }
                            else if (column.Equals("SerialNumber", StringComparison.OrdinalIgnoreCase))
                            {
                                SerialNumber = value;
                            }
                            else if (column.Equals("Manufacturer", StringComparison.OrdinalIgnoreCase))
                            {
                                Manufacturer = value;
                            }
                        }
                    }
                }
            }
        }
    }
}