using Script.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Script.Info
{
    public class GraphicsCard
    {
        public string Name { get; set; }
        public string InstalledDisplayDrivers { get; set; }
        public string VideoMemoryType { get; set; }
    }

    public class GraphicsCardInfo
    {
        public static List<GraphicsCard> GraphicsCards { get; set; }

        static GraphicsCardInfo()
        {
            GraphicsCards = new List<GraphicsCard>();
            var output = string.Empty;
            try
            {
                var baseBoardInfoCMD = new ProcessStartInfo("wmic", "path win32_VideoController get Name, InstalledDisplayDrivers, VideoMemoryType /format:table");
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
                        if (pair.Key != null && pair.Value != null && pair.Key.Length > 0 && pair.Value.Length > 0)
                        {
                            try
                            {
                                var graphicsCard = new GraphicsCard();
                                for (int i = 0; i < pair.Key.Length; i++)
                                {
                                    var column = pair.Key[i];
                                    var value = pair.Value[i];
                                    if (column != null)
                                    {
                                        if (column.Equals("Name", StringComparison.OrdinalIgnoreCase) && value != null)
                                        {
                                            graphicsCard.Name = value;
                                        }
                                        if (column.Equals("InstalledDisplayDrivers", StringComparison.OrdinalIgnoreCase) && value != null)
                                        {
                                            graphicsCard.InstalledDisplayDrivers = value;
                                        }
                                        if (column.Equals("VideoMemoryType", StringComparison.OrdinalIgnoreCase) && value != null)
                                        {
                                            var memoryTypeVal = 2; // Unknown
                                            if (int.TryParse(value, out memoryTypeVal))
                                            {
                                                graphicsCard.VideoMemoryType = GetVideoMemoryTypeText(memoryTypeVal);
                                            }
                                            else
                                            {
                                                graphicsCard.VideoMemoryType = GetVideoMemoryTypeText(memoryTypeVal);
                                            }
                                        }
                                    }
                                }
                                GraphicsCards.Add(graphicsCard);
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                }
            }
        }

        private static string GetVideoMemoryTypeText(int videoMemoryTypeVal)
        {
            switch (videoMemoryTypeVal)
            {
                case 1:
                    return "Other";
                case 2:
                    return "Unknown";
                case 3:
                    return "VRAM";
                case 4:
                    return "DRAM";
                case 5:
                    return "SRAM";
                case 6:
                    return "WRAM";
                case 7:
                    return "EDO RAM";
                case 8:
                    return "Burst Synchronous DRAM";
                case 9:
                    return "Pipelined Burst SRAM";
                case 10:
                    return "CDRAM";
                case 11:
                    return "3DRAM";
                case 12:
                    return "SDRAM";
                case 13:
                    return "SGRAM";
                default:
                    return string.Empty;
            }
        }
    }
}