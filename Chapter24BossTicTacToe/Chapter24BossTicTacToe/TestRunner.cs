﻿using System;
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
            Game game;
            GameBoard gameBoard;
            Player playerOne;
            Player playerTwo;

            title = "GameBoard.HasWinner() is initially false";
            gameBoard = new GameBoard();
            TestHelper.AssertFalse(title, gameBoard.HasWinner);

            title = "Player.Symbol return correct symbol";
            playerOne = new Player(Symbol.X);
            TestHelper.AssertEquals(title, Symbol.X, playerOne.PlayerSymbol);

            title = "GameBoard.HasWinner() is true after three plays in the same row";
            gameBoard = new GameBoard();
            playerOne = new Player(Symbol.X);
            gameBoard.ClaimLocation(playerOne, 3);
            gameBoard.ClaimLocation(playerOne, 4);
            gameBoard.ClaimLocation(playerOne, 5);
            TestHelper.AssertTrue(title, gameBoard.HasWinner);

            title = "GameBoard.HasWinner() is false when reclaimed location";
            gameBoard = new GameBoard();
            playerOne = new Player(Symbol.X);
            playerTwo = new Player(Symbol.O);
            gameBoard.ClaimLocation(playerOne, 3);
            try
            {
                gameBoard.ClaimLocation(playerTwo, 3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            gameBoard.ClaimLocation(playerTwo, 4);
            gameBoard.ClaimLocation(playerTwo, 5);
            TestHelper.AssertFalse(title, gameBoard.HasWinner);

            title = "GameBoard.HasWinner is true after three plays in same column";
            gameBoard = new GameBoard();
            playerOne = new Player(Symbol.X);
            gameBoard.ClaimLocation(playerOne, 1);
            gameBoard.ClaimLocation(playerOne, 4);
            gameBoard.ClaimLocation(playerOne, 7);
            TestHelper.AssertTrue(title, gameBoard.HasWinner);

            title = "GameBoard.HasWinner is true after three plays in top-left diagonal";
            gameBoard = new GameBoard();
            playerOne = new Player(Symbol.X);
            gameBoard.ClaimLocation(playerOne, 0);
            gameBoard.ClaimLocation(playerOne, 4);
            gameBoard.ClaimLocation(playerOne, 8);
            TestHelper.AssertTrue(title, gameBoard.HasWinner);

            title = "GameBoard.HasWinner is true after three plays in top-right diagonal";
            gameBoard = new GameBoard();
            playerOne = new Player(Symbol.X);
            gameBoard.ClaimLocation(playerOne, 2);
            gameBoard.ClaimLocation(playerOne, 4);
            gameBoard.ClaimLocation(playerOne, 6);
            TestHelper.AssertTrue(title, gameBoard.HasWinner);

            title = "GameBoard.IsFull is initially false";
            gameBoard = new GameBoard();
            TestHelper.AssertFalse(title, gameBoard.IsFull);

            title = "GameBoard.IsFull is false after some plays";
            gameBoard = new GameBoard();
            playerOne = new Player(Symbol.X);
            for (int location = 0; location < 7; location++)
                gameBoard.ClaimLocation(playerOne, location);
            TestHelper.AssertFalse(title, gameBoard.IsFull);

            title = "GameBoard.IsFull is true after 9 plays";
            gameBoard = new GameBoard();
            playerOne = new Player(Symbol.X);
            for (int location = 0; location < 9; location++)
                gameBoard.ClaimLocation(playerOne, location);
            TestHelper.AssertTrue(title, gameBoard.IsFull);

            title = "Turn number is initially 0";
            game = new Game();
            TestHelper.AssertEquals(title, 0, game.CurrentTurnNumber);

            title = "LocationsClaimed is initially 0";
            gameBoard = new GameBoard();
            TestHelper.AssertEquals(title, 0, gameBoard.LocationsClaimed);

            title = "LocationsClaimed is 1 after 1 claimed location";
            gameBoard = new GameBoard();
            playerOne = new Player(Symbol.X);
            gameBoard.ClaimLocation(playerOne, 1);
            TestHelper.AssertEquals(title, 1, gameBoard.LocationsClaimed);
        }
    }
}
