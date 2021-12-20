<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" 
    CodeBehind="ModifyDeleteProduct.aspx.cs" Inherits="drumcenterworld.Admin.ModifyDeleteProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center"><h1>Available Drum Products</h1></div>
    <asp:Button ID="Button1" runat="server" Text="Add New Product" OnClick="Button1_Click" />
     <asp:DataList ID="DataList2" runat="server" DataKeyField="ProductID" 
         DataSourceID="SqlDataSource1" RepeatDirection="Horizontal" OnItemCommand="DataList2_ItemCommand" RepeatColumns="3">
        <ItemTemplate>
            
            <table>
               
                <tr>    
                <td style="text-align:center">
                        
                    <asp:Label ID="Label1" runat="server" Text="Category"></asp:Label>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Eval("Category") %>' 
                            Font-Bold="True"></asp:TextBox>

                  </td>
                </tr> 

                <tr>
                     <td style="text-align:center">
                         <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
                        
                         <asp:TextBox ID="TextBox4" runat="server" Text='<%# Eval("Description") %>'></asp:TextBox>
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
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Eval("Price") %>' 
                            Font-Bold="True"></asp:TextBox>


                    </td>
                </tr>

                <tr>
                    <td style="text-align:center">
                        <asp:Label ID="Label3" runat="server" Text="Available Qty" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Eval("AvailableQty") %>' 
                            Font-Bold="True"></asp:TextBox>


                    </td>
                </tr>
               
                <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="ImageButton1" runat="server" 
                            ImageUrl="~/Images/Delete.jpg" Width="100px" 
                            CommandArgument='<%# Eval("ProductID") %>' CommandName="DelProduct" />
                           
                    </td>
                    
                </tr>

                 <tr>
                    <td style="text-align:center">
                        <asp:ImageButton ID="ImageButton2" runat="server" 
                            ImageUrl="~/Images/Modify.jpg" Width="100px" 
                            CommandArgument='<%# Eval("ProductID") %>' CommandName="ModProduct" />
                           
                    </td>
                    
                </tr>

            </table>
            <br>
            </br>
        </ItemTemplate>
    
    
    </asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:drumcenterconnection %>" 
        SelectCommand="SELECT * FROM [Product]"></asp:SqlDataSource>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>

