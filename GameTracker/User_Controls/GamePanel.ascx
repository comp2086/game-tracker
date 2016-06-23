<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GamePanel.ascx.cs" Inherits="GameTracker.User_Controls.GamePanel" %>

<div class="panel panel-default">
    <div class="panel-heading" role="tab" id="headingOne">
        <h4 class="panel-title">
            <asp:Label ID="lblGameHeading" runat="server"></asp:Label>
        </h4>
    </div>
    <div class="panel-body">
        Description:
                        <asp:Label ID="lblGameDescription" runat="server"></asp:Label><br />
        Total Points Scored:
                        <asp:Label ID="lblGameTotalPointsScored" runat="server"></asp:Label><br />
        Away Team Points Lost:
                        <asp:Label ID="lblGameAwayTeamPointsLost" runat="server"></asp:Label><br />
        Home Team Points Lost:
                        <asp:Label ID="lblGameHomeTeamPointsLost" runat="server"></asp:Label><br />
    </div>
</div>
