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
        private Keypad keypad;
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
            keypad = new Keypad();
        }
        public void Go()
        {
            while (!IsOver)
                PlayTurn();
            PrintResult();
        }
        private void PlayTurn()
        {
            PrintActiveGameStatus();
            GetNextMove();
        }
        private void PrintActiveGameStatus()
        {
            pedestal.Clear();
            pedestal.PrintNeutral($"It is {CurrentPlayer}'s turn.");
            pedestal.PrintGameBoard(gameBoard);
        }
        private void GetNextMove()
        {
            try
            {
                pedestal.PrintPrompt("What square do you want to play in? ");
                int location = keypad.GetIntInput();
                gameBoard.ClaimLocation(CurrentPlayer, location - 1);
            }
            catch (Exception e)
            {
                pedestal.PrintWarning(e.Message);
                GetNextMove();
            }
        }
        private void PrintResult()
        {
            pedestal.Clear();
            if (gameBoard.HasDraw())
                pedestal.PrintNeutral($"Game ends in a draw");
            else
                pedestal.PrintNeutral($"{gameBoard.GetWinningSymbol().ToString()} wins!");
            pedestal.PrintGameBoard(gameBoard);
        }
    }
}
