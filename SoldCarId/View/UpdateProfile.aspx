<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Guest.Master" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="SoldCarId.View.UpdateProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <link rel="stylesheet" href="CSS/forms.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="center-containerUp">
        <div class="center-containerUp2">
            <asp:Label ID="titleLbl" runat="server" Text="Update Profile" Font-Bold="True" Font-Size="XX-Large" Height="70px"></asp:Label>
            <div class="form-group">
                <asp:Label ID="nameLbl" runat="server" Text="Name" CssClass="label-top-left"></asp:Label>
                <asp:TextBox ID="nameTbx" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="emailLbl" runat="server" Text="Email" CssClass="label-top-left"></asp:Label>
                <asp:TextBox ID="emailTbx" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="passlbl" runat="server" Text="Password" CssClass="label-top-left"></asp:Label>
                <asp:TextBox ID="passTbx" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Label ID="addresslbl" runat="server" Text="Address" CssClass="label-top-left"></asp:Label>
                <asp:TextBox ID="addressTbx" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="btn-container">
                <asp:Button ID="updateBtn" runat="server" Text="Update" onClick="updateBtn_Click1" CssClass="btn" />
            </div>
            <div>
                <asp:Label ID="errorLbl" runat="server" CssClass="error-message" Visible="false"></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>
