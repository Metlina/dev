<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link rel="stylesheet" type="text/css" href="Style.css"/>
</head>
<body>
    <form id="form1" runat="server">
    <div id="body">
        <asp:CreateUserWizard ID="CreateUserWizard1" 
            runat="server"
            OnCreatedUser="CreateUserWizard1_OnCreatedUser"
            OnNextButtonClick="CreateUserWizard1_OnNextButtonClick" 
            RequireEmail="False">
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server"/>
                <asp:CompleteWizardStep runat="server"/>
            </WizardSteps>            
        </asp:CreateUserWizard>
    </div>
    </form>
</body>
</html>
