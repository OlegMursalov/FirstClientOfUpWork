using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Script.Common
{
    public static class CommonF
    {
        public static Dictionary<string, string> GetInfoOfFile(string path)
        {
            var dictionary = new Dictionary<string, string>();
            try
            {
                if (!string.IsNullOrEmpty(path))
                {
                    var fileInfo = new FileInfo(path);
                    var info = $"v.{FileVersionInfo.GetVersionInfo(fileInfo.FullName).FileVersion} - size: {fileInfo.Length} bytes - last modified: {fileInfo.LastWriteTime}";
                    dictionary.Add("ShortInfo", info);
                    dictionary.Add("Version", FileVersionInfo.GetVersionInfo(fileInfo.FullName).FileVersion);
                    dictionary.Add("MDP5", GetHash(fileInfo.FullName));
                }
            }
            catch (Exception ex)
            {
            }
            return dictionary;
        }

        public static string GetHash(string fullName)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(fullName))
                {
                    var hash = md5.ComputeHash(stream);
                    var sb = new StringBuilder();
                    for (int i = 0; i < hash.Length; i++)
                    {
                        sb.Append(hash[i].ToString("X2"));
                    }
                    return sb.ToString();
                }
            }
        }

        public static string GetPathOfInstalledSoftware(string nameFile)
        {
            try
            {
                var array = new string[] { @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\App Paths\", @"HKEY_LOCAL_MACHINE\Software\Microsoft\Windows\CurrentVersion\App Paths\" };
                for (int i = 0; i < array.Length; i++)
                {
                    var path = Registry.GetValue(array[i] + nameFile, "", null);
                    if (path != null)
                    {
                        return path.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return string.Empty;
        }

        public static bool? IsProcessRunning(params string[] mayBeNames)
        {
            try
            {
                var processes = Process.GetProcesses();
                for (int i = 0; i < mayBeNames.Length; i++)
                {
                    for (int j = 0; j < processes.Length; j++)
                    {
                        if (processes[j].ProcessName != null && processes[j].ProcessName.Equals(mayBeNames[i], StringComparison.OrdinalIgnoreCase))
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Dictionary<string[], string[]> GetDataFromCMDOutputWithTableFormat(string output)
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

        public static string DisplayBytesForHuman(double bytes)
        {
            try
            {
                var units = new string[] { "B", "KB", "MB", "GB", "TB", "PB" };
                double mod = 1024.0;
                int i = 0;
                while (bytes >= mod)
                {
                    bytes /= mod;
                    i++;
                }
                return Math.Round(bytes, 2) + " " + units[i];
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }

        public static string GetDateScan()
        {
            var nowShort = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}";
            try
            {
                return $"{DateTime.Now.ToString("hh:mm", new CultureInfo("en-US"))} {nowShort}";
            }
            catch (Exception ex)
            {
                return nowShort;
            }
        }
    }
}