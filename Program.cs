using System;

Maze maze = new Maze();
PacMan pacman = new PacMan();
Movement movement = new Movement();

while (true)
{
    Console.Clear();

    maze.Visa(pacman);
    pacman.VisaPosition();

    movement.LäsTangent(pacman, maze);
}
