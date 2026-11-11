using System;

Maze maze = new Maze();
PacMan pacman = new PacMan();
Movement movement = new Movement();
Ghost ghost = new Ghost(10, 10);
Ghost secondGhost = new Ghost(10,11);
Ghost thirdGhost = new Ghost(10,9);

while (true)
{
    Console.Clear();

    maze.Visa(pacman,ghost, secondGhost, thirdGhost);
    pacman.VisaPosition();

    movement.LäsTangent(pacman, maze);

    if (ghost.KrockarMed(pacman) || (secondGhost.KrockarMed(pacman)) || (thirdGhost.KrockarMed(pacman)))
    {
        break;
    }

    ghost.Patrullera(maze);

    if (ghost.KrockarMed(pacman))
    {
        break;
    }
}
Console.WriteLine("Spöket fångade Pac-Man! Game over.");
