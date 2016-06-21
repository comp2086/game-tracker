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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /**
        * <summary>
        * Event handler, saves a new user to the DB
        * </summary>
        * 
        * @method btnSave_Click
        * @param {object} sender
        * @param {EventArgs} e
        * @returns {void}
        */
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            // create new userStore and userManager objects
            var userStore = new UserStore<IdentityUser>();
            var userManager = new UserManager<IdentityUser>(userStore);

            // create a new user object
            var user = new IdentityUser()
            {
                UserName = txtUserName.Text,
                Email = txtEmail.Text
            };

            // create a new user in the db and store the result 
            IdentityResult result = userManager.Create(user, txtPassword.Text);

            // check if successfully registered
            if (result.Succeeded)
            {
                // authenticate and login our new user
                var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                // sign in 
                authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);

                // Redirect to the Main Menu page
                Response.Redirect("~/Games/GameDetails.aspx");
            }
            else
            {
                // display error in the AlertFlash div
                lblStatus.Text = result.Errors.FirstOrDefault();
                AlertFlash.Visible = true;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}