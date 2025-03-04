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
        private Pedestal pedestal;
        public Player CurrentPlayer { get { return players[CurrentTurnNumber % players.Length];  } }
        public int CurrentTurnNumber { get { return gameBoard.TotalClaimedLocations; } }
        public bool IsOver { get { return gameBoard.HasWinner() || gameBoard.HasDraw();  } }
        public Game()
        {
            gameBoard = new GameBoard();
            players = new Player[2];
            players[0] = new Player(Symbol.X);
            players[1] = new Player(Symbol.O);
            pedestal = new Pedestal();
        }
        public void Go()
        {
            while (!IsOver)
                PlayTurn();
        }
        private void PlayTurn()
        {
            pedestal.PrintNeutral($"It is {CurrentPlayer}'s turn.");
            pedestal.PrintGameBoard(gameBoard);
            pedestal.PrintPrompt("What square do you want to play in? ");
            Console.ReadLine();
        }
    }
}
