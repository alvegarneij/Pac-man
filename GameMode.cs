class GameMode
{
    public IHighscore VäljSpelläge()
    {
        Console.WriteLine("Välj spelläge:");
        Console.WriteLine("1. Träningsläge");
        Console.WriteLine("2. Tävlingsläge");

        string? val = Console.ReadLine();

        while (val != "1" && val != "2")
        {
            Console.WriteLine("Ogiltigt val. Välj 1 eller 2.");
            val = Console.ReadLine();
        }

        if (val == "1")
        {
            return new MemoryHighscore();
        }

        return new FileHighscore();
    }
}