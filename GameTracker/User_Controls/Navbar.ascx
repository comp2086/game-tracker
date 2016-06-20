﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="GameTracker.Navbar" %>
<!--
        Game Tracker
        By: Anthony Scinocco & Alex Andriisyn
        Navbar User Control
        -->
<nav class="navbar navbar-inverse" role="navigation">
    <div class="container-fluid">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="Default.aspx"><i class="fa fa-fort-awesome fa-lg"></i> SGT</a>
        </div>
        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav navbar-right">
                <li id="home" runat="server"><a href="Default.aspx"><i class="fa fa-home fa-lg"></i> Home</a></li>
                <li id="games" runat="server"><a href="Games.aspx"><i class="fa fa-trophy fa-lg"></i> Games</a></li>
                <li id="teamDetails" runat="server"><a href="TeamDetails.aspx"><i class="fa fa-tags fa-lg"></i> New Team</a></li>
                <li id="gameDetails" runat="server"><a href="GameDetails.aspx"><i class="fa fa-gamepad fa-lg"></i> New Game</a></li>
                <li id="contact" runat="server"><a href="Contact.aspx"><i class="fa fa-phone fa-lg"></i> Contact</a></li>
                <li id="register" runat="server"><a href="Register.aspx"><i class="fa fa-user fa-lg"></i> Sign Up</a></li>
                <li id="login" runat="server"><a href="Login.aspx"><i class="fa fa-sign-in fa-lg"></i> Sign In</a></li>
                <li id="logout" runat="server"><a href="Logout.aspx"><i class="fa fa-sign-out fa-lg"></i> Sign Out</a></li>
            </ul>
        </div>
        <!-- /.navbar-collapse -->
    </div>
    <!-- /.container-fluid -->
</nav>
