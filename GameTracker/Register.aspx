<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GameTracker.Register" %>
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
                    <label for="txtFirstName" class="control-label">First Name: </label>
                    <div class="row">
                        <div class="col-md-9">
                            <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            Validate
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtLastName" class="control-label">Last Name: </label>
                    <div class="row">
                        <div class="col-md-9">
                            <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            Valdiate
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
                    <label for="chkAdmin" class="control-label">Admin: </label>
                    <div class="row">
                        <div class="col-md-9">
                           <asp:CheckBox ID="chkAdmin" runat="server"/>
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
                                <asp:Button Text="Cancel" ID="btnCancel" CssClass="btn btn-warning btn-lg" runat="server"
                                    UseSubmitBehavior="false" CausesValidation="false" OnClick="btnCancel_Click" />
                                <asp:Button Text="Register" ID="btnRegister" CssClass="btn btn-primary btn-lg" runat="server" OnClick="btnRegister_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
