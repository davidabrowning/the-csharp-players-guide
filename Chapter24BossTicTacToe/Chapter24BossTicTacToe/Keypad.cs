using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter24BossTicTacToe
{
    internal class Keypad
    {
        public int GetIntInput()
        {
            if (int.TryParse(Console.ReadLine(), out int userInput))
                return userInput;
            throw new Exception("Non-integer input");
        }
    }
}
