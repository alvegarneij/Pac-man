class ChaseMovement : IGhostMovement
{
    private int avstånd;
    
    public ChaseMovement(int avstånd)
    {
        this.avstånd = avstånd;
    }

    public void Flytta(Ghost ghost, Maze maze, PacMan pacMan)
    {
        pacMan.AngeMålFör(ghost, maze, avstånd);
    }
}