<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GameTracker.Default" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!--
        Game Tracker
        By: Anthony Scinocco & Alex Andriisyn
        Default welcome page
        http://asp-game-tracker.azurewebsites.net/Default.aspx
        -->
     <bs3:Jumbotron runat="server" ID="Jumbotron1">
        <BodyContent>
            <h1>Welcome!</h1>
        </BodyContent>
    </bs3:Jumbotron>
</asp:Content>
