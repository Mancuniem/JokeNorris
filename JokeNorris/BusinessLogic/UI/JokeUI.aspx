<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JokeUI.aspx.cs" Inherits="JokeNorris.JokeUI" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>True Chuck Norris facts, on demand!</title>
</head>
<body >
    <form id="frmChuck" runat="server" style="background-position: right top; position: center; width: 800px; height: 600px; font-family: Stencil; background-image: url(&quot;https://pbs.twimg.com/profile_images/563648681526566912/zP8LPGCu_400x400.jpeg&quot;); background-repeat: no-repeat; position: relative;">
        <div>
            <h1>Chuck Norris, true facts!</h1>
            <br />
            <br />
            <asp:Button ID="btnRandomJoke" runat="server" OnClick="btnRandomJoke_Click" Text="Random Joke" Font-Names="Stencil" Font-Bold="False" Font-Overline="False" Font-Size="Large" Height="68px" Width="210px" />
            <br />
            <br />
            <asp:Label ID="lblEnterName" runat="server" Text="Enter a name ..."></asp:Label> 
             
            <br />
             
            <asp:TextBox ID="txtCharacterEntry" runat="server" Height="42px" Width="200px"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCharacterEntry" ValidationGroup="Search" ErrorMessage="Name required for this search" Font-Names="arial" Font-Size="small" Font-Italic="true" ForeColor="red"></asp:RequiredFieldValidator>
            <p><asp:Button ID="btnCharacterSearch" runat="server" Text="Search" ValidationGroup="Search" OnClick="btnCharacterSearch_Click" Font-Names="Stencil" Height="46px" Width="70px" /></p>
            <asp:RegularExpressionValidator runat="server" ControlToValidate="txtCharacterEntry" ValidationGroup="Search" ErrorMessage=" Please enter two names. Up to 50 characters." Font-Names="arial" Font-Size="small" Font-Italic="true" ForeColor="red" ValidationExpression="[a-zA-Z\s+\']{1,50}" />
            
            <br />
            <br />
        </div>
    </form>
</body>
</html>
