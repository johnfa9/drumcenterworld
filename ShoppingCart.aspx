<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="drumcenterworld.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
            <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
        </div>
        <div>
            <asp:Button ID="ButtonRemoveItem" runat="server" Text="Remove Item" OnClick="ButtonRemoveItem_Click" />
            <asp:Button ID="ButtonEmptyCart" runat="server" Text="Empty Cart" OnClick="ButtonEmptyCart_Click" />
        </div>
       
        <div>
            <asp:Button ID="ButtonContinue" runat="server" Text="Continue Shopping" PostBackUrl="~/Products.aspx" OnClick="ButtonContinue_Click"/>
            <asp:Button ID="ButtonCheckOut" runat="server" Text="Check Out" OnClick="ButtonCheckOut_Click1" />
        </div>
         <div>
            <asp:Label ID="lblMessage" runat="server" EnableViewState="False" ForeColor="Red" Font-Bold="True"></asp:Label>
        </div>
</asp:Content>
