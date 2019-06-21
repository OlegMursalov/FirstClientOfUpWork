<?
$rest_json = file_get_contents("php://input");
if ($rest_json != null) {
	$licenseKeyValue = str_replace("LicenseKeyValue=", "", $rest_json);
	if ($licenseKeyValue != null && $licenseKeyValue !== '') {
		$conn = new mysqli('localhost', 'd02eb2b7', 'kmG6PAbTxMWXKSkn', 'd02eb2b7');
		if (!$conn->connect_error) {
			$query = "select Id, Value, IsAvailable from `LicensingKeys` where Value = '" . $licenseKeyValue . "'";
			$result = $conn->query($query);
			if ($result != null && $result->num_rows > 0) {
				$row = $result->fetch_row();
				if ($row[2] == 1) {
					$query = "update `LicensingKeys` set `IsAvailable` = 0 where Value = '" . $licenseKeyValue . "'";
					$result = $conn->query($query);
					print "OK";
				} else {
					print "This key has already been used.";
				}
			} else {
				print "This key does not exist.";
			}
		}
	}
}
?>