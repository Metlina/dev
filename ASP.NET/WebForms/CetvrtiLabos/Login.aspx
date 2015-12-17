<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link rel="stylesheet" type="text/css" href="Style.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="body">
            <asp:Login ID="Login1" runat="server"
                DestinationPageUrl="~/Default.aspx"
                OnAuthenticate="Login1_OnAuthenticate" />
            <br/>
            <%--<h2><a href="Register.aspx">Register</a></h2>--%>
        </div>
    </form>
</body>
</html>
