<!--    TABLE for Documents -- ----------------  -->
<!-- document table -->
<div class="row">
    <div class="col-lg-12">
        <div class="ibox float-e-margins">
            <div class="ibox-content">
				<div id="assets-pc" class="table-responsive pc-tab-table ">
					<table class="table table-striped table-bordered table-hover dataTables-example " >
						<thead>
							<tr>
								<th>+</th>
								<th>Hostname</th>
								<th>Domain</th>
								<th>Date Scan</th>
								<th>Keys</th>
							</tr>
						</thead>
						<tbody>
							<?
								$conn = new mysqli("localhost", "d02eb2b7", "kmG6PAbTxMWXKSkn", "d02eb2b7");
								if (!$conn->connect_error) {
									$j = 0;
									$main_arr = [];
									$our_queries = array();
									array_push($our_queries, "select Id, Hostname from Hostnames");
									array_push($our_queries, "select Id, Domain from Domains");
									array_push($our_queries, "select Id, DateScan from Scans");
									foreach ($our_queries as $query) {
										$result = $conn->query($query);
										if ($result->num_rows > 0) {
											while($row = $result->fetch_assoc()) {
												if ($j == 0) {
													$main_arr[$row["Id"]]["Hostname"] = $row["Hostname"];
												} else if ($j == 1) {
													$main_arr[$row["Id"]]["Domain"] = $row["Domain"];
												} else {
													$main_arr[$row["Id"]]["DateScan"] = $row["DateScan"];
												}
											}
										}
										$j++;
									}
									if (sizeof($main_arr) > 0) {
										foreach($main_arr as $key => $value){
											?><tr class="gradeX">
												<td><input type="checkbox"  class="i-checks" name="input[]"></td>
												<td><?=$value["Hostname"]?></td>
												<td><?=$value["Domain"]?></td>
												<td><?=$value["DateScan"]?></td>
												<td><a class="tools-details-keys" onclick="showKeys('<?=$key?>', '<?=$value["Hostname"]?>', '<?=$value["Domain"]?>', '<?=$value["DateScan"]?>');">Click here</a></td>
											</tr><?
										}
									}
    							} else {
									$conn->close();
								}
							?>
						</tbody>
					</table>
				</div>
                <div id="details-keys-panel" class="hide-tools hidden">
					
                </div>
            </div>
        </div>
    </div>
</div>
<script>
	function showKeys(id, hostname, domain, dateScan) {
		$.ajax({
			url: 'tools_detail.php',
			type: "POST",
			data: "idRecord=" + id + "&hostname=" + hostname + "&domain=" + domain + "&dateScan=" + dateScan,
			success: function(data) {
				$('#details-keys-panel').html(data);
				$('#details-keys-panel').removeClass('hidden');
				$('#assets-pc').addClass('hide');
			}
		});
	}
</script>