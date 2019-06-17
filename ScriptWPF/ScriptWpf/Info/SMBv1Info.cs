using Microsoft.Win32;
using System;

namespace Script.Info
{
    public static class SMBv1Info
    {
        public static string SMBv1 { get; set; }

        static SMBv1Info()
        {
            try
            {
                var SMBv1ActivationCheck = "Activated";
                var rk = Registry.LocalMachine;
                var SMBv1Registry = rk.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\LanmanServer\Parameters\SMB1");
                if (SMBv1Registry == null)
                {
                    var SMBv1_Policy_mrxsmb10 = rk.OpenSubKey(@"SYSTEM\CurrentControlSet\services\mrxsmb10\Start");
                    var SMBv1_PolicyActivated = rk.OpenSubKey(@"SYSTEM\CurrentControlSet\Services\LanmanWorkstation\DependOnService");
                    if (SMBv1_Policy_mrxsmb10 == null)
                    {
                        SMBv1ActivationCheck = "Deactivated";
                    }
                }
                SMBv1 = SMBv1ActivationCheck;
            }
            catch (Exception ex)
            {
                SMBv1 = "Unknown";
            }
        }
    }
}