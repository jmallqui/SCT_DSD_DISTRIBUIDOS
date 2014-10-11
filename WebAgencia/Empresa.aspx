<%@ Page Title="Empresa" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Empresa.aspx.cs" Inherits="WebAgencia.Empresa" %>
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
            

          
         
        });
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
       <h3 class="page-title">Empresa
        <small>Mantenimiento de la empresa</small>
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
                    <a href="#">Actualizar</a>
                </li>
            </ul>
        </li>
        <li>
            <i class="fa fa-home"></i>
            <a href="#">Inicio</a>
            <i class="fa fa-angle-right"></i>
        </li>
        <li>
            <a href="#">Empresa</a>
            <i class="fa fa-angle-right"></i>
        </li>
        <li>
            <a href="#">Mantenimiento</a>
        </li>
    </ul>
<asp:Button ID="Button1" 
                        runat="server" Text="Grabar" onclick="Button1_Click" />
       <asp:Button ID="Button3" 
                        runat="server" Text="Modificar" onclick="Button3_Click"  />
       <asp:Button ID="Button4" 
                        runat="server" Text="Eliminar" onclick="Button4_Click"  />


       


    <div class="panel panel-default">
        <div class="form-horizontal form-bordered">
            <div class="form-body">
                
                <div class="form-group">
                    <label class="col-md-3 control-label">Codigo :</label>
&nbsp;<div class="col-md-3">
                        &nbsp;<asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox> <asp:Button ID="Button2" 
                        runat="server" Text="Consultar" onclick="Button2_Click" /><br />
                        <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>

                    </div>
                </div>
                 <div class="form-group">
                    <label class="col-md-3 control-label">Empresa :</label>
                    <div class="col-md-9">
                        <asp:TextBox ID="txtEmpresa" runat="server" Width="746px"></asp:TextBox>
                    </div>
                   
                </div>
                 <div class="form-group">
                    <label class="col-md-3 control-label">Ruc :</label>
                    <div class="col-md-3">
                        &nbsp;<asp:TextBox ID="txtruc" runat="server"></asp:TextBox>
                    </div>
                    <label class="col-md-3 control-label">Telefono:</label>
                    <div class="col-md-3">
                        &nbsp;<asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="col-md-3 control-label">Dirección :</label>
                    <div class="col-md-9">
                        &nbsp;<asp:TextBox ID="txtDireccion" runat="server" 
                            Width="719px"></asp:TextBox>
                    </div>
                   
                </div>
            </div>

        </div>
    </div>
     
    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-cube"></i>Tarifa
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




    <asp:GridView ID="gvempresa" runat="server" AutoGenerateColumns="False" CellPadding="4" 
                    ForeColor="#333333" GridLines="None" Width="1512px">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:BoundField DataField="ID_EMPRESA" HeaderText="Codigo">
            <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="EMPRESA" HeaderText="Empresa">
            <ItemStyle Width="400px" />
            </asp:BoundField>
            <asp:BoundField DataField="RUC" HeaderText="RUC">
            <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="DIRECCION" HeaderText="Direccion">
            <ItemStyle Width="400px" />
            </asp:BoundField>
            <asp:BoundField DataField="TELEFONO" HeaderText="Teléfono" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
               
            </div>
        </div>
    </div>
</asp:Content>
