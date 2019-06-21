<!--    TABLE for Documents -- ----------------  -->
<!-- document table -->
<div class="row">
    <div class="col-lg-12">
        <div class="ibox float-e-margins">
            <div class="ibox-content">
				<div class="table-responsive pc-tab-table ">
					<table class="table table-striped table-bordered table-hover dataTables-example " >
						<thead>
							<tr>
								<th>+</th>
								<th>Host</th>
								<th>Domain</th>
								<th>Date</th>
								<th>Keys</th>
								<th>Values</th>
								<th>Timestamp</th>
								<th>Type</th>
								<th>Rules</th>
								<th>Complaint</th>
								<th>To do</th>
							</tr>
						</thead>
						<tbody>
							<?
							/*	$conn = new mysqli("localhost", "d02eb2b7", "kmG6PAbTxMWXKSkn", "d02eb2b7");
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
												$j++;
											}
										}
									}
									if (sizeof($main_arr) > 0) {
										foreach($main_arr as $key => $value){
											?><tr class="gradeX">
												<td><input type="checkbox"  class="i-checks" name="input[]"></td>
												<td><?=$value["Hostname"]?></td>
												<td><?=$value["Domain"]?></td>
												<td><?=$value["DateScan"]?></td>
												<td><a id="tools-details" data-sel-record="<?=$key?>">Click here</a></td>
											</tr><?
										}
									}
    							} else {
									$conn->close();
								} */
							?>
							
							
							
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Microsoft KB</td>
								<td>4489878<br />4462915<br />4095874<br />4095514<br />4054176</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>MPP AppData</td>
								<td>0</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>MD5: chrome.exe</td>
								<td>43 2f 9d 1c 91 fb a0 c2 32 66 fd 33 db 60 14 46</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>No</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>File: chrome.exe</td>
								<td>v.74.0.3729.131 - size: 1723888 o - last modified 30/04/2019 07:31:31</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>No</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>IP</td>
								<td>192.168.42.16</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>No</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>OS Version</td>
								<td>6.1.7601</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>No</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Cetbix Version</td>
								<td>2.1</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>No</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>IP</td>
								<td>10.21.207.34</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>No</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
						
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Adobe Refresh Manager</td>
								<td>1.8.0</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Lockout Observation Windows</td>
								<td>15</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Shares</td>
								<td>No shared folder</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>UAC activated</td>
								<td>1</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Adobe Acrobat Reader DC - Français</td>
								<td>1.011</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>No</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>MPP Policy</td>
								<td>1</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>OS Caption</td>
								<td>Microsoft Windows 7 Professionnel  SP 1</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>File: Intel-perso.xml</td>
								<td>v. - size: 1927 o - last modified 09/11/2018 10:43:59</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>No</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>System Uptime</td>
								<td>0 day</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Autorun</td>
								<td>'255</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>MPP Enforced</td>
								<td>1</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>OS Organization</td>
								<td>Company Name</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>No</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Minimum Password Length</td>
								<td>12</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>No</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Computer Role</td>
								<td>STATION</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Firewall - LAN</td>
								<td>1</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Firewall - Home</td>
								<td>1</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
								<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Firewall - Public network</td>
								<td>1</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Microsoft KB</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Antivirus installed</td>
								<td>1</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Antivirus Name</td>
								<td>Kaspersky</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Microsoft KB</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Antivirus version</td>
								<td>11.0.0.6499</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Antivirus latest update</td>
								<td>10-05-2019 06-03-00</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>No</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Antivirus running</td>
								<td>1</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>No</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Antivirus protection</td>
								<td>4</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Antivirus registered SC</td>
								<td>s1-in5pj-i504.v11.adgroup.veolia</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>LAPS</td>
								<td>Not installed</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>IP</td>
								<td>12.11.130.016</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>No</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Chrome version</td>
								<td>74.0.3729.131</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>No</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>IP</td>
								<td>0.0.0.0</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>MD5: Intel-perso.xml</td>
								<td>23 5e 5e ef 56 a2 01 0d bd 17 3c 1b c4 39 33 df</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr><tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>SMBv1</td>
								<td>Activated</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr><tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Domain</td>
								<td>UNCORP</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr><tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>MPP temp\*.exe</td>
								<td>0</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr><tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>MPP Activated</td>
								<td>6</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr><tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Account Lockout Duration</td>
								<td>15</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>No</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr><tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Maximum Password Age</td>
								<td>60</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>No</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Password History</td>
								<td>15</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Minimum Password Age</td>
								<td>4</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Java</td>
								<td>jre1.8.0_201</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Lockout Threshold</td>
								<td>6</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>Type</td>
								<td>Workstation</td>
								<td>20190609</td>
								<td>Member Workstation</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							<tr class="gradeX">
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
								<td>LP001</td>
								<td>Corporate</td>
								<td>201906</td>
								<td>User</td>
								<td>Workstation</td>
								<td>20190609</td>
								<td>Oleg Mursalov</td>
								<td>Microsoft KB</td>
								<td>Yes</td>
								<td><input type="checkbox"  class="i-checks" name="input[]"></td>
							</tr>
							
						</tbody>
					</table>
				</div>
                <div class="hide-tools hidden">
                    <?php require 'tools_detail.php' ?>
                </div>
            </div>
        </div>
    </div>
</div>