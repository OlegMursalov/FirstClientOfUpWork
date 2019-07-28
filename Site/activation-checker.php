<?
$rest_json = file_get_contents("php://input");
if ($rest_json != null) {
	$activationId = str_replace("ActivationId=", "", $rest_json);
	if ($activationId != null && $activationId !== '') {
		$conn = new mysqli('localhost', 'd02f240b', 'BvLnSTHEzyBxRo38', 'd02f240b');
		if (!$conn->connect_error) {
			$query = "select LastDate from Activations where Id='" . $activationId . "'";
			$result = $conn->query($query);
			if ($result != null && $result->num_rows > 0) {
				$row = $result->fetch_row();
				$lastDate = $row[0];
				$now = date("Y-m-d H:i:s");
				if ($lastDate >= $now) {
					print 1;
				} else {
					print 0;
				}
			} else {
				print 0;
			}
		}
	}
}
?>