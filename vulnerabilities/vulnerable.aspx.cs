using reema7266e.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace reema7266e.vulnerabilities
{
    public partial class vulnerable : System.Web.UI.Page
    {
        private Dictionary<object, object> myPara;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateDdlSeverity();
                populateDdlStatus();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {

        }


        protected void PopulateDdlSeverity()

        {
            CRUD myCrde = new CRUD();
            string mySql = @"select severityId, severity from severity";
            SqlDataReader dr = myCrde.getDrPassSql(mySql);
            ddlSeverity.DataValueField = "severityId";
            ddlSeverity.DataTextField = "severity";
            ddlSeverity.DataSource = dr;
            ddlSeverity.DataBind();
        }


        protected void populateDdlStatus()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select StatusId, Status from Status";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlStatus.DataValueField = "StatusId";
            ddlStatus.DataTextField = "Status";
            ddlStatus.DataSource = dr;
            ddlStatus.DataBind();
        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            ShowVulnerabilities();

        }

        protected void ShowVulnerabilities()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select vulnerabilityId,vulnerabilityTitle,severity,status,discoveryDate,lastUpdatedDate
             from vulnerabilities  v inner join severity s on v.severityId= s.severityId
             inner join status st on v.statusId= st.statusId";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvVulnerability.DataSource = dr;
            gvVulnerability.DataBind();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // put server side validation to prevent entering empy cells

              if (String.IsNullOrEmpty(txtVulnerabilityTitle.Text))
                {
                   lblOutput.Text = "Please fill Vulnerability Title !";
                  lblOutput.ForeColor = System.Drawing.Color.Red;
                    txtVulnerabilityTitle.Focus();
                   return;
                }

                if (String.IsNullOrEmpty(txtDiscoveryDate.Text))
                    {
                        lblOutput.Text = "Please fill Discovery Date !";
                        lblOutput.ForeColor = System.Drawing.Color.Red;
                        txtDiscoveryDate.Focus();
                        return;
                    }

                    if (String.IsNullOrEmpty(txtLastUpdatedDate.Text))
                        {
                            lblOutput.Text = "Please fill last Updated Date!";
                           lblOutput.ForeColor = System.Drawing.Color.Red;
                           txtLastUpdatedDate.Focus();
                            return;
                        }

                        CRUD myCrud = new CRUD();
            string mySql = @"insert vulnerabilities (vulnerabilityTitle,severityId,statusId,discoveryDate,lastUpdatedDate)
             values ( @vulnerabilityTitle,@severityId,@statusId,@discoveryDate,@lastUpdatedDate)";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@vulnerabilityTitle ", int.Parse(txtVulnerabilityTitle.Text));
            myPara.Add("@discoveryDate ", txtDiscoveryDate.Text);
            myPara.Add("@lastUpdatedDate ", txtLastUpdatedDate.Text);
            myPara.Add("@vulnerabilityId", txtVulnerabilityId.Text);
            myPara.Add("@severityId ", ddlSeverity.SelectedItem.Value);
            myPara.Add("@statusId ", ddlStatus.SelectedItem.Value);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { lblOutput.Text = "Operation Successful"; }
            else
            { lblOutput.Text = "Operation Failed"; }

            // call select to show the new items  
            ShowVulnerabilities();
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = @" update vulnerabilities
             set vulnerabilityTitle = @vulnerabilityTitle,severityId=@severityId,statusId=@statusId,discoveryDate=@discoveryDate,lastUpdatedDate=@lastUpdatedDate
             where vulnerabilityId = @vulnerabilityId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@vulnerabilityTitle ", txtVulnerabilityTitle.Text);
            myPara.Add("@discoveryDate ", txtDiscoveryDate.Text);
            myPara.Add("@lastUpdatedDate ", txtLastUpdatedDate.Text);
            myPara.Add("@vulnerabilityId", txtVulnerabilityId.Text);
            myPara.Add("@severityId ", ddlSeverity.SelectedItem.Value);
            myPara.Add("@statusId ", ddlStatus.SelectedItem.Value); int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { lblOutput.Text = "Operation Successful"; }
            else
            { lblOutput.Text = "Operation Failed"; }

            ShowVulnerabilities();

        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {

            CRUD myCrud = new CRUD();
            string mySql = @"delete vulnerabilities
            where vulnerabilityid = @vulnerabilityid";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@vulnerabilityid", txtVulnerabilityId.Text);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { lblOutput.Text = "Operation Successful"; }
            else
            { lblOutput.Text = "Operation Failed"; }

            ShowVulnerabilities();

        }



        protected void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportGridToExcel(gvVulnerability);

        }
        public static void ExportGridToExcel(GridView myGv) // working 1
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ClearContent();
            HttpContext.Current.Response.ClearHeaders();
            HttpContext.Current.Response.Charset = "";
            string FileName = "ExportedReport_" + DateTime.Now + ".xls";
            StringWriter strwritter = new StringWriter();
            HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName);
            myGv.GridLines = GridLines.Both;
            myGv.HeaderStyle.Font.Bold = true;
            myGv.RenderControl(htmltextwrtter);
            HttpContext.Current.Response.Write(strwritter.ToString());
            HttpContext.Current.Response.End();
        }

        protected void populateForm_Click(object sender, EventArgs e)
        {
            int PK = int.Parse((sender as LinkButton).CommandArgument);
            //lblOuput.Text = PK.ToString();

            string mySql = @"select vulnerabilityId,vulnerabilityTitle,severityId,statusId,discoveryDate,lastUpdatedDate
             FROM vulnerabilities
              where vulnerabilityId = @vulnerabilityId";

            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@vulnerabilityId", PK);
            CRUD myCrud = new CRUD();
            using (SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        String vulnerabilityId = dr["vulnerabilityId"].ToString();
                        String vulnerabilityTitle = dr["vulnerabilityTitle"].ToString();
                        String discoveryDate = dr["discoveryDate"].ToString();
                        String lastUpdatedDate = dr["lastUpdatedDate"].ToString();
                        String severityId = dr["severityId"].ToString();
                        String statusId = dr["statusId"].ToString();
                        //lblOuput.Text = empId + employee+ depId;
                        txtVulnerabilityId.Text = vulnerabilityId;
                        txtVulnerabilityTitle.Text = vulnerabilityTitle;
                        txtDiscoveryDate.Text = discoveryDate;
                        txtLastUpdatedDate.Text = lastUpdatedDate;
                        ddlSeverity.SelectedValue = severityId;
                        ddlStatus.SelectedValue = statusId;
                    }
                }
            }
        }


    }
}
