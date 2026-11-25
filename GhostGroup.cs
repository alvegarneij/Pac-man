using System.Diagnostics;

class GhostGroup
{
    private Ghost[] ghosts;
    private Stopwatch spökTimer = new Stopwatch();

    public GhostGroup(Ghost[] ghosts)
    {
        this.ghosts = ghosts;
    }

    public void StartaTimer()
    {
        spökTimer.Restart();
    }

    public bool HanteraKollision(PacMan pacman)
    {
        foreach (Ghost ghost in ghosts)
        {
            if (ghost.HanteraKollision(pacman))
            {
                return true;
            }
        }

        return false;
    }

    public void Flytta(Maze maze, PacMan pacman, Level level)
    {
        if (level.SkaSpökenFlytta(spökTimer.ElapsedMilliseconds))
        {
            foreach (Ghost ghost in ghosts)
            {
                ghost.Flytta(maze, pacman);
            }

            spökTimer.Restart();
        }
    }

    public void ÅterställPosition()
    {
        foreach (Ghost ghost in ghosts)
        {
            ghost.ÅterställPosition();
        }
    }
}