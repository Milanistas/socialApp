<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" MasterPageFile="~/MasterPages/Site.Master" Inherits="FitnessApp.Views.Default" %>
<%@ Import Namespace="System.IO" %>

<asp:Content runat="server" ContentPlaceHolderID="menu">
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="body">
    <%--<form runat="server">--%>
    <div class=""></div>

    <div class="jumbotron">
        <h1 style="text-align: center">Välkommen Till FitnessTalk</h1>
    </div>

    <%--<asp:FileUpload runat="server" ID="file" CssClass="btn btn-success" />--%>
    
<%--    <%
        foreach (var item in GetImage())
       {
           %>
        <img height="250" width="300" src="<%= item%>" class="img-re"/>  
    <%  
       } %>--%>

    <%--<asp:Image runat="server" ID="image" Height="250" Width="300"/>--%>
    <%--<asp:Button runat="server" OnClick="Page_Load" Text="OK" CssClass="btn btn-form"/>--%>

    <%--<div data-ng-app="myApp" data-ng-controller="calendarCtrl">
            <div style="" data-ng-repeat="x in 'Milad' track by $index">
                <ul style="width: 200px; height: 100px; background-color: gray">
                   <li>{{$index +1}}</li> 
                </ul> 
            </div>
        </div>--%>

    <asp:Panel runat="server" Visible="True">
        <div style="margin: 0 auto; width: 100%">
            <div class="jumbotron" style="text-align: center">
                <h2>Din TräningsKalender för <%= DateTime.Now.Year%></h2>
            </div>

            <div class="jumbotron col-xs-12 col-sm-12 col-md-12" style="background-color: white">
                <% int i = 0, id = 1;
                   foreach (var item in GetCalendarMonths())
                   {
                       if (MonthBegun)
                       { %>
                <div style="text-align: center; margin-left: -70px" class="col-xs-12 col-sm-12 col-md-12">
                    <h1>
                        <%=GetMonthName(++i) %>
                    </h1>
                </div>
                <% } %>

                <div style="margin-left: 20px">
                    <a href="Details.aspx?id=<%=id++ %>&day=<%=HttpUtility.UrlEncode(item.Substring(3)) %>&month=<%=GetMonthName(i) %>&nday=<%=item.Substring(0, 2).Replace(".", "") %>" class="col-xs-12 col-sm-12 col-md-12 btn btn-info" style="text-align: left; width: 150px; height: 100px; margin-right: 15px; padding-bottom: 65px; margin-bottom: 10px"><%= item %> </a>
                </div>
                <%--<textarea wrap="hard" class="col-xs-5 col-md-2 btn btn-form" style="resize: none; white-space: normal; padding-right: -30px; text-align: left; width: auto; border: 1px solid lightgray; height: 80px"></textarea>--%>

                <% 
                   }
                %>
            </div>
        </div>
    </asp:Panel>
    <%--</form>--%>
    <script>
        $(document).ready(function () {
            //window.open(href, window.name, ',type=fullWindow,fullscreen,scrollbars=yes');
            $('button').click(function (e) {
                e.preventDefault();
            });
            $('.text').keypress(function (e) {
                //if (e.keyCode == 13)
                //$('.add').click();
            });

            $("a").click(function () {
                //window.open("http://www.google.com/", "fullWindow", "location=no,type=fullWindow,fullscreen,scrollbars=yes");
                $(this).css("background-color", "green");
            });
        });
        //});
    </script>
</asp:Content>
