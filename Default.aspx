<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="drumcenterworld.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style='text-align:center'>
         <h2>Located in sunny Hollywood, California</h2>
         <h2>Our drumstore has the best gear in town !!!<p>
         <img src="Images\drumstore.jpg" alt="Drum Center Photo" width="800">  

</div>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <footer style="text-align:center;padding: 5px;">


    <a href="mailto:drumcenterworld@yahoo.com">drumcenterworld@yahoo.com</a>
    <br/>
    <p>6834 Hollwood Blvd, Hollywood, CA 90028-6102</p>
    
    <form action="http://maps.google.com/maps" method="get" target="_blank">
        Enter your starting address:
        <input type="text" name="saddr" />
        <input type="hidden" name="daddr" value="6834 Hollwood Blvd, Hollywood, CA 90028-6102"/>
        <input type="submit" value="get directions" />
    </form>


    <p>(555)555-1234</p>
    <p>Author: John Acocella</p>
</footer>
</asp:Content>

