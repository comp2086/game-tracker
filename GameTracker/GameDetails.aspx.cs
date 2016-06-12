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
    public partial class GameDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            setupDdlTeam(ddlAwayTeam);
            setupDdlTeam(ddlHomeTeam);
            setupDdlWinningTeam();
        }

        private void setupDdlTeam(DropDownList ddl)
        {
            using (var db = new DefaultConnection())
            {
                ddl.DataSource = (from team in db.Teams
                                  orderby team.name
                                  select new { team.Id, team.name }).ToList();
                ddl.DataTextField = "name";
                ddl.DataValueField = "Id";
                ddl.DataBind();
            }
        }

        private void setupDdlWinningTeam()
        {
            var selectedDdlValues = new List<Team>();
            var team = new Team();

            // Home Team
            if (!String.IsNullOrEmpty(ddlHomeTeam.SelectedValue))
            {
                team.Id = Convert.ToInt32(ddlHomeTeam.SelectedValue);
                team.name = ddlHomeTeam.SelectedItem.Text;
                selectedDdlValues.Add(team);
            }

            // Away Team
            if (!String.IsNullOrEmpty(ddlAwayTeam.SelectedValue))
            {
                team.Id = Convert.ToInt32(ddlAwayTeam.SelectedValue);
                team.name = ddlHomeTeam.SelectedItem.Text;
                selectedDdlValues.Add(team);
            }    

            ddlWinningTeam.DataSource = selectedDdlValues;
            ddlWinningTeam.DataTextField = "name";
            ddlWinningTeam.DataValueField = "Id";
            ddlWinningTeam.DataBind();
        }

        protected void ddlHomeTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            setupDdlWinningTeam();
        }
    }
}