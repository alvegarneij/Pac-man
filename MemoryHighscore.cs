class MemoryHighscore : IHighscore
{
    private int rekord;

    public int Registrera(int poäng)
    {
        if (poäng > rekord)
        {
            rekord = poäng;
        }

        return rekord;
    }
}