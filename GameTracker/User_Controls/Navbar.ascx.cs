/**
 * Game Tracker
 * @author Anthony Scinocco & Alex Andriishyn
 * Navbar Code Behind file
 * http://asp-game-tracker.azurewebsites.net/Games.aspx
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

// required for Identity and OWIN Security
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace GameTracker
{
    public partial class Navbar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Check if a user is logged in
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {

                    // Show protected content
                    phDetails.Visible = true;
                    phPublic.Visible = false;

                    if (HttpContext.Current.User.Identity.GetUserName() == "admin")
                    {
                        // Admin placeholder for user management links...
                    }
                }
                else
                {
                    // Show only public content
                    phDetails.Visible = false;
                    phPublic.Visible = true;
                }

                SetActivePage();
            }
        }

        /**
         * This method adds a css class of "active" to list items
         * relating to the current page
         * 
         * @private
         * @method SetActivePage
         * @return {void}
         */
        private void SetActivePage()
        {
            switch (Page.Title)
            {
                case "Games":
                    games.Attributes.Add("class", "active");
                    break;
                case "Game Details":
                    gameDetails.Attributes.Add("class", "active");
                    break;
                case "Team Details":
                    teamDetails.Attributes.Add("class", "active");
                    break;
                case "Register":
                    register.Attributes.Add("class", "active");
                    break;
                case "Sign In":
                    login.Attributes.Add("class", "active");
                    break;
                case "User Dashboard":
                    userDashboard.Attributes.Add("class", "active");
                    break;
            }
        }
    }
}