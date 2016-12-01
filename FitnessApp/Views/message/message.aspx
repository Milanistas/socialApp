<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="message.aspx.cs" Inherits="FitnessApp.Views.message.message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <div class="jumbotron">
        <div>
            <asp:TextBox ID="Chat" runat="server" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
        </div>
        <div>
            <asp:TextBox TextMode="MultiLine" runat="server" ID="text"></asp:TextBox>
            <asp:Button runat="server" OnClick="Post"/>
        </div>
    </div>
</asp:Content>
