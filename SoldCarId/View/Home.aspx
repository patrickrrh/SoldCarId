<%@ Page Title="" Language="C#" MasterPageFile="~/View/Master/Guest.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SoldCarId.View.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="CSS/Home.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class ="containerUp2">
        <asp:Button ID="insertBtn" runat="server" Text="Insert Car" Visible="false" CssClass="btn2" OnClick="insertBtn_Click" />
    </div>
    <div class="containerUp">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div class="card">
                    <div class="cardHeader">
                        <h3 style="text-align: center;"><%# Eval("Brand")%></h3>
                    </div>
                    <div class="cardBody">
                        <div>
                            <asp:Image ID="carImage" runat="server" ImageUrl='<%# Eval("Image") %>' CssClass="cardImage" />
                        </div>
                        <p>Model : <%# Eval("Model") %></p>
                    </div>
                    <div class="cardFooter">
                        <asp:Button ID="detailBtn" runat="server" Text="See Details" CommandArgument='<%# Eval("CarID") %>' CssClass="btn" onClick="detailBtn_Click" />
                        <asp:Button ID="updateBtn" runat="server" Text="Update" CommandArgument='<%# Eval("CarID") %>' Visible="false" CssClass="btn" onClick="updateBtn_Click" />
                        <asp:Button ID="deleteBtn" runat="server" Text="Delete" CommandArgument='<%# Eval("CarID") %>' Visible="false" CssClass="btn" onClick="deleteBtn_Click" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
