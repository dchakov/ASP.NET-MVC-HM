<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Greeting.aspx.cs" Inherits="Template.Greeting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <form id="FormGreetings" runat="server">
        Enter your name:<asp:TextBox ID="TextBoxName" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonGreetings" runat="server" Text="Greetings" OnClick="ButtonGreetings_Click" />
        <br />
        <asp:Literal ID="LiteralGreetings" Text="" Mode="Encode" runat="server" />
    </form>
</body>
</html>
