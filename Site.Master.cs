using System;
using System.Web.UI;
using WindowsformsHibernateSql.Models;

namespace WindowsformsHibernateSql
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bool isAuthenticated = Session["Authentication"] != null;
                 
                if (isAuthenticated)
                {
                    /* Response.Redirect("~/Views/Login.aspx");*/
                    navLinkAccount.Visible = isAuthenticated;
                    /*navLinkItem.Visible = isAuthenticated;*/ 
                }
                else
                {
                    navLinkLogin.Visible = !isAuthenticated;
                    navLinkSignup.Visible = !isAuthenticated;
                }

            }
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session["AuthenticationResult"] = null;
        }
    }
}