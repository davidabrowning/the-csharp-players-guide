using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter39ChallengeTheLongGame
{
    public class UserInputRetriever
    {
        public string GetCompetitorName() => Console.ReadLine().Trim();
        public ConsoleKey ReadKey() => Console.ReadKey().Key;
    }
}
