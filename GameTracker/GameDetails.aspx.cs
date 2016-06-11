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
        }

        private void setupDdlTeam(DropDownList ddl)
        {
            using (var db = new GameTrackerModelConn())
            {
                ddl.DataSource = (from team in db.Teams
                                      orderby team.name
                                      select new { team.Id, team.name }).ToList();
                ddl.DataTextField = "name";
                ddl.DataValueField = "Id";
                ddl.DataBind();
            }
        }

    }
}