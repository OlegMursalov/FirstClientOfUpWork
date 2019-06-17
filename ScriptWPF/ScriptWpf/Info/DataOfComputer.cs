using System.Text;

namespace Script.Info
{
    public class DataOfComputer
    {
        public string Id { get; set; }
        public string DateScan { get; set; }
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

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Id = {Id}");
            sb.AppendLine($"Domain = {Domain}");
            sb.AppendLine($"Hostname = {HostName}");
            sb.AppendLine($"DateScan = {DateScan}");
            sb.AppendLine($"AccountLockoutDuration = {AccountLockoutDuration}");
            sb.AppendLine($"CetbixVulnerabilityScannerVersion = {CetbixVulnerabilityScannerVersion}");
            sb.AppendLine($"ComputerRole = {ComputerRole}");
            sb.AppendLine($"IP = {IP}");
            sb.AppendLine($"Java = {Java}");
            sb.AppendLine($"LAPS = {LAPS}");
            sb.AppendLine($"LockoutObservationWindows = {LockoutObservationWindows}");
            sb.AppendLine($"LockoutThreshold = {LockoutThreshold}");
            sb.AppendLine($"MaximumPasswordAge = {MaximumPasswordAge}");
            sb.AppendLine($"MicrosoftKB = {MicrosoftKB}");
            sb.AppendLine($"MinimumPasswordAge = {MinimumPasswordAge}");
            sb.AppendLine($"MinimumPasswordLength = {MinimumPasswordLength}");
            sb.AppendLine($"OSCaption = {OSCaption}");
            sb.AppendLine($"OSOrganization = {OSOrganization}");
            sb.AppendLine($"OSVersion = {OSVersion}");
            sb.AppendLine($"PasswordHistory = {PasswordHistory}");
            sb.AppendLine($"Shares = {Shares}");
            sb.AppendLine($"SMBv1 = {SMBv1}");
            sb.AppendLine($"SystemUptime = {SystemUptime}");
            sb.AppendLine($"Type = {Type}");
            sb.AppendLine($"AntivirusVersion = {AntivirusVersion}");
            sb.AppendLine($"AntivirusInstalled = {AntivirusInstalled}");
            sb.AppendLine($"AntivirusName = {AntivirusName}");
            sb.AppendLine($"AntivirusRunning = {AntivirusRunning}");
            sb.AppendLine($"FileChromeExe = {FileChromeExe}");
            sb.AppendLine($"ChromeVersion = {ChromeVersion}");
            sb.AppendLine($"FileExplorerExe = {FileExplorerExe}");
            sb.AppendLine($"IEVersion = {IEVersion}");
            sb.AppendLine($"FireFoxExe = {FireFoxExe}");
            sb.AppendLine($"FireFoxVersion = {FireFoxVersion}");
            sb.AppendLine($"MDP5FireFox = {MDP5FireFox}");
            sb.AppendLine($"MDP5Chrome = {MDP5Chrome}");
            sb.AppendLine($"MDP5InternetExplorer = {MDP5InternetExplorer}");
            sb.AppendLine($"AdobeAcrobatReaderDC = {AdobeAcrobatReaderDC}");
            sb.AppendLine($"AdobeRefrechManager = {AdobeRefrechManager}");
            sb.AppendLine($"UACActivated = {UACActivated}");
            sb.AppendLine($"Autorun = {Autorun}");
            sb.AppendLine($"FireWallHome = {FireWallHome}");
            sb.AppendLine($"FireWallLAN = {FireWallLAN}");
            sb.AppendLine($"FireWallPublicNetwork = {FireWallPublicNetwork}");
            sb.AppendLine($"AntivirusLatestUpdate = {AntivirusLatestUpdate}");
            sb.AppendLine($"ComplianceToolVersion = {ComplianceToolVersion}");
            sb.AppendLine($"MPPActivated = {MPPActivated}");
            sb.AppendLine($"MPPTempExe = {MPPTempExe}");
            return sb.ToString();
        }
    }
}