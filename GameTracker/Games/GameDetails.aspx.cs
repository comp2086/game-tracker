/**
 * Game Tracker
 * By: Anthony Scinocco & Alex Andriishyn
 * GameDetails Page Code Behind file
 * http://asp-game-tracker.azurewebsites.net/GameDetails.aspx
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
    public partial class GameDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setupDdlTeam(ddlHomeTeam);
                setupDdlTeam(ddlAwayTeam);
            }
        }

        /**
         * <summary>
         * This methods populates a dropdown list with values from the Teams table.
         * Optional: if valueToRemove is passed to the method, it will be removed from the dropdown list.
         *           Preserves the previously selected value.
         * </summary>
         * 
         * @method setupDdlTeam
         * @param {DropDownList} ddl
         * @param {int} valueToRemove
         * @param {int} selectedValue
         * @returns {void}
         */
        private void setupDdlTeam(DropDownList ddl, int valueToRemove = -1, int selectedValue = -1)
        {
            using (var db = new GameTrackerConn())
            {
                // Populate item list from the db
                ddl.DataSource = (from team in db.Teams
                                  orderby team.name
                                  select new { team.Id, team.name }).ToList();
                ddl.DataTextField = "name";
                ddl.DataValueField = "Id";
                ddl.DataBind();

                // Insert a dummy item
                ddl.Items.Insert(0, new ListItem("Select a team ...", "0"));

                // Remove an item, if necessary
                if (valueToRemove > 0)
                {
                    ddl.Items.Remove(ddl.Items.FindByValue(valueToRemove.ToString()));
                }

                // Restore previous selection, if any
                if (selectedValue != valueToRemove)
                {
                    ddl.SelectedValue = selectedValue.ToString();
                }
            }
        }

        /**
         * <summary>
         * Event handler, triggers on change of the selected value in home/away team dropdown list
         * </summary>
         * 
         * @method homeAwayTeam_SelectedIndexChanged
         * @param {object} sender
         * @param {EventArgs} e
         * @returns {void}
         */
        protected void homeAwayTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Determine which ddl's selected item has been changed
            DropDownList ddl = (DropDownList)sender;
            var ddlName = ddl.ID;

            // Make sure the selected item is not a dummy value
            var selectedValue = Convert.ToInt32(ddl.SelectedValue);

            // Render the second ddl without the selected item in the first ddl
            if (ddlName == "ddlHomeTeam")
            {
                setupDdlTeam(ddlAwayTeam, selectedValue, Convert.ToInt32(ddlAwayTeam.SelectedValue));
            }
            else
            {
                setupDdlTeam(ddlHomeTeam, selectedValue, Convert.ToInt32(ddlHomeTeam.SelectedValue));
            }

            // Finally, re-render the winning team ddl
            setupDdlWinningTeam();
        }

        /**
         * <summary>
         * This methods populates the ddlWinningTeam dropdown list
         * according to the selections made in home/away team dropdown lists
         * </summary>
         * 
         * @method setupDdlWinningTeam
         * @returns {void}
         */
        private void setupDdlWinningTeam()
        {
            // Clear all previous items
            ddlWinningTeam.Items.Clear();

            // Home Team
            if (!String.IsNullOrEmpty(ddlHomeTeam.SelectedValue) && !ddlHomeTeam.SelectedValue.Equals("0"))
            {
                ddlWinningTeam.Items.Add(new ListItem(ddlHomeTeam.SelectedItem.Text, ddlHomeTeam.SelectedValue));
            }

            // Away Team
            if (!String.IsNullOrEmpty(ddlAwayTeam.SelectedValue) && !ddlAwayTeam.SelectedValue.Equals("0"))
            {
                ddlWinningTeam.Items.Add(new ListItem(ddlAwayTeam.SelectedItem.Text, ddlAwayTeam.SelectedValue));
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        /**
        * <summary>
        * Event handler, saves a new game to the DB
        * </summary>
        * 
        * @method btnSave_Click
        * @param {object} sender
        * @param {EventArgs} e
        * @returns {void}
        */
        protected void btnSave_Click(object sender, EventArgs e)
        {
            Game game = new Game();
            game.name = txtGameName.Text;
            game.description = txtGameName.Text;
            game.FK_homeTeam = Convert.ToInt32(ddlHomeTeam.SelectedValue);
            game.FK_awayTeam = Convert.ToInt32(ddlAwayTeam.SelectedValue);
            game.homeTeamScore = Convert.ToInt32(txtHomeTeamScore.Text);
            game.awayTeamScore = Convert.ToInt32(txtAwayTeamScore.Text);
            game.numberOfSpectators = Convert.ToInt32(txtNumberOfSpectators.Text);
            game.FK_winningTeam = Convert.ToInt32(ddlWinningTeam.SelectedValue);
            game.gameDate = Convert.ToDateTime(txtGameDate.Text);

            using (var db = new GameTrackerConn())
            {
                try
                {
                    db.Games.Add(game);
                    db.SaveChanges();
                    // Display a success message
                }
                catch (Exception ex)
                {
                    // Display an error message
                }
            }

            //reset txt boxes
            txtGameName.Text = "";
            txtGameDescription.Text = "";
            txtGameDate.Text = "";
            txtAwayTeamScore.Text = "";
            txtHomeTeamScore.Text = "";
            txtNumberOfSpectators.Text = "";
        }
    }
}