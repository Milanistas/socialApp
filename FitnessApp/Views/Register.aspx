﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FitnessApp.Views.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="form-group">
        FirstName:
    <asp:TextBox runat="server" ID="fName"></asp:TextBox>
        Password:
    <asp:TextBox runat="server" ID="pass" TextMode="Password"></asp:TextBox>
        <asp:Button runat="server" Text="Save" OnClick="Btn_Click" CssClass="btn btn-form" />
    </div>
</asp:Content>