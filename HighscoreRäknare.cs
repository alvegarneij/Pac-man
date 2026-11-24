class HighscoreRäknare
{
    private IHighscore highscore;
    private int rekord; 

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
