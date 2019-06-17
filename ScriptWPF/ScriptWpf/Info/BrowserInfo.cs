using Script.Common;

namespace Script.Info
{
    public static class BrowserInfo
    {
        public static string IEShortInfo { get; set; }
        public static string IEVersion { get; set; }
        public static string IE_MDP5 { get; set; }
        public static string ChromeShortInfo { get; set; }
        public static string ChromeVersion { get; set; }
        public static string Chrome_MDP5 { get; set; }
        public static string FireFoxShortInfo { get; set; }
        public static string FireFoxVersion { get; set; }
        public static string FireFox_MDP5 { get; set; }

        static BrowserInfo()
        {
            var pathIE = CommonF.GetPathOfInstalledSoftware("IEXPLORE.exe");
            var ieInfo = CommonF.GetInfoOfFile(pathIE);
            if (ieInfo.ContainsKey("ShortInfo"))
            {
                IEShortInfo = ieInfo["ShortInfo"];
            }
            if (ieInfo.ContainsKey("Version"))
            {
                IEVersion = ieInfo["Version"];
            }
            if (ieInfo.ContainsKey("MDP5"))
            {
                IE_MDP5 = ieInfo["MDP5"];
            }

            var pathChrome = CommonF.GetPathOfInstalledSoftware("chrome.exe");
            var chromeInfo = CommonF.GetInfoOfFile(pathChrome);
            if (chromeInfo.ContainsKey("ShortInfo"))
            {
                ChromeShortInfo = chromeInfo["ShortInfo"];
            }
            if (chromeInfo.ContainsKey("Version"))
            {
                ChromeVersion = chromeInfo["Version"];
            }
            if (chromeInfo.ContainsKey("MDP5"))
            {
                Chrome_MDP5 = chromeInfo["MDP5"];
            }

            var pathFireFox = CommonF.GetPathOfInstalledSoftware("firefox.exe");
            var fireFoxInfo = CommonF.GetInfoOfFile(pathFireFox);
            if (fireFoxInfo.ContainsKey("ShortInfo"))
            {
                FireFoxShortInfo = fireFoxInfo["ShortInfo"];
            }
            if (fireFoxInfo.ContainsKey("Version"))
            {
                FireFoxVersion = fireFoxInfo["Version"];
            }
            if (fireFoxInfo.ContainsKey("MDP5"))
            {
                FireFox_MDP5 = fireFoxInfo["MDP5"];
            }
        }
    }
}