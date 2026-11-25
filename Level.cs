class Level
{
    private int nivå = 1;
    private int fördröjning = 400;

    public void VisaNivå()
    {
        Console.WriteLine($"Nivå: {nivå}");
    }

    public bool SkaSpökenFlytta(long millisekunder)
    {
        return millisekunder >= fördröjning;
    }

    public void Uppdatera(Maze maze, PacMan pacman, GhostGroup ghostGroup)
    {
        if (maze.AllaPelletsÄtna())
        {
            nivå++;
            maze.ÅterställPellets();
            pacman.ÅterställPosition();
            ghostGroup.ÅterställPosition();
            pacman.FörkortaPowerUp();

            if (fördröjning > 200)
            {
                fördröjning -= 50;
            }
        }
    }
}