<?
include 'config.php';
require_once('class.phpmailer.php');
if (isset($_POST['idApp']) && isset($_POST['userEmail']) && isset($_POST['languageCode']) && isset($_POST['amountOfMinutes']) && isset($_POST['amountOfUsers'])) {
	$conn = new mysqli($config['DB_HOST'], $config['DB_USERNAME'], $config['DB_PASSWORD'], $config['DB_DATABASE']);
	if (!$conn->connect_error) {
		// Retrieving app by id
		$query = "select Id, MainFileName from Applications where Id = '" . $_POST['idApp'] . "'";
		$result = $conn->query($query);
		if ($result != null && $result->num_rows > 0) {
			$row = $result->fetch_row();
			
			$mainFileName = $row[1];
			$languageCode = doubleval($_POST['languageCode']);
			if ($languageCode == 1) {
				$files = glob("applications/en/" . $mainFileName);
			} else if ($languageCode == 2) {
				$files = glob("applications/de/" . $mainFileName);
			} else if ($languageCode == 3) {
				$files = glob("applications/fr/" . $mainFileName);
			} else {
				$files = null;
			}
			
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
				$message->SetFrom('customer_support@cetbix.com', 'Cetbix');
				// Test email
				$message->AddAddress($_POST['userEmail']);
				$message->Subject = "Message from Cetbix";
				$message->Body = "Your licensing key = '" . $key . "'\n";
				$message->Body .= "Amount of users = '" . ($_POST['amountOfUsers'] == 9007199254740991 ? 'all users' : $_POST['amountOfUsers']) . "'\n";
				$message->Body .= "Amount of minutes = '" . ($_POST['amountOfMinutes'] == 9007199254740991 ? 'full version (always)' : $_POST['amountOfMinutes']) . "'\n";
				
				if ($languageCode == 1) {
					$message->Body .= "Language = 'English'" . "\n";
				} else if ($languageCode == 2) {
					$message->Body .= "Language = 'German'" . "\n";
				} else if ($languageCode == 3) {
					$message->Body .= "Language = 'French'" . "\n";
				}
				
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