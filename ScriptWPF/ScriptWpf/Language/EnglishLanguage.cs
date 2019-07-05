using ScriptWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CetbixCVD
{
    public static class EnglishLanguage
    {
        public static Dictionary<string, string> GetLanguageSettingsForControls()
        {
            return new Dictionary<string, string>
            {
                { "SendToCetbixRadio", "Send the Information to Your Cetbix Account" },
                { "SaveToLocalTxtRadio", "Save the Information on your local PC (*.txt)" },
                { "Run", "Run" },
                { "LabelCetbix", "Cetbix URI (add_assets.php)" },
                { "SaveToLocalExcelRadio", "Save the Information on your local PC (*.xlsx)" }
            };
        }
    }
}