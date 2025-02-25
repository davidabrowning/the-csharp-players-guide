namespace Chapter30ChallengeColoredItems
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ColoredItem<Sword> blueSword = new ColoredItem<Sword>(new Sword(), "blue");
            ColoredItem<Bow> redBow = new ColoredItem<Bow>(new Bow(), "red");
            ColoredItem<Axe> greenAxe = new ColoredItem<Axe>(new Axe(), "green");
            blueSword.Display();
            redBow.Display();
            greenAxe.Display();
        }
    }
}
