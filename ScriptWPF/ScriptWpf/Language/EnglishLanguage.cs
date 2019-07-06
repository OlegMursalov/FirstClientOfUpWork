using System;
using System.Collections.Generic;

namespace CetbixCVD.Language
{
    public class EnglishLanguageSetting : ILanguageSetting
    {
        public Dictionary<string, string> Setting
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
    }
}