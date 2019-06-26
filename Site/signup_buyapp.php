<? include 'config.php';
include ('../header.php'); ?>
<body>
<? include ('../navi.php'); ?>
	<div class="wrapper wrapper-content animated fadeInRight ecommerce">
		<div class="row">
			<div class="col-lg-12">
				<h1>Automatic user creation and application purchase.</h1>
			</div>
			<div class="col-lg-6">
                <div class="tabs-container">
					<h3>Fill these fields.</h3>
					<form name="userData">
						<div class="form-group">
							<label for="exampleInputEmail1">Email address</label>
    						<input required type="email" name="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">
						</div>
  						<div class="form-group">
							<label for="exampleInputLogin">Login</label>
							<input required type="text" name="login" class="form-control" id="exampleInputLogin" aria-describedby="loginHelp" placeholder="Enter login">
						</div>
						<div class="form-group">
							<label for="exampleInputPassword1">Password</label>
							<input required type="password" name="password" class="form-control" id="exampleInputPassword1" placeholder="Password">
						</div>
					</form>
                </div>
            </div>
            <div class="col-lg-6">
                <div class="tabs-container">
					<h3>By app.</h3>
					<?
					$conn = new mysqli($config['DB_HOST'], $config['DB_USERNAME'], $config['DB_PASSWORD'], $config['DB_DATABASE']);
					if (!$conn->connect_error) {
						$query = 'select Id, Title, Price from Applications';
						$result = $conn->query($query);
						if ($result != null && sizeof($result) > 0) {?>
							<table class="table table-bordered">
								<head>
									<tr class="info">
										<td>Title</td>
										<td colspan="2">Price</td>
									</tr>
								</head>
								<body>
									<?while($row = $result->fetch_row()) {
										if ($row != null && sizeof($row) >= 3) {?>
											<tr class="success">
												<td><?=$row[1];?></td>
												<td><?=$row[2];?></td>
												<td>
													<button class="buy-app" type="submit" data-id-app="<?=$row[0]?>" data-amount-of-days="14" data-amount-of-users="1" class="btn btn-primary" onclick="main(this);">Buy for 14 days</button>
												</td>
											</tr>
										<?}
									}?>
								</body>
							</table>
						<?} else {?>
							<div>No applications.</div>
						<?}
					} else {?>
						<div>No connection to MySQL.</div>
					<?}?>
                </div>
            </div>
        </div>
	</div>
	<script type="text/javascript">
		var main = function (elem) {
			debugger;
			var flag = true;
			var obj = new Object();
			var userData = document.forms["userData"].getElementsByTagName("input");
			for (var i = 0; i < userData.length; i++) {
				if (userData[i].checkValidity()) {
					userData[i].classList.remove('error');
					if (userData[i].id == 'exampleInputEmail1') {
						obj.userDataEmail = userData[i].value;
					} else if (userData[i].id == 'exampleInputLogin') {
						obj.userDataLogin = userData[i].value;
					} else if (userData[i].id == 'exampleInputPassword1') {
						obj.userDataPassword = userData[i].value;
					}
				} else {
					userData[i].classList.add('error');
					flag = false;
				}
			}
			if (flag) {
				obj.idApp = elem.getAttribute('data-id-app');
				obj.amountOfDays = elem.getAttribute('data-amount-of-days');
				obj.amountOfUsers = elem.getAttribute('data-amount-of-users');
				$.ajax({
					type: "POST",
					url: "main-seller.php",
					data: "userDataEmail=" + obj.userDataEmail + "&userDataLogin=" + obj.userDataLogin + "&userDataPassword=" + obj.userDataPassword + "&idApp=" + obj.idApp + "&amountOfDays=" + obj.amountOfDays + "&amountOfUsers=" + obj.amountOfUsers,
					success: function(msg){
						alert(msg);
					}
				});
			}
		}
	</script><?
include('../footer.php'); ?>