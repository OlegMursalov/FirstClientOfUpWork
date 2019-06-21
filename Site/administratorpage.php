<!--  DOCUMENT PAGE -->

<div class="row">
    <div class="col-lg-3">
        <div class="ibox float-e-margins">
			<? include('admin_tabs.php'); ?>
      <!--      <div class="ibox-title">
				
            </div>
             
            <div class="ibox-content">
              
				<? #include('admin_tabs.php'); ?>f

            </div> 
-->
           
					

        </div>
    </div>


    <div class="col-lg-9">
        <div class="ibox float-e-margins">
            <div class="ibox-title">
<!--<button type="button" class="btn btn-primary">Schedule Task</button> -->

                <div class="ibox-tools">
                    <a class="collapse-link">
                        <i class="fa fa-chevron-up"></i>
                    </a>
                    <a class="close-link">
                        <i class="fa fa-times"></i>
                    </a>
                </div>
            </div>


            <div class="ibox-content">
                <!-- Table Grid starts -->

                <div class="row">
                    <div class="col-lg-12">
                        <div class="ibox float-e-margins">


                            <!-- ------------Table--------- -->
                            <div class="row">

                    <div class="col-lg-12">
                        <div class="ibox float-e-margins">
                            
                           
                               <div class="row">
                                    <div class="col-sm-9 m-b-xs">
                                        <div data-toggle="buttons" class="btn-group">
                                          <!--  <label class="btn btn-sm btn-white"> <input type="radio" id="option1" name="options"> Day </label>
                                            <label class="btn btn-sm btn-white active"> <input type="radio" id="option2" name="options"> Week </label>
                                            <label class="btn btn-sm btn-white"> <input type="radio" id="option3" name="options"> Month </label> -->
											<button type="button" class="btn btn-primary">Schedule Task</button>
                                        </div>
                                    </div> 
                                    <div class="col-sm-3">
                                        <div class="input-group"><input type="text" placeholder="Search" class="input-sm form-control"> <span class="input-group-btn">
                                        <button type="button" class="btn btn-sm btn-primary"> Go!</button> </span>
										</div>
                                    </div>
                                </div>
                            <div class="table-responsive">
                                <table class="table table-striped">
                                    <thead>
                                    <tr>

                                        <th>#</th>
										<th>#</th>
                                        <th>Project </th>
                                        <th>Description </th>
                                    
                                        <th>Progress </th>
                                        <th>Task</th>
                                        <th>Start Date</th>
										<th>Next Date</th>
										<th>Status</th>
										<th>Action</th>
                                        <th>*</th>
                                    </tr>
                                    </thead>
                                    <tbody>
                                    <tr>
                                        <td>*</td>
										<td>*</td>
                                        <td><a href="" class="admin-file">Indexing Optimization</a> </td>
                                        <td>Cleans the index from deleted items and company</td>
                                        
                                        <td><span class="pie">0.52/1.561</span></td>
                                        <td>20%</td>
                                        <td>Jul 14, 2013</td>
										<td>Jul 14, 2013</td>
                                        <td>
                                        <span class="label label-success">Success</span>
                                    </td>
                                    <td class="text-right">
                                        <div class="btn-group">
                                            <button class="btn-white btn btn-xs">View</button>
                                            <button class="btn-white btn btn-xs">Edit</button>
                                        </div>
                                    </td>
                                        <td><a href="#"><i class="fa fa-check text-navy"></i></a></td> 
                                    </tr>
                                   
                                  <tr>
                                        <td>*</td>
										<td>*</td>
                                      <td><a href="" class="admin-file">Document Indexing</a> </td>

                                        <td>Performs the creation of the full-text indext</td>
                                        
                                        <td><span class="pie">0.52/1.561</span></td>
                                        <td>20%</td>
                                        <td>Jul 14, 2013</td>
										<td>Jul 14, 2013</td>
									  <td>
                                        <span class="label label-warning">Warning</span>
                                    </td>
                                    <td class="text-right">
                                        <div class="btn-group">
                                            <button class="btn-white btn btn-xs">View</button>
                                            <button class="btn-white btn btn-xs">Edit</button>
                                        </div>
                                    </td>
                                        <td><a href="#"><i class="fa fa-check text-navy"></i></a></td> 
                                    </tr>
                                  
                                  
                                  
                                  
                                    </tbody>
                                </table>
                            </div>
							<?php include('admin_footer_tab.php'); ?>
                       </div>
                  </div>
                    </div>
                </div>
 </div> </div>


			

   
                <!-- Table grid ends -->
            </div>

        </div>
    </div>
</div>
									