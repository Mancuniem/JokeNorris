<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JokeUI.aspx.cs" Inherits="JokeNorris.JokeUI" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        body {
            font-family: Stencil;
        }
        form {
            position: center; width: 360px; height: 640px;
        }
    </style>
    <title>True Chuck Norris facts, on demand!</title>
</head>
<body >
    <form id="frmChuck" runat="server" >
        <div>
            <h1>Chuck Norris, true facts!</h1>
            <img src="https://pbs.twimg.com/profile_images/563648681526566912/zP8LPGCu_400x400.jpeg" style="width: 354px;" />
            <asp:Button ID="btnRandomJoke" runat="server" OnClick="btnRandomJoke_Click" Text="Random Joke" Font-Names="Stencil" Font-Bold="False" Font-Overline="False" Font-Size="Large" Height="55px" Width="359px" />
            <%--<asp:Label ID="lblEnterName" runat="server" Text="Enter a name ..."></asp:Label>--%> 
            <br />
            <asp:TextBox ID="txtCharacterEntry" runat="server" Height="24px" Width="265px" Font-Italic="True" Font-Names="Stencil" ForeColor="#999999" Font-Overline="False" OnClick="this.value=''">Enter a name...</asp:TextBox>&nbsp;
            <asp:Button ID="btnCharacterSearch" runat="server" Text="Search" ValidationGroup="Search" OnClick="btnCharacterSearch_Click" Font-Names="Stencil" Height="30px" Width="79px" />
            <br />
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCharacterEntry" ValidationGroup="Search" ErrorMessage="Name required for this search" Font-Names="arial" Font-Size="small" Font-Italic="true" ForeColor="red"></asp:RequiredFieldValidator>
            <br />
            <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCharacterEntry" ValidationGroup="Search" ErrorMessage=" Please enter two names. Up to 50 characters. No daft ones!" Font-Names="arial" Font-Size="small" Font-Italic="true" ForeColor="red" ValidationExpression="^[A-Za-z\-']+\s+[A-Za-z\-']+$" />
            
        </div>
    </form>
</body>
</html>
