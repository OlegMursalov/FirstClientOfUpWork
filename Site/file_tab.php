
    <div class="col-lg-12">
        <div class="tabs-container hidden" id="tab_files">
            <ul class="nav nav-tabs">
                <li class="active"><a data-toggle="tab" href="#tab-5" class="active"
                                      aria-expanded="true">Properties</a></li>
                <li class=""><a data-toggle="tab" href="#tab-6">Ext. Properties</a></li>
                <li class=""><a data-toggle="tab" href="#tab-7"> Versions</a></li>
                <li class=""><a data-toggle="tab" href="#tab-8">Preview</a></li>
                <li class=""><a data-toggle="tab" href="#tab-9">Notes Links</a></li>
                <li class=""><a data-toggle="tab" href="#tab-10">Signature</a></li>
                <li class=""><a data-toggle="tab" href="#tab-11">Related</a></li>
				<li class=""><a data-toggle="tab" href="#tab-notes">Notes</a></li>
				<li class=""><a data-toggle="tab" href="#tab-history">History</a></li>
				<li class=""><a data-toggle="tab" href="#tab-activity">Activity Log</a></li>
				<li class=""><a data-toggle="tab" href="#tab-forum">Forum</a></li>
				<li class=""><a data-toggle="tab" href="#tab-meetup">MeetUp</a></li>
				<li class=""><a data-toggle="tab" href="#tab-wkflow">Workflow</a></li>
				
				
				
            </ul>
            <div class="tab-content">
                <div id="tab-5" class="tab-pane active" aria-expanded="true">
                    <div class="panel-body">
					<? include ('properties_tab.php');   ?>

                    </div>
                </div>
                <div id="tab-6" class="tab-pane">
                    <div class="panel-body">
                        2
                    </div>
                </div>
                <div id="tab-7" class="tab-pane">
                    <div class="panel-body">
                        <? include('file_version_tab.php') ; ?>
                    </div>
                </div>
                <div id="tab-8" class="tab-pane">
                    <div class="panel-body">
                        <div id="PDFpreview"></div>
                    </div>
                </div>
                <div id="tab-9" class="tab-pane">
                    <div class="panel-body">
                        5
                    </div>
                </div>
                <div id="tab-10" class="tab-pane">
                    <div class="panel-body">
                        7
                    </div>
                </div>
                <div id="tab-11" class="tab-pane">
                    <div class="panel-body">
                        <?  include ('invoice_tab.php');  ?>
                    </div>
                </div>
				<div id="tab-notes" class="tab-pane">
                    <div class="panel-body">
                       <?   include ('notes.php');  ?>
                    </div>
                </div>
				<div id="tab-history" class="tab-pane">
                    <div class="panel-body">
                       <? include ('file_history_tab.php'); ?> 
                    </div>
                </div>
				
				<div id="tab-activity" class="tab-pane">
                    <div class="panel-body">
                        <?  include ('logs.php');  ?>
                    </div>
                </div>
				
				<div id="tab-forum" class="tab-pane">
                    <div class="panel-body">
                        <? include ('forum/forum.php'); ?>
                    </div>
                </div>
				
				<div id="tab-meetup" class="tab-pane">
                    <div class="panel-body">
                        <? include ('meet/meetup.php'); ?>
                    </div>
                </div>
				
				<div id="tab-wkflow" class="tab-pane">
                    <div class="panel-body">
                        Wk Flow
                    </div>
                </div>
				
            </div>
        </div>
    </div>
