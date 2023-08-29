<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Guest.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SoldCarId.View.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="CSS/forms.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center-containerUp">
        <div class="leftSideBar">
            <div class="LSBContent">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Assets/black4.jfif"/>
            </div>
        </div>
        <div class="formToFillData">
            <h2>Login</h2>
            <div class="form-group">
                <asp:Label ID="emailLbl" runat="server" Text="Email" CssClass="label-top-left"></asp:Label>
                <div>
                    <asp:TextBox ID="emailTbx" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <asp:Label ID="passLbl" runat="server" Text="Password" CssClass="label-top-left"></asp:Label>
                <div>
                    <asp:TextBox ID="passTbx" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <div class="form-groupCbx">
                <asp:CheckBox ID="rememberMeCbx" runat="server" Text="Remember Me" CssClass="checkbox-label" />
            </div>
            <div class="btn-container">
                <asp:Button ID="loginPageBtn" runat="server" Text="Login" CssClass="btn" onClick="loginPageBtn_Click" />
            </div>
            <div class="error-container">
                <asp:Label ID="errorLbl" runat="server" CssClass="error-message" Visible="false"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
