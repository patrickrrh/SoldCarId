<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Customer.Master" AutoEventWireup="true" CodeBehind="Carts.aspx.cs" Inherits="SoldCarId.View.Carts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <link rel="stylesheet" href="CSS/Cart.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="title">
        <asp:Label ID="titleLbl" runat="server" Text="Your Cart"></asp:Label>
    </div>
    <div class="cart-grid">
        <asp:GridView ID="cartGrid" runat="server" AutoGenerateColumns="False" CssClass="grid-view" OnRowDeleting="cartGrid_RowDeleting"  >
            <Columns>
                <asp:TemplateField HeaderText="Car Image">
                    <ItemTemplate>
                        <asp:Image ID="CarImage" runat="server" ImageUrl='<%# Eval("Car.Image") %>' CssClass="car-image" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Car.CarId" HeaderText="ID" SortExpression="CarId" HeaderStyle-CssClass="Hide" ItemStyle-CssClass="Hide" >
<HeaderStyle CssClass="Hide"></HeaderStyle>

<ItemStyle CssClass="Hide"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Car.Brand" HeaderText="Brand" SortExpression="Brand" />
                <asp:BoundField DataField="Car.Model" HeaderText="Model" SortExpression="Model" />
                <asp:BoundField DataField="Car.ProductionYear" HeaderText="Production Year" SortExpression="ProductionYear" />
                <asp:BoundField DataField="Location" HeaderText="Meet Location" SortExpression="Location" />
                <asp:BoundField DataField="AppointmentDate" HeaderText="Appointment Date" SortExpression="AppointmentDate" />
                <asp:CommandField ButtonType="Button" DeleteText="Remove" ShowDeleteButton="True" ControlStyle-CssClass="btn">
<ControlStyle CssClass="btn"></ControlStyle>
                </asp:CommandField>
            </Columns>
            <HeaderStyle CssClass="grid-view-header" />
        </asp:GridView>
    </div>
    <div class="empty-message">
        <asp:Label ID="isEmptyLbl" runat="server" Text=""></asp:Label>
    </div>
    <div class="checkout-button">
        <asp:Button ID="checkoutBtn" runat="server" Text="Make Appointment" CssClass="btn" OnClick="checkoutBtn_Click" />
    </div>
    <div>
        <asp:Label ID="errorLbl" runat="server" Text="" Visible="false" CssClass="error-message"></asp:Label>
    </div>

</asp:Content>
