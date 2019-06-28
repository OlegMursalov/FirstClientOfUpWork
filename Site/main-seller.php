<?
include 'config.php';
require_once('class.phpmailer.php');
if (isset($_POST['userDataEmail']) && isset($_POST['userDataLogin']) && isset($_POST['userDataPassword']) && isset($_POST['idApp']) && isset($_POST['amountOfMinutes']) &&
	isset($_POST['amountOfUsers'])) {
	$conn = new mysqli($config['DB_HOST'], $config['DB_USERNAME'], $config['DB_PASSWORD'], $config['DB_DATABASE']);
	if (!$conn->connect_error) {
		// Creating user
		$userId = uniqid() . uniqid();
		$login = $_POST['userDataLogin'];
		$password = $_POST['userDataPassword'];
		$email = $_POST['userDataEmail'];
		$query = "INSERT INTO `Users`(`Id`, `Login`, `Password`, `Email`) VALUES ('" . $userId . "', '" . $login . "', '" . $password . "', '" . $email . "')";
		$result = $conn->query($query);
		if ($result == 1) {
			// Retrieving user
			$query = "select Id, Email, Login from Users where Id = '" . $userId . "'";
			$result = $conn->query($query);
			if ($result != null && $result->num_rows > 0) {
				$row = $result->fetch_row();
				$email = $row[1];
				$login = $row[2];
				if ($email != null && $email !== '' && $login != null && $login !== '') {
					// Retrieving app by id
					$query = "select Id, MainFileName from Applications where Id = '" . $_POST['idApp'] . "'";
					$result = $conn->query($query);
					if ($result != null && $result->num_rows > 0) {
						$row = $result->fetch_row();
						$mainFileName = $row[1];
						$files = glob("applications/" . $mainFileName);
						if ($files != null && count($files) > 0) {
							$filePath = $files[0];
							$id = uniqid() . uniqid();
							$key = '';
							for ($i = 0; $i < 30; $i++) {
								$key .= random_int(0, 9);
							}
							// Creating license key
							$query = "INSERT INTO `LicensingKeys`(`Id`, `Buyer`, `AppId`, `Value`, `GenerationDate`, `AmountOfMinutes`, `AmountOfUsers`) VALUES ('" . $id . "','" . $userId . "','" . $_POST['idApp'] . "','" . $key . "','" . date("Y-m-d H:i:s") . "','" . $_POST['amountOfMinutes'] . "','" . $_POST['amountOfUsers'] . "')";
							$result = $conn->query($query);
							$message = new PHPMailer();
							$message->SetFrom('olegmursalovistrue@gmail.com', 'Cetbix');
							$message->AddAddress($email);
							$message->Subject = "Message from Cetbix";
							$message->Body = "Your licensing key = '" . $key . "'";
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
}