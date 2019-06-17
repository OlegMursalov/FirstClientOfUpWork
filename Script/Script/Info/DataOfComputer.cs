using System.Collections.Generic;

namespace Script.Info
{
    public class DataOfComputer
    {
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
    }
}