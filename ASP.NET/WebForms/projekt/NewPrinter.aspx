<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewPrinter.aspx.cs" Inherits="NewPrinter" %>

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
                        <asp:Label runat="server" AssociatedControlID="PrinterModel" CssClass="col-md-2 control-label">Printer model</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="PrinterModel" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="PrinterModel"
                                CssClass="text-danger" ErrorMessage="The printer model field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="PrinterType" CssClass="col-md-2 control-label">Printer type</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="PrinterType" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="PrinterType"
                                CssClass="text-danger" ErrorMessage="The printer type field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="PrinterMaterial" CssClass="col-md-2 control-label">Printer material</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="PrinterMaterial" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="PrinterMaterial"
                                CssClass="text-danger" ErrorMessage="The printer material field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="PrinterLocation" CssClass="col-md-2 control-label">Printer location</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="PrinterLocation" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="PrinterLocation"
                                CssClass="text-danger" ErrorMessage="The printer location field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="PrinterMark" CssClass="col-md-2 control-label">Printer mark</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="PrinterMark" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="PrinterMark"
                                CssClass="text-danger" ErrorMessage="The printer mark field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="PrinterFunction" CssClass="col-md-2 control-label">Printer function</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="PrinterFunction" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="PrinterFunction"
                                CssClass="text-danger" ErrorMessage="The printer function field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="PrinterPaper" CssClass="col-md-2 control-label">Printer paper</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="PrinterPaper" CssClass="form-control" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="PrinterPaper"
                                CssClass="text-danger" ErrorMessage="The printer paper field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="AddNewPrinter_OnClick" Text="Add new printer" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>

</asp:Content>

