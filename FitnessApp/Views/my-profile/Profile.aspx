<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="FitnessApp.Views.my_profile.Profile" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
</asp:Content>--%>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">

    <div style="width: 100px; margin: 0 auto">
        <a href="/Views/my-profile/Settings.aspx">
            <asp:Image CssClass="img-circle img-responsive" Style="border: 2px lightgray solid; margin: 0 auto;" Width="100" Height="100" runat="server" ID="ProfileImg" /></a>
    </div>

    <div class="container jumbotron" style="max-width: 100%; width: 520px; border-radius: 10px;">
        <div class="form-group">
            <asp:Button runat="server" Style="display: none" CssClass="btn btn-success Comm" Text="OK" OnClick="Comm_Click" />
            <asp:TextBox runat="server" Wrap="True" Style="width: 500px; max-width: 100%" ID="textarea" placeholder="Vad gör du just nu?" CssClass="col-md-4 col-sm-4 col-xs-5 btn-info form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
            <asp:FileUpload Style="display: none" runat="server" ID="fi" AllowMultiple="True" />
            <a id="glyphicon-picture" class="btn btn-default btn-sm">
                <span style="cursor: pointer" class="glyphicon glyphicon-picture"></span>
                Picture
            </a>
            <span id="file"></span>
        </div>
    </div>
    
    <div align="left" style="width: 450px; height: auto;">
        <h2>Picture</h2>
        <% foreach (var item in GetImgUploads().Take(9))
           {%>
        <img src="<%=item.UpImg %>" alt="<%=item.UpImg %>" height="120" width="120" style="margin-bottom: 10px;" />
        <% } %>
    </div>

    <h2 style="text-align: center">Inlägg</h2>

    <asp:Repeater runat="server" ID="rep">
        <ItemTemplate>
            <div class="container jumbotron" style="max-width: 100%; width: 520px; border-radius: 10px;">
                <asp:Button runat="server" Style="float: right" CssClass="btn btn-form" CommandArgument='<%#Eval("Id") %>' Text="Remove" OnClick="Remove" />
                <h3><img width="70" class="img-circle" alt="<%#Eval("Register.ProfileImage") %>" src="<%#Eval("Register.ProfileImage") %>" />
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
                <a id="shortlink" href="Upload/Upload.aspx?id=<%#Eval("id") %>" class="btn btn-default btn-sm">
                    <span class="glyphicon glyphicon-comment"></span>
                    Comment
                </a>
                <span style="float: right"><%#Eval("CommDate") %></span>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <script>

        (function () {
            new Clipboard('#copy');
        })();

        var UpImg = $(".UpImg img");
        for (var i = 0; i < UpImg.length; i++) {
            var current = UpImg[i];

            if (current.currentSrc === "")
                $(current).remove();
        }

        $("textarea").keypress(function (e) {

            if ($("textarea").val().match(/[A-z0-9!"#%/()=?´+\´~¨^'*-.,§@£€\{}]/) || $("input[type=file]").val() !== "") {
                if (e.keyCode == 13) {
                    $('.Comm').click();
                    $("textarea").val("");
                }
            }
        });


        $("#glyphicon-picture").click(function () {
            $("input[type=file]").click();
        });

        $("#glyphicon-picture").mouseleave(function () {
            var m = $("input[type=file]").val().split('\\');
            var p = m[m.length - 1];

            if (p !== "" && p !== undefined)
                document.getElementById("file").innerText = p + "  (" + m.length / 3 + ")";
        });
        //console.log($(""));
    </script>
</asp:Content>
