<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GamePanel.ascx.cs" Inherits="GameTracker.User_Controls.GamePanel" %>

<div class="panel panel-default">
    <div class="panel-heading" role="tab" id="headingOne">
        <h4 class="panel-title">
            <asp:Label ID="lblGameHeading" runat="server"></asp:Label>
            <asp:Label ID="lblGameDate" CssClass="pull-right" runat="server"></asp:Label>
        </h4>
    </div>
    <div class="panel-body">
        <strong>Description:</strong>
        <asp:Label ID="lblGameDescription" runat="server"></asp:Label><br />
        <strong>Total Points Scored:</strong>
        <asp:Label ID="lblGameTotalPointsScored" runat="server"></asp:Label><br />
        <strong>Away Team Points Lost:</strong>
        <asp:Label ID="lblGameAwayTeamPointsLost" runat="server"></asp:Label><br />
        <strong>Home Team Points Lost:</strong>
        <asp:Label ID="lblGameHomeTeamPointsLost" runat="server"></asp:Label><br />
        <strong>Number of Spectators: </strong>
        <asp:Label ID="lblGameSpectators" runat="server" Text="Label"></asp:Label>
    </div>
</div>
