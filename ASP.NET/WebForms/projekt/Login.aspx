<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="Server">

    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <hr/>
                    <hr/>
                    <hr/>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Login ID="Login1" runat="server" DestinationPageUrl="~/Default.aspx" OnAuthenticate="Login_OnAuthenticate" />
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>

