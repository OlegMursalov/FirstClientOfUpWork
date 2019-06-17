using Script.Common;

namespace Script.Info
{
    public static class MPPInfo
    {
        public static string MPPActivated { get; set; }
        public static string MPPTempExe { get; set; }

        static MPPInfo()
        {
            MPPTempExe = "0";
            MPPActivated = "0";
            var mppFlag = CommonF.IsProcessRunning("mpp.exe", "mpp");
            if (mppFlag != null)
            {
                MPPActivated = mppFlag.Value ? "1" : "0";
            }
            else
            {
                MPPActivated = "Unknown";
            }
            var tempFlag = CommonF.IsProcessRunning("temp.exe", "temp");
            if (tempFlag != null)
            {
                MPPActivated = mppFlag.Value ? "1" : "0";
                MPPTempExe = mppFlag.Value ? "1" : "0";
            }
            else
            {
                MPPTempExe = "Unknown";
            }
        }
    }
}