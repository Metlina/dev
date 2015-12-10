<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>6 labos</title>
</head>
<body>
    <form id="form1" runat="server">

        <div>
            <asp:LoginStatus ID="LoginStatus1" CssClass="LoginStatus1" runat="server" LoginText="Prijava" LogoutText="Odjava" />
        </div>

        <br />

        <div>
            <asp:HyperLink ID="HyperLinkLogin" runat="server" NavigateUrl="Default.aspx?index=0">Login</asp:HyperLink>
            <asp:HyperLink ID="HyperLinkAritmetika" runat="server" NavigateUrl="Default.aspx?index=1">Aritmetika</asp:HyperLink>
            <asp:HyperLink ID="HyperLinkTrigonometrija" runat="server" NavigateUrl="Default.aspx?index=2">Trigonometrija</asp:HyperLink>
            <asp:HyperLink ID="HyperLinkTablicaMnozenja" runat="server" NavigateUrl="Default.aspx?index3">TablicaMnozenja</asp:HyperLink>
            <asp:HyperLink ID="HyperLink3MojiPodaci" runat="server" NavigateUrl="Default.aspx?index=4">MojiPodaci</asp:HyperLink>
            <asp:HyperLink ID="HyperLinkRegistracija" runat="server" NavigateUrl="Default.aspx?index=5">Registracija</asp:HyperLink>
            <asp:HyperLink ID="HyperLinkKalendar" runat="server" NavigateUrl="Default.aspx?index=6">Kalendar</asp:HyperLink>
            <asp:HyperLink ID="HyperLinkUpload" runat="server" NavigateUrl="Default.aspx?index=7">Upload</asp:HyperLink>
            <asp:HyperLink ID="HyperLinkDownload" runat="server" NavigateUrl="Default.aspx?index=8">Download</asp:HyperLink>

            <br />
            <br />
            <br />

            <asp:MultiView ID="MultiViewMain" runat="server">

                <%-- Login --%>
                <asp:View runat="server">
                    <asp:Login ID="Login1" runat="server"
                        DestinationPageUrl="~/Default.aspx"
                        OnAuthenticate="Login1_OnAuthenticate" />
                </asp:View>

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
                </asp:View>

                <%-- Trigonometrija --%>
                <asp:View runat="server">
                    <div>
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

                    <br />

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
                        <asp:Table ID="Table1" runat="server" CellSpacing="0" CellPadding="5" />
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

                <%-- Registracija --%>
                <asp:View runat="server">
                    <asp:CreateUserWizard ID="CreateUserWizard1"
                        runat="server"
                        RequireEmail="False">
                        <WizardSteps>
                            <asp:CreateUserWizardStep runat="server" />
                            <asp:CompleteWizardStep runat="server" />
                        </WizardSteps>
                    </asp:CreateUserWizard>
                </asp:View>

                <%-- Kalendar --%>
                <asp:View runat="server">
                    <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
                    <asp:Label ID="LabelCalendarInfo" runat="server" Style="color: Red; font-weight: bold" Text=""></asp:Label><br />
                    <asp:TextBox ID="TextBoxCalendarUnos" runat="server"></asp:TextBox>
                    <asp:Button ID="ButtonCalendarSpremi" runat="server" Text="Spremi" OnClick="ButtonCalendarSpremi_Click" />
                </asp:View>

                <%-- Upload --%>
                <asp:View runat="server">
                    <asp:FileUpload ID="FileUploadControl" runat="server" />
                    <asp:Button runat="server" ID="UploadButton" Text="Upload" OnClick="UploadButton_Click" />
                    <br />
                    <br />
                    <asp:Label runat="server" ID="StatusLabel" Text="Upload status: " />
                </asp:View>

                <%-- Download --%>
                <asp:View runat="server">
                    <div>
                        <asp:GridView ID="gridview1" CellPadding="5" runat="server" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk_Select" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Text" HeaderText="FileName" />
                            </Columns>
                            <HeaderStyle BackColor="white" Font-Bold="true" ForeColor="White" />
                        </asp:GridView>
                        <asp:Button ID="btn_Download" Text="Download " runat="server" OnClick="btnDownload_Click" />
                    </div>
                </asp:View>
            </asp:MultiView>

            <br />
            <br />
            <br />

        </div>
    </form>
</body>
</html>
