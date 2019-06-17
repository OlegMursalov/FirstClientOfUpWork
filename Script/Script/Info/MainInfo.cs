using System;
using System.Diagnostics;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Security.Principal;

namespace Script.Info
{
    public static class MainInfo
    {
        public static string SystemUptime { get; set; }
        public static string HostName { get; set; }
        public static string Domain { get; set; }
        public static string Type { get; set; }
        public static string IP { get; set; }

        static MainInfo()
        {
            var sUpt = GetSystemUpTyme();
            SystemUptime = $"{sUpt.Days}:{sUpt.Hours}:{sUpt.Minutes}:{sUpt.Seconds}";
            HostName = GetHostName();
            Domain = GetDomain();
            Type = GetType();
            IP = GetIPAddress();
        }
        
        private static string GetHostName()
        {
            return System.Net.Dns.GetHostName();
        }

        private static TimeSpan GetSystemUpTyme()
        {
            try
            {
                using (var uptime = new PerformanceCounter("System", "System Up Time"))
                {
                    uptime.NextValue();
                    return TimeSpan.FromSeconds(uptime.NextValue());
                }
            }
            catch (Exception ex)
            {
                return default(TimeSpan);
            }
        }

        private static string GetDomain()
        {
            try
            {
                var wi = WindowsIdentity.GetCurrent();
                if (wi != null)
                {
                    return wi.Name;
                }
            }
            catch (Exception ex)
            {
                return "Unknown";
            }
            return string.Empty;
        }

        private static new string GetType()
        {
            try
            {
                
                var searcher = new ManagementObjectSearcher("root\\cimv2", "Select DomainRole from Win32_ComputerSystem");
                foreach (var mo in searcher.Get())
                {
                    foreach (var prop in mo.Properties)
                    {
                        if (prop.Name.Equals("DomainRole", StringComparison.OrdinalIgnoreCase) && prop.Value != null)
                        {
                            switch (int.Parse(prop.Value.ToString()))
                            {
                                case 0:
                                    return "Standalone Workstation";
                                case 1:
                                    return "Member Workstation";
                                case 2:
                                    return "Standalone Server";
                                case 3:
                                    return "Member Server";
                                case 4:
                                    return "Backup Domain Controller";
                                case 5:
                                    return "Primary Domain Controller";
                                default:
                                    return string.Empty;
                            }
                        }
                    }
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        private static string GetIPAddress()
        {
            try
            {
                var localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress addr in localIPs)
                {
                    if (addr.AddressFamily == AddressFamily.InterNetwork)
                    {
                        return addr.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return string.Empty;
        }
    }
}