<?
$contents = file_get_contents('php://input');
if ($contents != null) {
	$data = json_decode($contents, true);
	if ($data != null) {
		$conn = new mysqli('localhost', 'd02f240b', 'BvLnSTHEzyBxRo38', 'd02f240b');
		if (!$conn->connect_error) {
			$query1 = "INSERT INTO Domains(`Id`, `Domain`) VALUES ('" . $data['Id'] . "', '" . $data['Domain'] . "')";
			$result = $conn->query($query1);
			
			$query2 = "INSERT INTO Hostnames(`Id`, `Hostname`) VALUES('" . $data['Id'] . "', '" . $data['HostName'] . "')";
			$result = $conn->query($query2);
		
			$query3 = "INSERT INTO Scans(`Id`, `DateScan`) VALUES ('" . $data['Id'] . "', '" . $data['DateScan'] . "')";
			$result = $conn->query($query3);
			
			$query4 = "INSERT INTO KeysValues(`Id`, `AccountLockoutDuration`, `CetbixVulnerabilityScannerVersion`, `ComputerRole`, `IP`, `Java`, `LAPS`, `LockoutObservationWindows`, ";
			$query4 .= "`LockoutThreshold`, `MaximumPasswordAge`, `MicrosoftKB`, `MinimumPasswordAge`, `MinimumPasswordLength`, `OSCaption`, `OSOrganization`, `OSVersion`, `PasswordHistory`, ";
			$query4 .= "`Shares`, `SMBv1`, `SystemUptime`, `Type`, `AntivirusVersion`, `AntivirusName`, `AntivirusRunning`, `FileChromeExe`, `ChromeVersion`, `FileExplorerExe`, `AntivirusInstalled`, ";
			$query4 .= "`IEVersion`, `FireFoxExe`, `FireFoxVersion`, `MDP5FireFox`, `MDP5Chrome`, `MDP5InternetExplorer`, `AdobeAcrobatReaderDC`, `AdobeRefrechManager`, `UACActivated`, ";
			$query4 .= "`Autorun`, `FireWallHome`, `FireWallLAN`, `FireWallPublicNetwork`, `AntivirusLatestUpdate`, `ComplianceToolVersion`, `MPPActivated`, `MPPTempExe`, ";
			$query4 .= "`MotherboardProduct`, `MotherboardVersion`, `MotherboardSerialNumber`, `MotherboardManufacturer`, `AmountOfRam`, `RamCapacity`, `RamSpeed`, ";
			$query4 .= "`RamDeviceLocator`, `AmountOfGraphicsCard`, `GraphicsCardName`, `GraphicsCardInstalledDisplayDrivers`, `GraphicsCardVideoMemoryType`, `AmountOfCPU`, ";
			$query4 .= "`CPUName`, `CPUProducer`, `AmountOfSoundCard`, `SoundCardCaption`, `SoundCardManufacturer`, `SoundCardStatusInfo`, ";
			$query4 .= "`AmountOfHDD`, `HDDCaption`, `HDDMediaType`, `HDDSize`) VALUES(";
			$query4 .= "'" . $data['Id'] . "', '" . $data['AccountLockoutDuration'] . "', '" . $data['CetbixVulnerabilityScannerVersion'] . "', ";
			$query4 .= "'" . $data['ComputerRole'] . "', '" . $data['IP'] . "', '" . $data['Java'] . "', '" . $data['LAPS'] . "', '" . $data['LockoutObservationWindows'] . "', '" . $data['LockoutThreshold'] . "', '" . $data['MaximumPasswordAge'] . "', ";
			$query4 .= "'" . $data['MicrosoftKB'] . "', '" . $data['MinimumPasswordAge'] . "', '" . $data['MinimumPasswordLength'] . "', '" . $data['OSCaption'] . "', '" . $data['OSOrganization'] . "', '" . $data['OSVersion'] . "', ";
			$query4 .= "'" . $data['PasswordHistory'] . "', '" . $data['Shares'] . "', '" . $data['SMBv1'] . "', '" . $data['SystemUptime'] . "', '" . $data['Type'] . "', '" . $data['AntivirusVersion'] . "', '" . $data['AntivirusName'] . "', ";
			$query4 .= "'" . $data['AntivirusRunning'] . "', '" . $data['FileChromeExe'] . "', '" . $data['ChromeVersion'] . "', '" . $data['FileExplorerExe'] . "', '" . $data['AntivirusInstalled'] . "', '" . $data['IEVersion'] . "', ";
			$query4 .= "'" . $data['FireFoxExe'] . "', '" . $data['FireFoxVersion'] . "', '" . $data['MDP5FireFox'] . "', '" . $data['MDP5Chrome'] . "', '" . $data['MDP5InternetExplorer'] . "', '" . $data['AdobeAcrobatReaderDC'] . "', ";
			$query4 .= "'" . $data['AdobeRefrechManager'] . "', '" . $data['UACActivated'] . "', '" . $data['Autorun'] . "', '" . $data['FireWallHome'] . "', '" . $data['FireWallLAN'] . "', '" . $data['FireWallPublicNetwork'] . "', ";
			$query4 .= "'" . $data['AntivirusLatestUpdate'] . "', '" . $data['ComplianceToolVersion'] . "', '" . $data['MPPActivated'] . "', '" . $data['MPPTempExe'] . "', ";
			$query4 .= "'" . $data['MotherboardProduct'] . "', '" . $data['MotherboardVersion'] . "', '" . $data['MotherboardSerialNumber'] . "', '" . $data['MotherboardManufacturer'] . "', ";
			if ($data['Rams'] != null) {
				$amountOfRam = sizeof($data['Rams']);
				$ramCapacity = "";
				$ramSpeed = "";
				$ramDeviceLocator = "";
				if ($amountOfRam > 0) {
					for ($i = 0; $i < $amountOfRam; $i++) {
						$ramCapacity .= $data['Rams'][$i]['Capacity'] . "; ";
						$ramSpeed .= $data['Rams'][$i]['Speed'] . "; ";
						$ramDeviceLocator .= $data['Rams'][$i]['DeviceLocator'] . "; ";
					}
					$query4 .= "'" . $amountOfRam . "', '" . substr($ramCapacity, 0, -2) . "', '" . substr($ramSpeed, 0, -2) . "', '" . substr($ramDeviceLocator, 0, -2) . "', ";
				} else {
					$query4 .= "'" . $amountOfRam . "', '', '', '', ";
				}
			}
			if ($data['GraphicsCards'] != null) {
				$amountOfGraphicsCard = sizeof($data['GraphicsCards']);
				$graphicsCardName = "";
				$graphicsCardInstalledDisplayDrivers = "";
				$graphicsCardVideoMemoryType = "";
				if ($amountOfGraphicsCard > 0) {
					for ($i = 0; $i < $amountOfGraphicsCard; $i++) {
						$graphicsCardName .= $data['GraphicsCards'][$i]['Name'] . "; ";
						$graphicsCardInstalledDisplayDrivers .= $data['GraphicsCards'][$i]['InstalledDisplayDrivers'] . "; ";
						$graphicsCardVideoMemoryType .= $data['GraphicsCards'][$i]['VideoMemoryType'] . "; ";
					}
					$query4 .= "'" . $amountOfGraphicsCard . "', '" . substr($graphicsCardName, 0, -2) . "', '" . substr($graphicsCardInstalledDisplayDrivers, 0, -2) . "', '" . substr($graphicsCardVideoMemoryType, 0, -2) . "', ";
				} else {
					$query4 .= "'" . $amountOfGraphicsCard . "', '', '', '', ";
				}
			}
			if ($data['CPUs'] != null) {
				$amountOfCPU = sizeof($data['CPUs']);
				$cpuName = "";
				$cpuProducer = "";
				if ($amountOfCPU > 0) {
					for ($i = 0; $i < $amountOfCPU; $i++) {
						$cpuName .= $data['CPUs'][$i]['Name'] . "; ";
						$cpuProducer .= $data['CPUs'][$i]['Producer'] . "; ";
					}
					$query4 .= "'" . $amountOfCPU . "', '" . substr($cpuName, 0, -2) . "', '" . substr($cpuProducer, 0, -2) . "', ";
				} else {
					$query4 .= "'" . $amountOfCPU . "', '', '', ";
				}
			}
			if ($data['SoundCards'] != null) {
				$amountOfSoundCard = sizeof($data['SoundCards']);
				$SoundCardCaption = "";
				$soundCardManufacturer = "";
				$soundCardStatusInfo = "";
				if ($amountOfSoundCard > 0) {
					for ($i = 0; $i < $amountOfSoundCard; $i++) {
						$soundCardCaption .= $data['SoundCards'][$i]['Caption'] . "; ";
						$soundCardManufacturer .= $data['SoundCards'][$i]['Manufacturer'] . "; ";
						$soundCardStatusInfo .= $data['SoundCards'][$i]['StatusInfo'] . "; ";
					}
					$query4 .= "'" . $amountOfSoundCard . "', '" . substr($soundCardCaption, 0, -2) . "', '" . substr($soundCardManufacturer, 0, -2) . "', '" . substr($soundCardStatusInfo, 0, -2) . "', ";
				} else {
					$query4 .= "'" . $amountOfSoundCard . "', '', '', '', ";
				}
			}
			if ($data['HDDs'] != null) {
				$amountOfHDD = sizeof($data['HDDs']);
				$hddCaption = "";
				$hddMediaType = "";
				$hddSize = "";
				if ($amountOfHDD > 0) {
					for ($i = 0; $i < $amountOfHDD; $i++) {
						$hddCaption .= $data['HDDs'][$i]['Caption'] . "; ";
						$hddMediaType .= $data['HDDs'][$i]['MediaType'] . "; ";
						$hddSize .= $data['HDDs'][$i]['Size'] . "; ";
					}
					$query4 .= "'" . $amountOfHDD . "', '" . substr($hddCaption, 0, -2) . "', '" . substr($hddMediaType, 0, -2) . "', '" . substr($hddSize, 0, -2) . "')";
				} else {
					$query4 .= "'" . $amountOfHDD . "', '', '', '')";
				}
			}
			$result = $conn->query($query4);
		}
	}
}
?>