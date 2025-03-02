using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter39ChallengeTheLongGame
{
    public class IslandCompetition
    {
        private UserInputRetriever userInputRetriever;
        private Printer printer;
        private Scribe scribe;
        private Competitor competitor;
        public IslandCompetition()
        {
            userInputRetriever = new UserInputRetriever();
            printer = new Printer();
            scribe = new Scribe();
            competitor = new Competitor("Unknown");
        }
        public void Start()
        {
            printer.SetTitle("The Long Game");
            while(Equals(competitor.Name, "Unknown"))
            {
                printer.PrintPrompt("Enter your name: ");
                competitor.Name = userInputRetriever.GetCompetitorName();
            }
            competitor.Score = scribe.GetScore(competitor);
            printer.SetTitle($"The Long Game: {competitor.Name}");
            while(!competitor.PressedEnter)
            {
                printer.PrintInstructions("Press keys to compete in the traditional IO Island key press competition.");
                printer.PrintNeutral(competitor.ToString());
                competitor.LogKeyPress(userInputRetriever.ReadKey());
                printer.Clear();
            }
            printer.PrintSuccess($"Good job, {competitor.Name}! See you next time.");
            scribe.SaveScore(competitor);
            printer.PrintSuccess($"Saved final score: {competitor.Score}.");
        }
    }
}
