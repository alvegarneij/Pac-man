class PatrolMovement : IGhostMovement
{
    public void Flytta(Ghost ghost, Maze maze, PacMan pacman)
    {
        ghost.Patrullera(maze);
    }
}