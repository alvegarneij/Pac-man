using System.IO;
class FileHighscore : IHighscore
{
    private string filnamn = "highscore.txt";
    public int Registrera(int poäng)
    {
        int rekord = 0;

        if (File.Exists(filnamn))
        {
            int.TryParse(File.ReadAllText(filnamn),out rekord);
        }
        if (poäng > rekord)
        {
            rekord = poäng;
            File.WriteAllText(filnamn, rekord.ToString());
        }
        return rekord;
    }
}