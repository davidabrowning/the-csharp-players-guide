using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Chapter39ChallengeTheLongGame
{
    public class Scribe
    {
        public void SaveScore(Competitor competitor)
        {
            string filename = GetFilenameFromCompetitor(competitor);
            string competitorAsJson = JsonSerializer.Serialize(competitor);
            File.WriteAllText(filename, competitorAsJson);
        }
        public int GetScore(Competitor competitor)
        {
            string filename = GetFilenameFromCompetitor(competitor);
            try {
                string competitorAsJson = File.ReadAllText(filename);
                Competitor loadedCompetitor = JsonSerializer.Deserialize<Competitor>(competitorAsJson) ?? new Competitor();
                return loadedCompetitor.Score;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        private string GetFilenameFromCompetitor(Competitor competitor)
        {
            return $"{competitor.Name}.json";
        }
    }
}
