using reema7266e.App_Code;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace reema7266e.email
{
    public partial class controls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                populateCblSeverity();
                populateRblSeverity();
            }
        }

        private void populateRblSeverity()
        {
      
            CRUD myCrde = new CRUD();
            string mySql = @"select statusId, status from status";
            SqlDataReader dr = myCrde.getDrPassSql(mySql);
            cblStatus.DataValueField = "StatusId";
            cblStatus.DataTextField = "Status";
            cblStatus.DataSource = dr;
            cblStatus.DataBind();
        }

        private void populateCblSeverity()
        {
            CRUD myCrde = new CRUD();
            string mySql = @"select severityId, severity from severity";
            SqlDataReader dr = myCrde.getDrPassSql(mySql);
            rblSeverity.DataValueField = "severityId";
            rblSeverity.DataTextField = "severity";
            rblSeverity.DataSource = dr;
            rblSeverity.DataBind();
        }

        protected void PopulateblSeverity()
        { 
}

        protected void populateblSeverity()
        {

        }

        protected void btnGetRblValue_Click(object sender, EventArgs e)
        {
            string selectedRating = "";    // declare variable to capture selected items from cbl 
            for (int i = 0; i < rblSeverity.Items.Count; i++)    // you need to loop checkBoxList to capture the selected values 
            {
                //if (rblSeverity.Items[i].Selected)
                //    // selectedHobby += rblSeverity.Items[i].Value.ToString() + ","; // capture the value only
                //    selectedCountry += rblSeverity.Items[i].Text + ",";   // capture the Text instead of the value 
                selectedRating = rblSeverity.SelectedItem.Text;
            }

            lblOuput.Text = selectedRating;
        }

        protected void btnGrtCblStatus_Click(object sender, EventArgs e)
        {
            string selectedRating = "";    // declare variable to capture selected items from cbl 
            for (int i = 0; i < cblStatus.Items.Count; i++)    // you need to loop checkBoxList to capture the selected values 
            {
                if (cblStatus.Items[i].Selected)
                    // selectedHobby += cblStatus.Items[i].Value.ToString() + ","; // capture the value only
                    selectedRating += cblStatus.Items[i].Text + ",";   // capture the Text instead of the value 
                                                                              // selectedRating = cblStatus.SelectedItem.Text;
            }
            lblOutputQ2.Text = selectedRating;
        }

        protected void cblStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }//cls
    
}//ns