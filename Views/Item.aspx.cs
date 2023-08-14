using System;
using System.Web.UI; 

namespace WindowsformsHibernateSql
{
    public partial class Item : Page
    { 

        protected async void ButtonCreate_Click(object sender, EventArgs e)
        {

            /*var authenticationResult = Session["Authentication"] as CSharpWebService.Users;*/


/*            items objectX = new items
            { 
                userId = authenticationResult.Id,
                name = TextBoxName.Text,
                description = TextBoxDescription.Text
            };

            items result = _javaWebService.CreateItem(objectX);

            if (result != null)
                Navigate("About");*/
        }

        public void Navigate(string page)
        {
            string script = "<script>window.location.href = '" + page + ".aspx';</script>";
            ClientScript.RegisterStartupScript(this.GetType(), "RedirectScript", script);
        }
    }
}
