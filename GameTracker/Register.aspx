<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="GameTracker.Register" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="page-header">
                <h2>Sign Up</h2>
            </div>
            <div class="col-md-8 col-md-offset-3">
                <div class="row">
                    <div class="col-md-7">
                        <div class="alert alert-danger text-center" id="AlertFlash" runat="server" visible="false">
                            <asp:Label runat="server" ID="lblStatus" />
                        </div>
                    </div>
                </div>
                <!-- Form -->
                <div class="form-group">
                    <label for="txtFirstName" class="control-label">Username: </label>
                    <div class="row">
                        <div class="col-md-7">
                            <asp:TextBox ID="txtUserName" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                        </div>
                        <div class="col-md-5">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUserName"
                                ErrorMessage='<div class="text-danger" role="alert"><span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> Username is Required</div>'
                                 SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtEmail" class="control-label">Email: </label>
                    <div class="row">
                        <div class="col-md-7">
                            <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="form-control" runat="server" required="true"></asp:TextBox>
                        </div>
                        <div class="col-md-5">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                                ErrorMessage='<div class="text-danger" role="alert"><span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> Email is Required</div>'
                                 SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtPassword" class="control-label">Password: </label>
                    <div class="row">
                        <div class="col-md-7">
                            <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-5">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPassword"
                                ErrorMessage='<div class="text-danger" role="alert"><span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> Password is Required</div>'
                                 SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtConfirmPassword" class="control-label">Confirm Password: </label>
                    <div class="row">
                        <div class="col-md-7">
                            <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" ID="txtConfirmPassword" placeholder="Confirm Password" required="true" TabIndex="0"></asp:TextBox>
                        </div>
                        <div class="col-md-5">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtConfirmPassword"
                                ErrorMessage='<div class="text-danger" role="alert"><span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> Password Confirmation is Required</div>'
                                 SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ErrorMessage='<div class="text-danger" role="alert"><span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> Passwords do not match</div>'
                                Type="String" Operator="Equal" ControlToValidate="txtConfirmPassword" runat="server"
                                ControlToCompare="txtPassword" SetFocusOnError="True" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="chkAdmin" class="control-label">Admin: </label>
                    <div class="row">
                        <div class="col-md-7">
                            <asp:CheckBox ID="chkAdmin" runat="server" Text="&nbspYes" />
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-7">
                            <div class="text-right">
                                <asp:Button Text="Cancel" ID="btnCancel" CssClass="btn btn-default" runat="server"
                                    UseSubmitBehavior="false" CausesValidation="false" OnClick="btnCancel_Click" />
                                <asp:Button Text="Register" ID="btnRegister" CssClass="btn btn-primary" runat="server" OnClick="btnRegister_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
