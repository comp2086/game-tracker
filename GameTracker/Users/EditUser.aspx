<%@ Page Title="Edit User" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="GameTracker.Users.EditUser" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-3 col-md-6">
                <h1>User Details</h1>
                <br />
                <div class="form-group">
                    <label class="control-label" for="txtUsername">Userame</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtUsername" placeholder="Username" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="txtEmail">First Name</label>
                    <asp:TextBox TextMode="Email" runat="server" CssClass="form-control" ID="txtEmail" placeholder="Email" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="chkAdmin" class="control-label">Admin: </label>
                    <div class="row">
                        <div class="col-md-7">
                            <asp:CheckBox ID="chkAdmin" runat="server" Text="&nbspYes" />
                        </div>
                    </div>
                </div>
                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn btn-warning btn-lg" runat="server" 
                        UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click" />
                    <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="SaveButton_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
