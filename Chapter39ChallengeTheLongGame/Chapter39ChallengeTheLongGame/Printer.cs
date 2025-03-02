using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter39ChallengeTheLongGame
{
    public class Printer
    {
        private ConsoleColor defaultConsoleColor;
        public Printer()
        {
            defaultConsoleColor = ConsoleColor.White;
        }
        public void Clear() => Console.Clear();
        public void SetTitle(string text)
        {
            Console.Title = text;
            Clear();
        }
        public void PrintPrompt(string text) => Print(text);
        public void PrintNeutral(string text) => PrintLine(text);
        public void PrintInstructions(string text) => PrintLine(text, ConsoleColor.Yellow);
        public void PrintSuccess(string text) => PrintLine(text, ConsoleColor.Green);
        private void Print(string text, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(text);
            Console.ForegroundColor = defaultConsoleColor;
        }
        private void Print(string text) => Print(text, defaultConsoleColor);
        private void PrintLine(string text, ConsoleColor consoleColor) => Print($"{text}\n", consoleColor);
        private void PrintLine(string text) => PrintLine(text, defaultConsoleColor);
    }
}
