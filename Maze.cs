using System.Data;
using System.Formats.Asn1;

class Maze
{
    string[] tiles =
    {
        "WWWWWWWWWWWWWWWWWWWWW",
        "WBPPPPPPPPWPPPPPPPPBW",
        "WPWWWPWWWPWPWWWPWWWPW",
        "WPWWWPWWWPWPWWWPWWWPW",
        "WPPPPPPPPPPPPPPPPPPPW",
        "WPWWWPWPWWWWWPWPWWWPW",
        "WPPPPPWPPPWPPPWPPPPPW",
        "WWWWWPWWWPWPWWWPWWWWW",
        "WWWWWPWPPPPPPPW WWWWW",
        "WWWWWPWPWW WWPWPWWWWW",
        "PPPPPPPPW   WPPPPPPPP",
        "WWWWWPWPWWWWWPWPWWWWW",
        "WWWWWPWPPPPPPPW WWWWW",
        "WWWWWPWWWPWPWWWPWWWWW",
        "WPPPPPWPPPWPPPWPPPPPW",
        "WPWWWPWPWWWWWPWPWWWPW",
        "WPPPPPPPPPPPPPPPPPPPW",
        "WPWWWPWWWPWPWWWPWWWPW",
        "WPWWWPWWWPWPWWWPWWWPW",
        "WBPPPPPPPPWPPPPPPPPBW",
        "WWWWWWWWWWWWWWWWWWWWW"
    };

    bool[,] ätnaPellets = new bool[21, 21];
    private IPellet normalPellet;
    private IPellet powerPellet;

    

    public Maze(IPellet normalPellet, IPellet powerPellet)
    {
        this.normalPellet = normalPellet;
        this.powerPellet = powerPellet;
         
    }



    public void Visa(PacMan pacman, Ghost ghost, Ghost secondGhost, Ghost thirdGhost)
    {
        for (int row = 0; row < tiles.Length; row++) //row = rad
        {
            for (int col = 0; col < tiles[row].Length; col++) //col = kolumn
            {
                if (pacman.FinnsPacMan(row, col))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(pacman.ÄndraSymbol() + " ");
                }
                else if (ghost.FinnsSpöke(row, col))
                {
                    Console.ForegroundColor = pacman.ÄrPowerUpAktiv() ? ConsoleColor.Blue : ConsoleColor.Red;
                    Console.Write("♟ ");
                }
                else if (secondGhost.FinnsSpöke(row, col))
                {
                    Console.ForegroundColor = pacman.ÄrPowerUpAktiv() ? ConsoleColor.Blue : ConsoleColor.Green;
                    Console.Write("♟ ");
                }
                else if (thirdGhost.FinnsSpöke(row, col))
                {
                    Console.ForegroundColor = pacman.ÄrPowerUpAktiv() ? ConsoleColor.Blue : ConsoleColor.White;
                    Console.Write("♟ ");
                }
                else if (tiles[row][col] == 'W')
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("██");
                }
                else if (tiles[row][col] == 'P' && !ätnaPellets[row, col])
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("· ");
                }
                else if (tiles[row][col] == 'B' && !ätnaPellets[row, col])
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write("● ");
                }
                else
                {
                    Console.Write("  ");
                }
                
            }

            Console.WriteLine();
        }
        
        Console.ResetColor();
        pacman.VisaPoäng();
    }

    public bool KanGå(int row, int col)
    {
        if (row < 0 || row >= tiles.Length)
        {
            return false;
        }

        if (col < 0 || col >= tiles[row].Length)
        {
            return false;
        }

        return tiles[row][col] != 'W';
    }

    public void ÄtPellet(int row, int col, PacMan pacman)
    {
        if (tiles[row][col] == 'P' && !ätnaPellets[row, col])
        {
            ätnaPellets[row, col] = true;
            normalPellet.Ät(pacman);
        }
        else if (tiles[row][col] == 'B' && !ätnaPellets[row, col])
        {
            ätnaPellets[row, col] = true;
            powerPellet.Ät(pacman);
        }
    }

    public bool AllaPelletsÄtna()
    {
        for (int row = 0; row < tiles.Length; row++)
        {
            for (int col = 0; col < tiles[row].Length; col++)
            {
                if ((tiles[row][col] == 'P' || tiles[row][col] == 'B') && !ätnaPellets[row, col])
                {
                    return false;
                }
            }
        }

        return true;
    }

    public void ÅterställPellets()
    {
        ätnaPellets = new bool[21, 21];
        
    }

}