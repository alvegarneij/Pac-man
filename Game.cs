class Game
{
    public void StartaSpel()
    {
        GameMode gameMode = new GameMode();
        IHighscore highscore = gameMode.VäljSpelläge();
        HighscoreRäknare räknare = new HighscoreRäknare(highscore);
        Character character = new Character();

        bool spelaIgen = true;

        while (spelaIgen)
        {
            GameRound gameRound = new GameRound(räknare, character);
            gameRound.Spela();

            Console.WriteLine("Vill du spela igen? (Ja eller Nej)");
            string? svar = Console.ReadLine();
            spelaIgen = svar == "Ja" || svar== "ja";
        }
    }
}