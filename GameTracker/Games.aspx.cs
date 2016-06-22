/**
 * Game Tracker
 * By: Anthony Scinocco & Alex Andriishyn
 * Games Page Code Behind file
 * http://asp-game-tracker.azurewebsites.net/Games.aspx
 */

using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GameTracker.Models;
using System.Diagnostics;

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
            var homeTeamScore = game.homeTeamScore;
            var awayTeamScore = game.awayTeamScore;
            var heading = homeTeam.name + " " + homeTeamScore + " : " + awayTeamScore + " " + awayTeam.name;
            var totalPointsScored = homeTeamScore + awayTeamScore;

            if (controlName == "One")
            {
                txtGameOneHeading.Text = heading;
                txtGameOneDescription.Text = game.description;
                txtGameOneTotalPointsScored.Text = totalPointsScored.ToString();
                txtGameOneAwayTeamPointsLost.Text = homeTeamScore.ToString();
                txtGameOneHomeTeamPointsLost.Text = awayTeamScore.ToString();
            }else if(controlName == "Two")
            {
                txtGameTwoHeading.Text = heading;
                txtGameTwoDescription.Text = game.description;
                txtGameTwoTotalPointsScored.Text = totalPointsScored.ToString();
                txtGameTwoAwayTeamPointsLost.Text = homeTeamScore.ToString();
                txtGameTwoHomeTeamPointsLost.Text = awayTeamScore.ToString();
            }
            else if(controlName == "Three")
            {
                txtGameThreeHeading.Text = heading;
                txtGameThreeDescription.Text = game.description;
                txtGameThreeTotalPointsScored.Text = totalPointsScored.ToString();
                txtGameThreeAwayTeamPointsLost.Text = homeTeamScore.ToString();
                txtGameThreeHomeTeamPointsLost.Text = awayTeamScore.ToString();
            }
            else if(controlName == "Four")
            {
                txtGameFourHeading.Text = heading;
                txtGameFourDescription.Text = game.description;
                txtGameFourTotalPointsScored.Text = totalPointsScored.ToString();
                txtGameFourAwayTeamPointsLost.Text = homeTeamScore.ToString();
                txtGameFourHomeTeamPointsLost.Text = awayTeamScore.ToString();
            }
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
                
                //counts the number of games iterated through
                int counter = 0;

                //iterates through game data
                foreach (Game game in games)
                {
                    counter++;

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
                        if (counter == 1)
                        {
                            displayGame(game, teamHome, teamAway, "One");
                        }
                        else if(counter == 2)
                        {
                            displayGame(game, teamHome, teamAway, "Two");
                        }
                        else if (counter == 3)
                        {
                            displayGame(game, teamHome, teamAway, "Three");
                        }
                        else if(counter == 4)
                        {
                            displayGame(game, teamHome, teamAway, "Four");
                        }
                        
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