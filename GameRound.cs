class GameRound
{
    private Maze maze = new Maze(new NormalPellet(), new PowerPellet());
    private PacMan pacman;
    private Ghost[] ghosts;
    private GhostGroup ghostGroup;
    private Movement movement = new Movement();
    private Level level = new Level();
    private GameDisplay display = new GameDisplay();

    public GameRound(HighscoreRäknare räknare, Character character)
    {
        pacman = character.SkapaPacMan(räknare);
        ghosts = character.SkapaSpöken();
        ghostGroup = new GhostGroup(ghosts);
    }

    public void Spela()
    {
        ghostGroup.StartaTimer();
        Console.Clear();
        Console.CursorVisible = false;

        while (true)
        {
            display.Visa(maze, pacman, ghosts, level);
            movement.LäsTangent(pacman, maze);
            if (ghostGroup.HanteraKollision(pacman)) break;
            ghostGroup.Flytta(maze, pacman, level);
            if (ghostGroup.HanteraKollision(pacman)) break;
            level.Uppdatera(maze, pacman, ghostGroup);
            Thread.Sleep(100);
        }

        Console.WriteLine("Spöket fångade Pac-Man! Game over.");
        pacman.RegistreraHighscore();
        Console.CursorVisible = true;
    }
}