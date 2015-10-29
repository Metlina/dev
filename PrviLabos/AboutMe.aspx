<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AboutMe.aspx.cs" Inherits="AboutMe" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>About Me</title>
    <style>
        body {
            font-family: Segou UI;
            margin: 0 auto;
            width: 50%;
        }
        h1 {
            text-align: center;
            color: #BF40FF;
        }
        h2 {
            text-align: left;
            color: #BF40FF;
            margin-left: 50px;
        }
        #body {
            background-color: #9C9C9C
        }
        .myLabel {
            color: #4B61DE;
            margin-left: 20px;
            margin-top: 20px;
            margin-right: 20px;
            margin-bottom: 20px;

            padding: 10px;
        }
        .btnStyle {
            margin-left: 30px;
            padding: 10px;
            background-color: #4b61de;
            border-color:#4b61de;
        }
        .tboxStyle {
            padding: 10px;
        }
        .errorMessage {
            padding: 10px;
            font-size: 40px;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="body">
        <div id="content">
            <h1>About Me</h1>

            <asp:Label Text="Name :"
                CssClass="myLabel"
                runat="server"/>

            <asp:Label Text="Tino Petrina"
                CssClass="myLabel"
                runat="server"/>
            
            <br/>

            <asp:Label Text="Phone Number :"
                CssClass="myLabel"
                runat="server"/>
            
            <asp:Label Text="098 988 7085"
                CssClass="myLabel"
                runat="server"/>

            <br/>

            <asp:Label Text="E-mail :"
                CssClass="myLabel"
                runat="server"/>
            
            <asp:Label Text="tpetrina@tvz.hr"
                CssClass="myLabel"
                runat="server"/>
            <br/><br/><br/>
            
            <div>
                <h2><a href="Default.aspx">Go to home</a></h2>
            </div>
            
            <br/><br/><br/>

        </div>
    </div>
    </form>
</body>
</html>
