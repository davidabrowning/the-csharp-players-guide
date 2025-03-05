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
        private Pedestal pedestal; // Output to users
        private Keypad keypad; // Input from users
        public Player CurrentPlayer { get { return players[CurrentTurnNumber % players.Length];  } }
        public int CurrentTurnNumber { get { return gameBoard.ClaimedLocationCount(); } }
        public bool IsOver { get { return gameBoard.HasWinner || gameBoard.HasDraw;  } }
        public Game()
        {
            gameBoard = new GameBoard();
            players = new Player[2];
            pedestal = new Pedestal();
            keypad = new Keypad();

            players[0] = new Player(Symbol.X);
            players[1] = new Player(Symbol.O);
        }
        public void Go()
        {
            while (!IsOver)
                PlayTurn();
            PrintGameResult();
        }
        private void PlayTurn()
        {
            PrintGameStatus();
            GetNextMove();
        }
        private void PrintGameStatus()
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
                GetAndClaimLocation();
            }
            catch (Exception e)
            {
                pedestal.PrintWarning(e.Message);
                GetNextMove();
            }
        }
        private void GetAndClaimLocation()
        {
            int location = keypad.GetIntInput();
            gameBoard.ClaimLocation(CurrentPlayer, location - 1);
        }
        private void PrintGameResult()
        {
            pedestal.Clear();
            if (gameBoard.HasDraw)
                pedestal.PrintNeutral($"Game ends in a draw.");
            else
                pedestal.PrintNeutral($"{gameBoard.GetWinningSymbol().ToString()} wins!");
            pedestal.PrintGameBoard(gameBoard);
            pedestal.PrintNeutral("Thank you for playing!");
        }
    }
}
