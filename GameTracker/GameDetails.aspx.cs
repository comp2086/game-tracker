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
            using (GameTrackerModelConn db = new GameTrackerModelConn())
            {
                var teams = (from team in db.Teams
                             select team.name);

                ddlTeam.DataSource = teams.ToList();
            }
        }
    }
}