<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BreadCrumb.ascx.cs" Inherits="FitnessApp.UserControl.BreadCrumb" %>
<asp:Repeater runat="server" ID="rep">
    <ItemTemplate>



        <% if (LastJ - 1 == K)
           { %>
        &nbsp;<%#Eval("Key") %>&nbsp;
        <% K++;
           } %>
        <%
           else
           { %>
        <a style="text-decoration: none" href="<%#Eval("Value") + "?guid=" + Request.QueryString["guid"] %>">&nbsp;<%#Eval("Key")  %>&nbsp;</a> /
        <% K++;
           } %>
    </ItemTemplate>
</asp:Repeater>
