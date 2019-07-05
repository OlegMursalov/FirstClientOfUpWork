using LicenseCheckerCustomAction;
using ScriptWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CetbixCVD
{
    public class MainLanguage : MainWindow
    {
        public Language language;

        public MainLanguage(Language language)
        {
            this.language = language;
        }

        public Dictionary<ContentControl, string> GetLanguageSettings()
        {
            if (language == LicenseCheckerCustomAction.Language.English)
            {
                return EnglishLanguage.GetLanguageSettingsForControls();
            }
        }
    }
}
