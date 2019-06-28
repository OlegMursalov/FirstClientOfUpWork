<?
// Check license key when installation..
$rest_json = file_get_contents("php://input");
if ($rest_json != null) {
	$parts = explode(";", $rest_json);
	if ($parts != null && count($parts) >= 2) {
		$licenseKeyValue = str_replace("LicenseKeyValue=", "", $parts[0]);
		$uuid = str_replace("UUID=", "", $parts[1]);
		if ($licenseKeyValue != null && $licenseKeyValue !== '' && $uuid != null && $uuid !== '') {
			$conn = new mysqli('localhost', 'd02eb2b7', 'kmG6PAbTxMWXKSkn', 'd02eb2b7');
			if (!$conn->connect_error) {
				$query = "select Id, AppId, Value, GenerationDate, AmountOfMinutes, AmountOfUsers from `LicensingKeys` where Value = '" . $licenseKeyValue . "'";
				$result = $conn->query($query);
				if ($result != null && $result->num_rows > 0) {
					$row = $result->fetch_row();
					$keyId = $row[0];
					$amountOfMinutes = $row[4];
					$amountOfUsers = (int)$row[5];
					// Check on the number of activations by this key
					$query = "select count(Id) from `Activations` where LicensingKeyId = '" . $keyId . "'";
					$result = $conn->query($query);
					if ($result != null && $result->num_rows > 0) {
						$row = $result->fetch_row();
						$amountOfActivationsForCurrKey = (int)$row[0];
						if ($amountOfActivationsForCurrKey < $amountOfUsers) {
							// Check the existing activation for this key and UUID.
							$query = "select count(Id) from `Activations` where LicensingKeyId = '" . $keyId . "' and UUID = '" . $uuid . "'";
							$result = $conn->query($query);
							if ($result != null && $result->num_rows > 0) {
								$row = $result->fetch_row();
								$amountOfActivationsForCurrKeyAndCurrUUID = (int)$row[0];
								if ($amountOfActivationsForCurrKeyAndCurrUUID == 0) {
									$activationId = uniqid() . uniqid();
									$now = date("Y-m-d H:i:s");
									$lastDate = date("Y-m-d H:i:s", strtotime('+' . $amountOfMinutes . ' minutes', strtotime($now)));
									$query = "INSERT INTO `Activations`(`Id`, `UUID`, `LicensingKeyId`, `ActivationDate`, `LastDate`) VALUES ('" . $activationId . "','" . $uuid . "','" . $keyId . "','" . $now . "','" . $lastDate . "')";
									$result = $conn->query($query);
									print "ActivationId=" . $activationId . ";AmountOfMinutes=" . $amountOfMinutes;
								} else {
									print "There is already an activation for this user.";
								}
							} else {
								"Error in MSI [1228].";
							}
						} else {
							print "For this key, activation is complete.";
						}
					} else {
						"Error in MSI [1218].";
					}
				} else {
					print "This key does not exist.";
				}
			}
		} else {
			"Error in MSI [1208].";
		}
	} else {
		print "Error in MSI [1206].";
	}
}
?>