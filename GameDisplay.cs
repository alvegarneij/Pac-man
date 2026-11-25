class GameDisplay
{
    public void Visa(Maze maze, PacMan pacman, Ghost[] ghosts, Level level)
    {
        Console.SetCursorPosition(0, 0);

        maze.Visa(pacman, ghosts[0], ghosts[1], ghosts[2]);
        level.VisaNivå();

        if (pacman.ÄrPowerUpAktiv())
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("POWER-UP AKTIV! Ät spökena!");
            Console.ResetColor();
        }
        else
        {
            Console.WriteLine(new string(' ', 30));
        }
    }
}