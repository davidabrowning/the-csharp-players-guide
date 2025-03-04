using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter24BossTicTacToe
{
    internal class Game
    {
        private GameBoard gameBoard;
        private Player[] players;
        public int CurrentTurnNumber { get { return gameBoard.TotalClaimedLocations; } }
        public Game()
        {
            gameBoard = new GameBoard();
            players = new Player[2];
            players[0] = new Player(Symbol.X);
            players[1] = new Player(Symbol.O);
        }
    }
}
