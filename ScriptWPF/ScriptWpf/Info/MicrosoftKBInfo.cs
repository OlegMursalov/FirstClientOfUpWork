using System;
using System.Collections.Generic;
using System.Management;

namespace Script.Info
{
    public static class MicrosoftKBInfo
    {
        public static string MicrosoftKB { get; set; }

        static MicrosoftKBInfo()
        {
            try
            {
                var list = new List<long>();
                var searcher = new ManagementObjectSearcher("Select Description, HotFixID from Win32_QuickFixEngineering");
                foreach (var mo in searcher.Get())
                {
                    bool flag = false;
                    var description = string.Empty;
                    long hotFixID = 0;
                    foreach (var prop in mo.Properties)
                    {
                        if (prop.Name.Equals("Description", StringComparison.OrdinalIgnoreCase) && prop.Value != null)
                        {
                            var descriptionVal = prop.Value as string;
                            if (descriptionVal.Equals("Update", StringComparison.OrdinalIgnoreCase) || descriptionVal.Equals("Security Update", StringComparison.OrdinalIgnoreCase))
                            {
                                flag = true;
                            }
                        }
                        if (prop.Name.Equals("HotFixID", StringComparison.OrdinalIgnoreCase) && prop.Value != null && flag)
                        {
                            hotFixID = long.Parse(prop.Value.ToString().Replace("KB", ""));
                            list.Add(hotFixID);
                        }
                    }
                }
                list.Sort();
                MicrosoftKB = string.Join(", ", list/*.Where(e => e > 4000000)*/);
            }
            catch (Exception ex)
            {
                MicrosoftKB = "Unknown";
            }
        }
    }
}