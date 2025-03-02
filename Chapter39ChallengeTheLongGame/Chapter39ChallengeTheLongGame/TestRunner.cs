using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter39ChallengeTheLongGame
{
    public class TestRunner
    {
        public void RunTests()
        {
            string title;
            Competitor competitor;
            Competitor anotherCompetitor;
            Scribe scribe;

            Console.WriteLine("Running tests.");

            title = "Competitor has intended name";
            competitor = new Competitor("Albert");
            TestHelper.AssertEquals(title, "Albert", competitor.Name);

            title = "Competitor can change names";
            competitor = new Competitor("Amy");
            competitor.Name = "Brenda";
            TestHelper.AssertEquals(title, "Brenda", competitor.Name);

            title = "Two competitors with same name are equal";
            competitor = new Competitor("Claudia");
            anotherCompetitor = new Competitor("Claudia");
            TestHelper.AssertEquals(title, competitor, anotherCompetitor);

            title = "Competitor score is initially 0";
            competitor = new Competitor();
            TestHelper.AssertEquals(title, 0, competitor.Score);

            title = "Competitor score is 2 after logging 2 keys";
            competitor = new Competitor();
            competitor.LogKeyPress(ConsoleKey.M);
            competitor.LogKeyPress(ConsoleKey.Z);
            TestHelper.AssertEquals(title, 2, competitor.Score);

            title = "Competitor score is still 0 after logging enter";
            competitor = new Competitor();
            competitor.LogKeyPress(ConsoleKey.Enter);
            competitor.LogKeyPress(ConsoleKey.Enter);
            TestHelper.AssertEquals(title, 0, competitor.Score);

            title = "Competitor.PressedEnter is false after pressing other keys";
            competitor = new Competitor();
            competitor.LogKeyPress(ConsoleKey.M);
            competitor.LogKeyPress(ConsoleKey.Z);
            TestHelper.AssertEquals(title, false, competitor.PressedEnter);

            title = "Competitor.PressedEnter is true after pressing enter";
            competitor = new Competitor();
            competitor.LogKeyPress(ConsoleKey.M);
            competitor.LogKeyPress(ConsoleKey.Enter);
            TestHelper.AssertEquals(title, true, competitor.PressedEnter);

            title = "Scribe returns the score of the same Competitor that it saved";
            competitor = new Competitor("TestDaniela");
            scribe = new Scribe();
            competitor.LogKeyPress(ConsoleKey.A);
            competitor.LogKeyPress(ConsoleKey.B);
            competitor.LogKeyPress(ConsoleKey.C);
            competitor.LogKeyPress(ConsoleKey.D);
            competitor.LogKeyPress(ConsoleKey.E);
            scribe.SaveScore(competitor);
            TestHelper.AssertEquals(title, 5, scribe.GetScore(competitor));

        }
    }
}
