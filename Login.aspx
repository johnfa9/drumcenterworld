<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="drumcenterworld.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="width:300px">    
    <div class="form-group">
            <label>Username</label>&nbsp;
            <asp:TextBox ID="TextBoxEmail" runat="server" Width="150px"></asp:TextBox>
    </div>
     <div class="form-group">
            <label>Password</label>&nbsp;
            <asp:TextBox ID="TextBoxPassword" runat="server" Width="152px"></asp:TextBox>
     </div>
        <p class="text-center" >
            <asp:Label ID="Label2" runat="server" Text="Role"></asp:Label>
            <asp:RadioButton ID="RadioButton1" runat = "server" Text="Admin" GroupName= "usertype" />
            <asp:RadioButton ID="RadioButton2" runat = "server" Text="Customer" GroupName = "usertype" Checked="true" />
        </p>

    <asp:Label ID="Label1" runat="server"></asp:Label>
     <div class="form-group">
            &nbsp;<asp:Button ID="BtnLogin" runat="server" Font-Bold="True" Text="Login" OnClick="BtnLogin_Click" />

     </div>
</div>   
</asp:Content>
