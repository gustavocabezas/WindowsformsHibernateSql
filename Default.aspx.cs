using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls; 
using System.Linq;

namespace WindowsformsHibernateSql
{
    public partial class _Default : Page
    { 

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterAsyncTask(new PageAsyncTask(LoadDataAsync));
        }

        private async Task LoadDataAsync()
        {
            try
            {
                /*currentUser = (CSharpWebService.Users)Session["Authentication"];*/
            }
            catch (Exception ex) { }

           /* var itemsList = _javaWebService.GetAllItems();
            if (itemsList != null)
            {
                ItemsGridView.DataSource = itemsList;
                ItemsGridView.DataBind();
            }*/

        }

        protected void ItemsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Button detailsButton = (Button)e.Row.FindControl("DetailsButton");
                string id = ItemsGridView.DataKeys[e.Row.RowIndex].Value.ToString();
                string userId = DataBinder.Eval(e.Row.DataItem, "UserId").ToString();

                /*if (currentUser != null)
                {
                    if (userId == currentUser.Id.ToString())
                        detailsButton.Enabled = false;
                }*/
            }
        }

        protected void ItemsDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList itemsDropDownList = (DropDownList)sender;
            string idSeleccionado = itemsDropDownList.SelectedValue;
        }

    }
}