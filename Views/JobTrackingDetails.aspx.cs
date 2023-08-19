using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping;
using static System.Collections.Specialized.BitVector32;

namespace WindowsformsHibernateSql
{
    public partial class JobTrackingDetails : Page
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
                int jobId = 1;
                using (mySession.BeginTransaction())
                {
                    String hql = "SELECT new map(c.CandidateName as CandidateName, jc.ApplicationDate as ApplicationDate, j.JobTitle as JobTitle, cd.CurriculumPath as CurriculumPath, cd.PresentationLetterPath as PresentationLetterPath) FROM JobsCandidates jc JOIN jc.Candidate c JOIN jc.Job j JOIN jc.CandidateDocument cd WHERE j.JobId = :jobId";

                    IList result = mySession.CreateQuery(hql).SetParameter("jobId", jobId).List();
                    JobsGridView.DataSource = result;
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