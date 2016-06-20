<%@ Page Title="User Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserDashboard.aspx.cs" Inherits="GameTracker.Users.UserDashboard" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h1>User Dashboard</h1>
        </div>
        <div class="row">
            <asp:Button ID="btnCreateUser" Text="Create User" CssClass="btn btn-success btn-lg pull-left" OnClick="btnCreateUser_Click" runat="server"/>
        </div>
        <div class="row">
            <asp:GridView runat="server" CssClass="table table-bordered table-striped table-hover"
                ID="grdUsers" AutoGenerateColumns="false" DataKeyNames="Id" 
                OnRowDeleting="grdUsers_RowDeleting" AllowPaging="true" PageSize="5" OnPageIndexChanging="grdUsers_PageIndexChanging"
                AllowSorting="true" OnSorting="grdUsers_Sorting" OnRowDataBound="grdUsers_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="User ID" Visible="true" SortExpression="Id" />
                    <asp:BoundField DataField="Email" HeaderText="Email" Visible="true" SortExpression="Email" />
                    <asp:BoundField DataField="Username" HeaderText="Username" Visible="true" SortExpression="Username" />
                    <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit"
                        NavigateUrl="~/Users/EditUser.aspx.cs" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="EditUser.aspx?Id={0}" />
                    <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete" ShowDeleteButton="true"
                        ButtonType="Link" ControlStyle-CssClass="btn btn danger btn-sm" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
