<? include 'config.php';
include ('../header.php'); ?>
<body>
<? include ('../navi.php'); ?>
	<div class="wrapper wrapper-content animated fadeInRight ecommerce">
		<div class="row">
            <div class="col-lg-6">
			<?if (isset($_SESSION['UserId'])) {?>
				<input type="hidden" name="user-id" id="user-id" value="<?=$_SESSION['UserId']?>" />
                <div class="tabs-container">
					<h3>Buy apps.</h3>
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
												<td><a href="#" data-id-app="<?=$row[0]?>" onclick="buyApp(this);" class="buy-app">Buy</a></td>
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
			<?} else {?>
				</div class="tabs-container">
					<h3>Please, log in or sign up.</h3>
				</div>
			<?}?>
            </div>
        </div>
	</div>
	<script type="text/javascript">
		var buyApp = function (elem) {
			debugger;
			var userIdElem = document.getElementById('user-id');
			if (userIdElem != null) {
				var userId = userIdElem.value;
				var idApp = elem.getAttribute('data-id-app');
				if (userId && idApp) {
					$.ajax({
						type: "POST",
						url: "main-seller.php",
						data: "userId=" + userId + "&idApp=" + idApp,
						success: function(msg){
							alert(msg);
						}
					});
				}
			}
		}
	</script><?
include('../footer.php'); ?>