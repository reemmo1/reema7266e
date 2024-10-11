<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="controls.aspx.cs" Inherits="reema7266e.email.controls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <div>
    <strong>    <span style="font-size: medium">    <asp:Label ID="lblOuput" runat="server" Text=""></asp:Label> <br /> 
     Q1.   What is the Severity of the Vulnerability ?</span></strong><br />
    <asp:RadioButtonList ID="rblSeverity" runat="server"></asp:RadioButtonList> <br />
    <asp:Button ID="btnGetRblValue" runat="server" Text="GetRblValue" OnClick="btnGetRblValue_Click" /> <br /> 
    

    </div>

    <hr />
    <div>
                <strong><span style="font-size: small">
                <asp:Label ID="lblOutputQ2" runat="server" Text=""></asp:Label><br />
                </span><span style="font-size: medium">Q2.</span></strong>   <strong><span style="font-size: medium">What is the Status of the Vulnerability ?</span></strong><br />
    <asp:CheckBoxList ID="cblStatus" runat="server"></asp:CheckBoxList>  <br />
    <asp:Button ID="btnGrtCblStatus" runat="server" Text="GrtCblStatus" OnClick="btnGrtCblStatus_Click" />

    </div>

</asp:Content>
