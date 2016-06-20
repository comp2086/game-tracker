using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GameTracker.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace GameTracker.Users
{
    public partial class UserDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["SortColumn"] = "Id";
                Session["SortDirection"] = "ASC";

                //get user data
                this.GetUsers();
            }
        }

        protected void GetUsers()
        {
            string sortString = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

            using (GameTrackerConn db = new GameTrackerConn())
            {
                var Users = (from AspNetUsers in db.AspNetUsers select AspNetUsers);

                grdUsers.DataSource = Users.AsQueryable().OrderBy(sortString).ToList();
                grdUsers.DataBind();
            }
        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {

        }

        protected void grdUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void grdUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void grdUsers_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void grdUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}