﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>Calculus</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="body">

            <h1>Calculus 001</h1>
            
            <div id="content">

                <div id="firstNumber">
                    <asp:Label CssClass="myLabel"
                        Text="First number: "
                        runat="server" />
                    <asp:TextBox CssClass="tboxStyle"
                        ID="firstNubmerTbox"
                        runat="server" />
                    <asp:RegularExpressionValidator ErrorMessage="Only numbers are allowed !!!"
                        CssClass="errorMessage"
                        ControlToValidate="firstNubmerTbox"
                        ValidationExpression="((\d+)((\.\d{1,2})?))$"
                        ForeColor="Red"
                        runat="server" />
                </div>

                <br />

                <div id="secondNumber">
                    <asp:Label CssClass="myLabel"
                        Text="Second number: "
                        runat="server" />
                    <asp:TextBox CssClass="tboxStyle"
                        ID="secondNumberTbox"
                        runat="server" />
                    <asp:RegularExpressionValidator ErrorMessage="Only numbers are allowed !!!"
                        CssClass="errorMessage"
                        runat="server"
                        ControlToValidate="secondNumberTbox"
                        ForeColor="Red"
                        ValidationExpression="((\d+)((\.\d{1,2})?))$" />
                </div>

                <br />

                <div id="logic">
                    <asp:Button ID="plusBtn"
                        CssClass="btnStyle"
                        Text="+"
                        OnClick="Btn_Click"
                        runat="server" />
                    <asp:Button ID="minusBtn"
                        CssClass="btnStyle"
                        Text="-"
                        OnClick="Btn_Click"
                        runat="server" />
                    <asp:Button ID="multiplyBtn"
                        CssClass="btnStyle"
                        Text="*"
                        OnClick="Btn_Click"
                        runat="server" />
                    <asp:Button ID="divideBtn"
                        CssClass="btnStyle"
                        Text="/"
                        OnClick="Btn_Click"
                        runat="server" />
                </div>

                <br />

                <div id="trigonometryLogic">
                    <asp:Button ID="Button1"
                        CssClass="btnStyle"
                        Text="sin"
                        OnClick="TrigonometryBtn_Click"
                        runat="server" />
                    <asp:Button ID="Button2"
                        CssClass="btnStyle"
                        Text="cos"
                        OnClick="TrigonometryBtn_Click"
                        runat="server" />
                    <asp:Button ID="Button3"
                        CssClass="btnStyle"
                        Text="tan"
                        OnClick="TrigonometryBtn_Click"
                        runat="server" />
                    <asp:Button ID="Button4"
                        CssClass="btnStyle"
                        Text="ctn"
                        OnClick="TrigonometryBtn_Click"
                        runat="server" />

                    <asp:DropDownList ID="dropDownList"
                        runat="server"
                        Width="200px">
                        <asp:ListItem Text="Select Input" Value="0"></asp:ListItem>
                        <asp:ListItem Text="First Number" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Second Number" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Result Number" Value="3"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <br />

                <div id="result">
                    <asp:Label CssClass="myLabel"
                        Text="Result: "
                        runat="server" />
                    <asp:TextBox CssClass="tboxStyle"
                        ID="resultTbox"
                        ReadOnly="True"
                        runat="server" />
                </div>

                <br />


                <div>
                    <asp:Label CssClass="myLabel"
                        Text="Date and time:"
                        runat="server" />
                    <asp:TextBox CssClass="tboxStyle"
                        ID="dateTimeTbox"
                        ReadOnly="True"
                        runat="server" />
                </div>

                <br />

                <div>
                    <asp:Label CssClass="myLabel"
                        Text="Trigonometry Result: "
                        runat="server" />
                    <asp:TextBox CssClass="tboxStyle"
                        ID="trigonometryResultTbox"
                        ReadOnly="True"
                        runat="server" />
                </div>
                
                <br/>
            </div>
        </div>
</asp:Content>
