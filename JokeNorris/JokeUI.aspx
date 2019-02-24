<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JokeUI.aspx.cs" Inherits="JokeNorris.JokeUI" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>foo</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnRandomJoke" runat="server" OnClick="btnRandomJoke_Click" Text="Random Joke" />
            <br />
            <br />
            <br />
            <asp:TextBox ID="txtCharacterEntry" runat="server"></asp:TextBox>
            <asp:Button ID="btnCharacterSearch" runat="server" Text="Search" />
            <br />
            <br />
            <br />
            <asp:Button ID="btnNeverEndingJokes" runat="server" Text="Never-ending Jokes" OnClick="btnNeverEndingJokes_Click" />
        </div>
    </form>
</body>
</html>
