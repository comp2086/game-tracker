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

        private void displayGame(Game game, Team homeTeam, Team awayTeam, string controlName)
        {
            var lblHeading = (Label)FindControl("txtGame" + controlName + "Heading");
            var lblDescription = (Label)FindControl("txtGame" + controlName + "Description");
            var lblTotalPointsScored = (Label)FindControl("txtGame" + controlName + "TotalPointsScored");
            var lblAwayTeamPointsLost = (Label)FindControl("txtGame" + controlName + "AwayTeamPointsLost");
            var lblHomeTeamPointsLost = (Label)FindControl("txtGame" + controlName + "HomeTeamPointsLost");

            var homeTeamScore = game.homeTeamScore;
            var awayTeamScore = game.awayTeamScore;
            var heading = homeTeam.name + " " + homeTeamScore + " : " + awayTeamScore + " " + awayTeam.name;
            var totalPointsScored = homeTeamScore + awayTeamScore;

            lblHeading.Text = heading;
            lblDescription.Text = game.description;
            lblTotalPointsScored.Text = totalPointsScored.ToString();
            lblHomeTeamPointsLost.Text = awayTeamScore.ToString();
            lblAwayTeamPointsLost.Text = homeTeamScore.ToString();
        }

        /**
         * Gets the most recent games
         * 
         * return {void}
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
                             select game).ToList();

                //stores the games we want to display
                List<Game> gamesToDisplay = new List<Game>();
                List<Team> teamsToDisplay = new List<Team>();
                List<Game> gamesToNotDisplay = new List<Game>();

                //stores the dates in a format c# likes
                var currentDate = DateTime.Now.AddDays(timeToAddOrSubtract);
                var endOfWeekDate = dateMinusAWeek.AddDays(timeToAddOrSubtract);

                //iterates through game data
                foreach (Game game in games)
                {
                    //gets associated home team
                    var teamHome = (from team in db.Teams
                                    where game.FK_homeTeam == team.Id
                                    select team).FirstOrDefault();

                    //gets associated away team
                    var teamAway = (from team in db.Teams
                                    where game.FK_awayTeam == team.Id
                                    select team).FirstOrDefault();

                    //checks if games were played in the current week the app is looking at
                    if (game.gameDate <= currentDate && game.gameDate >= endOfWeekDate)
                    {
                        // Display a game
                        displayGame(game, teamHome, teamAway, "One");
                    }
                    else if (game.gameDate > currentDate || game.gameDate < endOfWeekDate)
                    {
                        gamesToNotDisplay.Add(game);
                    }

                }

                if (gamesToNotDisplay.Count > 0)
                {
                    foreach (Game game in gamesToNotDisplay)
                    {
                        if (game.gameDate > currentDate)
                        {
                            NextWeekButton.Enabled = true;
                        }

                        if (game.gameDate < endOfWeekDate)
                        {
                            LastWeekButton.Enabled = true;
                        }
                    }
                }

                // Show the first day(date) of the current week
                lblCurrentWeek.Text = currentDate.ToShortDateString();
            }
        }

        /**
         * Handles the operations for adjusting the week todisplay for the previous week button click
         * 
         * return {void}
         */
        protected void LastWeekButton_Click(object sender, EventArgs e)
        {
            timeToAddOrSubtract -= 7;
            GetMostRecentGames();
        }

        /**
         * Handles the operations for adjusting the week todisplay for the next week button click
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