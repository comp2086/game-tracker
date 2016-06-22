<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GameTracker.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="page-header">
                <h2>Sign In</h2>
            </div>
            <div class="col-md-8 col-md-offset-3">
                <div class="row">
                    <div class="col-md-7">
                        <div class="alert alert-danger text-center" id="AlertFlash" runat="server" visible="false">
                            <asp:Label runat="server" ID="StatusLabel" />
                        </div>
                    </div>
                </div>
                <!-- Form -->
                <div class="form-group">
                    <label for="txtUserName" class="control-label">Username: </label>
                    <div class="row">
                        <div class="col-md-7">
                            <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                        </div>
                        <div class="col-md-5">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
                                ErrorMessage='<div class="text-danger" role="alert"><span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> User Name is Required</div>'
                                SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtPassword" class="control-label">Password: </label>
                    <div class="row">
                        <div class="col-md-7">
                            <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                        </div>
                        <div class="col-md-5">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                                ErrorMessage='<div class="text-danger" role="alert"><span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> Password is Required</div>'
                                SetFocusOnError="True" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-7">
                            <div class="text-right">
                                <asp:Button Text="Login" ID="btnLogin" CssClass="btn btn-primary" runat="server" OnClick="btnLogin_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
