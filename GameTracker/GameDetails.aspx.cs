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
            if (!IsPostBack)
            {
                setupDdlTeam(ddlAwayTeam);
                setupDdlTeam(ddlHomeTeam);
                setupDdlWinningTeam();
            }      
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
            // Clear all previous items
            ddlWinningTeam.Items.Clear();

            // Home Team
            if (!String.IsNullOrEmpty(ddlHomeTeam.SelectedValue))
            {
                ddlWinningTeam.Items.Add(new ListItem(ddlHomeTeam.SelectedItem.Text, ddlHomeTeam.SelectedValue));
            }

            // Away Team
            if (!String.IsNullOrEmpty(ddlAwayTeam.SelectedValue))
            {
                ddlWinningTeam.Items.Add(new ListItem(ddlAwayTeam.SelectedItem.Text, ddlAwayTeam.SelectedValue));
            }
        }

        protected void ddlHomeTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            setupDdlWinningTeam();
        }
    }
}