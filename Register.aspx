<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="drumcenterworld.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Email ID :"></asp:Label>
            <asp:TextBox ID="TextBoxEmail" placeholder="Enter Email" runat="server" TextMode="Email"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxEmail" Display="Dynamic" ErrorMessage="Email Required" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TextBoxPassword" placeholder="Enter Password" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPassword" Display="Dynamic" ErrorMessage="Password Required" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="First Name "></asp:Label>
            <asp:TextBox ID="TextBoxFirstName" placeholder="First Name" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxFirstName" Display="Dynamic" ErrorMessage="First Name Required" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Text="Last Name "></asp:Label>
            <asp:TextBox ID="TextBoxLastName" placeholder="Last Name" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxLastName" Display="Dynamic" ErrorMessage="Last Name Required" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label ID="Label5" runat="server" Text="Street Address"></asp:Label>
            <asp:TextBox ID="TextBoxStreet" placeholder="Enter Street Address" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxStreet" Display="Dynamic" ErrorMessage="Street Required" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label ID="Label6" runat="server" Text="City"></asp:Label>
            <asp:TextBox ID="TextBoxCity" placeholder="Enter City" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxCity" Display="Dynamic" ErrorMessage="City Required" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label ID="Label7" runat="server" Text="State"></asp:Label>
            <asp:TextBox ID="TextBoxState" placeholder="Enter State" runat="server" MaxLength="2"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBoxState" Display="Dynamic" ErrorMessage="State Required" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label ID="Label8" runat="server" Text="Zip Code"></asp:Label>
            <asp:TextBox ID="TextBoxZip" placeholder="Enter Zip Code" runat="server" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBoxZip" Display="Dynamic" ErrorMessage="Zip Code Required" ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div>
            <asp:Label ID="Label9" runat="server" Text="Billing Method"></asp:Label>
            <asp:DropDownList ID="DropDownListBilling"  runat="server">
                <asp:ListItem Value="AMEX"></asp:ListItem>
                <asp:ListItem>Visa</asp:ListItem>
                <asp:ListItem Value="Discover"></asp:ListItem>
            </asp:DropDownList>
        
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="DropDownListBilling" Display="Dynamic" ErrorMessage="Billing Method Required" ForeColor="Red"></asp:RequiredFieldValidator>
        
        </div>
        <div>
            <asp:Button ID="ButtonRegister" runat="server" Text="Register" OnClick="ButtonRegister_Click" />
        </div>
        </asp:Content>
