using System;
using System.Diagnostics;

Console.WriteLine("Välj spelläge:");
Console.WriteLine("1. Träningsläge");
Console.WriteLine("2. Tävlingsläge");

string? val = Console.ReadLine();

while (val != "1" && val != "2")
{
    Console.WriteLine("Ogiltigt val. Välj 1 eller 2.");
    val = Console.ReadLine();
}
IHighscore highscore;

if (val == "1")
{
    highscore = new MemoryHighscore();
}
else
{
    highscore = new FileHighscore();
}
HighscoreRäknare räknare = new HighscoreRäknare(highscore);
Maze maze = new Maze(new NormalPellet(), new PowerPellet());

PacMan pacman = new PacMan(räknare);

Movement movement = new Movement();
Ghost ghost = new Ghost(10, 10, new PatrolMovement());
Ghost secondGhost = new Ghost(10, 11, new ChaseMovement(2));
Ghost thirdGhost = new Ghost(10, 9, new ChaseMovement(4));

int nivå = 1;
int fördröjning = 400;
Stopwatch spökTimer = Stopwatch.StartNew();

Console.Clear();
Console.CursorVisible = false;

while (true)
{
    Console.SetCursorPosition(0, 0);

    maze.Visa(pacman, ghost, secondGhost, thirdGhost);
    Console.WriteLine($"Nivå: {nivå}");

    movement.LäsTangent(pacman, maze);

    if (ghost.HanteraKollision(pacman) || secondGhost.HanteraKollision(pacman) || thirdGhost.HanteraKollision(pacman))
    {
        break;
    }

    if (spökTimer.ElapsedMilliseconds >= fördröjning)
    {
        ghost.Flytta(maze, pacman);
        secondGhost.Flytta(maze, pacman);
        thirdGhost.Flytta(maze, pacman);
        spökTimer.Restart();
    }

    if (ghost.HanteraKollision(pacman) || secondGhost.HanteraKollision(pacman) || thirdGhost.HanteraKollision(pacman))
    {
        break;
    }

    if (maze.AllaPelletsÄtna())
    {
        nivå++;
        maze.ÅterställPellets();
        pacman.ÅterställPosition();
        ghost.ÅterställPosition();
        secondGhost.ÅterställPosition();
        thirdGhost.ÅterställPosition();
        pacman.FörkortaPowerUp();


        if (fördröjning > 200)
        {
            fördröjning -= 50;
        }
    }

    Thread.Sleep(100);
}

Console.WriteLine("Spöket fångade Pac-Man! Game over.");
pacman.RegistreraHighscore();