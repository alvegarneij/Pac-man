class HighscoreRäknare
{
    private IHighscore highscore;
    private int rekord;

    // FALL #2:
    // VAD: Subtypspolymorfism och beroendeinjektion.
    // HUR: GameMode väljer MemoryHighscore eller FileHighscore. Game skickar
    // in det valda objektet via konstruktorn som IHighscore.
    // HighscoreRäknare använder objektet för att hämta och registrera rekord.
    // VARFÖR: Samma räknare kan hantera rekord som sparas i minnet under
    // träningsläget eller i en fil som finns kvar mellan programstarter.

    public HighscoreRäknare(IHighscore highscore)
    {
        this.highscore = highscore;
        rekord = highscore.HämtaRekord();

    }

    public void RegistreraPoäng(int poäng)
    {
         rekord = highscore.Registrera(poäng);
        Console.WriteLine($"Highscore: {rekord}");
    }

    public void VisaHighscore(int poäng)
    {
        if (poäng > rekord)
        {
            Console.WriteLine($"Highscore: {poäng}");
        }
        else
        {
            Console.WriteLine($"Highscore: {rekord}");
        }
    }

    
}
