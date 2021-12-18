<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ModifyProduct.aspx.cs" Inherits="drumcenterworld.ModifyProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" HeaderStyle-BackColor="#284E98" DataSourceID="SqlDataSource1" >
        <Columns>
            <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="AvailableQty" HeaderText="AvailableQty" SortExpression="AvailableQty" />
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        </Columns>
<HeaderStyle BackColor="#284E98"></HeaderStyle>
    </asp:GridView>
   
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:drumcenterconnection %>" SelectCommand="SELECT [Category], [Description], [AvailableQty], [Price] FROM [Product]"></asp:SqlDataSource>
</asp:Content>
