<%@ Page Title="Game Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GameDetails.aspx.cs" Inherits="GameTracker.GameDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="page-header">
                <h2>Game Details</h2>
            </div>
            <div class="col-md-8 col-md-offset-3">
                <!-- Form -->
                <div class="form-group">
                    <label for="txtGameName" class="control-label">Game Name: </label>
                    <div class="row">
                        <div class="col-md-7">
                            <asp:TextBox ID="txtGameName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-5">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"
                                ErrorMessage='<div class="text-danger" role="alert"><span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> Game Name is Required</div>'
                                ControlToValidate="txtGameName" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtGameDescription" class="control-label">Game Description: </label>
                    <div class="row">
                        <div class="col-md-7">
                            <asp:TextBox ID="txtGameDescription" CssClass="form-control" runat="server"
                                TextMode="MultiLine" Rows="5" Columns="3"></asp:TextBox>
                        </div>
                        <div class="col-md-5">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"
                                ErrorMessage='<div class="text-danger" role="alert"><span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> Game Description is Required</div>'
                                ControlToValidate="txtGameDescription" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="ddlHomeTeam" class="control-label">Home Team: </label>
                    <div class="row">
                        <div class="col-md-7">
                            <asp:DropDownList ID="ddlHomeTeam" CssClass="form-control" runat="server"
                                OnSelectedIndexChanged="homeAwayTeam_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-5">
                            <asp:RangeValidator ID="RangeValidator1" runat="server"
                                ErrorMessage='<div class="text-danger" role="alert"><span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> Please select Home Team</div>'
                                ControlToValidate="ddlHomeTeam" MinimumValue="1" MaximumValue="9999" SetFocusOnError="True"></asp:RangeValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="ddlAwayTeam" class="control-label">Away Team: </label>
                    <div class="row">
                        <div class="col-md-7">
                            <asp:DropDownList ID="ddlAwayTeam" CssClass="form-control" runat="server"
                                OnSelectedIndexChanged="homeAwayTeam_SelectedIndexChanged" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-5">
                            <asp:RangeValidator ID="RangeValidator2" runat="server"
                                ErrorMessage='<div class="text-danger" role="alert"><span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> Please select Away Team</div>'
                                ControlToValidate="ddlAwayTeam" MinimumValue="1" MaximumValue="9999" SetFocusOnError="True"></asp:RangeValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtHomeTeamScore" class="control-label">Home Team Score: </label>
                    <div class="row">
                        <div class="col-md-7">
                            <asp:TextBox ID="txtHomeTeamScore" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-5">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"
                                ErrorMessage='<div class="text-danger" role="alert"><span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> Please enter Home Team Score</div>'
                                ControlToValidate="txtHomeTeamScore" SetFocusOnError="True" Display="Dynamic">
                            </asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator3" runat="server"
                                ErrorMessage='<div class="text-danger" role="alert"><span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> Invalid Value</div>'
                                ControlToValidate="txtHomeTeamScore" MinimumValue="0" MaximumValue="9999" Display="Dynamic" SetFocusOnError="True"></asp:RangeValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtAwayTeamScore" class="control-label">Away Team Score: </label>
                    <div class="row">
                        <div class="col-md-7">
                            <asp:TextBox ID="txtAwayTeamScore" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-5">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"
                                ErrorMessage='<div class="text-danger" role="alert"><span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> Please enter Away Team Score</div>'
                                ControlToValidate="txtAwayTeamScore" SetFocusOnError="True" Display="Dynamic">
                            </asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator4" runat="server"
                                ErrorMessage='<div class="text-danger" role="alert"><span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> Invalid Value</div>'
                                ControlToValidate="txtAwayTeamScore" MinimumValue="0" MaximumValue="9999" SetFocusOnError="True" Display="Dynamic"></asp:RangeValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtNumberOfSpectators" class="control-label">Number of Spectators: </label>
                    <div class="row">
                        <div class="col-md-7">
                            <asp:TextBox ID="txtNumberOfSpectators" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-md-5">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server"
                                ErrorMessage='<div class="text-danger" role="alert"><span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> Please enter the Number of Spectators</div>'
                                ControlToValidate="txtNumberOfSpectators" SetFocusOnError="True" Display="Dynamic">
                            </asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RangeValidator5" runat="server"
                                ErrorMessage='<div class="text-danger" role="alert"><span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> Invalid Value</div>'
                                ControlToValidate="txtNumberOfSpectators" MinimumValue="0" MaximumValue="9999" SetFocusOnError="True" Display="Dynamic"></asp:RangeValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="ddlWinningTeam" class="control-label">Winning Team: </label>
                    <div class="row">
                        <div class="col-md-7">
                            <asp:DropDownList ID="ddlWinningTeam" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-md-5">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"
                                ErrorMessage='<div class="text-danger" role="alert"><span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> Please select Winning Team</div>'
                                ControlToValidate="ddlWinningTeam" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <label for="txtGameDate" class="control-label">Game Date: </label>
                    <div class="row">
                        <div class="col-md-7">
                            <asp:TextBox ID="txtGameDate" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="col-md-5">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server"
                                ErrorMessage='<div class="text-danger" role="alert"><span class="glyphicon glyphicon-exclamation-sign" aria-hidden="true"></span> Please select Game Date</div>'
                                ControlToValidate="txtGameDate" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-7">
                            <div class="text-right">
                                <asp:Button Text="Cancel" ID="btnCancel" CssClass="btn btn-default" runat="server"
                                    UseSubmitBehavior="false" CausesValidation="false" OnClick="btnCancel_Click" />
                                <asp:Button Text="Save" ID="btnSave" CssClass="btn btn-primary" runat="server" OnClick="btnSave_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
