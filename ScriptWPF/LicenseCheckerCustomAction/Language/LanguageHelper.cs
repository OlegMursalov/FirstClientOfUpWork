using System.IO;
using System.Text;

namespace LicenseCheckerCustomAction
{
    public enum Language
    {
        English,
        German,
        French
    }

    public class LanguageHelper
    {
        private string languageSettingFilePath;

        public LanguageHelper(string languageSettingFilePath)
        {
            this.languageSettingFilePath = languageSettingFilePath;
        }

        public void CreateSetting(Language language)
        {
            try
            {
                using (var fstream = new FileStream(languageSettingFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    var encryptor = new Encryptor(Common.GuidForEncryptor);
                    var text = $"Language={language}";
                    var encryptText = encryptor.Encrypt(text);
                    var array = Encoding.UTF8.GetBytes(encryptText);
                    fstream.Write(array, 0, array.Length);
                    fstream.Close();
                }
            }
            finally
            {
            }
        }
    }
}