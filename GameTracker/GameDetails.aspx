<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GameDetails.aspx.cs" Inherits="GameTracker.GameDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">   
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <div class="form-group">
                    <label for="ddlHomeTeam" class="control-label">Home Team: </label>
                    <asp:DropDownList ID="ddlHomeTeam" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="ddlAwayTeam" class="control-label">Away Team: </label>
                    <asp:DropDownList ID="ddlAwayTeam" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">

                </div>
                <div class="form-group">

                </div>
            </div>
        </div>
    </div>
</asp:Content>
