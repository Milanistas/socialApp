<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="FitnessApp.Views.Details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="menu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="body" runat="server">
    <script src="http://ajax.googleapis.com/ajax/libs/angularjs/1.4.8/angular.min.js"></script>

    Lägg till saker att göra för <b>
        <asp:Label runat="server" ID="dateLabel"></asp:Label></b>
    <div data-ng-app="listApp" data-ng-controller="listCtrl">
        <div style="padding: 10px" class="jumbotron">

            <input type="text" style="text-align: left; cursor:default !important" class="btn btn-form text" data-ng-model="textValue" onkeydown="return (event.keyCode != 13);" placeholder="Enter item" />
            <input type="button" style="" value="Lägg till" class="btn btn-success add" data-ng-click="addNew()" />

            <br />
            <br />

            <div data-ng-repeat="x in loopArr() track by $index">
                <input type="checkbox" data-ng-model="check" id="{{$index}}" style="display: none" />
                <label class="btn btn-success" for="{{$index}}" style="padding: 4px;">{{x}}</label>
                <div align="center">
                    <input type="button" value="Remove" data-ng-disabled="!check" class="btn btn-danger" data-ng-click="removeAtIndex($index)" />
                </div>
            </div>
            <br />
            <input type="button" value="Remove all" class="btn btn-danger" data-ng-hide="arrLength()" data-ng-click="remove()" />
            <a href="SaveInfo.aspx?values=<%="Träna" %>" class="btn btn-success" data-ng-hide="arrLength()" data-ng-click="save()" >Save</a>
        </div>
    </div>

    <style>
        input:checked + label {
            background-color: green !important;
            border-color: #398439 !important;
        }

        input + label {
            background-color: #D9534F !important;
            border-color: #D43F3A !important;
        }
    </style>

    <script>

        var app = angular.module('listApp', []);

        app.directive('myEnter', function () {
            return function (scope, element, attrs) {
                element.bind("keydown keypress", function (event) {
                    if (event.which === 13) {
                        scope.$apply(function () {
                            scope.$eval(attrs.myEnter);
                        });
                        event.preventDefault();
                        console.log(document.getElementsByClassName("add"));
                        //document.getElementsByClassName("add").onclick();
                    }
                });
            };
        });

        app.controller('listCtrl', function ($scope, $http, $rootScope) {

            $rootScope.check = false;
            var arr = [];
            $scope.addNew = function () {
                arr.push($scope.textValue);
                $scope.textValue = "";

                console.log(arr);
            };

            $scope.loopArr = function () {
                $scope.check = false;
                return arr;
            };
            $scope.removeAtIndex = function (index) {
                arr.splice(index, 1);
            };
            $scope.remove = function () {
                arr.splice(0, arr.length);
            };
            $scope.arrLength = function () {
                return !arr.length;
            }
            $scope.errors = [];
            $scope.msgs = [];

            $scope.save = function() {
                $scope.errors.splice(0, $scope.errors.length); // remove all error messages
                $scope.msgs.splice(0, $scope.msgs.length);

                $http.post('saveinfo.aspx', { 'values': arr }
                ).success(function(data, status, headers, config) {
                    if (data.msg != '') {
                        $scope.msgs.push(data.msg);
                    } else {
                        $scope.errors.push(data.error);
                    }
                }).error(function(data, status) { // called asynchronously if an error occurs
                    // or server returns response with an error status.
                    $scope.errors.push(status);
                });
            };
        });
    </script>
</asp:Content>
