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

        /**
         * Gets the most recent games
         * 
         * return {void}
         */ 
        private void GetMostRecentGames()
        {
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

                    //stores the dates in a format c# likes
                    var currentDate = DateTime.Now.AddDays(timeToAddOrSubtract);
                    var endOfWeekDate = dateMinusAWeek.AddDays(timeToAddOrSubtract);

                    //checks if games were played in the current week the app is looking at
                    if (game.gameDate <= currentDate && game.gameDate >= endOfWeekDate)
                    {
                        //stores data in lists
                        teamsToDisplay.Add(teamHome);
                        teamsToDisplay.Add(teamAway);
                        gamesToDisplay.Add(game);
                    }
                    
                }


                //output game data
                try
                {
                    txtGameOneHeading.Text = teamsToDisplay[0].name.ToString() + " : "
                                              + gamesToDisplay[0].homeTeamScore.ToString() + " | "
                                              + gamesToDisplay[0].awayTeamScore.ToString() + " : "
                                              + teamsToDisplay[1].name.ToString();

                    txtGameOneDescription.Text = gamesToDisplay[0].description.ToString();


                    txtGameTwoHeading.Text = teamsToDisplay[2].name.ToString() + " : "
                                                  + gamesToDisplay[1].homeTeamScore.ToString() + " | "
                                                  + gamesToDisplay[1].awayTeamScore.ToString() + " : "
                                                  + teamsToDisplay[3].name.ToString();

                    txtGameTwoDescription.Text = gamesToDisplay[1].description.ToString();


                    txtGameThreeHeading.Text = teamsToDisplay[4].name.ToString() + " : "
                                                  + gamesToDisplay[2].homeTeamScore.ToString() + " | "
                                                  + gamesToDisplay[2].awayTeamScore.ToString() + " : "
                                                  + teamsToDisplay[5].name.ToString();

                    txtGameThreeDescription.Text = gamesToDisplay[2].description.ToString();

                    txtGameFourHeading.Text = teamsToDisplay[6].name.ToString() + " : "
                                                  + gamesToDisplay[3].homeTeamScore.ToString() + " | "
                                                  + gamesToDisplay[3].awayTeamScore.ToString() + " : "
                                                  + teamsToDisplay[7].name.ToString();

                    txtGameFourDescription.Text = gamesToDisplay[3].description.ToString();
                }
                catch
                {
                    txtGameOneHeading.Text = "No Game";
                    txtGameOneDescription.Text = "No Description";
                    txtGameTwoHeading.Text = "No Game";
                    txtGameTwoDescription.Text = "No Description";
                    txtGameThreeHeading.Text = "No Game";
                    txtGameThreeDescription.Text = "No Description";
                    txtGameFourHeading.Text = "No Game";
                    txtGameFourDescription.Text = "No Description";
                }
                
                
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