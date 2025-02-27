using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter08ChallengeTheDefenseOfConsolas
{
    public class DefenseProgram
    {
        Squad squad;
        Printer printer;
        public DefenseProgram()
        {
            squad = new Squad();
            printer = new Printer();
        }

        public void Go()
        {
            int targetRow = GetIntFromUser(2, 7, "Target row: ");
            int targetColumn = GetIntFromUser(2, 7, "Target column: ");
            Location deploymentLocation = new Location(targetRow, targetColumn);
            try
            {
                squad.Deploy(deploymentLocation);
                printer.PrintSuccess("Squad deployed.");
            } 
            catch (Exception e)
            {
                printer.PrintFailure(e.Message);
            }
            printer.PrintSummary($"Summary:\n{squad}");
        }
        private int GetIntFromUser(int min, int max, string promptText)
        {
            int userInput;
            printer.PrintPrompt(promptText);
            while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < 2 || userInput > 7)
                printer.PrintPrompt(promptText);
            return userInput;
        }
    }
}
