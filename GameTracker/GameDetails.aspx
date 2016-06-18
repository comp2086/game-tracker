<%@ Page Title="Game Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GameDetails.aspx.cs" Inherits="GameTracker.GameDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-8 col-md-offset-3">
                <!-- Form -->
                <div class="form-group">
                    <label for="txtGameName" class="control-label">Game Name: </label>
                    <div class="row">
                        <div class="col-md-9">
                            <asp:TextBox ID="txtGameName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            Validate
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtGameDescription" class="control-label">Game Description: </label>
                    <div class="row">
                        <div class="col-md-9">
                            <asp:TextBox ID="txtGameDescription" CssClass="form-control" runat="server"
                                TextMode="MultiLine" Rows="5" Columns="3"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            Validate
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="ddlHomeTeam" class="control-label">Home Team: </label>
                    <div class="row">
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddlHomeTeam" CssClass="form-control" runat="server"
                                OnSelectedIndexChanged="homeAwayTeam_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            Valdiate
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="ddlAwayTeam" class="control-label">Away Team: </label>
                    <div class="row">
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddlAwayTeam" CssClass="form-control" runat="server"
                                OnSelectedIndexChanged="homeAwayTeam_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            Validate
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtHomeTeamScore" class="control-label">Home Team Score: </label>
                    <div class="row">
                        <div class="col-md-9">
                            <asp:TextBox ID="txtHomeTeamScore" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            Validate
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtAwayTeamScore" class="control-label">Away Team Score: </label>
                    <div class="row">
                        <div class="col-md-9">
                            <asp:TextBox ID="txtAwayTeamScore" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            Validate
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtNumberOfSpectators" class="control-label">Number of Spectators: </label>
                    <div class="row">
                        <div class="col-md-9">
                            <asp:TextBox ID="txtNumberOfSpectators" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            Validate
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="ddlWinningTeam" class="control-label">Winning Team: </label>
                    <div class="row">
                        <div class="col-md-9">
                            <asp:DropDownList ID="ddlWinningTeam" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-md-3">
                            Validate
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtGameDate" class="control-label">Game Date: </label>
                    <div class="row">
                        <div class="col-md-9">
                            <asp:TextBox ID="txtGameDate" CssClass="form-control" runat="server" placeholder="mm/dd/yyyy"></asp:TextBox>
                        </div>
                        <div class="col-md-3">
                            Validate
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-9">
                            <div class="text-right">
                                <asp:Button Text="Cancel" ID="btnCancel" CssClass="btn btn-warning btn-lg" runat="server"
                                    UseSubmitBehavior="false" CausesValidation="false" OnClick="btnCancel_Click" />
                                <asp:Button Text="Save" ID="btnSave" CssClass="btn btn-primary btn-lg" runat="server" OnClick="btnSave_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
