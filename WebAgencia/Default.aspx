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
                <table class="table table-striped table-hover">
                    <thead>
                        <tr>
                            <th>#
                            </th>
                            <th>First Name
                            </th>
                            <th>Last Name
                            </th>
                            <th>Username
                            </th>
                            <th>Status
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>1
                            </td>
                            <td>Mark
                            </td>
                            <td>Otto
                            </td>
                            <td>makr124
                            </td>
                            <td>
                                <span class="label label-sm label-success">Approved </span>
                            </td>
                        </tr>
                        <tr>
                            <td>2
                            </td>
                            <td>Jacob
                            </td>
                            <td>Nilson
                            </td>
                            <td>jac123
                            </td>
                            <td>
                                <span class="label label-sm label-info">Pending </span>
                            </td>
                        </tr>
                        <tr>
                            <td>3
                            </td>
                            <td>Larry
                            </td>
                            <td>Cooper
                            </td>
                            <td>lar
                            </td>
                            <td>
                                <span class="label label-sm label-warning">Suspended </span>
                            </td>
                        </tr>
                        <tr>
                            <td>4
                            </td>
                            <td>Sandy
                            </td>
                            <td>Lim
                            </td>
                            <td>sanlim
                            </td>
                            <td>
                                <span class="label label-sm label-danger">Blocked </span>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

