using System.Collections.Generic;

namespace CetbixCVD.Language
{
    public class EnglishLanguageSetting : ILanguageSetting
    {
        public Dictionary<string, string> Contents
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { "SendToCetbixRadio", "Send the Information to Your Cetbix Account" },
                    { "SaveToLocalTxtRadio", "Save the Information on your local PC (*.txt)" },
                    { "Run", "Run" },
                    { "LabelCetbix", "Cetbix URI (add_assets.php)" },
                    { "SaveToLocalExcelRadio", "Save the Information on your local PC (*.xlsx)" },
                    { "Run_Click_Start", "Please, wait..." },
                    { "TitleForTrial", "Your trial is expired. \nYou can buy and enter new key. \nNeed internet connection that checking new key." },
                    { "CheckLicenseKey", "Check license key" },
                    { "LinkToBuyApp", "Link to buy app" }
                };
            }
        }

        public Dictionary<string, string> Messages
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { "DataSuccessfullySent", "Data successfully sent to Cetbix." },
                    { "DataSuccessfullySaveToTxt", "Data successfully save to local (*.txt)." },
                    { "DataSuccessfullySaveToExcel", "Data successfully save to local (*.xlsx)." },
                    { "FillCetbixURI", "Fill Cetbix URI (add_assets.php)" },
                    { "NotEnteredLicenseKey", "You have not entered a license key." },
                    { "NotDone", "Not done." }
                };
            }
        }

        public Dictionary<string, string> Titles
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { "SaveLogFile", "Save log file." }
                };
            }
        }

        public Dictionary<string, string> Strings
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { "Information", "Information" }
                };
            }
        }
    }
}