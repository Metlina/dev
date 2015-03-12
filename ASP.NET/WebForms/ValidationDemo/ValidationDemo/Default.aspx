<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ValidationDemo.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1"
            runat="server" 
            Text="Enter a value : "></asp:Label>
        <asp:TextBox 
            ID="TextBox1" 
            Text="Please enter name"
            runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidator1" 
            runat="server"
            ErrorMessage="Please change the text"
            InitialValue="Please enter name"
            ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator 
            ID="RequiredFieldValidator2" 
            runat="server"
            ErrorMessage="Please enter text"
            ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
        <br/>
        <asp:Button 
            ID="Button1" 
            runat="server" 
            Text="Submit" OnClick="Button1_Click" />
        <br/>
        <asp:Label 
            ID="Label2" 
            runat="server" 
            Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
