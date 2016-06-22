<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="GameTracker.Navbar" %>
<!--
        Game Tracker
        By: Anthony Scinocco & Alex Andriisyn
        Navbar User Control
        -->
<nav class="navbar navbar-default" role="navigation">
    <div class="container-fluid">
        <!-- Brand and toggle get grouped for better mobile display -->
        <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="Default.aspx"><span class="text-danger"><i class="fa fa-futbol-o  fa-lg"></i> Game Tracker</span></a>
        </div>
        <!-- Collect the nav links, forms, and other content for toggling -->
        <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
            <ul class="nav navbar-nav navbar-right">
                <li id="games" runat="server"><a href="/Games.aspx"><i class="fa fa-trophy fa-lg"></i> Games</a></li>
                <asp:PlaceHolder ID="phPublic" runat="server">
                    <li id="register" runat="server"><a href="/Register.aspx"><i class="fa fa-user fa-lg"></i> Sign Up</a></li>
                    <li id="login" runat="server"><a href="/Login.aspx"><i class="fa fa-sign-in fa-lg"></i> Sign In</a></li>
                </asp:PlaceHolder>
                <asp:PlaceHolder ID="phDetails" runat="server">
                    <li id="teamDetails" runat="server"><a href="/Games/TeamDetails.aspx"><i class="fa fa-tags fa-lg"></i> New Team</a></li>
                    <li id="gameDetails" runat="server"><a href="/Games/GameDetails.aspx"><i class="fa fa-gamepad fa-lg"></i> New Game</a></li>
                     <li id="userDashboard" runat="server"><a href="/Users/UserDashboard.aspx"><i class="fa fa-tachometer fa-lg"></i> User Dashboard</a></li>
                    <li id="logout" runat="server"><a href="/Logout.aspx"><i class="fa fa-sign-out fa-lg"></i> Sign Out</a></li>
                </asp:PlaceHolder>
            </ul>
        </div>
        <!-- /.navbar-collapse -->
    </div>
    <!-- /.container-fluid -->
</nav>
