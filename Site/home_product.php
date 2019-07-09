<?php
	include 'config.php';
	ob_start();
	session_start(); 
    include('https://cetbix.com/headers.php');
    $actual_link = "https://$_SERVER[HTTP_HOST]$_SERVER[REQUEST_URI]";
    $slug1 = explode("products/",$actual_link);
	$slug2 = explode("?", $slug1[1]);
	$slug = $slug2[0];
	//$slug = end($slug);
    //echo '<pre>'; print_r($slug);die;
    if(isset($slug)) {
        $query1 = "select products_template.*,overview.slugname AS 'overview_slug',overview.resources AS 'overview_resources',overview.features AS 'overview_features',overview.top_head AS 'main_heading',overview.small_head AS 'main_subheading',overview.pricing AS 'overview_pricing' from products_template LEFT JOIN overview ON products_template.id=overview.product where products_template.slugname='".$slug."'";
        //echo $query1; 
        if($x = mysqli_query($con,$query1))
        {
            while($data = mysqli_fetch_assoc($x))
            {
				//echo '<pre>'; print_r($data);
				$subheader = stripslashes($data['subheader']);
				$product_category = stripslashes($data['product_category']);
				$slugname = $data['slugname'];
				$product_cat_short_title = stripslashes($data['product_cat_short_title']);
				$product_category_desc = stripslashes($data['product_category_desc']);
				$product_list_main_title = stripslashes($data['product_list_main_title']);
				$product_1_title = stripslashes($data['product_1_title']);
				$product_1_desc = stripslashes($data['product_1_desc']);
				$product_2_desc = stripslashes($data['product_2_desc']);
				$product_2_title = stripslashes($data['product_2_title']);
				$product_3_title = stripslashes($data['product_3_title']);
				$product_3_desc = stripslashes($data['product_3_desc']);
				$product_4_title = stripslashes($data['product_4_title']);
				$product_4_desc = stripslashes($data['product_4_desc']);
				$product_5_title = stripslashes($data['product_5_title']);
				$product_5_desc = stripslashes($data['product_5_desc']);
				$product_6_title = stripslashes($data['product_6_title']);
				$product_6_desc = stripslashes($data['product_6_desc']);
				$product_7_title = stripslashes($data['product_7_title']);
				$product_7_desc = stripslashes($data['product_7_desc']);
				$product_8_title = stripslashes($data['product_8_title']);
				$product_8_desc = stripslashes($data['product_8_desc']);
				$overview_slug = $data['overview_slug'];
				$overview_resources = $data['overview_resources'];
				$overview_features = $data['overview_features'];
				$overview_pricing = $data['overview_pricing'];
				$main_heading = stripslashes($data['main_heading']);
				$main_subheading = stripslashes($data['main_subheading']);
   
				// Files
				$category_featured_img = $data['category_featured_img'];
				$product_1_featured_img = $data['product_1_featured_img'];
				$product_2_featured_img = $data['product_2_featured_img'];
				$product_3_featured_img = $data['product_3_featured_img'];
				$product_4_featured_img = $data['product_4_featured_img'];
				$product_5_featured_img = $data['product_5_featured_img']; 
				$product_6_featured_img = $data['product_6_featured_img'];
				$product_7_featured_img = $data['product_7_featured_img'];
				$product_8_featured_img = $data['product_8_featured_img'];
            }
        }
	}
	//echo $slug.'<br>'. $slugname;
	if($slug == $slugname) {
?>
<div class="base-page__content-wrapper">
   <div>
      <div class="heading-line-component section">
         <div data-component-rohat-rohat="HeadingLineComponent" >
            <div class="heading-line heading-line--bg-image-size-contain heading-line--bg-image-position-right heading-line--bg-image-hide-mobile   " style="background-color: rgba(51,127,111,1);
               ">
               <div class="heading-line__container">
                  <div class="heading-line__text ">
                     <h1 class="heading-line__header">
                        <span class="heading-line__header-text">
                           <?php
                              if($slug==null)
                              {
                                ?>
                           <p class="text-light">Home product</p>
                           <?php }
                              ?> 
                           <?php if($main_heading)
                              {
                              
                              echo $main_heading; 
                              
                              }else{
                               echo $product_category;
                              }?>
                        </span>
                     </h1>
                     <div class="heading-line__subheader">
                        <p><i> <?php echo $main_subheading; ?></i></p>
                     </div>
                  </div>
               </div>
               <div class="heading-line__tabs-container">
                  <div class="heading-line__tabs-overflow">
                     <ul class="heading-line__tabs">
                        <li class="heading-line__tab  heading-line__tab--active">
                           <a class="heading-line__tab-link" href="">
                           <span class="heading-line__tab-link-title">
                           Product
                           </span></a>
                        </li>
                        <?php if($overview_slug){?>
                        <li class="heading-line__tab  ">
                           <a class="heading-line__tab-link" href="<?php echo $siteurl.'/overview/'.$overview_slug ?>">
                           <span class="heading-line__tab-link-title">
                           Overview
                           </span>
                           </a>
                        </li>
                        <?php } if($overview_features){
                           $sqlquery="select slugname from feature where id='".$overview_features."'";
                           $getresource=mysqli_query($con,$sqlquery);
                           $resource_slug=mysqli_fetch_assoc($getresource);
                           //print_r($product_slug);die;
                           ?> 
                        <li class="heading-line__tab ">
                           <a class="heading-line__tab-link" href="<?php echo $siteurl.'/feature/'.$resource_slug['slugname'] ?>">
                           <span class="heading-line__tab-link-title">
                           Features
                           </span>
                           </a>
                        </li>
                        <?php } if($overview_resources){
                           $sqlquery="select slugname from products_resources where id='".$overview_resources."'";
                           $getresource=mysqli_query($con,$sqlquery);
                           $resource_slug=mysqli_fetch_assoc($getresource);
                           //print_r($product_slug);die;
                           ?> 
                        <li class="heading-line__tab">
                           <a class="heading-line__tab-link" href="<?php echo $siteurl.'/resources/'.$resource_slug['slugname'] ?>">
                           <span class="heading-line__tab-link-title">
                           Resources
                           </span>
                           </a>
                        </li>
                        <?php } if($overview_pricing){ 
                           $sqlquery1="select slugname from pricing where id='".$overview_pricing."'";
                           $getresource1=mysqli_query($con,$sqlquery1);
                           $resource_slug1=mysqli_fetch_assoc($getresource1);
                           ?>
                        <li class="heading-line__tab ">
                           <a class="heading-line__tab-link" href="<?php echo $siteurl.'/pricing/'.$resource_slug1['slugname'] ?>">
                           <span class="heading-line__tab-link-title">
                           Pricing
                           </span>
                           </a>
                        </li>
                        <?php } ?>
                     </ul>
                  </div>
               </div>
            </div>
         </div>
      </div>
      <div class="section">
         <div class="new"></div>
      </div>
      <div class="iparys_inherited">
         <div class="heading-content iparsys parsys"></div>
      </div>
   </div>
   <div>
      <div class="aem-Grid aem-Grid--12 aem-Grid--default--12 aem-Grid--tablet--12 aem-Grid--phone--12  ">
         <div class="section-with-background-component parbase aem-GridColumn aem-GridColumn--default--12">
            <div class="section-with-background " style="background-image: linear-gradient(
               rgba(241,241,241,1),
               rgba(241,241,241,1)
               );">
               <div class="section-with-background--bg-image-size-contain section-with-background--bg-image-position-center      " style="background-image: ">
                  <div class="container-component__container--centered container-component__container-spacing--md" style="max-width: 1220px;">
                     <div>
                        <div class="aem-Grid aem-Grid--12 aem-Grid--default--12 aem-Grid--tablet--12 aem-Grid--phone--12  ">
                           <div class="breadcrumbs-component aem-GridColumn--phone--hide aem-GridColumn aem-GridColumn--default--12 aem-GridColumn--offset--phone--0">
                              <div class="breadcrumbs  rohhat-component__component-spacing-above--ss rohhat-component__component-spacing-below--ss">
                                 <ul class="breadcrumbs__list">
                                    <li class="breadcrumbs__item">
                                       <a href="#">
                                       <span>All products</span>
                                       </a>
                                    </li>
                                    <li class="breadcrumbs__item">
                                       <span>
                                       <?php echo $product_category; ?>
                                       </span>
                                    </li>
                                 </ul>
                              </div>
                           </div>
                           <?php if($product_cat_short_title){ ?>
                           <div class="section-title-component aem-GridColumn aem-GridColumn--default--12">
                              <div class="section-title section-title--alignment-left
                                 section-title--only-title rohhat-component__component-spacing-above--md rohhat-component__component-spacing-below--ss">
                                 <div class="section-title__title-block">
                                    <h2 class="section-title__title section-title__title--green">
                                       <?php echo $product_cat_short_title; ?>
                                    </h2>
                                 </div>
                              </div>
                           </div>
                           <?php } if($product_category_desc || $category_featured_img){ ?>
                           <div class="responsivegrid aem-GridColumn--tablet--12 aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--12 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--offset--default--0">
                              <div class="aem-Grid aem-Grid--default--6 aem-Grid--phone--6 aem-Grid--tablet--6  ">
                                 <div class="rohhat-text base-component parbase aem-GridColumn--phone--none aem-GridColumn--phone--6 aem-GridColumn aem-GridColumn--offset--phone--0 aem-GridColumn--tablet--6 aem-GridColumn--default--6">
                                    <div class="rohhat-component__component-spacing-above--md rohhat-component__component-spacing-below--md">
                                       <div class="rohhat-text  ">
                                          <?php echo $product_category_desc; ?>
                                       </div>
                                    </div>
                                 </div>
                              </div>
                           </div>
                           <div class="responsivegrid aem-GridColumn--tablet--12 aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--12 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--offset--default--0">
                              <div class="aem-Grid aem-Grid--default--6 aem-Grid--phone--6 aem-Grid--tablet--6  ">
                                 <div class="image-component parbase aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--6 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--tablet--6 aem-GridColumn--offset--default--0">
                                    <div class="rohhat-image rohhat-image--align-center  rohhat-component__component-spacing-above--md " data-component-rohat="ImageComponent" >
                                       <div class="rohhat-image__view" style="max-width: 960px">
                                          <a class="nyroModal" href="#">
                                          <?php if($category_featured_img){ ?>
                                          <img src="<?php echo $siteurl; ?>/uploader/pageimg/<?php echo $category_featured_img; ?>">
                                          <?php } ?>
                                          </a>
                                       </div>
                                    </div>
                                 </div>
                              </div>
                           </div>
                           <div class="horizontal-delimiter parbase aem-GridColumn aem-GridColumn--default--12">
                              <div class="delimiter  rohhat-component__component-spacing-below--xl">
                                 <div style="width: 0%;
                                    border-bottom: 1px solid rgba(241,241,241,1);"></div>
                              </div>
                           </div>
                           <?php } ?>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
         </div>
         <?php if($product_list_main_title){ ?>
         <div class="container-component parbase aem-GridColumn--tablet--12 aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--12 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--12 aem-GridColumn--offset--phone--0 aem-GridColumn--offset--default--0">
            <div class="rohhat-component__component-spacing-above--xl rohhat-component__component-spacing-below--lg">
               <div class="container-component__container container-component__container--display-block container-component__container--centered container-component__container-spacing--md" style="max-width: 1220px;">
                  <div>
                     <div class="aem-Grid aem-Grid--12 aem-Grid--default--12  ">
                        <div class="section-title-component aem-GridColumn aem-GridColumn--default--12">
                           <div class="section-title section-title--alignment-center
                              section-title--only-title  ">
                              <div class="section-title__title-block">
                                 <h2 class="section-title__title section-title__title--gray">
                                    <?php echo $product_list_main_title; ?>
                                 </h2>
                              </div>
                           </div>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
         </div>
         <?php } ?>
         <div class="container-component parbase aem-GridColumn aem-GridColumn--default--12">
            <div class="rohhat-component__component-spacing-above--ss rohhat-component__component-spacing-below--lg">
               <div class="container-component__container container-component__container--display-block container-component__container--centered container-component__container-spacing--md" style="max-width: 1220px;">
                  <!--started at here--->
                  <div class="container">
                     <div class="row">
                        Home Product
                        
                     </div>
                  </div>
                  <!---end here------>
                  <div>
                     <div class="aem-Grid aem-Grid--12 aem-Grid--default--12 aem-Grid--tablet--12 aem-Grid--phone--12  ">
                        <?php if($product_1_featured_img  || $product_1_title || $product_1_desc){ ?>
                        <div class="responsivegrid aem-GridColumn--tablet--12 aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--12 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--offset--default--0">
                           <div class="aem-Grid aem-Grid--default--6 aem-Grid--tablet--6 aem-Grid--phone--6  ">
                              <div class="image-component parbase aem-GridColumn--offset--tablet--0 aem-GridColumn--phone--hide aem-GridColumn--default--none aem-GridColumn--phone--6 aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--tablet--6 aem-GridColumn--offset--default--0 aem-GridColumn--tablet--hide">
                                 <div class="rohhat-image rohhat-image--align-center   rohhat-component__component-spacing-below--lg" data-component-rohat="ImageComponent" >
                                    <div class="rohhat-image__view" style="max-width: 1040px">
                                       <?php if($product_1_featured_img){ ?>
                                       <img src="<?php echo $siteurl; ?>/uploader/pageimg/<?php echo $product_1_featured_img; ?>">
                                       <?php } ?>
                                    </div>
                                 </div>
                              </div>
                           </div>
                        </div>
                        <div class="responsivegrid aem-GridColumn--tablet--12 aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--12 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--offset--default--0">
                           <div class="aem-Grid aem-Grid--default--6 aem-Grid--tablet--6 aem-Grid--phone--6  ">
                              <div class="rohhat-text base-component parbase aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--6 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--tablet--6 aem-GridColumn--offset--default--0">
                                 <div class=" rohhat-component__component-spacing-below--md">
                                    <div class="rohhat-text rohhat-text--center-allignment ">
                                       <h3 style="margin-left: 0px"><?php echo $product_1_title; ?></h3>
                                       <?php echo $product_1_desc; ?>
                                    </div>
                                 </div>
                              </div>
                           </div>
                        </div>
                        <?php } ?>
                        <?php if($product_2_featured_img  || $product_2_title || $product_2_desc){ ?>
                        <div class="horizontal-delimiter parbase aem-GridColumn aem-GridColumn--default--12">
                           <div class="delimiter rohhat-component__component-spacing-above--lg rohhat-component__component-spacing-below--xl">
                              <div style="width: 100%;
                                 border-bottom: 1px solid rgb(171,171,171);"></div>
                           </div>
                        </div>
                        <div class="responsivegrid aem-GridColumn--tablet--12 aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--12 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--offset--default--0">
                           <div class="aem-Grid aem-Grid--default--6 aem-Grid--tablet--6 aem-Grid--phone--6  ">
                              <div class="rohhat-text base-component parbase aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--6 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--tablet--6 aem-GridColumn--offset--default--0">
                                 <div class=" rohhat-component__component-spacing-below--md">
                                    <div class="rohhat-text rohhat-text--center-allignment ">
                                       <h3  style="margin-left: 0px"><?php echo $product_2_title; ?></h3>
                                       <?php echo $product_2_desc; ?>
                                    </div>
                                 </div>
                              </div>
                           </div>
                        </div>
                        <div class="responsivegrid aem-GridColumn--tablet--12 aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--12 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--offset--default--0">
                           <div class="aem-Grid aem-Grid--default--6 aem-Grid--tablet--6 aem-Grid--phone--6  ">
                              <div class="image-component parbase aem-GridColumn--offset--tablet--0 aem-GridColumn--phone--hide aem-GridColumn--default--none aem-GridColumn--phone--6 aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--tablet--6 aem-GridColumn--offset--default--0 aem-GridColumn--tablet--hide">
                                 <div class="rohhat-image rohhat-image--align-center   rohhat-component__component-spacing-below--lg" data-component-rohat="ImageComponent" >
                                    <div class="rohhat-image__view" style="max-width: 1040px">
                                       <?php if($product_2_featured_img){ ?>
                                       <img src="<?php echo $siteurl; ?>/uploader/pageimg/<?php echo $product_2_featured_img; ?>">
                                       <?php } ?>
                                    </div>
                                 </div>
                              </div>
                           </div>
                        </div>
                        <div class="horizontal-delimiter parbase aem-GridColumn aem-GridColumn--default--12">
                           <div class="delimiter rohhat-component__component-spacing-above--lg rohhat-component__component-spacing-below--xl">
                              <div style="width: 100%;
                                 border-bottom: 1px solid rgb(171,171,171);"></div>
                           </div>
                        </div>
                        <?php } if($product_3_featured_img){ ?>
                        <div class="responsivegrid aem-GridColumn--tablet--12 aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--12 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--offset--default--0">
                           <div class="aem-Grid aem-Grid--default--6 aem-Grid--tablet--6 aem-Grid--phone--6  ">
                              <div class="image-component parbase aem-GridColumn--offset--tablet--0 aem-GridColumn--phone--hide aem-GridColumn--default--none aem-GridColumn--phone--6 aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--tablet--6 aem-GridColumn--offset--default--0 aem-GridColumn--tablet--hide">
                                 <div class="rohhat-image rohhat-image--align-center   rohhat-component__component-spacing-below--lg" data-component-rohat="ImageComponent" >
                                    <div class="rohhat-image__view" style="max-width: 1040px">
                                       <?php if($product_3_featured_img){ ?>
                                       <img src="<?php echo $siteurl; ?>/uploader/pageimg/<?php echo $product_3_featured_img; ?>"><?php } ?>
                                    </div>
                                 </div>
                              </div>
                           </div>
                        </div>
                        <?php } ?>
                        <?php  if($product_3_title || $product_3_desc){ ?>
                        <div class="responsivegrid aem-GridColumn--tablet--12 aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--12 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--offset--default--0">
                           <div class="aem-Grid aem-Grid--default--6 aem-Grid--tablet--6 aem-Grid--phone--6  ">
                              <div class="rohhat-text base-component parbase aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--6 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--tablet--6 aem-GridColumn--offset--default--0">
                                 <div class=" rohhat-component__component-spacing-below--md">
                                    <div class="rohhat-text rohhat-text--center-allignment ">
                                       <h3><?php echo $product_3_title; ?></h3>
                                       <?php echo $product_3_desc; ?>
                                    </div>
                                 </div>
                              </div>
                           </div>
                        </div>
                        <?php } ?><?php if($product_4_title || $product_4_desc || $product_4_featured_img){ ?>
                        <div class="horizontal-delimiter parbase aem-GridColumn aem-GridColumn--default--12">
                           <div class="delimiter rohhat-component__component-spacing-above--lg rohhat-component__component-spacing-below--xl">
                              <div style="width: 100%;
                                 border-bottom: 1px solid rgb(171,171,171);"></div>
                           </div>
                        </div>
                        <div class="responsivegrid aem-GridColumn--tablet--12 aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--12 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--offset--default--0">
                           <div class="aem-Grid aem-Grid--default--6 aem-Grid--tablet--6 aem-Grid--phone--6  ">
                              <div class="rohhat-text base-component parbase aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--6 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--tablet--6 aem-GridColumn--offset--default--0">
                                 <div class=" rohhat-component__component-spacing-below--md">
                                    <div class="rohhat-text rohhat-text--center-allignment ">
                                       <h3><?php echo $product_4_title; ?></h3>
                                       <?php echo $product_4_desc; ?>
                                    </div>
                                 </div>
                              </div>
                           </div>
                        </div>
                        <div class="responsivegrid aem-GridColumn--tablet--12 aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--12 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--offset--default--0">
                           <div class="aem-Grid aem-Grid--default--6 aem-Grid--tablet--6 aem-Grid--phone--6  ">
                              <div class="image-component parbase aem-GridColumn--offset--tablet--0 aem-GridColumn--phone--hide aem-GridColumn aem-GridColumn--offset--phone--0 aem-GridColumn--default--6 aem-GridColumn--tablet--hide">
                                 <div class="rohhat-image rohhat-image--align-center   rohhat-component__component-spacing-below--lg" data-component-rohat="ImageComponent" >
                                    <div class="rohhat-image__view" style="max-width: 1040px">
                                       <?php if($product_4_featured_img){ ?>
                                       <img src="<?php echo $siteurl; ?>/uploader/pageimg/<?php echo $product_4_featured_img; ?>">
                                       <?php } ?>
                                    </div>
                                 </div>
                              </div>
                           </div>
                        </div>
                        <?php } ?><?php if($product_5_title || $product_5_desc || $product_5_featured_img){ ?>
                        <div class="horizontal-delimiter parbase aem-GridColumn aem-GridColumn--default--12">
                           <div class="delimiter rohhat-component__component-spacing-above--lg rohhat-component__component-spacing-below--xl">
                              <div style="width: 100%;
                                 border-bottom: 1px solid rgb(171,171,171);"></div>
                           </div>
                        </div>
                        <div class="responsivegrid aem-GridColumn--tablet--12 aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--12 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--offset--default--0">
                           <div class="aem-Grid aem-Grid--default--6 aem-Grid--tablet--6 aem-Grid--phone--6  ">
                              <div class="image-component parbase aem-GridColumn--offset--tablet--0 aem-GridColumn--phone--hide aem-GridColumn aem-GridColumn--offset--phone--0 aem-GridColumn--default--6 aem-GridColumn--tablet--hide">
                                 <div class="rohhat-image rohhat-image--align-center   rohhat-component__component-spacing-below--lg" data-component-rohat="ImageComponent" >
                                    <div class="rohhat-image__view" style="max-width: 1040px">
                                       <?php if($product_5_featured_img){ ?>
                                       <img src="<?php echo $siteurl; ?>/uploader/pageimg/<?php echo $product_5_featured_img; ?>">
                                       <?php } ?>
                                    </div>
                                 </div>
                              </div>
                           </div>
                        </div>
                        <div class="responsivegrid aem-GridColumn--tablet--12 aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--12 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--offset--default--0">
                           <div class="aem-Grid aem-Grid--default--6 aem-Grid--tablet--6 aem-Grid--phone--6  ">
                              <div class="rohhat-text base-component parbase aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--6 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--tablet--6 aem-GridColumn--offset--default--0">
                                 <div class=" rohhat-component__component-spacing-below--md">
                                    <div class="rohhat-text rohhat-text--center-allignment ">
                                       <h3><?php echo $product_5_title; ?></h3>
                                       <?php echo $product_5_desc; ?>
                                    </div>
                                 </div>
                              </div>
                           </div>
                        </div>
                        <?php } if($product_6_title || $product_6_desc || $product_6_featured_img){ ?>
                        <div class="horizontal-delimiter parbase aem-GridColumn aem-GridColumn--default--12">
                           <div class="delimiter rohhat-component__component-spacing-above--lg rohhat-component__component-spacing-below--xl">
                              <div style="width: 100%;
                                 border-bottom: 1px solid rgb(171,171,171);"></div>
                           </div>
                        </div>
                        <div class="responsivegrid aem-GridColumn--tablet--12 aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--12 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--offset--default--0">
                           <div class="aem-Grid aem-Grid--default--6 aem-Grid--tablet--6 aem-Grid--phone--6  ">
                              <div class="rohhat-text base-component parbase aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--6 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--tablet--6 aem-GridColumn--offset--default--0">
                                 <div class=" rohhat-component__component-spacing-below--md">
                                    <div class="rohhat-text rohhat-text--center-allignment ">
                                       <h3><?php echo $product_6_title; ?></h3>
                                       <?php echo $product_6_desc; ?>
                                       </i></p>
                                    </div>
                                 </div>
                              </div>
                           </div>
                        </div>
                        <div class="responsivegrid aem-GridColumn--tablet--12 aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--12 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--offset--default--0">
                           <div class="aem-Grid aem-Grid--default--6 aem-Grid--tablet--6 aem-Grid--phone--6  ">
                              <div class="image-component parbase aem-GridColumn--offset--tablet--0 aem-GridColumn--phone--hide aem-GridColumn aem-GridColumn--offset--phone--0 aem-GridColumn--default--6 aem-GridColumn--tablet--hide">
                                 <div class="rohhat-image rohhat-image--align-center   rohhat-component__component-spacing-below--lg" data-component-rohat="ImageComponent" >
                                    <div class="rohhat-image__view" style="max-width: 1040px">
                                       <?php if($product_6_featured_img){ ?>
                                       <img src="<?php echo $siteurl; ?>/uploader/pageimg/<?php echo $product_6_featured_img; ?>">
                                       <?php } ?>
                                    </div>
                                 </div>
                              </div>
                           </div>
                        </div>
                        <?php } if($product_7_title || $product_7_desc || $product_7_featured_img){ ?>
                        <div class="horizontal-delimiter parbase aem-GridColumn aem-GridColumn--default--12">
                           <div class="delimiter rohhat-component__component-spacing-above--lg rohhat-component__component-spacing-below--xl">
                              <div style="width: 100%;
                                 border-bottom: 1px solid rgb(171,171,171);"></div>
                           </div>
                        </div>
                        <div class="responsivegrid aem-GridColumn--tablet--12 aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--12 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--offset--default--0">
                           <div class="aem-Grid aem-Grid--default--6 aem-Grid--tablet--6 aem-Grid--phone--6  ">
                              <div class="image-component parbase aem-GridColumn--offset--tablet--0 aem-GridColumn--phone--hide aem-GridColumn aem-GridColumn--offset--phone--0 aem-GridColumn--default--6 aem-GridColumn--tablet--hide">
                                 <div class="rohhat-image rohhat-image--align-center   rohhat-component__component-spacing-below--lg" data-component-rohat="ImageComponent" >
                                    <div class="rohhat-image__view" style="max-width: 1040px">
                                       <?php if($product_7_featured_img){ ?>
                                       <img src="<?php echo $siteurl; ?>/uploader/pageimg/<?php echo $product_7_featured_img; ?>">
                                       <?php } ?>
                                    </div>
                                 </div>
                              </div>
                           </div>
                        </div>
                        <div class="responsivegrid aem-GridColumn--tablet--12 aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--12 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--offset--default--0">
                           <div class="aem-Grid aem-Grid--default--6 aem-Grid--tablet--6 aem-Grid--phone--6  ">
                              <div class="rohhat-text base-component parbase aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--6 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--tablet--6 aem-GridColumn--offset--default--0">
                                 <div class=" rohhat-component__component-spacing-below--md">
                                    <div class="rohhat-text rohhat-text--center-allignment ">
                                       <h3><?php echo $product_7_title; ?></h3>
                                       <?php echo $product_7_desc; ?>
                                       </i></p>
                                    </div>
                                 </div>
                              </div>
                           </div>
                        </div>
                        <?php } if($product_8_title || $product_8_desc || $product_8_featured_img){ ?>
                        <div class="horizontal-delimiter parbase aem-GridColumn aem-GridColumn--default--12">
                           <div class="delimiter rohhat-component__component-spacing-above--lg rohhat-component__component-spacing-below--xl">
                              <div style="width: 100%;
                                 border-bottom: 1px solid rgb(171,171,171);"></div>
                           </div>
                        </div>
                        <div class="responsivegrid aem-GridColumn--tablet--12 aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--12 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--offset--default--0">
                           <div class="aem-Grid aem-Grid--default--6 aem-Grid--tablet--6 aem-Grid--phone--6  ">
                              <div class="rohhat-text base-component parbase aem-GridColumn--offset--tablet--0 aem-GridColumn--default--none aem-GridColumn--phone--none aem-GridColumn--phone--6 aem-GridColumn--tablet--none aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--tablet--6 aem-GridColumn--offset--default--0">
                                 <div class=" rohhat-component__component-spacing-below--md">
                                    <div class="rohhat-text rohhat-text--center-allignment ">
                                       <h3><?php echo $product_8_title; ?></h3>
                                       <?php echo $product_8_desc; ?>
                                       </i></p>
                                    </div>
                                 </div>
                              </div>
                           </div>
                        </div>
                        <div class="image-component parbase aem-GridColumn--tablet--12 aem-GridColumn--offset--tablet--0 aem-GridColumn--phone--hide aem-GridColumn--default--none aem-GridColumn--phone--12 aem-GridColumn aem-GridColumn--default--6 aem-GridColumn--offset--phone--0 aem-GridColumn--offset--default--0 aem-GridColumn--tablet--hide">
                           <div class="rohhat-image rohhat-image--align-center   rohhat-component__component-spacing-below--lg" data-component-rohat="ImageComponent" >
                              <div class="rohhat-image__view" style="max-width: 1040px">
                                 <?php if($product_8_featured_img){ ?>
                                 <img src="<?php echo $siteurl; ?>/uploader/pageimg/<?php echo $product_8_featured_img; ?>">
                                 <?php } ?>
                              </div>
                           </div>
                        </div>
                        <?php } ?>
                     </div>
                  </div>
               </div>
            </div>

            <!-- box section html start here -->
            <div class="container_box">
              <ul class="_box">
                <li>
                 <!-- <div class="imgbox">
                    <a href="#"><img src="images/products.jpg" /></a>
                  </div>-->
                  <h3>lipsum Security</h3>
                  <p>Quick-start endpoint protection with a Security-as-a-Service solution that makes minimal demands on your budget, time and energies. </p>
                  <ul>
                    <li>No extra server or software deployment costs</li>
                    <li>Protection for any endpoint – with free mobile device security</li>
                    <li>Instant protection with predefined security policies</li>
                  </ul>
                </li>
				<?
				$conn = new mysqli($config['DB_HOST'], $config['DB_USERNAME'], $config['DB_PASSWORD'], $config['DB_DATABASE']);
				if (!$conn->connect_error) {
					$query = 'select Id, ImagePath, Title, Description, Price from Applications';
					$result = $conn->query($query);
					if ($result != null && sizeof($result) > 0) {
						while($row = $result->fetch_row()) {
							if ($row != null && sizeof($row) >= 3) {?>
								<li>
									<div class="imgbox">
										<a href="#"><img src="<?=$row[1]?>" /></a>
									</div>
									<h3><?=$row[2]?></h3>
									<p><?=$row[3]?></p>
									<h2 align="center"><b>$<?=$row[4]?></b></h2>
									<p>Enter Desktops and Servers from 1 to 5</p>
									<div class="select_drop">
										<select name="amountOfUsers" id="amountOfUsers">
											<option>Select </option>
											<option value="1">1</option>
                      						<option value="2">2</option>
                      						<option value="3">3</option>
                      						<option value="4">4</option>
                      						<option value="5">5</option>
                    					</select>
										<select name="amountOfMinutes" id="amountOfMinutes">
											<option>Select License Year</option>
											<option value="1">1 year</option>
											<option value="2">2 year</option>
											<option value="3">3 year</option>
										</select>
										<select name="languageForApp" id="languageForApp">
											<option>Select language for app</option>
											<option value="1">English</option>
											<option value="2">German</option>
											<option value="3">French</option>
										</select>
									</div>
									<a href="#" class="btn" data-id-app="<?=$row[0]?>" onclick="buyApp(this);">Buy (select license year and amount)</a></br>
									<a href="#" class="btn" data-id-app="<?=$row[0]?>" onclick="buyApp(this, { amountOfUsers: Number.MAX_SAFE_INTEGER, amountOfMinutes: 10080 });">Trial for seven days for all</a></br>
									<a href="#" class="btn" data-id-app="<?=$row[0]?>" onclick="buyApp(this, { amountOfUsers: 1, amountOfMinutes: Number.MAX_SAFE_INTEGER });">Buy full for one</a>
								</li>
							<?}
						}
					}
				}?>
                <li>
                  <div class="imgbox">
                    <a href="#"><img src="https://www.cetbix.com/uploader/pageimg/classificationpolicy.jpeg" /></a>
                  </div>
                  <h3>lipsum Endpoint Security</h3>
                  <p>Quick-start endpoint protection with a Security-as-a-Service .</p>
					<h2 align="center"><b>$1.00*</b></h2>
					<p>Enter Desktops and Servers from 10 to 100</p>
                  <div class="select_drop">
                    <select>
                      <option>Select </option>
                      <option value="2019">1</option>
                      <option value="2019">2</option>
                      <option value="2019">3</option>
                      <option value="2019">4</option>
                      <option value="2019">5</option>
                    </select>
                    <select>
                      <option>Select License Year</option>
                      <option value="1">1 year</option>
                      <option value="2">2 year</option>
                      <option value="3">3 year</option>
                    
                    </select>
                  </div>
                   <a href="#" class="btn">Buy</a><br />
					<a href="#" class="btn">Try for 7 days</a>
                </li>
                 <li>
                  <div class="imgbox">
                    <a href="#"><img src="https://www.cetbix.com/uploader/pageimg/classificationpolicy.jpeg" /></a>
                  </div>
                  <h3>lipsum Endpoint Security</h3>
                  <p>Quick-start endpoint protection with a Security-as-a-Service .</p>
					<h2 align="center"><b>$1.00*</b></h2>
					<p>Enter Desktops and Servers from 10 to 100</p>
                 <div class="select_drop">
                    <select>
                      <option>Select </option>
                      <option value="2019">1</option>
                      <option value="2019">2</option>
                      <option value="2019">3</option>
                      <option value="2019">4</option>
                      <option value="2019">5</option>
                    </select>
                    <select>
                      <option>Select License Year</option>
                      <option value="1">1 year</option>
                      <option value="2">2 year</option>
                      <option value="3">3 year</option>
                    
                    </select>
                  </div>
                   <a href="#" class="btn">Buy</a><br />
					<a href="#" class="btn">Try for 7 days</a>
                </li>
              </ul>
              <ul class="_box">
                <li>
                  <div class="imgbox">
                    <a href="#"><img src="https://www.cetbix.com/uploader/pageimg/classificationpolicy.jpeg" /></a>
                  </div>
                  <h3>lipsum Endpoint Security</h3>
                  <p>Quick-start endpoint protection with a Security-as-a-Service .</p>
					<h2 align="center"><b>$1.00*</b></h2>
					<p>Enter Desktops and Servers from 10 to 100</p>
                  <div class="select_drop">
                    <select>
                      <option>Select </option>
                      <option value="2019">1</option>
                      <option value="2019">2</option>
                      <option value="2019">3</option>
                      <option value="2019">4</option>
                      <option value="2019">5</option>
                    </select>
                    <select>
                      <option>Select License Year</option>
                      <option value="1">1 year</option>
                      <option value="2">2 year</option>
                      <option value="3">3 year</option>
                    
                    </select>
                  </div>
                   <a href="#" class="btn">Buy</a><br />
					<a href="#" class="btn">Try for 7 days</a>
                </li>
                <li>
                  <div class="imgbox">
                    <a href="#"><img src="https://www.cetbix.com/uploader/pageimg/classificationpolicy.jpeg" /></a>
                  </div>
                  <h3>lipsum Endpoint Security</h3>
                  <p>Quick-start endpoint protection with a Security-as-a-Service .</p>
					<h2 align="center"><b>$1.00*</b></h2>
					<p>Enter Desktops and Servers from 10 to 100</p>
                <div class="select_drop">
                    <select>
                      <option>Select </option>
                      <option value="2019">1</option>
                      <option value="2019">2</option>
                      <option value="2019">3</option>
                      <option value="2019">4</option>
                      <option value="2019">5</option>
                    </select>
                    <select>
                      <option>Select License Year</option>
                      <option value="1">1 year</option>
                      <option value="2">2 year</option>
                      <option value="3">3 year</option>
                    
                    </select>
                  </div>
                   <a href="#" class="btn">Buy</a><br />
					<a href="#" class="btn">Try for 7 days</a>
                </li>
                 <li>
                  <div class="imgbox">
                    <a href="#"><img src="https://www.cetbix.com/uploader/pageimg/classificationpolicy.jpeg" /></a>
                  </div>
                  <h3>lipsum Endpoint Security</h3>
                  <p>Quick-start endpoint protection with a Security-as-a-Service .</p>
					<h2 align="center"><b>$1.00*</b></h2>
					<p>Enter Desktops and Servers from 10 to 100</p>
                 <div class="select_drop">
                    <select>
                      <option>Select </option>
                      <option value="2019">1</option>
                      <option value="2019">2</option>
                      <option value="2019">3</option>
                      <option value="2019">4</option>
                      <option value="2019">5</option>
                    </select>
                    <select>
                      <option>Select License Year</option>
                      <option value="1">1 year</option>
                      <option value="2">2 year</option>
                      <option value="3">3 year</option>
                    
                    </select>
                  </div>
                   <a href="#" class="btn">Buy</a><br />
					<a href="#" class="btn">Try for 7 days</a>
                </li>
              </ul>
            </div>
            <!-- box section html end here -->
            
         </div>
      </div>
   </div>
</div>
<?php include('https://cetbix.com/footer.php'); 
   }
   else{
       header('location:../404.php');
   }
   ?>
<style type="text/css">
   /*.rohhat-text ul{
   padding-left: 0px;
   }*/
</style>
<script type="text/javascript">
	// COMMON FUNCTION!!!
	// Transfer to footer!
	var buyApp = function (elem, info) {
		debugger;
		if (elem.parentNode != null) {
			var obj = new Object();
			obj.idApp = elem.getAttribute('data-id-app');
			if (info != null) {
				obj.amountOfUsers = info.amountOfUsers;
				obj.amountOfMinutes = info.amountOfMinutes;
			} else {
				var amUsSel = elem.parentNode.querySelector('#amountOfUsers');
				if (amUsSel.options != null && amUsSel.selectedIndex > 0) {
					var amountOfUsers = amUsSel.options[amUsSel.selectedIndex].value;
					if (amountOfUsers > 5000) {
						amountOfUsers = 5000;
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
			}
			if (obj.idApp && obj.amountOfUsers && obj.amountOfMinutes) {
				$.ajax({
					type: "POST",
					url: "main-seller.php",
					data: "idApp=" + obj.idApp + "&amountOfMinutes=" + obj.amountOfMinutes + "&amountOfUsers=" + obj.amountOfUsers,
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