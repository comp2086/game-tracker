﻿<%@ Page Title="Games" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Games.aspx.cs" Inherits="GameTracker.Games" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <!--
        Game Tracker
        By: Anthony Scinocco & Alex Andriisyn
        Games Page
        http://asp-game-tracker.azurewebsites.net/Games.aspx
        -->
    <div class="container">
        <h1 class="text-center">Games</h1>
    <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
  <div class="panel panel-default">
    <div class="panel-heading" role="tab" id="headingOne">
      <h4 class="panel-title">
        <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
          <asp:Label ID="txtGameOneHeading" runat="server"></asp:Label>
        </a>
      </h4>
    </div>
    <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
      <div class="panel-body">
       <asp:Label ID="txtGameOneDescription" runat="server"></asp:Label>
      </div>
    </div>
  </div>
  <div class="panel panel-default">
    <div class="panel-heading" role="tab" id="headingTwo">
      <h4 class="panel-title">
        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
          <asp:Label ID="txtGameTwoHeading" runat="server"></asp:Label>
        </a>
      </h4>
    </div>
    <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
      <div class="panel-body">
        <asp:Label ID="txtGameTwoDescription" runat="server"></asp:Label>
      </div>
    </div>
  </div>
  <div class="panel panel-default">
    <div class="panel-heading" role="tab" id="headingThree">
      <h4 class="panel-title">
        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
          <asp:Label ID="txtGameThreeHeading" runat="server"></asp:Label>
        </a>
      </h4>
    </div>
    <div id="collapseThree" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingThree">
      <div class="panel-body">
        <asp:Label ID="txtGameThreeDescription" runat="server"></asp:Label>
      </div>
    </div>
  </div>
  <div class="panel panel-default">
    <div class="panel-heading" role="tab" id="headingFour">
      <h4 class="panel-title">
        <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseFour" aria-expanded="false" aria-controls="collapseFour">
          <asp:Label ID="txtGameFourHeading" runat="server"></asp:Label>
        </a>
      </h4>
    </div>
    <div id="collapseFour" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingFour">
      <div class="panel-body">
        <asp:Label ID="txtGameFourDescription" runat="server"></asp:Label>
      </div>
    </div>
  </div>        
</div>
</div>
</asp:Content>