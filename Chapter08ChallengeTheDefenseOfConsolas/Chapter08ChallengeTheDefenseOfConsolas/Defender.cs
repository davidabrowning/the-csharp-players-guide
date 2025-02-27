using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter08ChallengeTheDefenseOfConsolas
{
    public class Defender
    {
        public Location Location { get; private set; }
        public Defender()
        {
            Location = new Location();
        }
        public void AssignLocation(Location newLocation)
        {
            Location = newLocation;
        }
    }
}
