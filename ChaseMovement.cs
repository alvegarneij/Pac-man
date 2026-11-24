class ChaseMovement : IGhostMovement
{
    private int avstånd;

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

            if (!ghost.ÄrFöregåendePosition(r, c) || ghost.ÄrPacManPåNästaRuta(r, c, pacman))
            {
                if (ghost.FörsökFlytta(r, c, maze))
                {
                    return;
                }
            }
        }

        foreach (var (r, c) in riktningar)
        {
            if (ghost.ÄrFöregåendePosition(r, c) && (r != 0 || c != 0))
            {
                if (ghost.FörsökFlytta(r, c, maze))
                {
                    return;
                }
            }
        }
    }

    public void Återställ()
    {
    }
}