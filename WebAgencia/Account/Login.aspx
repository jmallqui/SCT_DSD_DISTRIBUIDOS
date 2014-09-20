<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAgencia.Account.Login1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Account</title>

    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" /> 
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link href="../assets/global/plugins/select2/select2.css" rel="stylesheet" type="text/css" />
    <link href="../assets/admin/pages/css/login.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL SCRIPTS -->
    <!-- BEGIN THEME STYLES -->
    <link href="../assets/global/css/components.css" rel="stylesheet" type="text/css" />
    <link href="../assets/global/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="../assets/admin/layout/css/layout.css" rel="stylesheet" type="text/css" />
    <link id="style_color" href="../assets/admin/layout/css/themes/default.css" rel="stylesheet" type="text/css" />
    <link href="../assets/admin/layout/css/custom.css" rel="stylesheet" type="text/css" />
    <!-- END THEME STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />

    <!--[if lt IE 9]>
<script src="../assets/global/plugins/respond.min.js"></script>
<script src="../assets/global/plugins/excanvas.min.js"></script> 
<![endif]-->
    <script src="../assets/global/plugins/jquery-1.11.0.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <!-- IMPORTANT! Load jquery-ui-1.10.3.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->
    <script src="../assets/global/plugins/jquery-ui/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/jquery.cokie.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
    <!-- END CORE PLUGINS -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <script src="../assets/global/plugins/jquery-validation/js/jquery.validate.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../assets/global/plugins/select2/select2.min.js"></script>
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="../assets/global/scripts/metronic.js" type="text/javascript"></script>
    <script src="../assets/admin/layout/scripts/layout.js" type="text/javascript"></script>
    <script src="../assets/admin/layout/scripts/quick-sidebar.js" type="text/javascript"></script>
    <script src="../assets/admin/pages/scripts/login.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL SCRIPTS -->
    <script>

        jQuery(document).ready(function () {
            Metronic.init(); // init metronic core components
            Layout.init(); // init current layout
            QuickSidebar.init() // init quick sidebar
           // Login.init();
                      
        });
    </script>
    <!-- END JAVASCRIPTS -->


    <style type="text/css">
        body {
            background-color: white;
        }

        .login {
           /* background-color: #2A94D6 !important;*/ 
           background-color: #054B77 !important;
           
        }
        .login .content {
             border-radius:5px !important;
            
           box-shadow: 0px 0px 7px;
        }
            .login .content .select2-container {
                border-left: 2px solid #2A94D6 !important;
            }

        .back.btn {
            background-color: #327199;
            color:white;
        }

            .back.btn:hover {
                background-color: #054B77; 
            }
    </style>
</head>
<body class="login">
    <%--<form id="form1" runat="server">--%>

        <div class="logo">
            <%--<a class="form-title m-icon-white"  runat="server" href="~/">
               
                <img src="../Content/img/sgaa-red.png" width="150" />
                
            </a>--%>
            <%--<img src="../Content/img/sgaa-red.png" width="250" />--%>
            <h1 style="color:white;" > Sistema de Control de Boletos</h1>
        </div>
        <!-- END LOGO -->
        <!-- BEGIN SIDEBAR TOGGLER BUTTON -->
        <div class="menu-toggler sidebar-toggler">
        </div>
        <!-- END SIDEBAR TOGGLER BUTTON -->
        <!-- BEGIN LOGIN -->
        <div class="content">
            <!-- BEGIN LOGIN FORM -->
            <form class="login-form" runat="server" >
                <h3 class="form-title">Ingrese a su cuenta. </h3>
                <div class="alert alert-danger display-hide">
                    <button class="close" data-close="alert"></button>
                    <span>Introduzca nombre de usuario y contraseña. </span>
                </div>
                <div class="form-group">
                    <!--ie8, ie9 does not support html5 placeholder, so we just show field title for that-->
                    <label class="control-label visible-ie8 visible-ie9">Usuario</label>
                    <div class="input-icon">
                        <i class="fa fa-user"></i>
                        <asp:TextBox id="txtUser"  placeholder="Usuario" class="form-control placeholder-no-fix" autocomplete="off"  name="username"  runat="server" />
                        
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label visible-ie8 visible-ie9">Password</label>
                    <div class="input-icon">
                        <i class="fa fa-lock"></i>
                        <asp:TextBox id="txtPassword" class="form-control placeholder-no-fix" type="password" autocomplete="off" placeholder="Password" name="password" runat="server" />
                      
                    </div>
                    <div class="control-label">
                        <asp:Label ID="txtFailure" style="color:rgb(243, 99, 99);" Visible="false" Text="Error" runat="server" />
                    </div>
                </div>
                <div class="form-actions ">
                    <label class="checkbox">
                        <input type="checkbox" name="remember" value="1" />
                        Recordar cuenta
                    </label>
                    <asp:Button runat="server" OnClick="LogIn" Text="Iniciar sesión" CssClass="btn back pull-right" />
                    <%--<button runat="server" onclick="LogIn"  type="submit" class="btn back pull-right">
                        Acceder <i class="m-icon-swapright m-icon-white"></i>
                    </button>--%>
                </div>
               
                <div class="forget-password">
                    <h4>Olvido su usuario o password?</h4>
                    <p>
                        has click <a href="javascript:#forget-form;" id="forget-password">Aquí </a>
                        para restablecer su contraseña.D
                </div>
                <%--<div class="create-account">
                    <p>
                        ¿No tienes una cuenta todavía ?&nbsp; <a href="javascript:;" id="register-btn">Crea tu Cuenta </a>
                    </p>
                </div>--%>
            </form>
            <!-- END LOGIN FORM -->
            <!-- BEGIN FORGOT PASSWORD FORM -->
            <form class="forget-form" action="index.html" method="post">
                <h3>Olvide la contraseña ?</h3>
                <p>
                    Introduzca su dirección de correo electrónico a continuación para restablecer la contraseña.
                </p>
                <div class="form-group">
                    <div class="input-icon">
                        <i class="fa fa-envelope"></i>
                        <input class="form-control placeholder-no-fix" type="text" autocomplete="off" placeholder="Email" name="email" />
                    </div>
                </div>
                <div class="form-actions">
                    <button type="button" id="back-btn" class="btn">
                        <i class="m-icon-swapleft"></i> Volver
                    </button>

                    <button type="submit" class="btn back pull-right">
                        Enviar <i class="m-icon-swapright m-icon-white"></i>
                    </button>
                </div>
            </form>
           
        </div>
        <!-- END LOGIN -->
    <%--</form>--%>
</body>
</html>