using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/**
 * Game Tracker
 * By: Anthony Scinocco & Alex Andriisyn
 * Contact Page Code Behind file
 * http://asp-game-tracker.azurewebsites.net/Contact.aspx
 */
namespace GameTracker
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /**
         * This function sends the users form
         * TODO: Complete form submission
         * 
         * return {void}
         */ 
        protected void SendButton_Click(object sender, EventArgs e)
        {
            // this is a placeholder for working code that sends email 
            Response.Redirect("Default.aspx");
        }
    }
}