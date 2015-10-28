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
    
            <h1>Calculus 001</h1>
            
            <div id="content">
                
                <div id="firstNumber">
                    <asp:Label CssClass="myLabel" 
                        Text="First number: " 
                        runat="server"/>
                    <asp:TextBox CssClass="tboxStyle" 
                        ID="firstNubmerTbox" 
                        OnTextChanged="firstNubmerTbox_OnTextChanged" 
                        runat="server"/>
                    <asp:RegularExpressionValidator ErrorMessage="Only numbers are allowed !!!" 
                        CssClass="errorMessage"
                        ControlToValidate="firstNubmerTbox"
                        ValidationExpression="((\d+)+(\.\d+))$"
                        ForeColor="Red"
                        runat="server"/>
                </div> 
                
                <br/>

                <div id="secondNumber">
                    <asp:Label CssClass="myLabel" 
                        Text="Second number: " 
                        runat="server"/>
                    <asp:TextBox CssClass="tboxStyle" 
                        ID="secondNumberTbox" 
                        runat="server"/>
                    <asp:RegularExpressionValidator ErrorMessage="Only numbers are allowed !!!" 
                        CssClass="errorMessage"
                        runat="server"
                        ControlToValidate="secondNumberTbox"
                        ForeColor="Red"
                        ValidationExpression="((\d+)+(\.\d+))$"
                        />
                </div> 

                <br/>

                <div id="logic">
                    <asp:Button ID="plusBtn"
                        CssClass="btnStyle"
                        Text="+" 
                        OnClick="Btn_Click" 
                        runat="server"/>
                    <asp:Button ID="minusBtn" 
                        CssClass="btnStyle" 
                        Text="-" 
                        OnClick="Btn_Click" 
                        runat="server"/>
                    <asp:Button ID="multiplyBtn" 
                        CssClass="btnStyle" 
                        Text="*" 
                        OnClick="Btn_Click" 
                        runat="server"/>
                    <asp:Button ID="divideBtn"
                         CssClass="btnStyle" 
                        Text="/" 
                        OnClick="Btn_Click" 
                        runat="server"/>
                </div> 
                
                <br/>
                
                <div id="result">
                    <asp:Label CssClass="myLabel" 
                        Text="Result: " 
                        runat="server"/>
                    <asp:TextBox CssClass="tboxStyle" 
                        ID="resultTbox" 
                        ReadOnly="True" 
                        runat="server"/>
                </div>
                
                <br/><br/><br/>
            </div>

        </div>
    </form>
</body>
</html>
