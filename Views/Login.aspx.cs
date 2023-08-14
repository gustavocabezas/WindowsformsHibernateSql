using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using NHibernate.Cfg;

namespace WindowsformsHibernateSql
{
    public partial class Login : Page
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

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                using (mySession.BeginTransaction())
                {
                    var CurrentUser = mySession.Query<Models.Users>()
                              .Where(u => u.PrimaryEmail == TextBoxEmail.Text && u.Password == TextBoxPassword.Text)
                              .FirstOrDefault();

                    if (CurrentUser != null)
                    {
                        Session["Authentication"] = CurrentUser;
                        Navigate("/");
                    }
                    else
                        LabelError.Visible = true;
                }
            }
            catch (Exception ex)
            {
                mySession.Transaction.Rollback();
                LabelError.Visible = true;
                Console.WriteLine(ex.Message);
            }
        }

        protected void ButtonSignup_Click(object sender, EventArgs e)
        {
            Navigate("signup");
        }

        public void Navigate(string page)
        {
            string script = "<script>window.location.href = '" + page + ".aspx';</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "RedirectScript", script);
        }
    }
}
