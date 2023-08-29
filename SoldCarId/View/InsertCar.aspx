<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Admin.Master" AutoEventWireup="true" CodeBehind="InsertCar.aspx.cs" Inherits="SoldCarId.View.InsertCar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="CSS/insertCar.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="center-containerIns">
        <div style="margin-bottom: 20px;">
            <asp:Label ID="titleLbl" runat="server" Text="Insert New Car" Font-Bold="True" Font-Size="25px"></asp:Label>
        </div>
        <div style="margin-bottom: 20px;">
            <asp:Label ID="sellerLbl" runat="server" Text="Seller ID" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="sellerTbx" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div style="margin-bottom: 20px;">
            <asp:Label ID="brandLbl" runat="server" Text="Car brand" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="brandTbx" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div style="margin-bottom: 20px;">
            <asp:Label ID="modelLbl" runat="server" Text="Model" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="modelTbx" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div style="margin-bottom: 20px;">
            <asp:Label ID="kilometerLbl" runat="server" Text="Kilometer" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="kilometerTbx" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
        </div>
        <div style="margin-bottom: 20px;">
            <asp:Label ID="yearLbl" runat="server" Text="Production Year" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="yearTbx" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
        </div>
        <div style="margin-bottom: 20px;">
            <asp:Label ID="descLbl" runat="server" Text="Description" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="descTbx" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div style="margin-bottom: 20px;">
            <asp:Label ID="priceLbl" runat="server" Text="Price" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="priceTbx" runat="server" TextMode="Number" CssClass="form-control"></asp:TextBox>
        </div>
        <div style="margin-bottom: 20px;">
            <asp:Label ID="imageLbl" runat="server" Text="Car Photo" CssClass="form-label"></asp:Label>
        </div>
        <div style="margin-bottom: 20px;">
            <asp:FileUpload ID="imageUpload" runat="server" CssClass="form-control-file" />
        </div>
        <div class="btn-container">
            <asp:Button ID="insertBtn" runat="server" Text="Insert Car" CssClass="btn btn-primary" onClick="insertBtn_Click" />
        </div>
        <div>
            <asp:Label ID="errorLbl" runat="server" Text="" CssClass="error-label" Visible="false"></asp:Label>
        </div>
    </div>

</asp:Content>
