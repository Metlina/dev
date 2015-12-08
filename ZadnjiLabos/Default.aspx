<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>6 labos</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:HyperLink ID="HyperLinkAritmetika" runat="server" NavigateUrl="Default.aspx?index=0">Aritmetika</asp:HyperLink>
        <asp:HyperLink ID="HyperLinkTrigonometrija" runat="server" NavigateUrl="Default.aspx?index=1">Trigonometrija</asp:HyperLink>
        <asp:HyperLink ID="HyperLinkTablicaMnozenja" runat="server" NavigateUrl="Default.aspx?index=2">TablicaMnozenja</asp:HyperLink>
        <asp:HyperLink ID="HyperLink3MojiPodaci" runat="server" NavigateUrl="Default.aspx?index=3">MojiPodaci</asp:HyperLink>
        
        <br />
        <br />
        <br />

        <asp:MultiView ID="MultiViewMain" runat="server">
            <%-- Aritmetika --%>
            <asp:View runat="server">
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
                
                <br/>

                 <div id="result">
                    <asp:Label CssClass="myLabel"
                        Text="Result: "
                        runat="server" />
                    <asp:TextBox CssClass="tboxStyle"
                        ID="resultTbox"
                        ReadOnly="True"
                        runat="server" />
                </div>
            </asp:View>
            
            <%-- Trigonometrija --%>
            <asp:View runat="server">
                <div >
                    <asp:Label CssClass="myLabel"
                        Text="Enter number: "
                        runat="server" />
                    <asp:TextBox CssClass="tboxStyle"
                        ID="trigonometryNumberTbox"
                        runat="server" />
                    <asp:RegularExpressionValidator ErrorMessage="Only numbers are allowed !!!"
                        CssClass="errorMessage"
                        ControlToValidate="trigonometryNumberTbox"
                        ValidationExpression="((\d+)((\.\d{1,2})?))$"
                        ForeColor="Red"
                        runat="server" />
                </div>
                
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

                </div>

                <br/>

                <div>
                    <asp:Label CssClass="myLabel"
                        Text="Result: "
                        runat="server" />
                    <asp:TextBox CssClass="tboxStyle"
                        ID="trigonometryResultTbox"
                        ReadOnly="True"
                        runat="server" />
                </div>
            </asp:View>
            
            <%-- Tablica mnozenja --%>
            <asp:View runat="server">
                <div>
                    <asp:Table ID="Table1" runat="server" CellSpacing="0" CellPadding="5"/>
                </div>
            </asp:View>
            
            <%-- Moji podaci --%>
            <asp:View runat="server">
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
            </asp:View>
        </asp:MultiView>
        
        <br />
        <br />
        <br />

    </div>
    </form>
</body>
</html>
