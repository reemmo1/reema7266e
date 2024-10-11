<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
    CodeBehind="vulnerable.aspx.cs" Inherits="reema7266e.vulnerabilities.vulnerable"
    EnableEventValidation="false" ValidateRequest="false"
    %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <p>
    <br />
</p>
<table class="nav-justified">
    <tr>
        <td style="width: 294px" class="modal-sm">
            <asp:Label ID="lblOutput" runat="server" style="font-size: small"></asp:Label>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td style="width: 294px; color: #3366FF; font-size: small;" class="modal-sm"><strong>Vulnerability ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
            <asp:TextBox ID="txtVulnerabilityId" runat="server" style="font-size: small; margin-left: 0; color: #3366FF; margin-bottom: 4;" Width="82px" ForeColor="White" Height="16px" Wrap="False"></asp:TextBox>
        </td>
        <td class="text-left">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 294px; color: #3366FF; font-size: small;" class="modal-sm"><strong>Vulnerability Title&nbsp;&nbsp;&nbsp; </strong>
            <asp:TextBox ID="txtVulnerabilityTitle" runat="server" Width="82px" Height="16px" style="font-size: small; color: #3366FF; margin-left: 0px" Wrap="False"></asp:TextBox>
        </td>
        <td class="text-left">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 294px; color: #3366FF; font-size: small;" class="modal-sm"><strong>Discovery Date&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
            <asp:TextBox ID="txtDiscoveryDate" runat="server" TextMode="Date" Width="82px" Height="16px" style="font-size: small; color: #3366FF" Wrap="False"></asp:TextBox>
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 294px; color: #3366FF; font-size: small;" class="modal-sm"><strong>Last Updated Date&nbsp; </strong>
            <asp:TextBox ID="txtLastUpdatedDate" runat="server" TextMode="Date" Width="82px" Height="16px" style="font-size: small; color: #3366FF"></asp:TextBox>
            <br style="font-size: small; color: #3366FF" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 294px; color: #3366FF; font-size: small; height: 28px;" class="modal-sm"><strong>Severity&nbsp; <asp:DropDownList ID="ddlStatus" runat="server" Height="16px" style="font-size: small; color: #3366FF" Width="82px">
            </asp:DropDownList>
            </strong></td>
        <td style="height: 28px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 294px; color: #3366FF; height: 13px; font-size: small;"><strong>Status&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlSeverity" runat="server" Height="16px" style="font-size: small; color: #3366FF" Width="82px">
            </asp:DropDownList>
            </strong></td>
        <td style="height: 13px">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 294px; color: #0066FF; font-size: medium; height: 27px;" class="modal-sm"><strong>
            <asp:Button ID="btnSelect" runat="server" Text="Select"   OnClick="btnSelect_Click" Height="27px" style="font-size: 11pt; font-weight: bold" Width="76px"/>
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click"
                 OnClientClick="return confirm('Are you sure? want to delete the document.')" Height="27px" style="font-size: 11pt; font-weight: bold" Width="82px"
                />
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" Height="27px" style="font-size: 11pt; font-weight: bold" Width="82px" />
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" style="margin-left: 0; font-size: 11pt; font-weight: bold; margin-bottom: 0;" Height="27px" Width="82px" />
            <asp:Button ID="btnExportToExcel" runat="server" OnClick="btnExportToExcel_Click" Text="Export To Excel" Height="27px" style="font-weight: bold; font-size: 11pt" Width="166px" />
            </strong></td>
        <td style="height: 27px">
            &nbsp;</td>
    </tr>

    
    <tr>
        <td style="width: 294px; color: #0066FF;" class="modal-sm">&nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 294px" class="modal-sm">
            <asp:GridView ID="gvVulnerability" runat="server" AutoGenerateColumns="False" 
                DataKeyNames="vulnerabilityId" >
                
                <Columns>
                                           <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="vulnerabilityId">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkupdate" runat="server"  
                                        CommandArgument='<%# Bind("vulnerabilityId") %>' OnClick="populateForm_Click"
                                        Text='<%# Eval("vulnerabilityId") %>'></asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left"></ItemStyle>
                            </asp:TemplateField>
                    <asp:BoundField DataField="vulnerabilityTitle" HeaderText="vulnerabilityTitle" SortExpression="vulnerabilityTitle" />
                    <asp:BoundField DataField="severity" HeaderText="severity" SortExpression="severity" />
                    <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
                    <asp:BoundField DataField="discoveryDate" HeaderText="discoveryDate" SortExpression="discoveryDate" />
                    <asp:BoundField DataField="lastUpdatedDate" HeaderText="lastUpdatedDate" SortExpression="lastUpdatedDate" />
                </Columns>
            </asp:GridView>
        </td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Content>


