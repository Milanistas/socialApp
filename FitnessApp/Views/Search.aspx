<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="FitnessApp.Views.Search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    
    <h3>Antal träffar på <i>"<%=Getq %>"</i> är <b><%=GetReg().Count() %></b></h3>

    <% foreach (var item in GetReg())
       {%>
    <a href="UserPosts.aspx?pId=<%=item.FirstName %>">
        <img class="img-circle" src="<%=item.ProfileImage %>" alt="<%=item.ProfileImage %>" height="70" width="70" />
        <%=item.FirstName %></a>
    <% } %>
</asp:Content>
