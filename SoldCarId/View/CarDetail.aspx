<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Guest.Master" AutoEventWireup="true" CodeBehind="CarDetail.aspx.cs" Inherits="SoldCarId.View.CarDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="CSS/CarDetails.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="containerCar">
        <div class="product-card">
            <div>
                <asp:Image ID="carImg" runat="server" CssClass="product-image" />
            </div>
            <div class="containerDetails">
                <asp:Label ID="Label1" runat="server" Text="Car Details" CssClass="product-title" Font-Bold="True"></asp:Label>
                <div class="product-description">
                    <asp:Label ID="carBrand" runat="server" Text=""></asp:Label>
                    <asp:Label ID="carModel" runat="server" Text=""></asp:Label>
                    <asp:Label ID="carKilometer" runat="server" Text=""></asp:Label>
                    <asp:Label ID="carYear" runat="server" Text=""></asp:Label>
                    <asp:Label ID="carDesc" runat="server" Text=""></asp:Label>
                </div>
                <div class="product-price">
                    <asp:Label ID="carPrice" runat="server" Text=""></asp:Label>
                </div>
                <div runat="server" id="isAdmin">
                    <br />
                    <asp:Label ID="titleLabel" runat="server" Text="Appointment Form" CssClass="product-title" Font-Bold="True"></asp:Label>
                    <div style="margin-top:10px;">
                        <asp:Label ID="locationLbl" runat="server" Text="Meet Location"></asp:Label>
                        <asp:TextBox ID="locationTB" runat="server"></asp:TextBox>
                    </div>
                    <div style="margin-top:10px; margin-bottom:10px;">
                        <asp:Label ID="appDateLbl" runat="server" Text="Appointment Date"></asp:Label>
                        <input id="Button1" type="date" runat="server"/>
                    </div>
                </div>
                <asp:Button ID="addToStockBtn" runat="server" Text="Add to Cart" Visible="true" CssClass="add-to-cart-button" OnClick="addToStockBtn_Click" />
                <div>
                    <asp:Label ID="errorLbl" runat="server" Text="" CssClass="error-message"></asp:Label>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
