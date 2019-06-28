using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LicenseCheckerCustomAction
{
    public static class Common
    {
        public static string TestApi { get { return "https://xvex.de/isms/add_ons/cetbix_vulnerability_management"; } }
        public static string GuidForEncryptor { get { return "bf269582-eab7-4f53-9311-12cb834076b0"; } }
        public static string URIForBuyApp { get { return "https://xvex.de/isms/test/asset_management/signup_buyapp.php"; } }

        public static string GetUUID()
        {
            try
            {
                var uuidInfoCMD = new ProcessStartInfo("wmic", "csproduct get UUID /format:table");
                uuidInfoCMD.UseShellExecute = false;
                uuidInfoCMD.RedirectStandardOutput = true;
                uuidInfoCMD.CreateNoWindow = true;
                var process = Process.Start(uuidInfoCMD);
                var output = process.StandardOutput.ReadToEnd().Trim();
                if (!string.IsNullOrEmpty(output))
                {
                    var dictionary = GetDataFromCMDOutputWithTableFormat(output);
                    if (dictionary != null)
                    {
                        foreach (var pair in dictionary)
                        {
                            for (int i = 0; i < pair.Key.Length; i++)
                            {
                                var column = pair.Key[i];
                                var value = pair.Value[i];
                                if (column.Equals("UUID", StringComparison.OrdinalIgnoreCase))
                                {
                                    return value;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return string.Empty;
        }

        private static Dictionary<string[], string[]> GetDataFromCMDOutputWithTableFormat(string output)
        {
            string[] header = null;
            var dictionary = new Dictionary<string[], string[]>();
            var lines = output.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                try
                {
                    var parts = lines[i].Trim().Split(new string[] { "  " }, StringSplitOptions.RemoveEmptyEntries);
                    parts = parts.Select(s => s.Trim()).ToArray();
                    if (i == 0)
                    {
                        header = parts;
                    }
                    else
                    {
                        var newHeader = new string[header.Length];
                        Array.Copy(header, newHeader, header.Length);
                        dictionary.Add(newHeader, parts);
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return dictionary;
        }
    }
}