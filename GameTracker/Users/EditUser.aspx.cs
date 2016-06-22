using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using GameTracker.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace GameTracker.Users
{
    public partial class EditUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetUser();
            }
        }

        /**
         * Gets specified user
         * return {void}
         */ 
        protected void GetUser()
        {
            string UserID = Convert.ToString(Request.QueryString["Id"]);

            //connect to ef
            using (GameTrackerConn db = new GameTrackerConn())
            {
                AspNetUser updatedUser = (from AspNetUser in db.AspNetUsers
                                          where AspNetUser.Id == UserID
                                          select AspNetUser).FirstOrDefault();

                //map user to text fields
                if(updatedUser != null)
                {
                    txtUsername.Text = updatedUser.UserName;
                    txtEmail.Text = updatedUser.Email;
                }
            }
        }

        /**
         * Redirects users to userdashbaord
         * 
         * return {void}
         */ 
        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Users/UserDashboard.aspx");
        }

        /**
         * Handles saving a user
         * 
         * return {void}
         */ 
        protected void SaveButton_Click(object sender, EventArgs e)
        {
            using (GameTrackerConn db = new GameTrackerConn())
            {
                AspNetUser newUser = new AspNetUser();

                string UserID = "";

                if(Request.QueryString.Count > 0)
                {
                    UserID = Convert.ToString(Request.QueryString["Id"]);

                    newUser = (from AspNetUser in db.AspNetUsers
                               where AspNetUser.Id == UserID
                               select AspNetUser).FirstOrDefault();

                }

                newUser.UserName = txtUsername.Text;
                newUser.Email = txtEmail.Text;

                //save updates
                db.SaveChanges();

                Response.Redirect("~/Users/UserDashboard.aspx");
            }
        }
    }
}