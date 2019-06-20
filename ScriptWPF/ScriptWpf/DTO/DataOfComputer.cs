using System.Collections.Generic;
using System.Text;
using System.Linq;
using System;

namespace Script.Info
{
    public class DataOfComputer
    {
        public string Id { get; set; }
        public string SystemUptime { get; set; }
        public string HostName { get; set; }
        public string Domain { get; set; }
        public string Type { get; set; }
        public string IP { get; set; }
        public string OSVersion { get; set; }
        public string OSOrganization { get; set; }
        public string OSCaption { get; set; }
        public string AccountLockoutDuration { get; set; }
        public string CetbixVulnerabilityScannerVersion { get; set; }
        public string DateScan { get; set; }
        public string ComputerRole { get; set; }
        public string Java { get; set; }
        public string LAPS { get; set; }
        public string LockoutObservationWindows { get; set; }
        public string LockoutThreshold { get; set; }
        public string MaximumPasswordAge { get; set; }
        public string MicrosoftKB { get; set; }
        public string MinimumPasswordAge { get; set; }
        public string MinimumPasswordLength { get; set; }
        public string PasswordHistory { get; set; }
        public string Shares { get; set; }
        public string SMBv1 { get; set; }
        public string AntivirusInstalled { get; set; }
        public string AntivirusName { get; set; }
        public string AntivirusVersion { get; set; }
        public string AntivirusProtection { get; set; }
        public string AntivirusRunning { get; set; }
        public string FileChromeExe { get; set; }
        public string ChromeVersion { get; set; }
        public string MDP5Chrome { get; set; }
        public string FileExplorerExe { get; set; }
        public string IEVersion { get; set; }
        public string MDP5InternetExplorer { get; set; }
        public string FireFoxExe { get; set; }
        public string FireFoxVersion { get; set; }
        public string MDP5FireFox { get; set; }
        public string AdobeAcrobatReaderDC { get; set; }
        public string AdobeRefrechManager { get; set; }
        public string UACActivated { get; set; }
        public string Autorun { get; set; }
        public string FireWallHome { get; set; }
        public string FireWallLAN { get; set; }
        public string FireWallPublicNetwork { get; set; }
        public string AntivirusLatestUpdate { get; set; }
        public string ComplianceToolVersion { get; set; }
        public string MPPActivated { get; set; }
        public string MPPTempExe { get; set; }
        public string MotherboardProduct { get; set; }
        public string MotherboardVersion { get; set; }
        public string MotherboardSerialNumber { get; set; }
        public string MotherboardManufacturer { get; set; }
        public List<Ram> Rams { get; set; }
        public List<GraphicsCard> GraphicsCards { get; set; }
        public List<CPU> CPUs { get; set; }
        public List<SoundCard> SoundCards { get; set; }
        public List<HDD> HDDs { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var type = typeof(DataOfComputer);
            foreach (var prop in type.GetProperties())
            {
                try
                {
                    if (prop.PropertyType == typeof(string))
                    {
                        sb.AppendLine($"{prop.Name} = {prop.GetValue(this, null)}");
                    }
                    else if (prop.PropertyType.GetInterfaces().Where(i => i.GetGenericTypeDefinition() == typeof(IList<>)).FirstOrDefault() != null)
                    {
                        var value = prop.GetValue(this, null);
                        var rams = value as List<Ram>;
                        if (rams != null)
                        {
                            sb.AppendLine($"AmountOfRam = {rams.Count}");
                            sb.AppendLine($"RamCapacity = {string.Join("; ", rams.Select(e => e.Capacity))}");
                            sb.AppendLine($"RamSpeed = {string.Join("; ", rams.Select(e => e.Speed))}");
                            sb.AppendLine($"RamDeviceLocator = {string.Join("; ", rams.Select(e => e.DeviceLocator))}");
                            continue;
                        }
                        var graphicsCards = value as List<GraphicsCard>;
                        if (graphicsCards != null)
                        {
                            sb.AppendLine($"AmountOfGraphicsCard = {graphicsCards.Count}");
                            sb.AppendLine($"GraphicsCardName = {string.Join("; ", graphicsCards.Select(e => e.Name))}");
                            sb.AppendLine($"GraphicsCardInstalledDisplayDrivers = {string.Join("; ", graphicsCards.Select(e => e.InstalledDisplayDrivers))}");
                            sb.AppendLine($"GraphicsCardVideoMemoryType = {string.Join("; ", graphicsCards.Select(e => e.VideoMemoryType))}");
                            continue;
                        }
                        var cpus = value as List<CPU>;
                        if (cpus != null)
                        {
                            sb.AppendLine($"AmountOfCPU = {cpus.Count}");
                            sb.AppendLine($"CPUName = {string.Join("; ", cpus.Select(e => e.Name))}");
                            sb.AppendLine($"CPUProducer = {string.Join("; ", cpus.Select(e => e.Producer))}");
                            continue;
                        }
                        var soundCards = value as List<SoundCard>;
                        if (soundCards != null)
                        {
                            sb.AppendLine($"AmountOfSoundCard = {soundCards.Count}");
                            sb.AppendLine($"SoundCardCaption = {string.Join("; ", soundCards.Select(e => e.Caption))}");
                            sb.AppendLine($"SoundCardManufacturer = {string.Join("; ", soundCards.Select(e => e.Manufacturer))}");
                            sb.AppendLine($"SoundCardStatusInfo = {string.Join("; ", soundCards.Select(e => e.StatusInfo))}");
                            continue;
                        }
                        var hdds = value as List<HDD>;
                        if (hdds != null)
                        {
                            sb.AppendLine($"AmountOfHDD = {hdds.Count}");
                            sb.AppendLine($"HDDCaption = {string.Join("; ", hdds.Select(e => e.Caption))}");
                            sb.AppendLine($"HDDMediaType = {string.Join("; ", hdds.Select(e => e.MediaType))}");
                            sb.AppendLine($"HDDSize = {string.Join("; ", hdds.Select(e => e.Size))}");
                            continue;
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return sb.ToString();
        }
    }
}