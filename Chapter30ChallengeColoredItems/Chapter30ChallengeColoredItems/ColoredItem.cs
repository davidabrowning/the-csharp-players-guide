using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter30ChallengeColoredItems
{
    internal class ColoredItem<T>
    {
        private T item;
        private ConsoleColor defaultColor;
        private ConsoleColor itemColor;
        public ColoredItem(T item, string color)
        {
            this.item = item;
            defaultColor = GetConsoleColor("white");
            itemColor = GetConsoleColor(color);
        }
        public void Display()
        {
            Console.ForegroundColor = itemColor;
            Console.WriteLine(item.ToString());
            Console.ForegroundColor = defaultColor;
        }
        private ConsoleColor GetConsoleColor(string color)
        {
            switch (color.ToLower())
            {
                case "blue": return ConsoleColor.Blue;
                case "green": return ConsoleColor.Green;
                case "red": return ConsoleColor.Red;
                case "white": return ConsoleColor.White;
                case "yellow": return ConsoleColor.Yellow;
                default: return ConsoleColor.White;
            }
        }
    }
}
