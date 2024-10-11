<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs"
    Inherits="reema7266e.LogIn.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table class="style1">
        <tr><td colspan="2"><strong><span style="font-size: large"><br /><br />Welcome</span></strong></td></tr>
        <tr>
            <td class="style2" style="font-size: medium"><strong>Login</strong></td>
            <td><br /><br /></td>
        </tr>
        <tr>
            <td class="style2" id="txtUserName" style="font-size: 14pt"><strong>User Name</strong></td>
            <td>
                <strong>
                <asp:TextBox ID="txtUserName" runat="server" style="font-size: medium"></asp:TextBox>
                </strong>
            </td>
        </tr>
        <tr>
            <td class="style2" id="txtPassword" style="font-size: medium"><strong>Password</strong></td>
            <td>
                <strong>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" style="font-size: medium"></asp:TextBox> 
                </strong> 
            </td>
        </tr>
        <tr>
            <td class="style2">&nbsp;</td>
            <td>
                <strong>
                <asp:Button ID="btnLogin" runat="server" onclick="btnLogin_Click" 
                    Text="Login" style="font-weight: bold; font-size: medium" />
                </strong>
            </td>
        </tr>
        <tr>
            <td class="style2">&nbsp;</td>
            <td>
                <asp:Label ID="lblOutput" runat="server"></asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>


