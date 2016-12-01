<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="UserPosts.aspx.cs" Inherits="FitnessApp.Views.UserPosts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <h2 style="text-align: center"><%= string.IsNullOrEmpty(GetPId) ? "Alla inlägg" : "inlägg av " + GetPId %></h2>

    <asp:Repeater runat="server" ID="rep">
        <ItemTemplate>
            <div class="container jumbotron" style="max-width: 100%; width: 520px; border-radius: 10px;">
                <h3><img style="width: 70px" class="img-circle" alt="<%#Eval("Register.ProfileImage") %>" src="<%#Eval("Register.ProfileImage") %>" />
                <%#Eval("Register.FirstName") %></h3>
                <div class="form-group">
                    <br />
                    <div id="w" style="width: 500px; max-width: 100%; word-wrap: break-word; height: auto;" class="col-md-4 col-sm-3 col-xs-5 form-control">
                        <%#Eval("Comm")%>
                        <div class="UpImg">
                            <img style="width: 150px; height: 170px; max-width: 100%" src="<%#Eval("UpImg") %>" />
                        </div>
                    </div>
                </div>
                <button type="button" class="btn btn-default btn-sm">
                    <span class="glyphicon glyphicon-thumbs-up"></span>
                    Like
                </button>
                <a id="copy" data-clipboard-target="#shortlink" type="button" class="btn btn-default btn-sm">
                    <span class="glyphicon glyphicon-share"></span>
                    Share
                </a>
                <a id="shortlink" href="my-profile/Upload/Upload.aspx?id=<%#Eval("id") %>" class="btn btn-default btn-sm">
                    <span class="glyphicon glyphicon-comment"></span>
                    Comment
                </a>
                <span style="float: right"><%#Eval("CommDate") %></span>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
