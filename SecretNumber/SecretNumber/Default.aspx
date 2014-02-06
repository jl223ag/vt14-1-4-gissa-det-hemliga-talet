<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SecretNumber.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gissa det hemliga talet</title>
    <link rel="stylesheet" href="css/style.css" />
</head>
<body>
    <h1>Gissa det hemliga talet</h1>
    <form id="form1" runat="server">
        <div>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="red" ValidationGroup="ThaGuess" />

            <asp:Label ID="Ange" runat="server" Text="Ange ett tal mellan 1 och 100:"></asp:Label>
            <asp:TextBox ID="InputField" runat="server"></asp:TextBox>

            <%--validation controls --%>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Fältet får inte vara tomt" ControlToValidate="InputField" CssClass="red" Display="Dynamic" ValidationGroup="ThaGuess">*</asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Talet måste vara mellan 1 och 100" ControlToValidate="InputField" CssClass="red" MaximumValue="100" MinimumValue="1" Type="Integer" Display="Dynamic" ValidationGroup="ThaGuess">*</asp:RangeValidator>
            <%--validation end --%>

            <asp:Button ID="Send" runat="server" Text="Skicka gissning" OnClick="Send_Click" ValidationGroup="ThaGuess" />
            <asp:Label ID="GuessHolder" runat="server" Text=""></asp:Label>
            <asp:Label ID="WinText" runat="server" Text=""></asp:Label>
            <asp:Button ID="GetNewNumber" runat="server" Text="Slumpa ett nytt tal" OnClick="GetNewNumber_Click" Visible="false" />
        </div>
    </form>
    <script src="script/script.js"></script>
</body>
</html>
