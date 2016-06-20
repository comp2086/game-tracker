<%@ Page Title="Team Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TeamDetails.aspx.cs" Inherits="GameTracker.TeamDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="page-header">
                <h2>Team Details</h2>
            </div>
            <div class="col-md-8 col-md-offset-3">
                <!-- Form -->
                <div class="form-group">
                    <label for="txtTeamName" class="control-label">Team Name: </label>
                    <div class="row">
                        <div class="col-md-7">
                            <asp:TextBox ID="txtTeamName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-5">
                            Validate
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtTeamDescription" class="control-label">Team Description: </label>
                    <div class="row">
                        <div class="col-md-7">
                            <asp:TextBox ID="txtTeamDescription" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-5">
                            Validate
                        </div>
                    </div>
                </div>
                <div class="text-right">
                    <div class="row">
                        <div class="col-md-7">
                            <asp:Button Text="Cancel" ID="btnCancel" CssClass="btn btn-default" runat="server"
                                UseSubmitBehavior="false" CausesValidation="false" OnClick="btnCancel_Click" />
                            <asp:Button Text="Save" ID="btnSave" CssClass="btn btn-primary" runat="server" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
