<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AboutMe.aspx.cs" Inherits="AboutMe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>About Me</title>
    <link rel="stylesheet" type="text/css" href="Style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="body">
            <div id="content">
                <h1>About Me</h1>

                <asp:Label Text="Name :"
                    CssClass="myLabel"
                    runat="server" />

                <asp:Label Text="Tino Petrina"
                    CssClass="myLabel"
                    runat="server" />

                <br />

                <asp:Label Text="Phone Number :"
                    CssClass="myLabel"
                    runat="server" />

                <asp:Label Text="098 988 7085"
                    CssClass="myLabel"
                    runat="server" />

                <br />

                <asp:Label Text="E-mail :"
                    CssClass="myLabel"
                    runat="server" />

                <asp:Label Text="tpetrina@tvz.hr"
                    CssClass="myLabel"
                    runat="server" />
                <br />
                <br />
                <br />

                <div>
                    <h2><a href="Default.aspx">Go to home</a></h2>
                </div>

                <asp:LoginStatus ID="LoginStatus1" runat="server" LoginText="Log In" LogoutText="Log Out" />

                <br />
                <asp:LoginName ID="LoginName2" runat="server" />

                <br />
                <br />

            </div>
        </div>
    </form>
</body>
</html>
