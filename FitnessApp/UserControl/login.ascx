﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="login.ascx.cs" Inherits="FitnessApp.UserControl.login" %>
<h3>Logon Page</h3>
<table>
    <tr>
        <td>E-mail address:</td>
        <td>
            <asp:TextBox ID="UserEmail" runat="server" /></td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                ControlToValidate="UserEmail"
                Display="Dynamic"
                ErrorMessage="Cannot be empty."
                runat="server" />
        </td>
    </tr>
    <tr>
        <td>Password:</td>
        <td>
            <asp:TextBox ID="UserPass" TextMode="Password"
                runat="server" />
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                ControlToValidate="UserPass"
                ErrorMessage="Cannot be empty."
                runat="server" />
        </td>
    </tr>
    <tr>
        <td>Remember me?</td>
        <td>
            <asp:CheckBox ID="Persist" runat="server" /></td>
    </tr>
</table>
<asp:Button ID="Submit1" OnClick="Logon_Click" Text="Log On"
    runat="server" />
<p>
    <asp:Label ID="Msg" ForeColor="red" runat="server" />
</p>
