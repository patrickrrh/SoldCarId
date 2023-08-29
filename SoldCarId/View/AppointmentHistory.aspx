<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Customer.Master" AutoEventWireup="true" CodeBehind="AppointmentHistory.aspx.cs" Inherits="SoldCarId.View.AppointmentHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="CSS/Appointment.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="containerUp">
        <div class="transaction-title">
            <asp:Label ID="titleLbl" runat="server" Text="Appointment History"></asp:Label>
        </div>
        <div>
            <asp:GridView ID="transactionGrid" runat="server" AutoGenerateColumns="False"  CssClass="transaction-grid"  OnRowDataBound="transactionGrid_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="AppointmentID" HeaderText="Appointment ID" SortExpression="AppointmentID" ItemStyle-Width="120px" />
                    <asp:BoundField DataField="BookingDate" HeaderText="Booking Date" SortExpression="BookingDate" ItemStyle-Width="180px" />
                    <asp:BoundField DataField="User.UserName" HeaderText="Customer Name" SortExpression="User.UserName" />
                    <asp:TemplateField HeaderText="Car Appointment List">
                        <ItemTemplate>
                            <asp:GridView ID="transactionDetailGrid" runat="server" AutoGenerateColumns="false" CssClass="transaction-detail-grid">
                                <Columns>
                                    <asp:TemplateField HeaderText="Car Image">
                                        <ItemTemplate>
                                            <asp:Image ID="CarImage" runat="server" ImageUrl='<%# Eval("Car.Image") %>' CssClass="car-image" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Car.Brand" HeaderText="Car Brand" SortExpression="Car.Brand" />
                                    <asp:BoundField DataField="Car.Model" HeaderText="Car Model" SortExpression="Car.Model" />
                                    <asp:BoundField DataField="Location" HeaderText="Meet Location" SortExpression="AppointmentDetail.Location" />
                                    <asp:BoundField DataField="AppointmentDate" HeaderText="Appointment Date" SortExpression="AppointmentDetail.AppointmentDate" />
                                </Columns>
                            </asp:GridView>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Label ID="isEmptyLbl" runat="server" Text=""></asp:Label>
        </div>
    </div>
</asp:Content>
