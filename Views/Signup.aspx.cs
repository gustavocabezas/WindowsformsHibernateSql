using System;
using System.Diagnostics;
using System.ServiceModel.Channels;
using System.Web.UI;
using System.Windows.Forms;
using NHibernate.Cfg;

namespace WindowsformsHibernateSql
{
    public partial class Signup : Page
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
        }

        protected NHibernate.ISession GetMySession()
        {
            return mySession;
        }

        protected async void ButtonCreate_Click(object sender, EventArgs e)
        {
            using (mySession.BeginTransaction())
            {
                try
                {
                    Models.Users newUser = new Models.Users
                    {
                        ProfileId = 1,
                        Username = TextBoxEmail.Text,
                        PrimaryEmail = TextBoxEmail.Text,
                        Password = TextBoxPassword.Text,
                        StatusId = 1,
                        DateCreated = DateTime.Now,
                        CreatedBy = 0
                    };
                    mySession.Save(newUser);

                    if (newUser.Id > 0)
                    {
                        Models.Persons newPerson = new Models.Persons
                        {
                            UserId = newUser.Id,
                            DateCreated = DateTime.Now,
                            CreatedBy = newUser.Id
                        };
                        mySession.Save(newPerson);
                    }
                    else
                    {
                        throw new Exception("Could not get new user id after save");
                    }

                    mySession.Transaction.Commit();

                    Navigate("login");
                }
                catch (Exception ex)
                {
#if DEBUG
                    Debugger.Break();
#endif 
                    mySession.Transaction.Rollback();
                    LabelError.Visible = true;
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