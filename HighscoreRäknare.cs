//FALL #3
//VAD: Subtypsplymorfism och beroendeinjektion.
//HUR: FileHighscore eller MemoryHighscore injiceras
//Genom: konstruktorn via interfacet Ihighscore.
//VARFÖR: HighscoreRäknare kan hentera både tillfälliga
//och permanenta rekord utan att dess kod behöver ändras.


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
