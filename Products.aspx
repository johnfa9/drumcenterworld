<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="drumcenterworld.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="Button1" runat="server" Text="Add New Product" OnClick="Button1_Click" />
     <asp:DataList ID="DataList1" runat="server" DataKeyField="ProductID" DataSourceID="SqlDataSource1" RepeatDirection="Horizontal" OnItemCommand="DataList1_ItemCommand">
        <ItemTemplate>
            <table>
               
                <tr>    
                <td style="text-align:center">
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Category") %>' Font-Bold="True"></asp:Label>
                  </td>
                </tr>    
                <tr>
                     <td style="text-align:center">
                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("Description") %>' Font-Bold="True"></asp:Label>
                    </td>
                </tr>
                <tr>
                <td style="text-align:center">
                    <asp:Image ID="Image1" runat="server" BorderColor="#FF3300" Height="279px"
                        Width="278px" ImageUrl='<%# Eval ("PhotoLink")%>'/>
                    </td>
                </tr>

                <tr>
                    <td style="text-align:center">
                        <asp:Label ID="Label4" runat="server" Text="Price" Font-Bold="True"></asp:Label>
                        <asp:Label ID="Label5" runat="server" Text=<%# Eval("Price") %> Font-Bold="True"></asp:Label>
                    </td>
                </tr>


                <tr>
                    <td style="text-align:center">
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                         </asp:DropDownList>
                    </td>
                   
                </tr>
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            ImageUrl="~/Images/Add.jpg" Width="100px" CommandArgument='<%# Eval("ProductID") %>' CommandName="Cart" />
                           
                    </td>
                    
                </tr>

            </table>
            <br>
            </br>
        </ItemTemplate>
    
    
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:drumcenterconnection %>" SelectCommand="SELECT * FROM [Product]"></asp:SqlDataSource>


</asp:Content>

