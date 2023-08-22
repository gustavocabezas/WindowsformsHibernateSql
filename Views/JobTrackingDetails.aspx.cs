using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using NHibernate;
using NHibernate.Cfg;

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
                int jobId;

                if (int.TryParse(Request.QueryString["id"], out jobId))
                {
                }
                else
                {
                }

                using (mySession.BeginTransaction())
                {
                    String hql = @"SELECT new map(u.Username as CandidateName, 
                              jc.DateCreated as ApplicationDate, 
                              j.Title as JobTitle, 
                              jc.CandidateDocumentId as CandidateDocumentId) 
                           FROM JobsCandidates jc, Users u, Jobs j 
                           WHERE jc.CandidateId = u.Id 
                           AND jc.JobId = j.Id 
                           AND j.Id = :jobId";


                    IList<Models.JobTrackingDetails> ConvertToJobsDetailsList(IList hashtables)
                    {
                        var jobsDetailsList = new List<Models.JobTrackingDetails>();

                        foreach (Hashtable hashtable in hashtables)
                        {
                            var jobDetails = new Models.JobTrackingDetails
                            {
                                CandidateName = hashtable["CandidateName"]?.ToString(),
                                ApplicationDate = DateTime.Parse(hashtable["ApplicationDate"]?.ToString() ?? DateTime.Now.ToString()),
                                JobTitle = hashtable["JobTitle"]?.ToString(),
                                CandidateDocumentId = hashtable["CandidateDocumentId"]?.ToString()
                            };

                            jobsDetailsList.Add(jobDetails);
                        }

                        return jobsDetailsList;
                    }

                    IList result = mySession.CreateQuery(hql).SetParameter("jobId", jobId).List();
                     
                    IList<Models.JobTrackingDetails> JobTrackingDetailsList = ConvertToJobsDetailsList(result);

                    try
                    {
                        JobsGridView.DataSource = JobTrackingDetailsList;
                        JobsGridView.DataBind();
                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex.Message);
                    }
                }
            }
        }

        public void Navigate(string page)
        {
            string script = "<script>window.location.href = '" + page + ".aspx';</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "RedirectScript", script);
        }
    }
}