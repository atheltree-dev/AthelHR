<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_Old.aspx.cs" Inherits="PharmaERP.Login_Old" %>

<!DOCTYPE html>

<html lang="en">
    <!--<![endif]-->
    <!-- BEGIN HEAD -->

    <head>
        <meta charset="utf-8" />
        <title>AthelTree ERP Application</title>
        <meta http-equiv="X-UA-Compatible" content="IE=edge">
        <meta content="width=device-width, initial-scale=1" name="viewport" />
        <%--<meta content="#1 selling multi-purpose bootstrap admin theme sold in themeforest marketplace packed with angularjs, material design, rtl support with over thausands of templates and ui elements and plugins to power any type of web applications including saas and admin dashboards. Preview page of Theme #1 for "--%>
            <%--name="description" />--%>
        <meta content="" name="PharmaIT" />
        <!-- BEGIN GLOBAL MANDATORY STYLES -->
        <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
        <link href="<%= Page.ResolveClientUrl("~/assets/global/plugins/font-awesome/css/font-awesome.min.css") %>" rel="stylesheet" type="text/css" />
        <link href="<%= Page.ResolveClientUrl("~/assets/global/plugins/simple-line-icons/simple-line-icons.min.css") %>" rel="stylesheet" type="text/css" />
        <link href="<%= Page.ResolveClientUrl("~/assets/global/plugins/bootstrap/css/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
        <link href="<%= Page.ResolveClientUrl("~/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css") %>" rel="stylesheet" type="text/css" />
        <!-- END GLOBAL MANDATORY STYLES -->
        <!-- BEGIN PAGE LEVEL PLUGINS -->
        <link href="<%= Page.ResolveClientUrl("~/assets/global/plugins/select2/css/select2.min.css") %>" rel="stylesheet" type="text/css" />
        <link href="<%= Page.ResolveClientUrl("~/assets/global/plugins/select2/css/select2-bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
        <!-- END PAGE LEVEL PLUGINS -->
        <!-- BEGIN THEME GLOBAL STYLES -->
        <link href="<%= Page.ResolveClientUrl("~/assets/global/css/components-md.min.css") %>" rel="stylesheet" id="style_components" type="text/css" />
        <link href="<%= Page.ResolveClientUrl("~/assets/global/css/plugins-md.min.css") %>" rel="stylesheet" type="text/css" />
        <!-- END THEME GLOBAL STYLES -->
        <!-- BEGIN PAGE LEVEL STYLES -->
        <link href="<%= Page.ResolveClientUrl("~/assets/pages/css/login-5.min.css") %>" rel="stylesheet" type="text/css" />

        

        <!-- END PAGE LEVEL STYLES -->
        <!-- BEGIN THEME LAYOUT STYLES -->

        <!-- END THEME LAYOUT STYLES -->
        <link rel="shortcut icon" href="favicon.ico" /> 
        
         <script type="text/javascript">
             var GeneralHelperAjaxUrl = "<%= Page.ResolveClientUrl("~/Helper.aspx") %>" + "/";
         </script>
        <style type="text/css">
            .user-login-5 .login-container>.login-content>.login-form .form-control
            {width:100%;padding:5px 0;border:#a0a9b4;border-bottom:1px solid;color:#868e97;font-size:14px;margin-bottom:30px}
          
        </style>
    </head>
    <!-- END HEAD -->

<body class=" login">
        <!-- BEGIN : LOGIN PAGE 5-2 -->
        <div class="user-login-5">
            <div class="row bs-reset">
                <div class="col-md-6 login-container bs-reset">
                    <img class="login-logo login-6" src="<%= Page.ResolveClientUrl("~/assets/pages/img/login/login-invert.png") %>" />
                    <div class="login-content">
                        <h1>Login Screen</h1>
                        <%--<p> Lorem ipsum dolor sit amet, coectetuer adipiscing elit sed diam nonummy et nibh euismod aliquam erat volutpat. Lorem ipsum dolor sit amet, coectetuer adipiscing. </p>--%>
                        <form action="javascript:;" class="login-form" method="post">
                            <div class="alert alert-danger display-hide">
                                <button class="close" data-close="alert"></button>
                                <span>Enter any username and password. </span>
                            </div>
                            

                            <div class="row">
                                <div class="col-xs-6">
                                    <input class="form-control form-control-solid placeholder-no-fix form-group" type="text" autocomplete="off" placeholder="Username" name="username" id="txtUserName" required/> </div>
                                <div class="col-xs-6">
                                    <input class="form-control form-control-solid placeholder-no-fix form-group" type="password" autocomplete="off" placeholder="Password" name="password" id="txtPassword" required/> </div>
                            </div>
                            
                            <div class="row">
                                  <div class="col-xs-6">
                                      

                                            <div class="form-group form-md-line-input form-md-floating-label has-info">
                                                <select class="form-control" id="selCompany" onchange="FillBranch();" required>
                                                    <option value=""></option>
                                                    <%--<option value="1">Option 1</option>
                                                    <option value="2">Option 2</option>
                                                    <option value="3">Option 3</option>
                                                    <option value="4">Option 4</option>--%>
                                                </select>
                                                <label for="selCompany">Company</label>
                                            </div>
                                        </div>

                                <div class="col-xs-6">
                                        <div class="form-group form-md-line-input form-md-floating-label has-info">
                                                    <select class="form-control" id="selBranch"  required>
                                                        <option value=""></option>
                                                        <%--<option value="1">Option 1</option>
                                                        <option value="2">Option 2</option>
                                                        <option value="3">Option 3</option>
                                                        <option value="4">Option 4</option>--%>
                                                    </select>
                                                    <label for="selBranch">Branch</label>
                                         </div>
                                    

                                       </div>
                                      
                           </div>
                            
                            <div class="row">
                                <div class="col-sm-12">
                                  <div class="form-group form-md-radios">
                                                                      <label>Language</label>
                                                                        <div class="md-radio-inline">
                                                                            <div class="md-radio">
                                                                                <input type="radio" id="chkLangEn" name="radio2"  class="md-radio" checked >
                                                                                <label for="chkLangEn">
                                                                                    <span></span>
                                                                                    <span class="check"></span>
                                                                                    <span class="box"></span>English</label>
                                                                            </div>
                                                                            <div class="md-radio">
                                                                                <input type="radio" id="chkLangAr" name="radio2" class="md-radio" >
                                                                                <label for="chkLangAr">
                                                                                    <span></span>
                                                                                    <span class="check"></span>
                                                                                    <span class="box"></span>Arabic</label>
                                                                            </div>
                                                                            
                                                                        </div>

                                                                </div>
                                 </div>
                            </div>
                            

                            <div class="row">
                                <div class="col-sm-4">
                                    <label class="rememberme mt-checkbox mt-checkbox-outline">
                                        <input type="checkbox" name="remember" id="ChkRememberMe"  value="1" /> Remember me
                                        <span></span>
                                    </label>
                                </div>
                                <div class="col-sm-8 text-right">
                                    <div class="forgot-password">
                                        <a href="javascript:;" id="forget-password" class="forget-password">Forgot Password?</a>
                                    </div>
                                    <button class="btn blue" type="submit" onclick="CheckValidedInputData();">Sign In</button>
                                    <input type="button" id="testsign" onclick="createUser();"/>
                                </div>
                            </div>
                        </form>
                        <!-- BEGIN FORGOT PASSWORD FORM -->
                        <form class="forget-form" action="javascript:;" method="post">
                            <h3>Forgot Password ?</h3>
                            <p> Enter your e-mail address below to reset your password. </p>
                            <div class="form-group">
                                <input class="form-control placeholder-no-fix" type="text" autocomplete="off" placeholder="Email" name="email" /> </div>
                            <div class="form-actions">
                                <button type="button" id="back-btn" class="btn blue btn-outline">Back</button>
                                <button type="button" class="btn blue uppercase pull-right">Submit</button>
                            </div>
                        </form>
                        <!-- END FORGOT PASSWORD FORM -->
                    </div>
                    <div class="login-footer">
                        <div class="row bs-reset">
                           <%-- <div class="col-xs-5 bs-reset">
                                <ul class="login-social">
                                    <li>
                                        <a href="javascript:;">
                                            <i class="icon-social-facebook"></i>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <i class="icon-social-twitter"></i>
                                        </a>
                                    </li>
                                    <li>
                                        <a href="javascript:;">
                                            <i class="icon-social-dribbble"></i>
                                        </a>
                                    </li>
                                </ul>
                            </div>--%>
                            <div class="col-xs-7 bs-reset">
                                <div class="login-copyright text-right">
                                    <p>Copyright &copy; Athel Tree Company 2016</p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-6 bs-reset">
                    <div class="login-bg"> </div>
                </div>
            </div>
        </div>
        <!-- END : LOGIN PAGE 5-2 -->
        <!--[if lt IE 9]>
<script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/respond.min.js") %>"></script>
<script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/excanvas.min.js") %>"></script> 
<script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/ie8.fix.min.js") %>"></script> 
<![endif]-->
        <!-- BEGIN CORE PLUGINS -->
   
        <link href="<%= Page.ResolveClientUrl("~/spStyles/Jquery_ui.css") %>" rel="stylesheet" />
        <link href="<%= Page.ResolveClientUrl("~/spStyles/jquery-ui.min.css") %>" rel="stylesheet" />

        <link href="<%= Page.ResolveClientUrl("~/spStyles/chosen.min.css") %>" rel="stylesheet" />

        <script src="<%= Page.ResolveClientUrl("~/spScripts/jquery-1.11.1.min.js") %>" type="text/javascript"></script>
        <script src="<%= Page.ResolveClientUrl("~/spScripts/jquery-ui.min.js") %>" type="text/javascript"></script>
        <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/respond.min.js") %>"></script>
        <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/excanvas.min.js") %>"></script> 
        <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/ie8.fix.min.js") %>"></script> 
        <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/jquery.min.js") %>" type="text/javascript"></script>
        <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/bootstrap/js/bootstrap.min.js") %>" type="text/javascript"></script>
        <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/js.cookie.min.js") %>" type="text/javascript"></script>
        <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js") %>" type="text/javascript"></script>
        <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/jquery.blockui.min.js") %>" type="text/javascript"></script>
        <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js") %>" type="text/javascript"></script>
        <!-- END CORE PLUGINS -->
        <!-- BEGIN PAGE LEVEL PLUGINS -->
        <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/jquery-validation/js/jquery.validate.min.js") %>" type="text/javascript"></script>
        <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/jquery-validation/js/additional-methods.min.js") %>" type="text/javascript"></script>
        <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/select2/js/select2.full.min.js") %>" type="text/javascript"></script>
        <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/backstretch/jquery.backstretch.min.js") %>" type="text/javascript"></script>

        <script src="<%= Page.ResolveClientUrl("~/scripts/GeneralHelper.js") %>" type="text/javascript"></script>
        <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/bootbox/bootbox.min.js") %>"> type="text/javascript"></script>
      
        <script src="<%= Page.ResolveClientUrl("~/Login_Old.js") %>"></script>

      

        <!-- END PAGE LEVEL PLUGINS -->
        <!-- BEGIN THEME GLOBAL SCRIPTS -->
        <script src="<%= Page.ResolveClientUrl("~/assets/global/scripts/app.min.js") %>" type="text/javascript"></script>
        <!-- END THEME GLOBAL SCRIPTS -->
        <!-- BEGIN PAGE LEVEL SCRIPTS -->
        <script src="<%= Page.ResolveClientUrl("~/assets/pages/scripts/login-5.min.js") %>" type="text/javascript"></script>
        <script src="<%= Page.ResolveClientUrl("~/assets/pages/scripts/ui-bootbox.min.js") %>"> type="text/javascript"></script>
        <!-- END PAGE LEVEL SCRIPTS -->
        <!-- BEGIN THEME LAYOUT SCRIPTS -->
        <!-- END THEME LAYOUT SCRIPTS -->

      

    </body>

</html>
