using Script.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Script.Info
{
    public class CPU
    {
        public string Name { get; set; }
        public string Producer { get; set; }
    }

    public class CPUInfo
    {
        public static List<CPU> CPUs { get; set; }

        static CPUInfo()
        {
            CPUs = new List<CPU>();
            var output = string.Empty;
            try
            {
                var baseBoardInfoCMD = new ProcessStartInfo("wmic", "cpu get name, manufacturer /format:table");
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
                        var cpu = new CPU();
                        for (int i = 0; i < pair.Key.Length; i++)
                        {
                            var column = pair.Key[i];
                            var value = pair.Value[i];
                            if (column.Equals("Name", StringComparison.OrdinalIgnoreCase))
                            {
                                cpu.Name = value;
                            }
                            if (column.Equals("Manufacturer", StringComparison.OrdinalIgnoreCase))
                            {
                                cpu.Producer = GetProducerName(value);
                            }
                        }
                        CPUs.Add(cpu);
                    }
                }
            }
        }

        public static string GetProducerName(string manufacturer)
        {
            if (manufacturer.IndexOf("AMD", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                return "AMD";
            }
            if (manufacturer.IndexOf("Intel", 0, StringComparison.CurrentCultureIgnoreCase) != -1)
            {
                return "Intel";
            }
            else
            {
                return "Unknown";
            }
        }
    }
}