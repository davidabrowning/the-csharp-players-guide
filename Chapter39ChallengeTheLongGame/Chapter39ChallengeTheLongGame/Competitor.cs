using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Chapter39ChallengeTheLongGame
{
    public class Competitor
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public bool PressedEnter { get; private set; }
        public Competitor()
        {
            Name = "No-man";
            Score = 0;
            PressedEnter = false;
        }
        public Competitor(string name) : this()
        {
            Name = name;
        }
        [JsonConstructor]
        public Competitor(string name, int score) : this(name)
        {
            Score = score;
        }
        public void LogKeyPress(ConsoleKey key)
        {
            if (key == ConsoleKey.Enter)
                PressedEnter = true;
            else
                Score++;
        }
        public override string ToString()
        {
            return $"{Name}: {Score}";
        }
        public override bool Equals(object? obj)
        {
            if (!(obj is Competitor))
                return false;
            Competitor otherCompetitor = (Competitor)obj;
            if (!Equals(Name, otherCompetitor.Name))
                return false;
            return true;
        }
    }
}
