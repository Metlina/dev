<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewStorage.aspx.cs" Inherits="NewStorage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <h4>Please fill all fields</h4>
                    <hr />
                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Paper" CssClass="col-md-2 control-label">Paper : </asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Paper" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Paper"
                                CssClass="text-danger" ErrorMessage="The paper field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Ink" CssClass="col-md-2 control-label">Ink : </asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Ink" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Ink"
                                CssClass="text-danger" ErrorMessage="The ink field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Parts" CssClass="col-md-2 control-label">Parts : </asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Parts" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Parts"
                                CssClass="text-danger" ErrorMessage="The parts field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Mark" CssClass="col-md-2 control-label">Mark : </asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Mark" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Mark"
                                CssClass="text-danger" ErrorMessage="The mark field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="AddNewStorageData_OnClick" Text="Add storage materials" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>

