<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GameTracker.Login" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-8 col-md-offset-3">
                <!-- Form -->
                <div class="form-group">
                    <label for="txtEmail" class="control-label">Email: </label>
                    <div class="row">
                        <div class="col-md-9">
                            <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            Validate
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtPassword" class="control-label">Password: </label>
                    <div class="row">
                        <div class="col-md-9">
                             <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            Validate
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-9">
                            <div class="text-right">
                                <asp:Button Text="Login" ID="btnLogin" CssClass="btn btn-primary btn-lg" runat="server" OnClick="btnLogin_Click"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
