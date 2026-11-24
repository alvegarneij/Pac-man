using System;
using System.Diagnostics;

Maze maze = new Maze(new NormalPellet(), new PowerPellet());
IHighscore highscore = new FileHighscore();
HighscoreRäknare räknare = new HighscoreRäknare(highscore);
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