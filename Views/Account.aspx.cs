using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Transactions;
using System.Web.Razor.Text;
using System.Web.UI;
using System.Windows.Forms;
using NHibernate.Cfg;
using WindowsformsHibernateSql.Helpers;

namespace WindowsformsHibernateSql
{
    public partial class Account : Page
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

        protected async Task LoadDataAsync()
        {
            if (Session["Authentication"] != null)
            {
                Models.Users CurrentAuthentication = (Models.Users)Session["Authentication"];

                using (mySession.BeginTransaction())
                {
                    var CurrentUser = mySession.Query<Models.Users>().Where(u => u.Id == CurrentAuthentication.Id).FirstOrDefault();

                    if (CurrentUser != null)
                    {
                        var CurrentPerson = mySession.Query<Models.Persons>().Where(u => u.UserId == CurrentUser.Id).FirstOrDefault();
                        if (CurrentPerson != null)
                        {
                            if (CurrentUser.UserImageId == 0)
                                ImageAvatar.ImageUrl = "https://picsum.photos/1200/1200?random=50";
                            else
                            {
                                var CurrentUserImage = mySession.Query<Models.UserImages>().Where(u => u.Id == CurrentUser.UserImageId).FirstOrDefault();
                                if (CurrentUserImage.ImageData != null)
                                {
                                    string base64Image = Utils.ConvertImageToBase64(CurrentUserImage.ImageData);
                                    ImageAvatar.ImageUrl = "data:image;base64," + base64Image;
                                }
                            }
                            TextBoxUserName.Text = CurrentUser.Username;
                            TextBoxEmail.Text = CurrentUser.PrimaryEmail;
                            TextBoxFirstName.Text = CurrentPerson.FirstName;
                            TextBoxLastName.Text = CurrentPerson.LastName;
                            TextBoxPassword.Text = CurrentUser.Password;
                        }
                    }
                    else
                        LabelError.Visible = true;
                }
            }
        }

        protected async void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (Session["Authentication"] != null)
            {
                Models.Users CurrentAuthentication = (Models.Users)Session["Authentication"];

                using (mySession.BeginTransaction())
                {
                    try
                    {
                        var CurrentUser = mySession.Query<Models.Users>().Where(u => u.Id == CurrentAuthentication.Id).FirstOrDefault();

                        if (CurrentUser != null)
                        {
                            var CurrentPerson = mySession.Query<Models.Persons>().Where(u => u.UserId == CurrentUser.Id).FirstOrDefault();
                            if (CurrentPerson != null)
                            {
                                if (FileUploadImage.HasFile)
                                {
                                    using (Stream stream = FileUploadImage.PostedFile.InputStream)
                                    {
                                        byte[] imageBytes = new byte[stream.Length];
                                        stream.Read(imageBytes, 0, imageBytes.Length);

                                        Models.UserImages newUserImage = new Models.UserImages
                                        {
                                            UserId = CurrentUser.Id,
                                            ImageTypeId = 1,
                                            ImageData = imageBytes,
                                            Active = true,
                                            DateCreated = DateTime.Now,
                                            CreatedBy = CurrentPerson.Id,
                                        };

                                        mySession.Save(newUserImage);

                                        if (newUserImage.Id > 0)
                                            CurrentUser.UserImageId = newUserImage.Id;
                                    }
                                }
                                CurrentUser.Username = TextBoxUserName.Text;
                                CurrentUser.PrimaryEmail = TextBoxEmail.Text;
                                CurrentPerson.FirstName = TextBoxFirstName.Text;
                                CurrentPerson.LastName = TextBoxLastName.Text;
                                CurrentUser.Password = TextBoxPassword.Text;
                                mySession.Update(CurrentUser);
                                mySession.Update(CurrentPerson);
                                mySession.Transaction.Commit();
                                Navigate("/");
                            }
                        }
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

        }

        public void Navigate(string page)
        {
            string script = "<script>window.location.href = '" + page + ".aspx';</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "RedirectScript", script);
        }
    }
}