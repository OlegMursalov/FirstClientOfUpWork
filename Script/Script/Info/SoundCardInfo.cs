using System;
using System.Collections.Generic;
using System.Management;

namespace Script.Info
{
    public class SoundCard
    {
        public string Caption { get; set; }
        public string Manufacturer { get; set; }
        public string StatusInfo { get; set; }
    }

    public class SoundCardInfo
    {
        public static List<SoundCard> SoundCards { get; set; }

        static SoundCardInfo()
        {
            SoundCards = new List<SoundCard>();
            var searcher = new ManagementObjectSearcher("Select Caption, Manufacturer, StatusInfo from Win32_SoundDevice");
            foreach (var mo in searcher.Get())
            {
                var soundCard = new SoundCard();
                foreach (var prop in mo.Properties)
                {
                    if (prop.Name.Equals("Caption", StringComparison.OrdinalIgnoreCase) && prop.Value != null)
                    {
                        soundCard.Caption = prop.Value as string;
                    }
                    if (prop.Name.Equals("Manufacturer", StringComparison.OrdinalIgnoreCase) && prop.Value != null)
                    {
                        soundCard.Manufacturer = prop.Value as string;
                    }
                    if (prop.Name.Equals("StatusInfo", StringComparison.OrdinalIgnoreCase) && prop.Value != null)
                    {
                        var value = int.Parse(prop.Value.ToString());
                        soundCard.StatusInfo = GetStatus(value);
                    }
                }
                SoundCards.Add(soundCard);
            }
        }

        public static string GetStatus(int value)
        {
            switch (value)
            {
                case 1:
                    return "Other";
                case 2:
                    return "Unknown";
                case 3:
                    return "Enabled";
                case 4:
                    return "Disabled";
                case 5:
                    return "Not Applicable";
                default:
                    return string.Empty;
            }
        }
    }
}