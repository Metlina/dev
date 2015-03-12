<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebControls.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:CheckBox ID="SSD" Text="SSD?" runat="server" />
        <asp:CheckBox ID="SixteenGB" Text="16GB?" runat="server" />
        <asp:CheckBox ID="DualMonitor" Text="Dual Monitor?" runat="server" />
        <hr />
        <asp:RadioButton ID="Male" GroupName="Sex" Text="Male" runat="server" Checked="True" />
        <asp:RadioButton ID="Female" GroupName="Sex" Text="Female" runat="server" />
        <hr />
        <asp:CheckBoxList ID="CheckBoxList1" runat="server">
            <asp:ListItem Text="Power Windows" Value="Feature1"></asp:ListItem>
            <asp:ListItem Text="Power Seats" Value="Feature2"></asp:ListItem>
            <asp:ListItem Text="Fog Lights" Value="Feature3"></asp:ListItem>
            <asp:ListItem Text="Winter Package" Value="Feature4"></asp:ListItem>
        </asp:CheckBoxList>
        <hr />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server">
            <asp:ListItem Text="Under 30" Value="Young" Selected="true"></asp:ListItem>
            <asp:ListItem Text="30-60" Value="Middle"></asp:ListItem>
            <asp:ListItem Text="Over 60" Value="Old"></asp:ListItem>
        </asp:RadioButtonList>
        <hr />
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Text="Item 1" Value="1"></asp:ListItem>
            <asp:ListItem Text="Item 2" Value="2"></asp:ListItem>
            <asp:ListItem Text="Item 3" Value="3"></asp:ListItem>
            <asp:ListItem Text="Item 4" Value="4"></asp:ListItem>
            <asp:ListItem Text="Item 5" Value="5"></asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
        <asp:Label ID="Message" runat="server" Text=""></asp:Label>re
        


    </div>
    </form>
</body>
</html>
