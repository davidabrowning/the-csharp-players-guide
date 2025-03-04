using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter24BossTicTacToe
{
    internal static class TestHelper
    {
        public static void AssertEquals(string title, object expected, object actual)
        {
            if (Equals(expected, actual))
                PrintSuccess(title);
            else
                PrintFailure(title, expected, actual);
        }
        public static void AssertTrue(string title, bool result)
        {
            if (result)
                PrintSuccess(title);
            else
                PrintFailure(title, false, result);
        }
        public static void AssertFalse(string title, bool result)
        {
            if (!result)
                PrintSuccess(title);
            else
                PrintFailure(title, true, result);
        }
        private static void PrintSuccess(string title)
        {
            Console.WriteLine($"Success: {title}");
        }
        private static void PrintFailure(string title, object expected, object actual)
        {
            Console.WriteLine($"Failure: {title} | Expected: {expected.ToString()} | Actual: {actual.ToString()}");
        }
    }
}
