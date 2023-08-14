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
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(LoadDataAsync));
        }

        private async Task LoadDataAsync()
        {
            if (Session["AuthenticationResult"] != null)
            {
  /*              UserService userService = new UserService();

                List<User> users = await userService.GetAllUsers();

                UsersGridView.DataSource = users;
                UsersGridView.DataBind();*/
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
