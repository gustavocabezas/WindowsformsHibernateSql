using System;
using System.Web.UI;
using WindowsformsHibernateSql.Models;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Razor.Text;
using System.Windows.Forms;
using NHibernate.Cfg;
using WindowsformsHibernateSql.Helpers;

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
                    navLinkUsers.Visible = isAuthenticated;
                    navLinkJobTracking.Visible = isAuthenticated;
                    navLinkLogout.Visible = isAuthenticated;
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
            Session["Authentication"] = null;

        }

    }
}