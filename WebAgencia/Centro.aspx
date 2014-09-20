<%@ Page Title="Centro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Centro.aspx.cs" Inherits="WebAgencia.Centro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <link rel="stylesheet" type="text/css" href="../../../assets/global/plugins/clockface/css/clockface.css" />
    <link rel="stylesheet" type="text/css" href="../../../assets/global/plugins/bootstrap-datepicker/css/datepicker3.css" />
    <link rel="stylesheet" type="text/css" href="../../../assets/global/plugins/bootstrap-timepicker/css/bootstrap-timepicker.min.css" />
    <link rel="stylesheet" type="text/css" href="../../../assets/global/plugins/bootstrap-colorpicker/css/colorpicker.css" />
    <link rel="stylesheet" type="text/css" href="../../../assets/global/plugins/bootstrap-daterangepicker/daterangepicker-bs3.css" />
    <link rel="stylesheet" type="text/css" href="../../../assets/global/plugins/bootstrap-datetimepicker/css/datetimepicker.css" />
    <!--DataTables-->
    <link rel="stylesheet" type="text/css" href="../../assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.css" />

    <link href="../../assets/admin/layout/css/custom.css" rel="stylesheet" type="text/css" />

    <!-- BEGIN PAGE LEVEL STYLES -->
<link rel="stylesheet" type="text/css" href="../../assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.css"/>
<link rel="stylesheet" type="text/css" href="../../assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css"/>
<link rel="stylesheet" type="text/css" href="../../assets/global/plugins/jquery-tags-input/jquery.tagsinput.css"/>
<link rel="stylesheet" type="text/css" href="../../assets/global/plugins/bootstrap-markdown/css/bootstrap-markdown.min.css">
<link rel="stylesheet" type="text/css" href="../../assets/global/plugins/typeahead/typeahead.css">
<!-- END PAGE LEVEL STYLES -->

    <script type="text/javascript" src="../../../assets/global/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>
    <script type="text/javascript" src="../../../assets/global/plugins/bootstrap-timepicker/js/bootstrap-timepicker.min.js"></script>
    <script type="text/javascript" src="../../../assets/global/plugins/clockface/js/clockface.js"></script>
    <script type="text/javascript" src="../../../assets/global/plugins/bootstrap-daterangepicker/moment.min.js"></script>
    <script type="text/javascript" src="../../../assets/global/plugins/bootstrap-daterangepicker/daterangepicker.js"></script>
    <script type="text/javascript" src="../../../assets/global/plugins/bootstrap-datetimepicker/js/bootstrap-datetimepicker.min.js"></script>
    <script type="text/javascript" src="../../../assets/admin/pages/scripts/components-pickers.js"></script>
    <%--<link href="../../assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" />--%>
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <script type="text/javascript" src="../../assets/global/plugins/select2/select2.min.js"></script>
    <script type="text/javascript" src="../../assets/global/plugins/datatables/media/js/jquery.dataTables.min.js"></script>
    <script type="text/javascript" src="../../assets/global/plugins/datatables/plugins/bootstrap/dataTables.bootstrap.js"></script>

    
<script type="text/javascript" src="../../assets/global/plugins/fuelux/js/spinner.min.js"></script>
<script type="text/javascript" src="../../assets/global/plugins/bootstrap-fileinput/bootstrap-fileinput.js"></script>
<script type="text/javascript" src="../../assets/global/plugins/jquery-inputmask/jquery.inputmask.bundle.min.js"></script>
<script src="../../assets/global/plugins/jquery-tags-input/jquery.tagsinput.min.js" type="text/javascript"></script>

    <script src="../../assets/admin/pages/scripts/table-managed.js"></script>
    <!-- END PAGE LEVEL PLUGINS -->

    <script type="text/javascript">
        $(function () {
            ComponentsPickers.init();
            TableManaged.init();
            var elArray = new Array();
            elArray.primero = marca;
            elArray.segundo = 2;
            var titulos = {
                nombre: "Lector RSS",
            };
            var marca = new Object();
            marca.nombre = "sedal";
         
            $('.SeleccOp').click(function () {

                var name = $(this).parent('td').siblings('td').find('span').html();
                $('#txtNombre ').val(name);
                //alert(name);
            });
            //
            $('#btnListProduct,.SeleccOp').click(function () {
                $('#ListProduct').fadeToggle("");
            });
        });


    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <h3 class="page-title">Centros
        <small>Listado de los Centros</small>
    </h3>

    <ul class="page-breadcrumb breadcrumb">
        <li class="btn-group">
            <button type="button" class="btn blue dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-delay="1000" data-close-others="true">
                <span>Opciones</span><i class="fa fa-angle-down"></i>
            </button>
            <ul class="dropdown-menu pull-right" role="menu">
                <li>
                    <a href="#">Imprimir</a>
                </li>
                <li>
                    <a href="#">Enviar por email</a>
                </li>
                <li class="divider"></li>
                <li>
                    <a href="#">Guardar</a>
                </li>
            </ul>
        </li>
        <li>
            <i class="fa fa-home"></i>
            <a href="#">Inicio</a>
            <i class="fa fa-angle-right"></i>
        </li>
        <li>
            <a href="#">Centro</a>
            <i class="fa fa-angle-right"></i>
        </li>
        <li>
            <a href="#">Mantenimiento</a>
        </li>
    </ul>

    <div class="panel panel-default">
        <div class="form-horizontal form-bordered">
            <div class="form-body">
                
                <div class="form-group">
                    <label class="col-md-3 control-label">Codigo :</label>
                    <div class="col-md-3">
                        <input type="text" class="form-control" />
                    </div>
                    
                </div>
                
                <div class="form-group">
                    <label class="col-md-3 control-label">Descripción :</label>
                    <div class="col-md-9">
                        <input type="text" class="form-control" />
                    </div>
                   
                </div>
                
            </div>

        </div>
    </div>

    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-cube"></i>Centros
            </div>
            <div class="tools">
                <a href="javascript:;" class="collapse"></a>
                <%--<a href="#portlet-config" data-toggle="modal" class="config"></a>--%>
                <a href="javascript:;" class="reload"></a>
                <%--<a href="javascript:;" class="remove"></a>--%>
            </div>
        </div>

        <div class="portlet-body">
            <div class="table-scrollable">
               
            </div>
        </div>
    </div>
</asp:Content>
