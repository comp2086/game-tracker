/**
 * Game Tracker
 * By: Anthony Scinocco & Alex Andriishyn
 * Games Page Code Behind file
 * http://asp-game-tracker.azurewebsites.net/Games.aspx
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameTracker.Models;
using GameTracker.User_Controls;

namespace GameTracker
{
    public partial class Games : System.Web.UI.Page
    {
        //stores the amount of days to add or subtract from our date
        static int timeToAddOrSubtract = 0;

        /**
         * Handles the page load event
         * 
         * return {void}
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            GetMostRecentGames();
        }

        /**
         * <summary>
         * This methods renders game info to the screen
         * </summary>
         * 
         * @method displayGame
         * @param {Game} game
         * @param {Team} homeTeam
         * @param {Team} awayTeam
         * @param {string} controlName
         * @returns {void}
         */
        private void displayGame(Game game, Team homeTeam, Team awayTeam)
        {
            // Load custom user control
            var gamePanel = (GamePanel) LoadControl("~/User_Controls/GamePanel.ascx");

            // Get data from objects
            var homeTeamScore = game.homeTeamScore;
            var awayTeamScore = game.awayTeamScore;
            var heading = homeTeam.name + " " + homeTeamScore + " : " + awayTeamScore + " " + awayTeam.name;
            var totalPointsScored = homeTeamScore + awayTeamScore;

            // Find labels within our user control
            var lblGameHeading = (Label)gamePanel.FindControl("lblGameHeading");
            var lblGameDescription = (Label)gamePanel.FindControl("lblGameDescription");
            var lblGameTotalPointsScored = (Label)gamePanel.FindControl("lblGameTotalPointsScored");
            var lblGameHomeTeamPointsLost = (Label)gamePanel.FindControl("lblGameHomeTeamPointslost");
            var lblGameAwayTeamPointsLost = (Label)gamePanel.FindControl("lblGameAwayTeamPointslost");

            // Render data into labels
            lblGameHeading.Text = heading;
            lblGameDescription.Text = game.description;
            lblGameTotalPointsScored.Text = totalPointsScored.ToString();
            lblGameHomeTeamPointsLost.Text = awayTeamScore.ToString();
            lblGameAwayTeamPointsLost.Text = homeTeamScore.ToString();

            // Finally, add game panel to the page
            accordion.Controls.Add(gamePanel);
        }
        
        /**
         * <summary>
         * Gets the most recent games
         * </summary>
         * 
         * @returns {void}
         */
        private void GetMostRecentGames()
        {
            //set next and prev buttons to hidden
            NextWeekButton.Enabled = false;
            LastWeekButton.Enabled = false;

            using (var db = new GameTrackerConn())
            {
                //stores a week before the current date
                var dateMinusAWeek = DateTime.Now;
                dateMinusAWeek = dateMinusAWeek.AddDays(-7);

                var games = (from game in db.Games
                             select game).OrderBy(game => game.gameDate).ToList();

                //stores the dates in a format c# likes
                var currentDate = DateTime.Now.AddDays(timeToAddOrSubtract);
                var endOfWeekDate = dateMinusAWeek.AddDays(timeToAddOrSubtract);

                //iterates through game data
                for (int i = 0; i <= 3; i++)
                {
                    var game = games[i];

                    //gets associated home team
                    var teamHome = (from team in db.Teams
                                    where game.FK_homeTeam == team.Id
                                    select team).FirstOrDefault();

                    //gets associated away team
                    var teamAway = (from team in db.Teams
                                    where game.FK_awayTeam == team.Id
                                    select team).FirstOrDefault();

                    // Render game data
                    displayGame(game, teamHome, teamAway);
                }

                // Show the first day(date) of the current week
                lblCurrentWeek.Text = currentDate.ToShortDateString();
            }
        }

        /**
         * <summary>
         * Handles the operations for adjusting the week todisplay for the previous week button click
         * </summary>
         * 
         * returns {void}
         */
        protected void LastWeekButton_Click(object sender, EventArgs e)
        {
            timeToAddOrSubtract -= 7;
            GetMostRecentGames();
        }

        /**
         * <summary>
         * Handles the operations for adjusting the week todisplay for the next week button click
         * </summary>
         * 
         * return {void}
         */
        protected void NextWeekButton_Click(object sender, EventArgs e)
        {
            timeToAddOrSubtract += 7;
            GetMostRecentGames();
        }
    }
}