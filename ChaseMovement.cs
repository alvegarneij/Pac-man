class ChaseMovement : IGhostMovement
{
    private int avstånd;
    private int previousRowChange = 0;
    private int previousColChange = 0;

    public ChaseMovement(int avstånd)
    {
        this.avstånd = avstånd;
    }

    public void Flytta(Ghost ghost, Maze maze, PacMan pacman)
    {
        (int targetRow, int targetCol) = pacman.BeräknaMål(avstånd);
        (int rowChange, int colChange) = ghost.RiktningMot(targetRow, targetCol);

        (int, int)[] riktningar =
        {
            (rowChange, 0),
            (0, colChange),
            (-1, 0),
            (0, -1),
            (1, 0),
            (0, 1)
        };

        foreach (var (r, c) in riktningar)
        {
            if (r == 0 && c == 0)
            {
                continue;
            }

            bool gårTillbaka = r == -previousRowChange && c == -previousColChange;

            if (!gårTillbaka || ghost.ÄrPacManPåNästaRuta(r, c, pacman))
            {
                if (ghost.FörsökFlytta(r, c, maze))
                {
                    previousRowChange = r;
                    previousColChange = c;
                    return;
                }
            }
        }

        if (previousRowChange != 0 || previousColChange != 0)
        {
            if (ghost.FörsökFlytta(-previousRowChange, -previousColChange, maze))
            {
                previousRowChange = -previousRowChange;
                previousColChange = -previousColChange;
            }
        }
    }

    public void Återställ()
    {
        previousRowChange = 0;
        previousColChange = 0;
    }
}