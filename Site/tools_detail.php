<?
if ($_POST && isset($_POST['idRecord'])) {
	$id = $_POST['idRecord'];
	$hostname = $_POST['hostname'];
	$domain = $_POST['domain'];
	$dateScan = $_POST['dateScan'];
	$conn = new mysqli("localhost", "d02eb2b7", "kmG6PAbTxMWXKSkn", "d02eb2b7");
	if (!$conn->connect_error) {
		$arr = [];
		$arr[$id] = [];
		$query_key_value = "select * from KeysValues where Id = '" . $id . "'";
		$result = $conn->query($query_key_value);
		while($row = $result->fetch_assoc()) {
			$arr[$row["Id"]]["Cetbix Version"] = $row["CetbixVulnerabilityScannerVersion"];
			$arr[$row["Id"]]["System Uptime"] = $row["SystemUptime"];
			$arr[$row["Id"]]["Type"] = $row["Type"];
			$arr[$row["Id"]]["IP"] = $row["IP"];
			$arr[$row["Id"]]["OS Caption"] = $row["OSCaption"];
			$arr[$row["Id"]]["OS Version"] = $row["OSVersion"];
			$arr[$row["Id"]]["OS Organization"] = $row["OSOrganization"];
			$arr[$row["Id"]]["Java"] = $row["Java"];
			$arr[$row["Id"]]["SMBv1"] = $row["SMBv1"];
			$arr[$row["Id"]]["LAPS"] = $row["LAPS"];
			$arr[$row["Id"]]["Microsoft KB"] = $row["MicrosoftKB"];
			$arr[$row["Id"]]["Minimum Password Age"] = $row["MinimumPasswordAge"];
			$arr[$row["Id"]]["Maximum Password Age"] = $row["MaximumPasswordAge"];
			$arr[$row["Id"]]["Minimum Password Length"] = $row["MinimumPasswordLength"];
			$arr[$row["Id"]]["Password History"] = $row["PasswordHistory"];
			$arr[$row["Id"]]["Lockout Threshold"] = $row["LockoutThreshold"];
			$arr[$row["Id"]]["Account Lockout Duration"] = $row["AccountLockoutDuration"];
			$arr[$row["Id"]]["Lockout Observation Windows"] = $row["LockoutObservationWindows"];
			$arr[$row["Id"]]["Computer Role"] = $row["ComputerRole"];
			$arr[$row["Id"]]["Shares"] = $row["Shares"];
			// $arr[$row["Id"]]["MPP AppData"] = "";
			// $arr[$row["Id"]]["MPP Policy"] = "";
			// $arr[$row["Id"]]["MPP enforced"] = "";
			$arr[$row["Id"]]["MPP temp\*.exe"] = $row["MPPTempExe"];
			$arr[$row["Id"]]["MPP Activated"] = $row["MPPActivated"];
			$arr[$row["Id"]]["MDP5: chrome.exe"] = $row["MDP5Chrome"];
			$arr[$row["Id"]]["File: chrome.exe"] = $row["FileChromeExe"];
			$arr[$row["Id"]]["MDP5: firefox.exe"] = $row["MDP5FireFox"];
			$arr[$row["Id"]]["File: firefox.exe"] = $row["FireFoxExe"];
			$arr[$row["Id"]]["MDP5: internet explorer.exe"] = $row["MDP5InternetExplorer"];
			$arr[$row["Id"]]["File: exploere.exe"] = $row["FileExplorerExe"];
			$arr[$row["Id"]]["Chrome version"] = $row["ChromeVersion"];
			$arr[$row["Id"]]["Firefox version"] = $row["FireFoxVersion"];
			$arr[$row["Id"]]["Internet Explorer version"] = $row["IEVersion"];
			$arr[$row["Id"]]["Compliance Tool Version"] = $row["ComplianceToolVersion"];
			$arr[$row["Id"]]["Adobe Refrech Manager"] = $row["AdobeRefrechManager"];
			$arr[$row["Id"]]["Adobe Acrobat Reader DC"] = $row["AdobeAcrobatReaderDC"];
			$arr[$row["Id"]]["Antivirus name"] = $row["AntivirusName"];
			$arr[$row["Id"]]["Antivirus latest update"] = $row["AntivirusLatestUpdate"];
			$arr[$row["Id"]]["Antivirus installed"] = $row["AntivirusInstalled"];
			$arr[$row["Id"]]["Antivirus version"] = $row["AntivirusVersion"];
			$arr[$row["Id"]]["Antivirus running"] = $row["AntivirusRunning"];
			$arr[$row["Id"]]["UAC activated"] = $row["UACActivated"];
			// $arr[$row["Id"]]["File: Intel-perso.xml"] = "";
			$arr[$row["Id"]]["Autorun"] = $row["Autorun"];
			$arr[$row["Id"]]["Firewall Home"] = $row["FireWallHome"];
			$arr[$row["Id"]]["Firewall - LAN"] = $row["FireWallLAN"];
			$arr[$row["Id"]]["Firewall - Public network"] = $row["FireWallPublicNetwork"];
			// $arr[$row["Id"]]["MDP5: Intel-perso.xml"] = "";
		}
	} else {
		$conn->close();
	}
}
?>
<div class="row">
    <div class="col-lg-12">
        <br />
        <a href="">
            <h5>Asset: <?=$hostname?></h5>
        </a>
		<div class="ibox float-e-margins">
            <div class="ibox-content">
				<div id="assets-pc" class="table-responsive pc-tab-table ">
					<table class="table table-striped table-bordered table-hover dataTables-example-detail " style="word-break: break-all;" >
						<thead>
							<tr style="white-space: nowrap;">
								<th>+</th>
								<th>Hostname</th>
								<th>Domain</th>
								<th>Date Scan</th>
								<th>Keys</th>
								<th>Values</th>
								<th>Type</th>
								<th>Complaint</th>
							</tr>
						</thead>
						<tbody>
							<?
								$keys = array_keys($arr[$id]);
								for ($i = 0; $i <= count($keys); $i++) {
									if (trim($keys[$i]) !== '') {
										?><tr>
											<td><input type="checkbox"  class="i-checks" name="input[]"></td>
											<td style="white-space: nowrap;"><?=$hostname?></td>
											<td style="white-space: nowrap;"><?=$domain?></td>
											<td style="white-space: nowrap;"><?=$dateScan?></td>
											<td style="white-space: nowrap;"><?=$keys[$i]?></td>
											<td style="word-break: break-word;"><?=$arr[$id][$keys[$i]]?></td>
											<td style="white-space: nowrap;"><?=$arr[$id]["Type"]?></td>
											<td>No</td>
										</tr><?
									}
								}
							?>
						</tbody>
					</table>
				</div>
			</div>
		</div>
    </div>
</div>
<script>
$('.dataTables-example-detail').DataTable({
    dom: '<"html5buttons"B>lTfgitp',
    buttons: [
        {extend: 'copy'},
        {extend: 'csv'},
        {extend: 'excel', title: 'ExampleFile'},
        {extend: 'pdf', title: 'ExampleFile'},

        {extend: 'print',
			customize: function (win){
                $(win.document.body).addClass('white-bg');
                $(win.document.body).css('font-size', '10px');

                $(win.document.body).find('table')
                                    .addClass('compact')
                                    .css('font-size', 'inherit');
			}
		}
	]});
</script>