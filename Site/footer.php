modal-upload-file  <div class="footer">
            <div class="pull-right">
                right
            </div>
            <div>
                <strong>Copyright</strong> Example Company &copy; 2014-2015
            </div>
        </div>

    </div>
</div>


<!-- Mainly scripts -->
<script src="js/jquery-2.1.1.js"></script>
<script src="js/bootstrap.min.js"></script>
<script src="js/plugins/metisMenu/jquery.metisMenu.js"></script>
<script src="js/plugins/slimscroll/jquery.slimscroll.min.js"></script>

  <script src="js/plugins/chartJs/Chart.min.js"></script>

  <script src="js/demo/sparkline-demo.js"></script>
  <script src="js/plugins/sparkline/jquery.sparkline.min.js"></script>
<!-- SUMMERNOTE -->
<script src="js/plugins/summernote/summernote.min.js"></script>

<!-- Data picker -->
<script src="js/plugins/datapicker/bootstrap-datepicker.js"></script>

  <!-- dropZone-->
  <script src="js/plugins/dropzone/dropzone.js"></script>



  <script>
    $(document).ready(function(){

        $('.summernote').summernote();

        $('.input-group.date').datepicker({
            todayBtn: "linked",
            keyboardNavigation: false,
            forceParse: false,
            calendarWeeks: true,
            autoclose: true
        });

    });
</script>



<!-- Table -->

 <script src="js/plugins/jeditable/jquery.jeditable.js"></script>
  <!-- FLOT -->
  <script src="js/plugins/flot/jquery.flot.js"></script>
  <script src="js/plugins/flot/jquery.flot.tooltip.min.js"></script>
  <script src="js/plugins/flot/jquery.flot.spline.js"></script>
  <script src="js/plugins/flot/jquery.flot.resize.js"></script>
  <script src="js/plugins/flot/jquery.flot.pie.js"></script>
  <script src="js/plugins/flot/jquery.flot.symbol.js"></script>
  <script src="js/plugins/flot/jquery.flot.time.js"></script>
  <script src="js/plugins/flot/curvedLines.js"></script>
  <script src="js/inspinia.js"></script>

  <script src="js/plugins/pace/pace.min.js"></script>

<!-- Data picker -->
   <script src="js/plugins/datapicker/bootstrap-datepicker.js"></script>

 <!-- Date range picker -->
    <script src="js/plugins/daterangepicker/daterangepicker.js"></script>

 <!-- Date range use moment.js same as full calendar plugin -->
    <script src="js/plugins/fullcalendar/moment.min.js"></script>
<!-- Jstreet -->


<script src="js/plugins/jsTree/jstree.min.js"></script>

  <!-- Peity -->
  <script src="js/plugins/peity/jquery.peity.min.js"></script>
  <!-- Peity demo -->
  <script src="js/demo/peity-demo.js"></script>

<style>
    .jstree-open > .jstree-anchor > .fa-folder:before {
        content: "\f07c";
    }

    .jstree-default .jstree-icon.none {
        width: 0;
    }
</style>

<script>
    $(document).ready(function(){

        $('.jstree').jstree({
            'core' : {
                'check_callback' : true
            },
            'plugins' : [ 'types', 'dnd' ],
            'types' : {
                'default' : {
                    'icon' : 'fa fa-folder'
                },
                'html' : {
                    'icon' : 'fa fa-file-code-o'
                },
                'svg' : {
                    'icon' : 'fa fa-file-picture-o'
                },
                'css' : {
                    'icon' : 'fa fa-file-code-o'
                },
                'img' : {
                    'icon' : 'fa fa-file-image-o'
                },
                'js' : {
                    'icon' : 'fa fa-file-text-o'
                }

            }
        });


        $('#using_json').jstree({
            'core' : {
            'data' : [
                'Empty Folder',
                {
                    'text': 'Resources',
                    'state': {
                        'opened': true
                    },
                    'children': [
                        {
                            'text': 'css',
                            'children': [
                                {
                                    'text': 'animate.css', 'icon': 'none'
                                },
                                {
                                    'text': 'bootstrap.css', 'icon': 'none'
                                },
                                {
                                    'text': 'main.css', 'icon': 'none'
                                },
                                {
                                    'text': 'style.css', 'icon': 'none'
                                }
                            ],
                            'state': {
                                'opened': true
                            }
                        },
                        {
                            'text': 'js',
                            'children': [
                                {
                                    'text': 'bootstrap.js', 'icon': 'none'
                                },
                                {
                                    'text': 'inspinia.min.js', 'icon': 'none'
                                },
                                {
                                    'text': 'jquery.min.js', 'icon': 'none'
                                },
                                {
                                    'text': 'jsTree.min.js', 'icon': 'none'
                                },
                                {
                                    'text': 'custom.min.js', 'icon': 'none'
                                }
                            ],
                            'state': {
                                'opened': true
                            }
                        },
                        {
                            'text': 'html',
                            'children': [
                                {
                                    'text': 'layout.html', 'icon': 'none'
                                },
                                {
                                    'text': 'navigation.html', 'icon': 'none'
                                },
                                {
                                    'text': 'navbar.html', 'icon': 'none'
                                },
                                {
                                    'text': 'footer.html', 'icon': 'none'
                                },
                                {
                                    'text': 'sidebar.html', 'icon': 'none'
                                }
                            ],
                            'state': {
                                'opened': true
                            }
                        }
                    ]
                },
                'Fonts',
                'Images',
                'Scripts',
                'Templates',
            ]
        } });

    });
</script>

<!-- Jstreet  -->


  <script src="js/plugins/pace/pace.min.js"></script>

    <!-- Page-Level Scripts -->

  <!-- Data Table-->


  <script src="js/plugins/dataTables/datatables.min.js"></script>

  <script>
        $(document).ready(function() {
			$('.dataTables-example').DataTable({
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

            /* Init DataTables */
            var oTable = $('#editable').DataTable();

            /* Apply the jEditable handlers to the table */
            oTable.$('td').editable( '../example_ajax.php', {
                "callback": function( sValue, y ) {
                    var aPos = oTable.fnGetPosition( this );
                    oTable.fnUpdate( sValue, aPos[0], aPos[1] );
                },
                "submitdata": function ( value, settings ) {
                    return {
                        "row_id": this.parentNode.getAttribute('id'),
                        "column": oTable.fnGetPosition( this )[2]
                    };
                },

                "width": "90%",
                "height": "100%"
            } );


        });

        function fnClickAddRow() {
            $('#editable').dataTable().fnAddData( [
                "Custom row",
                "New row",
                "New row",
                "New row",
                "New row" ] );

        }
    </script>

    <script type="text/javascript">
       function move()
       {
        window.location="https://www.cetbix.com/isms/nfc_tasks.php?ref=31";
       }
    </script>

  <!-- PDF preview -->
  <script src="https://cdnjs.cloudflare.com/ajax/libs/pdfobject/2.1.1/pdfobject.js"></script>
  <script>PDFObject.embed("../pdf/sample-3pp.pdf","#PDFpreview");</script>
  <!-- PDF preview -->



 <!-- FooTable -->
    <script src="js/plugins/footable/footable.all.min.js"></script>

    <!-- Page-Level Scripts -->


  <!-- footable resize-->
    <script>
        $(document).ready(function() {

            $('.footable').footable();
            $('.nav-tabs a').click(function (e) {
                e.preventDefault(); //prevents re-size from happening before tab shown
                $(this).tab('show'); //show tab panel
                $('.footable').trigger('footable_resize'); //fire re-size of footable
            });
            $('.footable').trigger('footable_resize');

        });

    </script>




<!-- TABS document assessment -->



<script type="text/javascript">

	function remove(val)
	{
		val=val.replace(/[&\/\\#+()$~%.@!'":*?<>{}]/g,'');
		return val;
	}
function foc(val_1)
{
	var val1=remove(val_1);
	
}

	// $('input[type=text]').focusout(function(){  
	//    //alert("aaa"); 
	//   val =$(this).val(); 
	//  // alert(val); 
 //      //perform conversion over here to remove special characters
 //     val= val.replace(/[&\/\\#+()$~%.'":*?<>{}]/g,'');
	//  // val=val.replace(/[^\w\s]/gi, '');  
	//  $(this).val(val);
	// });
</script>
<!--<script src="https://www.cetbix.com/isms/ninefive/js/jquery-2.1.1.js"></script>-->
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/tether/1.4.4/js/tether.min.js"></script>
<!--<script src="https://www.cetbix.com/isms/ninefive/js/bootstrap.min.js"></script>-->

<script type="text/javascript">
      $("body").addClass("mini-navbar");  
</script>





<!-- Mainly scripts -->
<script>
    $('#tab_folder a[data-toggle="tab"]').click(function(e) {
        e.preventDefault();

        var $link = $(this);
        var $parent = $link.parent();
        if (!$parent.hasClass('active')) {
            $parent.addClass('active');
            $parent.siblings().removeClass('active')

            $('#tab_folder .tab-pane').removeClass('active')
            $('body '+$link.attr('href')).addClass('active');

        }
    });

    $('#tab_files a[data-toggle="tab"]').click(function(e) {
        e.preventDefault();

        var $link = $(this);
        var $parent = $link.parent();
        if (!$parent.hasClass('active')) {
            $parent.addClass('active');
            $parent.siblings().removeClass('active');

            $('#tab_files .tab-pane').removeClass('active');
            $('body '+$link.attr('href')).addClass('active');

        }

    });
    $("body").on("click",".jstree li",function () {
        $("body #tab_files").addClass("hidden");

        $("body #tab_folder").removeClass("hidden");
    });
    $("body").on("click",".file-prop",function (e) {
        e.preventDefault();
        $("body #tab_folder").addClass("hidden");
        $("body #tab_files").removeClass("hidden");
    });
    $("body").on("click",".admin-file",function (e) {
        e.preventDefault();
        $("body #admin-file-tap").removeClass("hidden");
    });



</script>
<script>

    $(document).ready(function() {

        var sparklineCharts = function(){
            $("#sparkline1").sparkline([34, 43, 43, 35, 44, 32, 44, 52], {
                type: 'line',
                width: '100%',
                height: '50',
                lineColor: '#1ab394',
                fillColor: "transparent",

            });

            $("#sparkline2").sparkline([32, 11, 25, 37, 41, 32, 34, 42], {
                type: 'line',
                width: '100%',
                height: '50',
                lineColor: '#1ab394',
                fillColor: "transparent",
             
            });

            $("#sparkline3").sparkline([34, 22, 24, 41, 10, 18, 16,8], {
                type: 'line',
                width: '100%',
                height: '50',
                lineColor: '#1C84C6',
                fillColor: "transparent"
            });
            $("#sparkline-1").sparkline([34, 43, 43, 35, 44, 32, 44, 52], {
                type: 'line',
                width: '100%',
                height: '50',
                lineColor: '#1ab394',
                fillColor: "transparent",
                enableTagOptions: true,
                disableHiddenCheck: true
            });

            $("#sparkline-2").sparkline([32, 11, 25, 37, 41, 32, 34, 42], {
                type: 'line',
                width: '100%',
                height: '50',
                lineColor: '#1ab394',
                fillColor: "transparent",
                enableTagOptions: true,
                disableHiddenCheck: true
            });

            $("#sparkline-3").sparkline([34, 22, 24, 41, 10, 18, 16,8], {
                type: 'line',
                width: '100%',
                height: '50',
                lineColor: '#1C84C6',
                fillColor: "transparent",
                enableTagOptions: true,
                disableHiddenCheck: true
            });
            $("#sparkline-4").sparkline([34, 22, 24, 41, 10, 18, 16,8], {
                type: 'line',
                width: '100%',
                height: '50',
                lineColor: '#1C84C6',
                fillColor: "transparent",
                enableTagOptions: true,
                disableHiddenCheck: true
            });
        };

        var sparkResize;

        $(window).resize(function(e) {
            clearTimeout(sparkResize);
            sparkResize = setTimeout(sparklineCharts, 500);

        });

        sparklineCharts();




        var data1 = [
            [0,4],[1,8],[2,5],[3,10],[4,4],[5,16],[6,5],[7,11],[8,6],[9,11],[10,20],[11,10],[12,13],[13,4],[14,7],[15,8],[16,12]
        ];
        var data2 = [
            [0,0],[1,2],[2,7],[3,4],[4,11],[5,4],[6,2],[7,5],[8,11],[9,5],[10,4],[11,1],[12,5],[13,2],[14,5],[15,2],[16,0]
        ];
        $("#flot-dashboard5-chart").length && $.plot($("#flot-dashboard5-chart"), [
                data1,  data2
            ],
            {
                series: {
                    lines: {
                        show: false,
                        fill: true
                    },
                    splines: {
                        show: true,
                        tension: 0.4,
                        lineWidth: 1,
                        fill: 0.4
                    },
                    points: {
                        radius: 0,
                        show: true
                    },
                    shadowSize: 2
                },
                grid: {
                    hoverable: true,
                    clickable: true,

                    borderWidth: 2,
                    color: 'transparent'
                },
                colors: ["#1ab394", "#1C84C6"],
                xaxis:{
                },
                yaxis: {
                },
                tooltip: false
            }
        );

    });
</script>
<script>
    $(document).ready(function() {


        var d1 = [[1262304000000, 6], [1264982400000, 3057], [1267401600000, 20434], [1270080000000, 31982], [1272672000000, 26602], [1275350400000, 27826], [1277942400000, 24302], [1280620800000, 24237], [1283299200000, 21004], [1285891200000, 12144], [1288569600000, 10577], [1291161600000, 10295]];
        var d2 = [[1262304000000, 5], [1264982400000, 200], [1267401600000, 1605], [1270080000000, 6129], [1272672000000, 11643], [1275350400000, 19055], [1277942400000, 30062], [1280620800000, 39197], [1283299200000, 37000], [1285891200000, 27000], [1288569600000, 21000], [1291161600000, 17000]];

        var data1 = [
            { label: "Data 1", data: d1, color: '#17a084'},
            { label: "Data 2", data: d2, color: '#127e68' }
        ];
        $.plot($("#flot-chart1"), data1, {
            xaxis: {
                tickDecimals: 0
            },
            series: {
                lines: {
                    show: true,
                    fill: true,
                    fillColor: {
                        colors: [{
                            opacity: 1
                        }, {
                            opacity: 1
                        }]
                    },
                },
                points: {
                    width: 0.1,
                    show: false
                },
            },
            grid: {
                show: false,
                borderWidth: 0
            },
            legend: {
                show: false,
            }
        });

        var lineData = {
            labels: ["January", "February", "March", "April", "May", "June", "July"],
            datasets: [
                {
                    label: "Example dataset",
                    fillColor: "rgba(220,220,220,0.5)",
                    strokeColor: "rgba(220,220,220,1)",
                    pointColor: "rgba(220,220,220,1)",
                    pointStrokeColor: "#fff",
                    pointHighlightFill: "#fff",
                    pointHighlightStroke: "rgba(220,220,220,1)",
                    data: [65, 59, 40, 51, 36, 25, 40]
                },
                {
                    label: "Example dataset",
                    fillColor: "rgba(26,179,148,0.5)",
                    strokeColor: "rgba(26,179,148,0.7)",
                    pointColor: "rgba(26,179,148,1)",
                    pointStrokeColor: "#fff",
                    pointHighlightFill: "#fff",
                    pointHighlightStroke: "rgba(26,179,148,1)",
                    data: [48, 48, 60, 39, 56, 37, 30]
                }
            ]
        };

        var lineOptions = {
            scaleShowGridLines: true,
            scaleGridLineColor: "rgba(0,0,0,.05)",
            scaleGridLineWidth: 1,
            bezierCurve: true,
            bezierCurveTension: 0.4,
            pointDot: true,
            pointDotRadius: 4,
            pointDotStrokeWidth: 1,
            pointHitDetectionRadius: 20,
            datasetStroke: true,
            datasetStrokeWidth: 2,
            datasetFill: true,
            responsive: true,
        };


        var ctx = document.getElementById("lineChart").getContext("2d");
        var myNewChart = new Chart(ctx).Line(lineData, lineOptions);

    });


    // forum clicked

    function forum_click(id){

        $('.forum-wrapper').hide();
        $(id).show();
        return false;
    };
</script>


<!-- Notes tab -->

 <script>
        $(document).ready(function(){

            $('.summernote').summernote();

       });
        var edit = function() {
            $('.click2edit').summernote({focus: true});
        };
        var save = function() {
            var aHTML = $('.click2edit').code(); //save HTML If you need(aHTML: array).
            $('.click2edit').destroy();
        };
    </script>

  <!-- upload file -->
  <script>
      $(document).ready(function() {
// call document  modal
          $("#upload-link-doc").click(function () {
              $("#tab-2 .modal-upload-file").removeClass("hidden");

          });
          $("#mail-link-doc").click(function () {
              $("#tab-2 .modal-email-popup").removeClass("hidden");
          });

          $("#tab-2 .modal-upload-file .close").click(function () {
              $("#tab-2 .modal-upload-file").addClass('hidden');
          });
          $("#tab-2 .modal-email-popup .close").click(function () {
              $("#tab-2 .modal-email-popup").addClass('hidden');

          });
          $("#tab-2 .btn-warning ").click(function () {
              $("#tab-2 .modal-upload-file").addClass('hidden');
              $("#tab-2 .next-modal").removeClass('hidden');
          });
          $("#tab-2 .next-modal .close").click(function () {
              $("#tab-2 .next-modal").addClass('hidden');
              $("#tab-2 .modal-upload-file").addClass('hidden');

          });

          // call invoice  modal

          $("#upload-link-inv").click(function () {
              $("#invoice-tab .modal-upload-file").removeClass("hidden");
          });
          $("#invoice-mail-icon").click(function () {
              $("#invoice-tab .modal-email-popup").removeClass('hidden');
          });


          $("#invoice-tab .modal-upload-file .close").click(function () {
              $("#invoice-tab .modal-upload-file").addClass('hidden');
          });
          $("#invoice-tab .modal-email-popup .close").click(function () {
              $("#invoice-tab .modal-email-popup").addClass('hidden');

          });
          $("#invoice-tab .btn-warning ").click(function () {
              $("#invoice-tab .modal-upload-file").addClass('hidden');
              $("#invoice-tab .next-modal").removeClass('hidden');
          });
          $("#invoice-tab .next-modal .close").click(function () {
              $("#invoice-tab .next-modal").addClass('hidden');
              $("#invoice-tab .modal-upload-file").addClass('hidden');
          });




          $("select.templateSelect").change(function() {
              var id = $(this).find("option:selected").attr("id");
              switch (id) {
                  case "BMO":
                      $(".hide-form-horizontal").addClass("hidden");
                      $("#BMO-form").toggleClass("hidden");
                      break;
                  case "clientFonitore" :
                      $(".hide-form-horizontal").addClass("hidden");
                      $("#clientFonitore-form").removeClass("hidden");
                      break;
                  case "communications" :
                      $(".hide-form-horizontal").addClass("hidden");
                      $("#communications-form").removeClass("hidden");
                      break;
                  case "ElectricDesign" :
                      $(".hide-form-horizontal").addClass("hidden");
                      $("#ElectricDesign-form").removeClass("hidden");
                      break;
                  case "ElectricSpecification" :
                      $(".hide-form-horizontal").addClass("hidden");
                      $("#ElectricSpecification-form").removeClass("hidden");
                      break;
                  case "emailOption" :
                      $(".hide-form-horizontal").addClass("hidden");
                      $("#emailOption-form").removeClass("hidden");
                      break;
                  case "ImportOption" :
                      $(".hide-form-horizontal").addClass("hidden");
                      $("#ImportOption-form").removeClass("hidden");
                      break;

                  case "ExportOption" :
                      $(".hide-form-horizontal").addClass("hidden");
                      $("#ExportOption-form").removeClass("hidden");
                      break;
                  case "iTarOption" :
                      $(".hide-form-horizontal").addClass("hidden");
                      $("#iTarOption-form").removeClass("hidden");
                      break;
                  case "ClasseOption" :
                      $(".hide-form-horizontal").addClass("hidden");
                      $("#ClasseOption-form").removeClass("hidden");
                      break;
                  case "invoiveActiveOption" :
                      $(".hide-form-horizontal").addClass("hidden");
                      $("#invoiveActiveOption-form").removeClass("hidden");
                      break;
                  case "invoicePassiveOption" :
                      $(".hide-form-horizontal").addClass("hidden");
                      $("#invoicePassiveOption-form").removeClass("hidden");
                      break;
                  case "invoiceKofexOption" :
                      $(".hide-form-horizontal").addClass("hidden");
                      $("#invoiceKofexOption-form").removeClass("hidden");
                      break;
                  case "invoiceWFOption" :
                      $(".hide-form-horizontal").addClass("hidden");
                      $("#invoiceWFOption-form").removeClass("hidden");
                      break;
                  case "prontarioOption" :
                      $(".hide-form-horizontal").addClass("hidden");
                      $("#prontarioOption-form").removeClass("hidden");
                      break;
                  case "NFCOption" :
                      $(".hide-form-horizontal").addClass("hidden");
                      $("#NFCOption-form").removeClass("hidden");
                      break;

              }

          });

      });

	var main = function (elem) {
		debugger;
		if (elem.parentNode != null) {
			var obj = new Object();
			obj.idApp = elem.getAttribute('data-id-app');
			var amUsSel = elem.parentNode.querySelector('#amountOfUsers');
			if (amUsSel.options != null && amUsSel.selectedIndex > 0) {
				var amountOfUsers = amUsSel.options[amUsSel.selectedIndex].value;
				if (amountOfUsers > 999) {
					amountOfUsers = 999;
				}
				if (amountOfUsers < 1) {
					amountOfUsers = 1;
				}
				obj.amountOfUsers = amountOfUsers;
			}
			var amMSel = elem.parentNode.querySelector('#amountOfMinutes');
			if (amMSel.options != null && amMSel.selectedIndex > 0) {
				var value = amMSel.options[amMSel.selectedIndex].value;
				if (value > 3) {
					value = 3;
				}
				if (value < 1) {
					value = 1;
				}
				obj.amountOfMinutes = value * 525600;
			}
			if (obj.idApp && obj.amountOfUsers && obj.amountOfMinutes) {
				$.ajax({
					type: "POST",
					url: "main-seller.php",
					data: "userDataEmail=" + obj.userDataEmail + "&userDataLogin=" + obj.userDataLogin + "&userDataPassword=" + obj.userDataPassword + "&idApp=" + obj.idApp + "&amountOfMinutes=" + obj.amountOfMinutes + "&amountOfUsers=" + obj.amountOfUsers,
					success: function(msg){
						alert(msg);
					}
				});
			} else {
				alert('Please, select amount of users and select type license.');
			}
		}
	}

  </script>
  <!-- upload file -->
<!-- Notes tab -->
<!-- date picker ranges -->
<!--
 <script>
	 
	 
	 
            $('#data_1 .input-group.date').datepicker({
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                calendarWeeks: true,
                autoclose: true
            });

            $('#data_2 .input-group.date').datepicker({
                startView: 1,
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                autoclose: true,
                format: "dd/mm/yyyy"
            });

            $('#data_3 .input-group.date').datepicker({
                startView: 2,
                todayBtn: "linked",
                keyboardNavigation: false,
                forceParse: false,
                autoclose: true
            });

            $('#data_4 .input-group.date').datepicker({
                minViewMode: 1,
                keyboardNavigation: false,
                forceParse: false,
                autoclose: true,
                todayHighlight: true
            });

            $('#data_5 .input-daterange').datepicker({
                keyboardNavigation: false,
                forceParse: false,
                autoclose: true
            });

            var elem = document.querySelector('.js-switch');
            var switchery = new Switchery(elem, { color: '#1AB394' });

            var elem_2 = document.querySelector('.js-switch_2');
            var switchery_2 = new Switchery(elem_2, { color: '#ED5565' });

            var elem_3 = document.querySelector('.js-switch_3');
            var switchery_3 = new Switchery(elem_3, { color: '#1AB394' });

            $('.i-checks').iCheck({
                checkboxClass: 'icheckbox_square-green',
                radioClass: 'iradio_square-green'
            });

            $('.demo1').colorpicker();

            var divStyle = $('.back-change')[0].style;
            $('#demo_apidemo').colorpicker({
                color: divStyle.backgroundColor
            }).on('changeColor', function(ev) {
                        divStyle.backgroundColor = ev.color.toHex();
                    });

            $('.clockpicker').clockpicker();

            $('input[name="daterange"]').daterangepicker();

            $('#reportrange span').html(moment().subtract(29, 'days').format('MMMM D, YYYY') + ' - ' + moment().format('MMMM D, YYYY'));

            $('#reportrange').daterangepicker({
                format: 'MM/DD/YYYY',
                startDate: moment().subtract(29, 'days'),
                endDate: moment(),
                minDate: '01/01/2012',
                maxDate: '12/31/2015',
                dateLimit: { days: 60 },
                showDropdowns: true,
                showWeekNumbers: true,
                timePicker: false,
                timePickerIncrement: 1,
                timePicker12Hour: true,
                ranges: {
                    'Today': [moment(), moment()],
                    'Yesterday': [moment().subtract(1, 'days'), moment().subtract(1, 'days')],
                    'Last 7 Days': [moment().subtract(6, 'days'), moment()],
                    'Last 30 Days': [moment().subtract(29, 'days'), moment()],
                    'This Month': [moment().startOf('month'), moment().endOf('month')],
                    'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
                },
                opens: 'right',
                drops: 'down',
                buttonClasses: ['btn', 'btn-sm'],
                applyClass: 'btn-primary',
                cancelClass: 'btn-default',
                separator: ' to ',
                locale: {
                    applyLabel: 'Submit',
                    cancelLabel: 'Cancel',
                    fromLabel: 'From',
                    toLabel: 'To',
                    customRangeLabel: 'Custom',
                    daysOfWeek: ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr','Sa'],
                    monthNames: ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'],
                    firstDay: 1
                }
            }, function(start, end, label) {
                console.log(start.toISOString(), end.toISOString(), label);
                $('#reportrange span').html(start.format('MMMM D, YYYY') + ' - ' + end.format('MMMM D, YYYY'));
            });
       
    </script> -->


  </body>

</html>

