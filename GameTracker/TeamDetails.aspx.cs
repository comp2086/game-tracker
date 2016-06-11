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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var teamName = txtTeamName.Text;
            var teamDescription = txtTeamDescription.Text;

            // Add a new team
            using (var db = new GameTrackerModelConn())
            {
                Team team = new Team();
                team.name = teamName;
                team.description = teamDescription;

                try
                {
                    db.Teams.Add(team);
                    db.SaveChanges();
                    // Display a success message
                }
                catch
                {
                    // Displayy an error message
                }
            }  
        }


    }
}