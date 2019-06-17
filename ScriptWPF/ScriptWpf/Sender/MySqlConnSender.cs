using MySql.Data.MySqlClient;
using Script.Info;
using System;

namespace Script.Sender
{
    public class MySqlConnSender
    {
        public void SendData(DataOfComputer data)
        {
            try
            {
                string connStr = "server=xvex.de;user=d02eb2b7;database=d02eb2b7;password=kmG6PAbTxMWXKSkn;";
                using (var connection = new MySqlConnection(connStr))
                {
                    // Console.WriteLine("Try to open connection...");
                    // File.AppendAllText("log.txt", "Try to open connection...");
                    connection.Open();
                    // Console.WriteLine("Connection done");
                    // File.AppendAllText("log.txt", "Connection done");
                    // Console.WriteLine("\n");
                    var guid = Guid.NewGuid();
                    var query1 = $"INSERT INTO Domains(`Id`, `Domain`) VALUES ('{guid}', '{data.Domain}')";
                    using (var command1 = new MySqlCommand(query1, connection))
                    {
                        // Console.WriteLine($"query1 = {query1}");
                        // File.AppendAllText("log.txt", $"query1 = {query1}");
                        command1.ExecuteNonQuery();
                        // Console.WriteLine("query1 done");
                        // Console.WriteLine("\n");
                    }
                    var query2 = $"INSERT INTO Hostnames(`Id`, `Hostname`) VALUES('{guid}', '{data.HostName}')";
                    using (var command2 = new MySqlCommand(query2, connection))
                    {
                        // Console.WriteLine($"query2 = {query2}");
                        // File.AppendAllText("log.txt", $"query2 = {query2}");
                        command2.ExecuteNonQuery();
                        // Console.WriteLine($"query2 done");
                        // Console.WriteLine("\n");
                    }
                    var query3 = $"INSERT INTO Scans(`Id`, `DateScan`) VALUES ('{guid}', '{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}')";
                    using (var command3 = new MySqlCommand(query3, connection))
                    {
                        // Console.WriteLine($"query3 = {query3}");
                        // File.AppendAllText("log.txt", $"query3 = {query3}");
                        command3.ExecuteNonQuery();
                        // Console.WriteLine($"query3 done");
                        // Console.WriteLine("\n");
                    }
                    var query4 = "INSERT INTO KeysValues(`Id`, `AccountLockoutDuration`, `CetbixVulnerabilityScannerVersion`, `ComputerRole`, `IP`, `Java`, `LAPS`, `LockoutObservationWindows`, ";
                    query4 += "`LockoutThreshold`, `MaximumPasswordAge`, `MicrosoftKB`, `MinimumPasswordAge`, `MinimumPasswordLength`, `OSCaption`, `OSOrganization`, `OSVersion`, `PasswordHistory`, ";
                    query4 += "`Shares`, `SMBv1`, `SystemUptime`, `Type`, `AntivirusVersion`, `AntivirusName`, `AntivirusRunning`, `FileChromeExe`, `ChromeVersion`, `FileExplorerExe`, `AntivirusInstalled`, ";
                    query4 += "`IEVersion`, `FireFoxExe`, `FireFoxVersion`, `MDP5FireFox`, `MDP5Chrome`, `MDP5InternetExplorer`, `AdobeAcrobatReaderDC`, `AdobeRefrechManager`, `UACActivated`, ";
                    query4 += $"`Autorun`, `FireWallHome`, `FireWallLAN`, `FireWallPublicNetwork`, `AntivirusLatestUpdate`, `ComplianceToolVersion`, `MPPActivated`, `MPPTempExe`) VALUES(";
                    query4 += $"'{guid}', '{data.AccountLockoutDuration}', '{data.CetbixVulnerabilityScannerVersion}', ";
                    query4 += $"'{data.ComputerRole}', '{data.IP}', '{data.Java}', '{data.LAPS}', '{data.LockoutObservationWindows}', '{data.LockoutThreshold}', '{data.MaximumPasswordAge}', ";
                    query4 += $"'{data.MicrosoftKB}', '{data.MinimumPasswordAge}', '{data.MinimumPasswordLength}', '{data.OSCaption}', '{data.OSOrganization}', '{data.OSVersion}', ";
                    query4 += $"'{data.PasswordHistory}', '{data.Shares}', '{data.SMBv1}', '{data.SystemUptime}', '{data.Type}', '{data.AntivirusVersion}', '{data.AntivirusName}', ";
                    query4 += $"'{data.AntivirusRunning}', '{data.FileChromeExe}', '{data.ChromeVersion}', '{data.FileExplorerExe}', '{data.AntivirusInstalled}', '{data.IEVersion}', ";
                    query4 += $"'{data.FireFoxExe}', '{data.FireFoxVersion}', '{data.MDP5FireFox}', '{data.MDP5Chrome}', '{data.MDP5InternetExplorer}', '{data.AdobeAcrobatReaderDC}', ";
                    query4 += $"'{data.AdobeRefrechManager}', '{data.UACActivated}', '{data.Autorun}', '{data.FireWallHome}', '{data.FireWallLAN}', '{data.FireWallPublicNetwork}', ";
                    query4 += $"'{data.AntivirusLatestUpdate}', '{data.ComplianceToolVersion}', '{data.MPPActivated}', '{data.MPPTempExe}')";
                    using (var command4 = new MySqlCommand(query4, connection))
                    {
                        // Console.WriteLine($"query4 = {query4}");
                        // File.AppendAllText("log.txt", $"query4 = {query4}");
                        command4.ExecuteNonQuery();
                        // Console.WriteLine($"query4 done");
                    }
                    connection.Close();
                    // Console.WriteLine("Connection closed");
                }
            }
            catch (Exception ex)
            {
                // Console.WriteLine($"Error when sending to mysql = {ex.Message}");
                // File.AppendAllText("log.txt", ex.Message);
            }
            Console.ReadKey();
        }
    }
}
