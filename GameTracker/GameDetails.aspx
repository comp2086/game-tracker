﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GameDetails.aspx.cs" Inherits="GameTracker.GameDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">   
    <div class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <div class="form-group">
                    <label for="txtGameName" class="control-label">Game Name: </label>
                    <asp:TextBox ID="txtGameName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtGameDescription" class="control-label">Game Description: </label>
                    <asp:TextBox ID="txtGameDescription" CssClass="form-control" runat="server" 
                        TextMode="MultiLine" Rows="5" Columns="3"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="ddlHomeTeam" class="control-label">Home Team: </label>
                    <asp:DropDownList ID="ddlHomeTeam" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="ddlAwayTeam" class="control-label">Away Team: </label>
                    <asp:DropDownList ID="ddlAwayTeam" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="txtHomeTeamScore" class="control-label">Home Team Score: </label>
                    <asp:TextBox ID="txtHomeTeamScore" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtAwayTeamScore" class="control-label">Away Team Score: </label>
                    <asp:TextBox ID="txtAwayTeamScore" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtNumberOfSpectators" class="control-label">Number of Spectators: </label>
                    <asp:TextBox ID="txtNumberOfSpectators" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                 <div class="form-group">
                    <label for="ddlWinningTeam" class="control-label">Winning Team: </label>
                    <asp:DropDownList ID="ddlWinningTeam" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
