<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Register.ascx.cs" Inherits="FitnessApp.UserControl.Register" %>

<h2>Register</h2>
<div class="form-group">
    FirstName:
    <asp:TextBox runat="server" ID="fName"></asp:TextBox>
    Password:
    <asp:TextBox runat="server" ID="pass" TextMode="Password"></asp:TextBox>
    <asp:Button runat="server" Text="Save" OnClick="Btn_Click" CssClass="btn btn-form" />
    <br/>
    <asp:Label runat="server" ID="text"></asp:Label>
</div>
