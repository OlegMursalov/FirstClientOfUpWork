using LicenseCheckerCustomAction;

namespace CetbixCVD.Language
{
    public static class LanguageSettingFactory
    {
        public static ILanguageSetting GetSettingByLanguage(LanguageEnum language)
        {
            if (language == LanguageEnum.English)
            {
                return new EnglishLanguageSetting();
            }
            else if (language == LanguageEnum.German)
            {
                return new GermanLanguageSetting();
            }
            else if (language == LanguageEnum.French)
            {
                return new FrenchLanguageSetting();
            }
            else
            {
                return null;
            }
        }
    }
}