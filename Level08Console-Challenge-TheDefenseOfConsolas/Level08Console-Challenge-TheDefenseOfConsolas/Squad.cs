using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Chapter08ChallengeTheDefenseOfConsolas
{
    public class Squad
    {
        private List<Defender> defenders;
        public Squad()
        {
            defenders = new List<Defender>();
            AddDefenders(4);
        }
        public void AddDefender(Defender newDefender)
        {
            defenders.Add(newDefender);
        }
        public void AddDefenders(int numDefenders)
        {
            for (int i = 0; i < numDefenders; i++)
            {
                AddDefender(new Defender());
            }
        }
        public void Deploy(Location location)
        {
            if (defenders.Count < 4)
            {
                throw new Exception("Insufficient number of defenders. Need at least four.");
            }
            defenders[0].AssignLocation(location.MoveUp());
            defenders[1].AssignLocation(location.MoveLeft());
            defenders[2].AssignLocation(location.MoveDown());
            defenders[3].AssignLocation(location.MoveRight());
        }
        public override string ToString()
        {
            StringBuilder squadStringBuilder = new StringBuilder();
            foreach (Defender defender in defenders)
                squadStringBuilder.Append($"{defender.Location}\n");
            return squadStringBuilder.ToString();
        }
    }
}
