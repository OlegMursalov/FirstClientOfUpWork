﻿using System.Collections.Generic;

namespace CetbixCVD.Language
{
    public class GermanLanguageSetting : ILanguageSetting
    {
        public Dictionary<string, string> Contents
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { "SendToCetbixRadio", "Senden Sie die Informationen an Ihr Cetbix-Konto" },
                    { "SaveToLocalTxtRadio", "Speichern Sie die Informationen auf Ihrem lokalen PC (* .txt)" },
                    { "Run", "Lauf" },
                    { "LabelCetbix", "Cetbix URI (add_assets.php)" },
                    { "SaveToLocalExcelRadio", "Speichern Sie die Informationen auf Ihrem lokalen PC (* .xlsx)" },
                    { "Run_Click_Start", "Warten Sie mal..." },
                    { "TitleForTrial", "Ihre Testversion ist abgelaufen. \nSie können einen neuen Schlüssel kaufen und eingeben. \nIch brauche eine Internetverbindung, die den neuen Schlüssel überprüft." },
                    { "CheckLicenseKey", "Überprüfen Sie den Lizenzschlüssel" },
                    { "LinkToBuyApp", "Link zum App kaufen" }
                };
            }
        }

        public Dictionary<string, string> Messages
        {
            get
            {
                return new Dictionary<string, string>
                {
                    { "DataSuccessfullySent", "Daten erfolgreich an Cetbix gesendet." },
                    { "DataSuccessfullySaveToTxt", "Daten erfolgreich lokal (* .txt) speichern." },
                    { "DataSuccessfullySaveToExcel", "Daten erfolgreich lokal (* .xlsx) speichern." },
                    { "FillCetbixURI", "Füllen Sie das Cetbix-URI aus (add_assets.php)" },
                    { "NotEnteredLicenseKey", "Sie haben keinen Lizenzschlüssel eingegeben." }
                };
            }
        }
    }
}