using System;
using System.Threading.Tasks;
using System.Web.UI;
using WindowsformsHibernateSql.Models; 

namespace WindowsformsHibernateSql
{
    public partial class UserDetails : Page
    {
       /* private User _user = new User();*/
/*        private readonly UserService _userService = new UserService();*/

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(LoadDataAsync));
        }

        private async Task LoadDataAsync()
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    string userId = Request.QueryString["id"];

                    if (userId != "0")
                    {
                  /*      _user = await _userService.GetUserById(Convert.ToInt32(userId));*/

       /*                 TextBoxUsername.Text = _user.Username;
                        TextBoxPassword.Text = _user.Password;*/
                    }
                }
            }

        }

        protected async void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                string userId = Request.QueryString["id"];

                if (userId != "0")
                {
 /*                   var user = await _userService.GetUserById(Convert.ToInt32(userId));

                    user.Username = TextBoxUsername.Text;
                    user.Password = TextBoxPassword.Text;*/
                    // Actualizar otros campos del usuario aquí
/*
                    var result = await _userService.UpdateUser(user);
                    if (result)
                        Navigate("users");*/
                }
                else
                {
                   /* var user = new User();*/

               /*     user.Username = TextBoxUsername.Text;*/
                  /*  user.Password = TextBoxPassword.Text;*/
      /*              var result = await _userService.CreateUser(user);*/
       /*             if (result)
                        Navigate("users");*/
                }
            }
        }

        protected void TextBoxUsername_TextChanged(object sender, EventArgs e)
        {
/*            _user.Username = TextBoxUsername.Text;*/
        }

        protected void TextBoxPassword_TextChanged(object sender, EventArgs e)
        {
     /*       _user.Password = TextBoxPassword.Text;*/
        }

        protected async void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] != null)
            {
                string userId = Request.QueryString["id"];

                if (userId != "0")
                {
 /*                   var user = await _userService.GetUserById(Convert.ToInt32(userId));
                    var result = await _userService.DeleteUser(user.Id);
                    if (result)
                        Navigate("users");*/
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
