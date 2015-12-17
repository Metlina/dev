<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SlideShow.aspx.cs" Inherits="SlideShow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="body">
        <asp:ScriptManager ID="SriptManager1" runat="server">
        </asp:ScriptManager>
        
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <asp:Image ID="Image1" ImageUrl="/Images/Image1.jpg" runat="server"/>
                <asp:Timer ID="Timer1" Interval="1000" OnTick="Timer1_OnTick" runat="server"/>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

