<%@ Page Title="Team Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TeamDetails.aspx.cs" Inherits="GameTracker.TeamDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <div class="form-group">
                    <label for="txtTeamName" class="control-label">Team Name: </label>
                    <asp:TextBox ID="txtTeamName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtTeamDescription" class="control-label">Team Description: </label>
                    <asp:TextBox ID="txtTeamDescription" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="text-right">
                    <asp:Button Text="Cancel" ID="btnCancel" CssClass="btn btn-warning btn-lg" runat="server" 
                        UseSubmitBehavior="false" CausesValidation="false" OnClick="btnCancel_Click" />
                    <asp:Button Text="Save" ID="btnSave" CssClass="btn btn-primary btn-lg" runat="server" OnClick="btnSave_Click" />
                </div>             
            </div>
        </div>
    </div>
</asp:Content>
