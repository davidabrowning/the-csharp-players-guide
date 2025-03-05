namespace Chapter24BossTicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            // game.Go();

            TestRunner testRunner = new TestRunner();
            testRunner.RunTests();
        }
    }
}
