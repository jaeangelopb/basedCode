<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="RFID.Admin.Report.Report" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>





<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt">
            <LocalReport ReportPath="Report\StudentLogs.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="SqlDataSource1" Name="StudentLogDataSet" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>   
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:DeLoreanConnectionString %>" SelectCommand="sp_GetReportStudentLogs" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter Name="Search" QueryStringField="Search" Type="String" />
                <asp:QueryStringParameter Name="AccountID" QueryStringField="AccountID" Type="Object" />
                <asp:QueryStringParameter DbType="Date" Name="DateTimeStart" QueryStringField="DateTimeStart" />
                <asp:QueryStringParameter DbType="Date" Name="DateTimeEnd" QueryStringField="DateTimeEnd" />
            </SelectParameters>
        </asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:DeLoreanConnectionString %>" SelectCommand="sp_GetReportStudentLogs" SelectCommandType="StoredProcedure">
            <SelectParameters>
                <asp:QueryStringParameter Name="Search" QueryStringField="Search" Type="String" />
                <asp:QueryStringParameter Name="AccountID" QueryStringField="AccountID" Type="Object" />
                <asp:QueryStringParameter DbType="Date" Name="DateTimeStart" QueryStringField="DateTimeStart" />
                <asp:QueryStringParameter DbType="Date" Name="DateTimeEnd" QueryStringField="DateTimeEnd" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
         </form>
</body>
</html>
