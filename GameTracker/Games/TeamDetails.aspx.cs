/**
 * Game Tracker
 * By: Anthony Scinocco & Alex Andriishyn
 * TeamDetails Page Code Behind file
 * http://asp-game-tracker.azurewebsites.net/TeamDetails.aspx
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameTracker.Models;

namespace GameTracker
{
    public partial class TeamDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        /**
        * <summary>
        * Event handler, saves a new team to the database on save button click
        * </summary>
        * 
        * @method btnSave_Click
        * @param {object} sender
        * @param {EventArgs} e
        * @returns {void}
        */
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Team team = new Team();
            team.name = txtTeamName.Text;
            team.description = txtTeamDescription.Text;

            // Add a new team
            using (var db = new GameTrackerConn())
            {
                try
                {
                    db.Teams.Add(team);
                    db.SaveChanges();
                    // Display a success message
                }
                catch (Exception ex)
                {
                    // Displayy an error message
                }
            }  
        }


    }
}