<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="drumcenterworld.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <form> 
    <div runat="server" id="add">

 <label>Product Photo:</label>
    <asp:FileUpload ID="FileUpload1" runat="server" />
    
    <div>
        <label>Product Category:</label>
    <asp:DropDownList ID="DropDownCategory" runat="server">
        <asp:ListItem Value="Drums">Drums</asp:ListItem>
        <asp:ListItem Value="Cymbals">Cymbals</asp:ListItem>
    </asp:DropDownList>
    </div>
    <div>
        <label>Product Description:</label>
    <asp:TextBox ID="TextBoxDescription" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxDescription" ErrorMessage="Description is required" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div>
    <label>Product Price:</label>
    <asp:TextBox ID="TextBoxPrice" runat="server" Height="22px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPrice" ErrorMessage="Price is required" ForeColor="Red"></asp:RequiredFieldValidator>
    </div>
    <div>
    <label>Available Qty:"</label>
    <asp:TextBox ID="TextBoxAvailableQty" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxAvailableQty" ErrorMessage="Available Qty is Required" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
    <div>
    <asp:Button ID="btnUpload" runat="server" Text="Upload Photo" OnClick="btnUpload_Click" />
    </div>
      
        <asp:Label ID="lblMessage" runat="server" Text="Label"></asp:Label>
      
        <br />
        </div>
    </form>
</asp:Content>
