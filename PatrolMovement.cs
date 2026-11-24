class PatrolMovement : IGhostMovement
{
    private int direction = 0;
    public void Flytta(Ghost ghost, Maze maze, PacMan pacman)
    {
        for (int attempt = 0; attempt < 4; attempt++)
        {
            (int rowChange, int colChange) = direction switch
            {
                0 => (-1, 0),
                1 => (0, 1),
                2 => (1, 0),
                _ => (0, -1)
            };

            if (ghost.FörsökFlytta(rowChange, colChange, maze))
            {
                return;
            }

            direction = (direction + 1) % 4;
        }
    }

    public void Återställ()
{
    direction = 0;
}
}