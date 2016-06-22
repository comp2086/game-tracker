using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GameTracker.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

/**
 * Game Tracker
 * By: Anthony Scinocco & Alex Andriishyn
 * UserDashboard Page Code Behind file
 * http://asp-game-tracker.azurewebsites.net/Users/UserDashboard.aspx
 */ 


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

        /**
         * Gets Users
         * 
         * return {void}
         */ 
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
            Response.Redirect("~/Users/EditUser.aspx");
        }

        /**
         * Hanles deleting a user
         * 
         * return {void}
         */ 
        protected void grdUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //get the row that was clicked
            int SelectedRow = e.RowIndex;

            //get the selected user id
            string UserID = Convert.ToString(grdUsers.DataKeys[SelectedRow].Values["Id"]);

            //find and delete user
            using (GameTrackerConn db = new GameTrackerConn())
            {
                AspNetUser deletedUser = (from AspNetUser in db.AspNetUsers
                                          where AspNetUser.Id == UserID
                                          select AspNetUser).FirstOrDefault();

                //perform removal
                db.AspNetUsers.Remove(deletedUser);

                //save changes
                db.SaveChanges();

                //refresh users list
                this.GetUsers();
            }
        }
        /**
         * Hanles changing pages
         * 
         * return {void}
         */ 
        protected void grdUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set page number
            grdUsers.PageIndex = e.NewPageIndex;

            //refresh grid
            this.GetUsers();
        }

        /**
         * Hanles sorting the users
         * 
         * return {void}
         */ 
        protected void grdUsers_Sorting(object sender, GridViewSortEventArgs e)
        {
            //get the column sort
            Session["SortColumn"] = e.SortExpression;

            //refresh grid
            this.GetUsers();

            //toggle direction
            Session["SortDirection"] = Session["SortDirection"].ToString() == "ASC" ? "DESC" : "ASC";
        }

        /**
         * Handles sorting infographics for ease of use
         * 
         * return {void}
         */ 
        protected void grdUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if(e.Row.RowType == DataControlRowType.Header)//check if the click is on the header row
                {
                    LinkButton btnLink = new LinkButton();

                    for(int i = 0; i < grdUsers.Columns.Count; i++)
                    {
                        if(grdUsers.Columns[i].SortExpression == Session["SortColumn"].ToString())
                        {
                            if(Session["SortDirection"].ToString() == "ASC")
                            {
                                btnLink.Text = " <i class='fa fa-caret-up fa-lg'></a>";
                            }else
                            {
                                btnLink.Text = " <i class='fa fa-caret-up fa-lg'></a>";
                            }

                            e.Row.Cells[i].Controls.Add(btnLink);
                        }
                    }
                }
            }
        }
    }
}