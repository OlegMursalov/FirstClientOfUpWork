<?
$rest_json = file_get_contents("php://input");
if ($rest_json != null) {
	$licenseKeyValue = str_replace("LicenseKeyValue=", "", $rest_json);
	if ($licenseKeyValue != null && $licenseKeyValue !== '') {
		$conn = new mysqli('localhost', 'd02eb2b7', 'kmG6PAbTxMWXKSkn', 'd02eb2b7');
		if (!$conn->connect_error) {
			$query = "select Id, AppId, Value, GenerationDate, UserId, AmountOfDays, AmountOfUsers from `LicensingKeys` where Value = '" . $licenseKeyValue . "'";
			$result = $conn->query($query);
			if ($result != null && $result->num_rows > 0) {
				$row = $result->fetch_row();
				$keyId = $row[0];
				$userId = $row[4];
				$amountOfDays = $row[5];
				$amountOfUsers = $row[6];
				$query = "select count(*) from `Activations`";
				$result = $conn->query($query);
				if ($result != null && $result->num_rows > 0) {
					$row = $result->fetch_row();
					$amountOfActivations = $row[0];
					if ($amountOfActivations < $amountOfUsers) {
						$query = "select count(*) from `Activations` where UserId = '" . $userId . "'";
						$result = $conn->query($query);
						if ($result != null && $result->num_rows > 0) {
							$row = $result->fetch_row();
							$amountOfActivationsForCurrUser = $row[0];
							if ($amountOfActivationsForCurrUser == 0) {
								$id = uniqid() . uniqid();
								$now = date("Y-m-d H:i:s");
								$lastDate = date("Y-m-d H:i:s", strtotime('+' . $amountOfDays . ' days', strtotime($now)));
								$query = "INSERT INTO `Activations`(`Id`, `UserId`, `LicensingKeyId`, `ActivationDate`, `LastDate`) VALUES ('" . $id . "','" . $userId . "','" . $keyId . "','" . $now . "','" . $lastDate . "')";
								$result = $conn->query($query);
								print "OK";
							} else {
								print "There is already an activation for this user.";
							}
						}
					} else {
						print "Activations have ended.";
					}
				}
			} else {
				print "This key does not exist.";
			}
		}
	}
}
?>