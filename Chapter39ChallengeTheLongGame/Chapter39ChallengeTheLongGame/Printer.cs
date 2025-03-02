using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter39ChallengeTheLongGame
{
    public class Printer
    {
        public void Clear()
        {
            Console.Clear();
        }
        public void PrintPrompt(string text)
        {
            Console.Write(text);
        }
        public void PrintNeutral(string text)
        {
            Console.WriteLine(text);
        }
        public void PrintInstructions(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void PrintSuccess(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        public void SetTitle(string text)
        {
            Console.Title = text;
            Console.Clear();
        }
    }
}
