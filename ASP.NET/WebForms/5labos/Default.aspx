<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Default page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content">

        <asp:Label ID="LabelUser" runat="server" Text=""></asp:Label>

        <asp:PlaceHolder ID="containerMy" runat="server">
        </asp:PlaceHolder>

        <asp:PlaceHolder ID="containerUsers" runat="server">
        </asp:PlaceHolder>

    </div>
</asp:Content>

