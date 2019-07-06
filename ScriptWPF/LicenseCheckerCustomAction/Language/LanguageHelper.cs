using System.IO;
using System.Text;

namespace LicenseCheckerCustomAction
{
    public class LanguageHelper
    {
        private string languageSettingFilePath;

        public LanguageHelper(string languageSettingFilePath)
        {
            this.languageSettingFilePath = languageSettingFilePath;
        }

        /// <summary>
        /// Create language setting when installation
        /// </summary>
        /// <param name="language">Language enum</param>
        public void CreateSetting(LanguageEnum language)
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

        /// <summary>
        /// Read language setting from file "Cetbix.Language.dll".
        /// If file doesn't exists, return English (default).
        /// </summary>
        /// <returns>Language.</returns>
        public LanguageEnum ReadLanguageFromSetting()
        {
            try
            {
                if (File.Exists(languageSettingFilePath))
                {
                    var text = File.ReadAllText(languageSettingFilePath).Trim();
                    if (!string.IsNullOrEmpty(text))
                    {
                        var encryptor = new Encryptor(Common.GuidForEncryptor);
                        var decryptText = encryptor.Decrypt(text);
                        if (!string.IsNullOrEmpty(decryptText))
                        {
                            var parts = decryptText.Split('=');
                            if (parts.Length >= 2)
                            {
                                var languageVal = parts[1];
                                if (!string.IsNullOrEmpty(languageVal))
                                {
                                    var language = 0;
                                    if (int.TryParse(languageVal, out language))
                                    {
                                        return (LanguageEnum)language;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            finally
            {
            }
            return LanguageEnum.English;
        }
    }
}