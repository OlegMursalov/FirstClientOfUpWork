<?
include 'config.php';
require_once('class.phpmailer.php');
if (isset($_POST['userId']) && isset($_POST['idApp'])) {
	$conn = new mysqli($config['DB_HOST'], $config['DB_USERNAME'], $config['DB_PASSWORD'], $config['DB_DATABASE']);
	if (!$conn->connect_error) {
		$query = "select Id, Email, Login from Users where Id = '" . $_POST['userId'] . "'";
		$result = $conn->query($query);
		if ($result != null && $result->num_rows > 0) {
			$row = $result->fetch_row();
			$email = $row[1];
			$login = $row[2];
			if ($email != null && $email !== '' && $login != null && $login !== '') {
				$query = "select Id, MainFileName from Applications where Id = '" . $_POST['idApp'] . "'";
				$result = $conn->query($query);
				if ($result != null && $result->num_rows > 0) {
					$row = $result->fetch_row();
					$mainFileName = $row[1];
					$files = glob("applications/" . $mainFileName);
					if ($files != null && count($files) > 0) {
						$filePath = $files[0];
						$query = "select Id, Value from LicensingKeys where UserId = '" . $_POST['userId'] . "' and AppId = '" . $_POST['idApp'] . "' and IsAvailable = 1";
						$result = $conn->query($query);
						$bodytext = '';
						if ($result != null && $result->num_rows > 0) {
							$row = $result->fetch_row();
							$bodytext = "Your licensing key = '" . $row[1] . "'";
						} else {
							$id = uniqid();
							$value = $id . uniqid();
							$query = "INSERT INTO `LicensingKeys`(`Id`, `UserId`, `AppId`, `Value`, `IsAvailable`) VALUES ('" . $id . "','" . $_POST['userId'] . "','" . $_POST['idApp'] . "','" . $value . "',1)";
							$result = $conn->query($query);
							$bodytext = "Your licensing key = '" . $value . "'";
						}
						$message = new PHPMailer();
						$message->SetFrom('olegmursalovistrue@gmail.com', 'Cetbix');
						$message->AddAddress($email);
						$message->Subject = "Message from Cetbix";
						$message->Body = $bodytext;
						$message->AddAttachment($filePath, $mainFileName);
						if($message->Send()) {
							echo 'Please, check your email box.';
						} else {
							echo 'Sorry, bad request.';
						}
					}
				}
			}
		}
	}
}