using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter24BossTicTacToe
{
    internal class Pedestal
    {
        private readonly ConsoleColor defaultConsoleColor = ConsoleColor.White;
        private void Print(string text, ConsoleColor textColor)
        {
            Console.ForegroundColor = textColor;
            Console.Write(text);
            Console.ForegroundColor = defaultConsoleColor;
        }
        private void PrintLine(string text, ConsoleColor textColor) => Print(text + "\n", textColor);
        private void PrintLine() => PrintLine("", defaultConsoleColor);
        public void Clear() => Console.Clear();
        public void PrintNeutral(string text) => PrintLine(text, ConsoleColor.White);
        public void PrintWarning(string text) => PrintLine(text, ConsoleColor.Yellow);
        public void PrintPrompt(string text) => Print(text, ConsoleColor.Cyan);
        public void PrintGameBoardComponent(string text) => Print(text, ConsoleColor.Gray);
        public void PrintGamePiece(string text) => Print(text, ConsoleColor.Cyan);
        public void PrintGameBoard(GameBoard gameBoard)
        {
            PrintGameBoardComponent("#############\n");
            for (int row = 0; row < 3; row++)
            {
                if (row > 0)
                    PrintGameBoardComponent("#---+---+---#\n");
                PrintGameBoardComponent("#");
                for (int col = 0; col < 3; col++)
                {
                    if (col > 0)
                        PrintGameBoardComponent("|");
                    Symbol symbol = gameBoard.SymbolAt(row * 3 + col);
                    if (symbol == Symbol.Empty)
                        PrintGameBoardComponent($" {row * 3 + col + 1} ");
                    else
                        PrintGamePiece($" {symbol} ");
                }
                PrintGameBoardComponent("#");
                PrintLine();
            }
            PrintGameBoardComponent("#############\n");
        }
    }
}
