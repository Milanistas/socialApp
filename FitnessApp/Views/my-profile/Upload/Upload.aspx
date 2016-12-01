<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Upload.aspx.cs" Inherits="FitnessApp.Views.my_profile.Upload.Upload" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <% foreach (var item in GetUpload())
       {%>
    <div class="jumbotron">
        <img height="300" width="300" src="<%=item.UpImg %>" alt="<%=item.UpImg %>" />
        <br />
        <%=item.Comm %>
    </div>
    <%} %>
    <h2>Comment</h2>
    <% foreach (var item in GetComment())
       {%>
    <div class="jumbotron">
        <%=item.PostedComment %>
    </div>
    <%} %>
    <br />
    <asp:TextBox runat="server" ID="comm" CssClass="form-control"></asp:TextBox>
    <asp:Button ID="Save" runat="server" CssClass="btn btn-form" Text="Post" OnClick="SaveComment" />

</asp:Content>
