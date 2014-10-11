<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAgencia._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="page-title">
        Inicio
        <small>Sistema de Gestión y Administración de Almacenes</small>
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
        </li>
    </ul>
    

    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption">
                <i class="fa fa-comments"></i>Striped Table
            </div>
            <div class="tools">
                <a href="javascript:;" class="collapse"></a>
                <a href="#portlet-config" data-toggle="modal" class="config"></a>
                <a href="javascript:;" class="reload"></a>
                <a href="javascript:;" class="remove"></a>
            </div>
        </div>
        <div class="portlet-body">
            <div class="table-scrollable">
                <asp:GridView ID="grdTickets" runat="server" Width="911px">
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>

