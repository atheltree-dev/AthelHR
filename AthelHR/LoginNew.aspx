<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginNew.aspx.cs" Inherits="AthelHR.LoginNew" %>

<!DOCTYPE html>

<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login</title>
    <%--    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.2/css/all.min.css" />--%>
    <link href='<%= Page.ResolveClientUrl("~/assets/global/plugins/font_awesome5.15.2/css/all.min.css") %>' rel="stylesheet" />
    <link href="<%= Page.ResolveClientUrl("~/assets/global/plugins/bootstrap/css/bootstrap.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="<%= Page.ResolveClientUrl("~/assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css") %>" rel="stylesheet" type="text/css" />
    <link href="spStyles/Login/login.css" rel="stylesheet" />

    <script type="text/javascript">
        var GeneralHelperAjaxUrl = "<%= Page.ResolveClientUrl("~/Helper.aspx") %>" + "/";
    </script>
</head>
<body>
    <div class="row" style="display: none">
        <div class="col-xs-6">


            <div class="form-group form-md-line-input form-md-floating-label has-info">
                <select class="form-control" id="selCompany" onchange="FillBranch();" required>
                    <option value=""></option>
                </select>
                <label for="selCompany">Company</label>
            </div>
        </div>

        <div class="col-xs-6">
            <div class="form-group form-md-line-input form-md-floating-label has-info">
                <select class="form-control" id="selBranch" required>
                    <option value=""></option>
                </select>
                <label for="selBranch">Branch</label>
            </div>


        </div>

    </div>

    <section class="login-section">
        <!-- <div class="overlay"></div> -->
        <!-- Form -->
        <form action="javascript:;" method="POST" class="mainlogin">
            <!-- Form Container -->
            <div class="form">
                <div class="logo">
                    <img src="images/Main-Logo.png" />
                </div>
                <div class="inputBx">
                    <!-- username -->
                    <input type="text" required placeholder="username" name="username" id="txtUserName">
                    <div class="icon"><i class="fas fa-user"></i></div>
                </div>
                <div class="inputBx">
                    <!-- password -->
                    <input type="password" class="password" required placeholder="Password" name="password" id="txtPassword">
                    <div class="icon"><i class="fas fa-lock"></i></div>
                    <div class="showHide"><i class="fas fa-eye"></i></div>
                </div>
                <!-- Radio Buttons -->
                <div class="text">Please Choose Language </div>
                <ul>
                    <li>
                        <!-- Radio button 1-->
                        <input type="radio" name="radio2" id="chkLangAr" />
                        <label for="chkLangAr">Arabic</label>
                        <div class="check"><i class="far fa-hand-point-right"></i></div>
                    </li>

                    <li>
                        <!-- Radio button 2-->
                        <input type="radio" name="radio2" id="chkLangEn" checked />
                        <label for="chkLangEn">English</label>
                        <div class="check"><i class="far fa-hand-point-right"></i></div>
                    </li>
                </ul>
                <!-- Forget Password -->
                <a class="forget" href="" id="forget-password">Forget Password ?</a>
                <!-- Submit Login -->
                <%--                <input type="submit" value="Login">--%>
                <input type="submit" onclick="CheckValidedInputData();" value="Login">
            </div>
        </form>
        <form class="forget-section hidden" action="javascript:;" method="POST">
            <h3>Forget password ?</h3>
            <p>Enter Your-Email Address Below To Reset Your Password</p>
            <div class="inputBx">
                <!-- Email -->
                <input type="email" class="email" required placeholder="email" name="email" id="txtEmail">
                <div class="icon"><i class="fas fa-envelope"></i></div>
            </div>
            <div class="buttons">
                <a href="javascript:;" class="back">Back</a>
                <input id="Submit-btn" type="submit" value="Reset">
            </div>
        </form>
        <div class="footer">Copyright &copy; Athel Tree Company 2016</div>
    </section>


    <script src="<%= Page.ResolveClientUrl("~/spScripts/jquery-1.11.1.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/scripts/GeneralHelper.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/bootbox/bootbox.min.js") %>"> type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/pages/scripts/ui-bootbox.min.js") %>"> type="text/javascript"></script>

    <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/bootstrap/js/bootstrap.min.js") %>" type="text/javascript"></script>
    <script src="<%= Page.ResolveClientUrl("~/assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js") %>" type="text/javascript"></script>


    <script src="spScripts/Login/three.min.js"></script>
    <script src="spScripts/Login/vanta.waves.min.js"></script>
    <script src="spScripts/Login/login.js"></script>
    <script src="Login.js"></script>
</body>
</html>
