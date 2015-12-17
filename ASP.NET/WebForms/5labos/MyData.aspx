<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyData.aspx.cs" Inherits="MyData" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>My data</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="LabelStatus" runat="server" Text=""></asp:Label>

    Name:
    <asp:TextBox ID="LabelName2" runat="server"/><br />
    <br />
    Surname:
    <asp:TextBox ID="LabelSurname2" runat="server"/><br />
    <br />

    <asp:Button ID="BtnSave" runat="server" Text="Save changes" Visible="False" OnClick="BtnSave_OnClick"/>
</asp:Content>

