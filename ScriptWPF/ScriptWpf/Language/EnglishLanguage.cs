﻿using System;
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
                    { "Run_Click_Start", "Please, wait..." }
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
                    { "FillCetbixURI", "Fill Cetbix URI (add_assets.php)" }
                };
            }
        }
    }
}