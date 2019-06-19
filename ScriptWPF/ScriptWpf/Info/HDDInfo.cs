using Script.Common;
using System;
using System.Collections.Generic;
using System.Management;

namespace Script.Info
{
    public class HDD
    {
        public string Caption { get; set; }
        public string MediaType { get; set; }
        public string Size { get; set; }
    }

    public class HDDInfo
    {
        public static List<HDD> HDDs { get; set; }

        static HDDInfo()
        {
            HDDs = new List<HDD>();
            var searcher = new ManagementObjectSearcher("Select Caption, MediaType, Size from Win32_DiskDrive");
            foreach (var mo in searcher.Get())
            {
                var hdd = new HDD();
                foreach (var prop in mo.Properties)
                {
                    if (prop.Name.Equals("Caption", StringComparison.OrdinalIgnoreCase) && prop.Value != null)
                    {
                        hdd.Caption = prop.Value.ToString();
                    }
                    if (prop.Name.Equals("MediaType", StringComparison.OrdinalIgnoreCase) && prop.Value != null)
                    {
                        hdd.MediaType = prop.Value.ToString();
                    }
                    if (prop.Name.Equals("Size", StringComparison.OrdinalIgnoreCase) && prop.Value != null)
                    {
                        var size = Convert.ToUInt64(prop.Value);
                        hdd.Size = CommonF.DisplayBytesForHuman(size);
                    }
                }
                HDDs.Add(hdd);
            }
        }
    }
}