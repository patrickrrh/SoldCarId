<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Guest.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SoldCarId.View.Register" %>
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
            <h2>Register</h2>
            <div class="form-group">
                <asp:Label ID="nameLbl" runat="server" Text="Name" CssClass="label-top-left"></asp:Label>
                <asp:TextBox ID="nameTbx" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="emailLbl" runat="server" Text="Email" CssClass="label-top-left"></asp:Label>
                <asp:TextBox ID="emailTbx" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="passLbl" runat="server" Text="Password" CssClass="label-top-left"></asp:Label>
                <asp:TextBox ID="passTbx" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="addressLbl" runat="server" Text="Address" CssClass="label-top-left"></asp:Label>
                <asp:TextBox ID="addressTbx" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="btn-container">
                <asp:Button ID="registerBtn" runat="server" Text="Register" CssClass="btn" onClick="registerBtn_Click" />
            </div>
            <div>
                <asp:Label ID="errorLbl" runat="server" CssClass="error-message" Visible="false"></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>
