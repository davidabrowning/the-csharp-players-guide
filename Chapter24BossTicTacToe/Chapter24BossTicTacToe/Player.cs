using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter24BossTicTacToe
{
    internal class Player
    {
        public Symbol PlayerSymbol { get;  }
        public Player(Symbol symbol)
        {
            PlayerSymbol = symbol;
        }
    }
}
