using RFID.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Microsoft.Reporting.WebForms;


namespace RFID.Admin.Report
{
    public partial class Report : System.Web.UI.Page
    {
        GlobalModel global = new GlobalModel();
        protected void Page_LoadComplete(object sender, EventArgs e)
        {

            Warning[] warnings;
            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            SqlDataSource sql = new SqlDataSource();
            sql.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DeLoreanConnectionString"].ConnectionString;
            sql.SelectCommand = "sp_GetReportStudentLogs";
            sql.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;

            if (Request["search"] != null)
                sql.SelectParameters.Add("Search", null);
            if (Request["accountID"] != null)
                sql.SelectParameters.Add("AccountID", null);
            if (Request["dateTimeStart"] != null)
                sql.SelectParameters.Add("DateTimeStart", Request["dateTimeStart"]);
            if (Request["dateTimeEnd"] != null)
                sql.SelectParameters.Add("DateTimeEnd", Request["dateTimeEnd"]);

             LocalReport lrpt = ReportViewer1.LocalReport;
            //ReportViewer1.LocalReport.ReportPath = Server.MapPath(@"StudentLogs.rdlc");
            //ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("StudentLogDataSet", sql));
            lrpt.ReportPath = Server.MapPath(@"StudentLogs.rdlc");
            lrpt.DataSources.Add(new ReportDataSource("StudentLogDataSet", sql));

            string filepath = System.IO.Path.GetTempFileName().Replace(".tmp", ".pdf");
            Export(lrpt, filepath);
            lrpt.Dispose();

        }

        public string Export(LocalReport rpt, string filePath)
        {
            string ack = "";
            try
            {
                Warning[] warnings;
                string[] streamids;
                string mimeType;
                string encoding;
                string extension;

                byte[] bytes = rpt.Render("Excel", null, out mimeType, out encoding, out extension, out streamids, out warnings);
                using (FileStream stream = File.OpenWrite(filePath))
                {
                    stream.Write(bytes, 0, bytes.Length);
                }
                Response.AddHeader("Content-Disposition", "inline; filename=Report.xls");
                Response.ContentType = "application/vnd.ms-excel";
                Response.BinaryWrite(bytes);
                Response.End();
                return ack;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
    }
}