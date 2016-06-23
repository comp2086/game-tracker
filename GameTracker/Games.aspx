<%@ Page Title="Games" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Games.aspx.cs" Inherits="GameTracker.Games" %>

<%@ Register Src="~/User_Controls/GamePanel.ascx" TagPrefix="bs3" TagName="GamePanel" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!--
        Game Tracker
        By: Anthony Scinocco & Alex Andriishyn
        Games Page
        http://asp-game-tracker.azurewebsites.net/Games.aspx
        -->
    <div class="container">
        <div class="row">
            <div class="page-header">
                <h2>Games Statistics</h2>
            </div>
            <div class="col-md-8 col-md-offset-2">
                <div class="text-center">
                    <div class="btn-group" role="group" aria-label="Basic example">
                        <asp:Button runat="server" ID="LastWeekButton" CssClass="btn btn-default btn-lg" Text="<" OnClick="LastWeekButton_Click" />
                        <asp:Button runat="server" ID="NextWeekButton" CssClass="btn btn-default btn-lg" Text=">" OnClick="NextWeekButton_Click" />
                    </div>
                </div>
                <div class="clearfix"></div>
                <asp:PlaceHolder ID="GameStats" runat="server"></asp:PlaceHolder>
            </div>
        </div>
    </div>
</asp:Content>
