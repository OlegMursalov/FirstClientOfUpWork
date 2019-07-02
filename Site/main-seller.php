<?
include 'config.php';
require_once('class.phpmailer.php');
if (isset($_POST['idApp']) && isset($_POST['amountOfMinutes']) && isset($_POST['amountOfUsers'])) {
	$conn = new mysqli($config['DB_HOST'], $config['DB_USERNAME'], $config['DB_PASSWORD'], $config['DB_DATABASE']);
	if (!$conn->connect_error) {
		// Retrieving app by id
		$query = "select Id, MainFileName from Applications where Id = '" . $_POST['idApp'] . "'";
		$result = $conn->query($query);
		if ($result != null && $result->num_rows > 0) {
			$row = $result->fetch_row();
			$mainFileName = $row[1];
			$files = glob("applications/" . $mainFileName);
			if ($files != null && count($files) > 0) {
				$filePath = $files[0];
				// Creating license key
				$id = uniqid() . uniqid();
				$key = '';
				for ($i = 0; $i < 30; $i++) {
					$key .= random_int(0, 9);
				}
				$userId = ''; // User Id (if you need)
				$query = "INSERT INTO `LicensingKeys`(`Id`, `Buyer`, `AppId`, `Value`, `GenerationDate`, `AmountOfMinutes`, `AmountOfUsers`) VALUES ('" . $id . "','" . $userId . "','" . $_POST['idApp'] . "','" . $key . "','" . date("Y-m-d H:i:s") . "','" . $_POST['amountOfMinutes'] . "','" . $_POST['amountOfUsers'] . "')";
				$result = $conn->query($query);
				$message = new PHPMailer();
				$message->SetFrom('olegmursalovistrue@gmail.com', 'Cetbix');
				// Test email
				$message->AddAddress('german@xvex.de');
				$message->AddAddress('olofovich@mail.ru');
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