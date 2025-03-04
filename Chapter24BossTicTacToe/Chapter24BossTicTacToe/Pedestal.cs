using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter24BossTicTacToe
{
    internal class Pedestal
    {
        public void Clear()
        {
            Console.Clear();
        }
        public void PrintNeutral(string text)
        {
            Console.WriteLine(text);
        }
        public void PrintWarning(string text)
        {
            Console.WriteLine(text);
        }
        public void PrintPrompt(string text)
        {
            Console.Write(text);
        }
        public void PrintGameBoard(GameBoard gameBoard)
        {
            for (int row = 0; row < 3; row++)
            {
                if (row > 0)
                    Console.Write("---+---+---\n");
                for (int col = 0; col < 3; col++)
                {
                    if (col > 0)
                        Console.Write("|");
                    Symbol symbol = gameBoard.SymbolAt(row * 3 + col);
                    if (symbol == Symbol.Empty)
                        Console.Write($" {row * 3 + col + 1} ");
                    else
                        Console.Write($" {symbol.ToString()} ");
                }                    
                Console.WriteLine();
            }
        }
    }
}
