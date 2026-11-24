using System;

Maze maze = new Maze(new NormalPellet(), new PowerPellet());
PacMan pacman = new PacMan();
Movement movement = new Movement();
Ghost ghost = new Ghost(10, 10);
Ghost secondGhost = new Ghost(10,11);
Ghost thirdGhost = new Ghost(10,9);

while (true)
{
    Console.Clear();

    maze.Visa(pacman,ghost, secondGhost, thirdGhost);
    // pacman.VisaPosition();

    movement.LäsTangent(pacman, maze);

    if (ghost.HanteraKollision(pacman) || secondGhost.HanteraKollision(pacman) || thirdGhost.HanteraKollision(pacman))
    {
        break;
    }

    Thread.Sleep(400);
}
Console.WriteLine("Spöket fångade Pac-Man! Game over.");
