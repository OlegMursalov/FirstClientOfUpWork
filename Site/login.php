<?
include 'config.php';
if (isset($_POST['email']) && isset($_POST['login']) && isset($_POST['password'])) {
	$conn = new mysqli($config['DB_HOST'], $config['DB_USERNAME'], $config['DB_PASSWORD'], $config['DB_DATABASE']);
	if (!$conn->connect_error) {
		$id = uniqid();
		$login = $_POST['login'];
		$password = $_POST['password'];
		$email = $_POST['email'];
		$query = "INSERT INTO `Users`(`Id`, `Login`, `Password`, `Email`) VALUES ('" . $id . "', '" . $login . "', '" . $password . "', '" . $email . "')";
		$result = $conn->query($query);
		$_SESSION['UserId'] = $id;
		$_SESSION['UserLogin'] = $login;
		header('location:../asset_management/tabs1.php');
	} else {
		print_r('No connection');
	}
} else {
	include ('../header.php');
	?><body><?
	include ('../navi.php');?>
	<div class="wrapper wrapper-content animated fadeInRight ecommerce">
		<div class="row">
            <div class="col-lg-12">
                <div class="tabs-container">
					<h3>Please, enter your data.</h3>
					<form method="post" action="login.php">
						<div class="form-group">
							<label for="exampleInputEmail1">Email address</label>
    						<input type="email" name="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">
						</div>
  						<div class="form-group">
							<label for="exampleInputLogin">Login</label>
							<input type="text" name="login" class="form-control" id="exampleInputLogin" aria-describedby="loginHelp" placeholder="Enter login">
						</div>
						<div class="form-group">
							<label for="exampleInputPassword1">Password</label>
							<input type="password" name="password" class="form-control" id="exampleInputPassword1" placeholder="Password">
						</div>
						<button type="submit" class="btn btn-primary" onclick="checkSignUpData(event);">Sign up</button>
					</form>
                </div>
            </div>
        </div>
	</div>
	<script type="text/javascript">
		var checkSignUpData = function (e) {
			debugger;
			var flag = true;
			var email = document.getElementById('exampleInputEmail1');
			if (email.value === null || email.value === '') {
				e.preventDefault();
				flag = false;
			}
			var login = document.getElementById('exampleInputLogin');
			if (login.value === null || login.value === '') {
				e.preventDefault();
				flag = false;
			}
			var pass = document.getElementById('exampleInputPassword1');
			if (pass.value === null || pass.value === '') {
				e.preventDefault();
				flag = false;
			}
			if (!flag) {
				alert('Please, fill all fields.');
			}
		}
	</script><?
}
?>
<?php include('../footer.php'); ?>