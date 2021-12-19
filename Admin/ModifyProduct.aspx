<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ModifyProduct.aspx.cs" Inherits="drumcenterworld.ModifyProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br/>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" HeaderStyle-BackColor="#284E98" DataSourceID="SqlDataSource1" DataKeyNames="OrderID" >
        <Columns>
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
            <asp:BoundField DataField="OrderID" HeaderText="OrderID" InsertVisible="False" ReadOnly="True" SortExpression="OrderID" />
            <asp:BoundField DataField="ProductID" HeaderText="ProductID" SortExpression="ProductID" />
            <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
            <asp:BoundField DataField="OrderQty" HeaderText="OrderQty" SortExpression="OrderQty" />
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            <asp:BoundField DataField="Total" HeaderText="Total" ReadOnly="True" SortExpression="Total" />
        </Columns>
<HeaderStyle BackColor="#284E98"></HeaderStyle>
    </asp:GridView>
   
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
   
   
   
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:drumcenterconnection %>" SelectCommand="SELECT users.LastName, customerorder.OrderID,items.ProductID, product.Description, 
       items.OrderQty, product.Price, items.OrderQty*product.Price as Total
        From Users, customerorder, items, product
        where Users.UserID = customerorder.CustomerID 
          and Users.UserID=1 and customerorder.OrderID= items.OrderID and items.ProductID = product.ProductID
Order by customerorder.OrderID;"></asp:SqlDataSource>
   
   
</asp:Content>
