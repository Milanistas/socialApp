<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="FitnessApp.Views.Settings" %>

<%--<style>
    .profile {
        background-color: ;
    }
</style>--%>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <asp:Panel Visible="True" runat="server" ID="p">
        <div class="jumbotron" style="border-radius: 10px; width: 40%; margin: 0 auto;">
            <h2 style="text-align: center">Min Profil</h2>
            <br />
            <br />
            <asp:Image CssClass="img-circle img-responsive" Style="border: 2px lightgray solid; margin: 0 auto;" Width="200" Height="200" runat="server" ID="ProfileImg" />
            <br />
            <asp:FileUpload TabIndex="1" runat="server" ID="ImgUp" CssClass="btn btn-info" Style="margin: 0 auto; max-width: 100%;" />
            <br />
            <asp:TextBox runat="server" ID="firstName" CssClass="form-control" TabIndex="2" Style="margin: 0 auto; max-width: 100%; width: 298px" placeholder="Förnamn"></asp:TextBox>
            <br />
            <asp:TextBox runat="server" CssClass="form-control" TabIndex="3" Style="margin: 0 auto; max-width: 100%; width: 298px" placeholder="Efternamn"></asp:TextBox>
            <br />
            <br />
            <br />
            <asp:LinkButton TabIndex="4" ID="ProfileImg1" runat="server" Text="Spara" CssClass="btn btn-success" OnClick="ProfileImg_Click" Style="max-width: 100%; width: 100%; font-size: large; height: 40px" />
            <br />
            <br />
            <asp:LinkButton TabIndex="5" ID="ProfileImg2" runat="server" Text="Ta bort" CssClass="btn btn-danger" OnClick="ProfileImg1_Click" Style="width: 100%; max-width: 100%; font-size: large; height: 40px" />
        </div>
    </asp:Panel>
    <script>
        var m = "Allegri";
        console.log(m.toLowerCase());
        $("#body_ImgUp").click(function () {
            //console.log($("<%=ImgUp.ClientID%>"));



            if (document.getElementById("body_ImgUp").value !== "")
                document.getElementById("body_ProfileImg").value = document.getElementById("body_ImgUp").value;

            //if (imgsrc === "" || imgsrc === null || imgsrc === undefined)
            //    $("img").attr("src", "/Static/Profile/profile.png");
        });
    </script>
</asp:Content>
