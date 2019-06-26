<?php include ('../header.php'); ?> 
<body>

<?php include ('../navi.php'); ?>
      

        <div class="wrapper wrapper-content animated fadeInRight ecommerce">

            <div class="row">
                <div class="col-lg-12">
                    <div class="tabs-container">
                            <ul class="nav nav-tabs">
                                <li class="active"><a data-toggle="tab" href="#tab-1">Dashboards</a></li>
                                <li class=""><a data-toggle="tab" href="#asset_tab"> Assets</a></li>
								<li class=""><a data-toggle="tab" href="#invoice-tab">Invoice</a></li>
                                <li class=""><a data-toggle="tab" href="#tab-3"> Search</a></li>
                                <li class=""><a data-toggle="tab" href="#tab-4"> Administrator</a></li>
                                <li class=""><a data-toggle="tab" href="#group-tab">Group</a></li>
                                <li class=""><a data-toggle="tab" href="#Code-tab">Code Editor</a></li>
                            </ul>
                            <div class="tab-content">
								<div id="tab-1" class="tab-pane active">
                                    <div class="panel-body">
									<?php  include ('dashboardpage.php');   ?>
                                    </div>
                                </div>
                                	
                                <div id="asset_tab" class="tab-pane">
                                    <div class="panel-body">
										<?php  include ('tools_tab.php');   ?>
                                    </div>
                                </div>
                                <div id="tab-3" class="tab-pane">
                                    <div class="panel-body">
								  <?php include ('searchpage.php');  ?>
                                    </div>
                                </div>
                                <div id="tab-4" class="tab-pane">
                                    <div class="panel-body">
								    <?php include ('administratorpage.php'); ?>
                                    </div>
                                </div>
                                <div id="group-tab" class="tab-pane tab-pane5">
                                    <div class="panel-body">
                                         <?  include ('invoice_tab.php');  ?>
                                    </div>
                                </div>
                                <div id="invoice-tab" class="tab-pane tab-pane6">
                                    <div class="panel-body">
                                        <? include ('invoicepage.php'); ?>
                                    </div>
                                </div>
                                
								<div id="Code-tab" class="tab-pane tab-pane7">
                                    <div class="panel-body">
                                        7code
                                    </div>
                                </div>
                            </div>
                    </div>
                </div>
            </div>

        </div>

<?php include('../footer.php'); ?>
