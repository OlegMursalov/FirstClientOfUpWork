<?
if ($_POST && isset($_POST['Id'])) {
	$conn = new mysqli("localhost", "d02eb2b7", "kmG6PAbTxMWXKSkn", "d02eb2b7");
	if (!$conn->connect_error) {
		$query1 = "INSERT INTO Domains(`Id`, `Domain`) VALUES ('" . $_POST['Id'] . "', '" . $_POST['Domain'] . "')";
		$result = $conn->query($query1);
		$query2 = "INSERT INTO Hostnames(`Id`, `Hostname`) VALUES('" . $_POST['Id'] . "', '" . $_POST['Hostname'] . "')";
		$result = $conn->query($query2);
		$query3 = "INSERT INTO Scans(`Id`, `DateScan`) VALUES ('" . $_POST['Id'] . "', '" . $_POST['DateScan'] . "')";
		$result = $conn->query($query3);
		$query4 = "INSERT INTO KeysValues(`Id`, `AccountLockoutDuration`, `CetbixVulnerabilityScannerVersion`, `ComputerRole`, `IP`, `Java`, `LAPS`, `LockoutObservationWindows`, ";
        $query4 .= "`LockoutThreshold`, `MaximumPasswordAge`, `MicrosoftKB`, `MinimumPasswordAge`, `MinimumPasswordLength`, `OSCaption`, `OSOrganization`, `OSVersion`, `PasswordHistory`, ";
        $query4 .= "`Shares`, `SMBv1`, `SystemUptime`, `Type`, `AntivirusVersion`, `AntivirusName`, `AntivirusRunning`, `FileChromeExe`, `ChromeVersion`, `FileExplorerExe`, `AntivirusInstalled`, ";
        $query4 .= "`IEVersion`, `FireFoxExe`, `FireFoxVersion`, `MDP5FireFox`, `MDP5Chrome`, `MDP5InternetExplorer`, `AdobeAcrobatReaderDC`, `AdobeRefrechManager`, `UACActivated`, ";
        $query4 .= "`Autorun`, `FireWallHome`, `FireWallLAN`, `FireWallPublicNetwork`, `AntivirusLatestUpdate`, `ComplianceToolVersion`, `MPPActivated`, `MPPTempExe`) VALUES(";
        $query4 .= "'" . $_POST['Id'] . "', '" . $_POST['AccountLockoutDuration'] . "', '" . $_POST['CetbixVulnerabilityScannerVersion'] . "', ";
        $query4 .= "'" . $_POST['ComputerRole'] . "', '" . $_POST['IP'] . "', '" . $_POST['Java'] . "', '" . $_POST['LAPS'] . "', '" . $_POST['LockoutObservationWindows'] . "', '" . $_POST['LockoutThreshold'] . "', '" . $_POST['MaximumPasswordAge'] . "', ";
        $query4 .= "'" . $_POST['MicrosoftKB'] . "', '" . $_POST['MinimumPasswordAge'] . "', '" . $_POST['MinimumPasswordLength'] . "', '" . $_POST['OSCaption'] . "', '" . $_POST['OSOrganization'] . "', '" . $_POST['OSVersion'] . "', ";
        $query4 .= "'" . $_POST['PasswordHistory'] . "', '" . $_POST['Shares'] . "', '" . $_POST['SMBv1'] . "', '" . $_POST['SystemUptime'] . "', '" . $_POST['Type'] . "', '" . $_POST['AntivirusVersion'] . "', '" . $_POST['AntivirusName'] . "', ";
        $query4 .= "'" . $_POST['AntivirusRunning'] . "', '" . $_POST['FileChromeExe'] . "', '" . $_POST['ChromeVersion'] . "', '" . $_POST['FileExplorerExe'] . "', '" . $_POST['AntivirusInstalled'] . "', '" . $_POST['IEVersion'] . "', ";
        $query4 .= "'" . $_POST['FireFoxExe'] . "', '" . $_POST['FireFoxVersion'] . "', '" . $_POST['MDP5FireFox'] . "', '" . $_POST['MDP5Chrome'] . "', '" . $_POST['MDP5InternetExplorer'] . "', '" . $_POST['AdobeAcrobatReaderDC'] . "', ";
        $query4 .= "'" . $_POST['AdobeRefrechManager'] . "', '" . $_POST['UACActivated'] . "', '" . $_POST['Autorun'] . "', '" . $_POST['FireWallHome'] . "', '" . $_POST['FireWallLAN'] . "', '" . $_POST['FireWallPublicNetwork'] . "', ";
        $query4 .= "'" . $_POST['AntivirusLatestUpdate'] . "', '" . $_POST['ComplianceToolVersion'] . "', '" . $_POST['MPPActivated'] . "', '" . $_POST['MPPTempExe'] . "')";
		$result = $conn->query($query4);
	}
}
?>