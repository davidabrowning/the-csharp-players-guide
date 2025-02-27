using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Chapter08ChallengeTheDefenseOfConsolas
{
    public class Printer
    {
        private ConsoleColor defaultConsoleColor = ConsoleColor.White;
        private void Print(string text, ConsoleColor consoleColor)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(text);
            Console.ForegroundColor = defaultConsoleColor;
        }

        private void PrintLine(string text, ConsoleColor consoleColor) => Print(text + "\n", consoleColor);
        public void PrintPrompt(string promptText) => Print(promptText, ConsoleColor.Yellow);
        public void PrintSuccess(string successText) => PrintLine(successText, ConsoleColor.Green);
        public void PrintFailure(string failureText) => PrintLine(failureText, ConsoleColor.Red);
        public void PrintSummary(string summaryText) => PrintLine(summaryText, ConsoleColor.Blue);
    }
}
