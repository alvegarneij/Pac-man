class Movement
{
    public void LäsTangent(PacMan pacman, Maze maze)
    {
        ConsoleKey key = Console.ReadKey(true).Key;

        switch (key)
        {
            case ConsoleKey.UpArrow:
                pacman.Flytta(-1, 0, maze);
                break;
            
            case ConsoleKey.DownArrow:
                pacman.Flytta(1, 0, maze);
                break;

            case ConsoleKey.LeftArrow:
                pacman.Flytta(0, -1, maze);
                break;

            case ConsoleKey.RightArrow:
                pacman.Flytta(0, 1, maze);
                break;
        }
    }
}