<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="body">
            <asp:Login ID="Login1" runat="server"
                DestinationPageUrl="~/KalkulatorContent.cshtml"
                OnAuthenticate="Login1_OnAuthenticate" />
            <br/>
            <h2><a href="Register.aspx">Register</a></h2>
        </div>

    </form>
</body>
</html>
