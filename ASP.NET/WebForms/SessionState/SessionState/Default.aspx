<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SessionState.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Labe1" runat="server" Text="Enter your name : "></asp:Label>
        <asp:TextBox ID="Name" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Enter your email : "></asp:Label>
        <asp:TextBox ID="Email" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Save" runat="server" Text="Save" OnClick="Save_Click" />
        <asp:Button ID="Retrieve" runat="server" Text="Retrieve" OnClick="Retrieve_Click" />
        <br />
        <asp:Label ID="NameAndEmail" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="RetrievedNameAndEmail" runat="server" Text=""></asp:Label>
        <br />
    </div>
    </form>
</body>
</html>
