using System;
using MySql.Data.MySqlClient;
using Script.Info;
using System.IO;
using Script.Sender;
using Script.Common;

namespace Script
{
    class Program
    {
        static void Main()
        {
            var uriCetbixApi = "https://xvex.de/isms/add_ons/cetbix_vulnerability_management/add_assets.php";

            var dataOfComputer = new DataOfComputer();

            dataOfComputer.Id = Guid.NewGuid().ToString();
            dataOfComputer.CetbixVulnerabilityScannerVersion = "2.7.00.1";
            dataOfComputer.DateScan = CommonF.GetDateScan();

            dataOfComputer.SystemUptime = MainInfo.SystemUptime;
            dataOfComputer.HostName = MainInfo.HostName;
            dataOfComputer.Domain = MainInfo.Domain;
            dataOfComputer.Type = MainInfo.Type;
            dataOfComputer.IP = MainInfo.IP;

            dataOfComputer.OSVersion = OSInfo.OSVersion;
            dataOfComputer.OSOrganization = OSInfo.OSOrganization;
            dataOfComputer.OSCaption = OSInfo.OSCaption;

            dataOfComputer.Java = JavaInfo.JavaVersion;

            dataOfComputer.LAPS = LapsInfo.LAPSInstalled;

            dataOfComputer.AntivirusInstalled = AntivirusInfo.AntivirusInstalled;
            dataOfComputer.AntivirusName = AntivirusInfo.AntivirusName;
            dataOfComputer.AntivirusRunning = AntivirusInfo.AntivirusRunning;
            dataOfComputer.AntivirusVersion = AntivirusInfo.AntivirusVersion;
            dataOfComputer.AntivirusLatestUpdate = AntivirusInfo.AntivirusLatestUpdate;

            dataOfComputer.MicrosoftKB = MicrosoftKBInfo.MicrosoftKB;

            dataOfComputer.Shares = FoldersInfo.Shares;

            dataOfComputer.FileExplorerExe = BrowserInfo.IEShortInfo;
            dataOfComputer.IEVersion = BrowserInfo.IEVersion;
            dataOfComputer.MDP5InternetExplorer = BrowserInfo.IE_MDP5;
            dataOfComputer.FileChromeExe = BrowserInfo.ChromeShortInfo;
            dataOfComputer.ChromeVersion = BrowserInfo.ChromeVersion;
            dataOfComputer.MDP5Chrome = BrowserInfo.Chrome_MDP5;
            dataOfComputer.FireFoxExe = BrowserInfo.FireFoxShortInfo;
            dataOfComputer.FireFoxVersion = BrowserInfo.FireFoxVersion;
            dataOfComputer.MDP5FireFox = BrowserInfo.FireFox_MDP5;

            dataOfComputer.SMBv1 = SMBv1Info.SMBv1;

            dataOfComputer.MinimumPasswordAge = NetAccountsInfo.MinimumPasswordAge;
            dataOfComputer.MaximumPasswordAge = NetAccountsInfo.MaximumPasswordAge;
            dataOfComputer.MinimumPasswordLength = NetAccountsInfo.MinimumPasswordLength;
            dataOfComputer.ComputerRole = NetAccountsInfo.ComputerRole;
            dataOfComputer.AccountLockoutDuration = NetAccountsInfo.AccountLockoutDuration;
            dataOfComputer.LockoutObservationWindows = NetAccountsInfo.LockoutObservationWindows;
            dataOfComputer.PasswordHistory = NetAccountsInfo.PasswordHistory;
            dataOfComputer.LockoutThreshold = NetAccountsInfo.LockoutThreshold;

            dataOfComputer.AdobeAcrobatReaderDC = AdobeInfo.AdobeAcrobatReaderDC;
            dataOfComputer.AdobeRefrechManager = AdobeInfo.AdobeRefrechManager;

            dataOfComputer.UACActivated = UACInfo.UACActivated;

            dataOfComputer.Autorun = AutorunInfo.Autorun;

            dataOfComputer.FireWallHome = FireWallInfo.FireWallHome;
            dataOfComputer.FireWallLAN = FireWallInfo.FireWallLAN;
            dataOfComputer.FireWallPublicNetwork = FireWallInfo.FireWallPublicNetwork;

            dataOfComputer.ComplianceToolVersion = ComplianceToolInfo.ComplianceToolVersion;

            dataOfComputer.MPPActivated = MPPInfo.MPPActivated;
            dataOfComputer.MPPTempExe = MPPInfo.MPPTempExe;

            dataOfComputer.MotherboardProduct = BaseBoardInfo.Product;
            dataOfComputer.MotherboardVersion = BaseBoardInfo.Version;
            dataOfComputer.MotherboardSerialNumber = BaseBoardInfo.SerialNumber;
            dataOfComputer.MotherboardManufacturer = BaseBoardInfo.Manufacturer;

            dataOfComputer.Rams = RamInfo.Rams;

            dataOfComputer.GraphicsCards = GraphicsCardInfo.GraphicsCards;

            dataOfComputer.CPUs = CPUInfo.CPUs;

            dataOfComputer.SoundCards = SoundCardInfo.SoundCards;

            dataOfComputer.HDDs = HDDInfo.HDDs;

            var sender = new HttpJsonSender(uriCetbixApi);
            sender.SendData(dataOfComputer);
        }
    }
}