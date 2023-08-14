using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using WindowsformsHibernateSql.Models;

namespace WindowsformsHibernateSql
{
    public partial class Users : Page
    {
        private Configuration myConfiguration = new Configuration();
        private NHibernate.ISessionFactory mySessionFactory;
        private NHibernate.ISession mySession;

        protected void Page_Load(object sender, EventArgs e)
        {
            myConfiguration = new Configuration();
            myConfiguration.Configure();
            mySessionFactory = myConfiguration.BuildSessionFactory();
            mySession = mySessionFactory.OpenSession();
            RegisterAsyncTask(new PageAsyncTask(LoadDataAsync));
        }
        protected NHibernate.ISession GetMySession()
        {
            return mySession;
        }

        private async Task LoadDataAsync()
        {
            if (Session["Authentication"] != null)
            {

                using (mySession.BeginTransaction())
                {
                    ICriteria criteria = mySession.CreateCriteria<Models.Users>();
                    IList<Models.Users> list = criteria.List<Models.Users>();
                    UsersGridView.DataSource = list;
                    UsersGridView.DataBind();
                }
            }
        }

        protected void UsersGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button detailsButton = (Button)e.Row.FindControl("DetailsButton");
                string id = UsersGridView.DataKeys[e.Row.RowIndex].Value.ToString();

                detailsButton.PostBackUrl = $"UserDetails.aspx?id={id}";
            }
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            if (Session["AuthenticationResult"] != null)
                Response.Redirect("UserDetails.aspx?id=0");
        }
    }
}
