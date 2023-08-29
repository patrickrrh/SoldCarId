<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Admin.Master" AutoEventWireup="true" CodeBehind="EditCar.aspx.cs" Inherits="SoldCarId.View.EditCar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/UpdateCar.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="containerEdit">
        <h2>Update Car Data</h2>
        <div>
            <label for="BrandTbx">Brand</label>
            <asp:TextBox ID="BrandTbx" runat="server" CssClass="input"></asp:TextBox>
        </div>
        <div>
            <label for="ModelTbx">Model</label>
            <asp:TextBox ID="ModelTbx" runat="server" CssClass="input"></asp:TextBox>
        </div>
        <div>
            <label for="kilometerTbx">Kilometer</label>
            <asp:TextBox ID="kilometerTbx" runat="server" type="number" CssClass="input"></asp:TextBox>
        </div>
        <div>
            <label for="yearTbx">Year</label>
            <asp:TextBox ID="yearTbx" runat="server" type="number" CssClass="input"></asp:TextBox>
        </div>
        <div>
            <label for="descTbx">Description</label>
            <asp:TextBox ID="descTbx" runat="server" CssClass="input"></asp:TextBox>
        </div>
        <div>
            <label for="priceTbx">Price</label>
            <asp:TextBox ID="priceTbx" runat="server" type="number" CssClass="input"></asp:TextBox>
        </div>
        <div class="image-container">
            <asp:Image ID="carImage" runat="server" CssClass="album-image" Height="150" Width="150" />
        </div>
        <div class="form-group">
            <label for="imageUpload">Car Image</label>
            <asp:FileUpload ID="imageUpload" runat="server" CssClass="file-upload" />
            <asp:Label ID="imageErrorLbl" runat="server" CssClass="error" Text="" Visible="false"></asp:Label>
        </div>
        <div>
            <asp:Button ID="updateBtn" runat="server" Text="Update" CssClass="button" OnClick="updateBtn_Click"   />
            <asp:Label ID="errorLbl" runat="server" CssClass="error" Text="" Visible="false"></asp:Label>
        </div>
    </div>

</asp:Content>
