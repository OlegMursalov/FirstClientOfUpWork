using System;
using System.Management;

namespace Script.Info
{
    public class OSInfo
    {
        public static string OSVersion { get; set; }
        public static string OSOrganization { get; set; }
        public static string OSCaption { get; set; }

        static OSInfo()
        {
            var servicePackMajorVersion = 0;
            try
            {
                var searcher = new ManagementObjectSearcher("Select * from Win32_OperatingSystem");
                foreach (var mo in searcher.Get())
                {
                    foreach (var prop in mo.Properties)
                    {
                        if (prop.Name.Equals("Version", StringComparison.OrdinalIgnoreCase) && prop.Value != null)
                        {
                            OSVersion = prop.Value.ToString();
                        }
                        if (prop.Name.Equals("Organization", StringComparison.OrdinalIgnoreCase) && prop.Value != null)
                        {
                            var value = prop.Value.ToString();
                            if (!string.IsNullOrEmpty(value))
                            {
                                OSOrganization = value;
                            }
                            else
                            {
                                OSOrganization = "None";
                            }
                        }
                        if (prop.Name.Equals("Caption", StringComparison.OrdinalIgnoreCase) && prop.Value != null)
                        {
                            OSCaption = prop.Value.ToString();
                        }
                        if (prop.Name.Equals("ServicePackMajorVersion", StringComparison.OrdinalIgnoreCase) && prop.Value != null)
                        {
                            servicePackMajorVersion = int.Parse(prop.Value.ToString());
                        }
                    }
                }
                if (!string.IsNullOrEmpty(OSCaption))
                {
                    OSCaption += $" SP {servicePackMajorVersion}";
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}