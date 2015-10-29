<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Calculus 001</title>
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
            background-color: #9C9C9C;
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
            border-color: #4b61de;
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

            <h1>Calculus 001</h1>

            <div id="content">

                <div id="firstNumber">
                    <asp:Label CssClass="myLabel"
                        Text="First number: "
                        runat="server" />
                    <asp:TextBox CssClass="tboxStyle"
                        ID="firstNubmerTbox"
                        runat="server" />
                    <asp:RegularExpressionValidator ErrorMessage="Only numbers are allowed !!!"
                        CssClass="errorMessage"
                        ControlToValidate="firstNubmerTbox"
                        ValidationExpression="((\d+)((\.\d{1,2})?))$"
                        ForeColor="Red"
                        runat="server" />
                </div>

                <br />

                <div id="secondNumber">
                    <asp:Label CssClass="myLabel"
                        Text="Second number: "
                        runat="server" />
                    <asp:TextBox CssClass="tboxStyle"
                        ID="secondNumberTbox"
                        runat="server" />
                    <asp:RegularExpressionValidator ErrorMessage="Only numbers are allowed !!!"
                        CssClass="errorMessage"
                        runat="server"
                        ControlToValidate="secondNumberTbox"
                        ForeColor="Red"
                        ValidationExpression="((\d+)((\.\d{1,2})?))$" />
                </div>

                <br />

                <div id="logic">
                    <asp:Button ID="plusBtn"
                        CssClass="btnStyle"
                        Text="+"
                        OnClick="Btn_Click"
                        runat="server" />
                    <asp:Button ID="minusBtn"
                        CssClass="btnStyle"
                        Text="-"
                        OnClick="Btn_Click"
                        runat="server" />
                    <asp:Button ID="multiplyBtn"
                        CssClass="btnStyle"
                        Text="*"
                        OnClick="Btn_Click"
                        runat="server" />
                    <asp:Button ID="divideBtn"
                        CssClass="btnStyle"
                        Text="/"
                        OnClick="Btn_Click"
                        runat="server" />
                </div>

                <br />

                <div id="trigonometryLogic">
                    <asp:Button ID="Button1"
                        CssClass="btnStyle"
                        Text="sin"
                        OnClick="TrigonometryBtn_Click"
                        runat="server" />
                    <asp:Button ID="Button2"
                        CssClass="btnStyle"
                        Text="cos"
                        OnClick="TrigonometryBtn_Click"
                        runat="server" />
                    <asp:Button ID="Button3"
                        CssClass="btnStyle"
                        Text="tan"
                        OnClick="TrigonometryBtn_Click"
                        runat="server" />
                    <asp:Button ID="Button4"
                        CssClass="btnStyle"
                        Text="ctn"
                        OnClick="TrigonometryBtn_Click"
                        runat="server" />

                    <asp:DropDownList ID="dropDownList"
                        runat="server"
                        Width="200px">
                        <%--<asp:ModelDataSource id="inputList"/>--%>
                        <asp:ListItem Text="Select Input" Value="0"></asp:ListItem>
                        <asp:ListItem Text="First Number" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Second Number" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Result Number" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <br />

                <div id="result">
                    <asp:Label CssClass="myLabel"
                        Text="Result: "
                        runat="server" />
                    <asp:TextBox CssClass="tboxStyle"
                        ID="resultTbox"
                        ReadOnly="True"
                        runat="server" />
                </div>

                <br />


                <div>
                    <asp:Label CssClass="myLabel"
                        Text="Date and time:"
                        runat="server" />
                    <asp:TextBox CssClass="tboxStyle"
                        ID="dateTimeTbox"
                        ReadOnly="True"
                        runat="server" />
                </div>

                <br />

                <div>
                    <asp:Label CssClass="myLabel"
                        Text="Trigonometry Result: "
                        runat="server" />
                    <asp:TextBox CssClass="tboxStyle"
                        ID="trigonometryResultTbox"
                        ReadOnly="True"
                        runat="server" />
                </div>
                
                <br/>
                    
                <asp:Table runat="server">
                    
                </asp:Table>
                                
                <div>
                    <h1><a href="http://www.tvz.hr">TVZ</a></h1>
                </div>

                <div>
                    <h2><a href="AboutMe.aspx">Go to about me</a></h2>
                </div>

                <br />
                <br />
                <br />
            </div>
        </div>
    </form>
</body>
</html>
