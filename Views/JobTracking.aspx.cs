using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Cfg;

namespace WindowsformsHibernateSql
{
    public partial class JobTracking : Page
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
                    ICriteria criteria = mySession.CreateCriteria<Models.Jobs>();
                    IList<Models.Jobs> list = criteria.List<Models.Jobs>();
                    JobsGridView.DataSource = list;
                    JobsGridView.DataBind();
                }
            }
        }

        protected void JobsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                System.Web.UI.WebControls.Button detailsButton = (System.Web.UI.WebControls.Button)e.Row.FindControl("DetailsButton");
                string id = JobsGridView.DataKeys[e.Row.RowIndex].Value.ToString();

                detailsButton.PostBackUrl = $"UserDetails.aspx?id={id}";
            }
        }

        public void Navigate(string page)
        {
            string script = "<script>window.location.href = '" + page + ".aspx';</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "RedirectScript", script);
        }
    }
}