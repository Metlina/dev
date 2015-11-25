<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AboutMe.aspx.cs" Inherits="AboutMe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>About Me</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="body">
            <div id="content">
                <h1>About Me</h1>

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
                <br />
                <br />
                <br />
            </div>
        </div>
</asp:Content>

