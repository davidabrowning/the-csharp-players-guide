using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter24BossTicTacToe
{
    internal class TestRunner
    {
        public void RunTests()
        {
            string title;
            GameBoard gameBoard;
            Player playerOne;
            Player playerTwo;

            title = "GameBoard.HasCompletedRow() is initially false";
            gameBoard = new GameBoard();
            TestHelper.AssertFalse(title, gameBoard.HasCompletedRow());

            title = "Player.Symbol return correct symbol";
            playerOne = new Player(Symbol.X);
            TestHelper.AssertEquals(title, Symbol.X, playerOne.PlayerSymbol);

            title = "GameBoard.HasCompletedRow() is true after three plays in the same row";
            gameBoard = new GameBoard();
            playerOne = new Player(Symbol.X);
            gameBoard.ClaimLocation(playerOne, 3);
            gameBoard.ClaimLocation(playerOne, 4);
            gameBoard.ClaimLocation(playerOne, 5);
            TestHelper.AssertTrue(title, gameBoard.HasCompletedRow());

            title = "GameBoard.HasCompletedRow() is false when reclaimed location";
            gameBoard = new GameBoard();
            playerOne = new Player(Symbol.X);
            playerTwo = new Player(Symbol.O);
            gameBoard.ClaimLocation(playerOne, 3);
            gameBoard.ClaimLocation(playerTwo, 3);
            gameBoard.ClaimLocation(playerTwo, 4);
            gameBoard.ClaimLocation(playerTwo, 5);
            TestHelper.AssertFalse(title, gameBoard.HasCompletedRow());

            title = "GameBoard.HasCompletedColumn() is true after three plays in same column";
            gameBoard = new GameBoard();
            playerOne = new Player(Symbol.X);
            gameBoard.ClaimLocation(playerOne, 1);
            gameBoard.ClaimLocation(playerOne, 4);
            gameBoard.ClaimLocation(playerOne, 7);
            TestHelper.AssertTrue(title, gameBoard.HasCompletedColumn());

            title = "GameBoard.IsFull() is initially false";
            gameBoard = new GameBoard();
            TestHelper.AssertFalse(title, gameBoard.IsFull());

            title = "GameBoard.IsFull() is false after some plays";
            gameBoard = new GameBoard();
            playerOne = new Player(Symbol.X);
            for (int location = 0; location < 7; location++)
                gameBoard.ClaimLocation(playerOne, location);
            TestHelper.AssertFalse(title, gameBoard.IsFull());

            title = "GameBoard.IsFull() is true after 9 plays";
            gameBoard = new GameBoard();
            playerOne = new Player(Symbol.X);
            for (int location = 0; location < 9; location++)
                gameBoard.ClaimLocation(playerOne, location);
            TestHelper.AssertTrue(title, gameBoard.IsFull());
        }
    }
}
