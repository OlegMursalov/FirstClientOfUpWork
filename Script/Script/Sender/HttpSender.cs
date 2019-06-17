using Script.Info;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace Script.Sender
{
    public class HttpSender
    {
        public void SendData(DataOfComputer data)
        {
            var cetbixURI = "https://xvex.de/isms/add_ons/cetbix_vulnerability_management/add_assets.php";
            try
            {
                using (var wb = new WebClient())
                {
                    var guid = Guid.NewGuid();
                    var value = new NameValueCollection();
                    value["Id"] = guid.ToString();
                    value["Domain"] = data.Domain;
                    value["Hostname"] = data.HostName;
                    value["DateScan"] = $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}";
                    value["AccountLockoutDuration"] = data.AccountLockoutDuration;
                    value["CetbixVulnerabilityScannerVersion"] = data.CetbixVulnerabilityScannerVersion;
                    value["ComputerRole"] = data.ComputerRole;
                    value["IP"] = data.IP;
                    value["Java"] = data.Java;
                    value["LAPS"] = data.LAPS;
                    value["LockoutObservationWindows"] = data.LockoutObservationWindows;
                    value["LockoutThreshold"] = data.LockoutThreshold;
                    value["MaximumPasswordAge"] = data.MaximumPasswordAge;
                    value["MicrosoftKB"] = data.MicrosoftKB;
                    value["MinimumPasswordAge"] = data.MinimumPasswordAge;
                    value["MinimumPasswordLength"] = data.MinimumPasswordLength;
                    value["OSCaption"] = data.OSCaption;
                    value["OSOrganization"] = data.OSOrganization;
                    value["OSVersion"] = data.OSVersion;
                    value["PasswordHistory"] = data.PasswordHistory;
                    value["Shares"] = data.Shares;
                    value["SMBv1"] = data.SMBv1;
                    value["SystemUptime"] = data.SystemUptime;
                    value["Type"] = data.Type;
                    value["AntivirusVersion"] = data.AntivirusVersion;
                    value["AntivirusName"] = data.AntivirusName;
                    value["AntivirusRunning"] = data.AntivirusRunning;
                    value["FileChromeExe"] = data.FileChromeExe;
                    value["ChromeVersion"] = data.ChromeVersion;
                    value["FileExplorerExe"] = data.FileExplorerExe;
                    value["AntivirusInstalled"] = data.AntivirusInstalled;
                    value["IEVersion"] = data.IEVersion;
                    value["FireFoxExe"] = data.FireFoxExe;
                    value["FireFoxVersion"] = data.FireFoxVersion;
                    value["MDP5FireFox"] = data.MDP5FireFox;
                    value["MDP5Chrome"] = data.MDP5Chrome;
                    value["MDP5InternetExplorer"] = data.MDP5InternetExplorer;
                    value["AdobeAcrobatReaderDC"] = data.AdobeAcrobatReaderDC;
                    value["AdobeRefrechManager"] = data.AdobeRefrechManager;
                    value["UACActivated"] = data.UACActivated;
                    value["Autorun"] = data.Autorun;
                    value["FireWallHome"] = data.FireWallHome;
                    value["FireWallLAN"] = data.FireWallLAN;
                    value["FireWallPublicNetwork"] = data.FireWallPublicNetwork;
                    value["AntivirusLatestUpdate"] = data.AntivirusLatestUpdate;
                    value["ComplianceToolVersion"] = data.ComplianceToolVersion;
                    value["MPPActivated"] = data.MPPActivated;
                    value["MPPTempExe"] = data.MPPTempExe;

                    value["MotherboardProduct"] = data.MotherboardProduct;
                    value["MotherboardVersion"] = data.MotherboardVersion;
                    value["MotherboardVersion"] = data.MotherboardVersion;

                    var response = wb.UploadValues(cetbixURI, "POST", value);
                    var responseInString = Encoding.UTF8.GetString(response);
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText("log.txt", ex.Message);
            }
        }
    }
}