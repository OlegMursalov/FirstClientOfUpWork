using System;
using System.Collections.Generic;
using System.Management;

namespace Script.Info
{
    public static class FoldersInfo
    {
        public static string Shares { get; set; }

        static FoldersInfo()
        {
            try
            {
                var list = new List<string>();
                using (var shareObj = new ManagementClass("Win32_Share"))
                {
                    var shares = shareObj.GetInstances();
                    foreach (var share in shares)
                    {
                        list.Add($"To: {share["Name"].ToString()} - {share["Path"].ToString()} - Type: {share["Type"].ToString()}");
                    }
                }
                Shares = string.Join(", ", list);
            }
            catch (Exception ex)
            {
                Shares = "Unknown";
            }
        }
    }
}