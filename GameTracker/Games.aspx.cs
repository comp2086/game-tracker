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

        // Nullable type for currentWeek
        static DateTime currentWeek;

        /**
         * Handles the page load event
         * 
         * return {void}
         */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetMostRecentGames();
            } 
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
            var gameDate = game.gameDate.ToShortDateString();
            var homeTeamScore = game.homeTeamScore;
            var awayTeamScore = game.awayTeamScore;
            var heading = homeTeam.name + " " + homeTeamScore + " : " + awayTeamScore + " " + awayTeam.name;
            var totalPointsScored = homeTeamScore + awayTeamScore;
            var spectators = game.numberOfSpectators;

            // Find labels within our user control
            var lblGameHeading = (Label)gamePanel.FindControl("lblGameHeading");
            var lblGameDate = (Label)gamePanel.FindControl("lblGameDate");
            var lblGameDescription = (Label)gamePanel.FindControl("lblGameDescription");
            var lblGameTotalPointsScored = (Label)gamePanel.FindControl("lblGameTotalPointsScored");
            var lblGameHomeTeamPointsLost = (Label)gamePanel.FindControl("lblGameHomeTeamPointslost");
            var lblGameAwayTeamPointsLost = (Label)gamePanel.FindControl("lblGameAwayTeamPointslost");
            var lblGameSpectators = (Label)gamePanel.FindControl("lblGameSpectators");

            // Render data into labels
            lblGameHeading.Text = heading;
            lblGameDate.Text = gameDate;
            lblGameDescription.Text = game.description;
            lblGameTotalPointsScored.Text = totalPointsScored.ToString();
            lblGameHomeTeamPointsLost.Text = awayTeamScore.ToString();
            lblGameAwayTeamPointsLost.Text = homeTeamScore.ToString();
            lblGameSpectators.Text = spectators.ToString();

            // Finally, add game panel to the page
            GameStats.Controls.Add(gamePanel);
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
            LastWeekButton.Enabled = true;
            NextWeekButton.Enabled = true;

            using (var db = new GameTrackerConn())
            {
                var games = (from game in db.Games
                             select game).OrderBy(game => game.gameDate).ToList();

                // Get the first/last game weeks
                var firstWeek = games[0].gameDate;
                var lastWeek = games[games.Count - 1].gameDate;

                // Update currentWeek
                currentWeek = firstWeek.AddDays(timeToAddOrSubtract);

                // Disable pagination if no more data available
                if (currentWeek <= firstWeek)
                {
                    LastWeekButton.Enabled = false;
                }

                if (currentWeek.AddDays(7) >= lastWeek)
                {
                    NextWeekButton.Enabled = false;
                }

                //iterates through game data
                if (games.Count != 0)
                {
                    foreach (Game game in games)
                    {
                        if (game.gameDate >= currentWeek && game.gameDate < currentWeek.AddDays(7))
                        {
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
                    }
                }
                else
                {
                    var lblNoGames = new Label();
                    lblNoGames.Text = "Sorry, no Games were played this week";
                    GameStats.Controls.Add(lblNoGames);
                }
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