using reema7266e.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace reema7266e.LogIn
{
    public partial class login : Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
           
            string username = txtUserName.Text;
            string password = txtPassword.Text;

           
            if (username == "admin" && password == "12345") 
            {
               
                Response.Redirect("~/vulnerabilities/vulnerable.aspx");
            }
            else
            {
                lblOutput.Text = "Invalid username or password!";
                lblOutput.ForeColor = System.Drawing.Color.Red;
            }
        }

    }
}



