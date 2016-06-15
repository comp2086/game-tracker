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
        protected void Page_Load(object sender, EventArgs e)
        {
            GetMostRecentGames();
        }

        private void GetMostRecentGames()
        {
            using (var db = new GameTrackerConn())
            {

                //stores a week before the current date
                var dateMinusAWeek = DateTime.Now;
                dateMinusAWeek.AddDays(-7);

                var games = (from game in db.Games
                             select game).ToList();
                //stores the games we want to display
                List<Game> gamesToDisplay = new List<Game>();
                List<Team> teamsToDisplay = new List<Team>();
                
                foreach (Game game in games)
                {

                    var teamHome = (from team in db.Teams
                                    where game.FK_homeTeam == team.Id
                                    select team).FirstOrDefault();

                    var teamAway = (from team in db.Teams
                                    where game.FK_awayTeam == team.Id
                                    select team).FirstOrDefault();

                    teamsToDisplay.Add(teamHome);
                    teamsToDisplay.Add(teamAway);
                    gamesToDisplay.Add(game);

                    
                    if (DateTime.Compare(Convert.ToDateTime(game.gameDate), DateTime.Now) > 0 &&
                         DateTime.Compare(Convert.ToDateTime(game.gameDate), dateMinusAWeek) < 0)
                    {
                        gamesToDisplay.Add(game); 
                        
                    }
                }
            
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

        }

    }

}