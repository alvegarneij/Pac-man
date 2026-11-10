using System.Data;
using System.Formats.Asn1;

class Maze
{
    string[] tiles =
    {
        "WWWWWWWWWWWWWWWWWWWWW",
        "WPPPPPPPPPWPPPPPPPPPW",
        "WPWWWPWWWPWPWWWPWWWPW",
        "WPWWWPWWWPWPWWWPWWWPW",
        "WPPPPPPPPPPPPPPPPPPPW",
        "WPWWWPWPWWWWWPWPWWWPW",
        "WPPPPPWPPPWPPPWPPPPPW",
        "WWWWWPWWWPWPWWWPWWWWW",
        "WWWWWPWPPPPPPPW PWWWW",
        "WWWWWPWPWW WWPWPWWWWW",
        "PPPPPPPPW   WPPPPPPPP",
        "WWWWWPWPWWWWWPWPWWWWW",
        "WWWWWPWPPPPPPPW PWWWW",
        "WWWWWPWWWPWPWWWPWWWWW",
        "WPPPPPWPPPWPPPWPPPPPW",
        "WPWWWPWPWWWWWPWPWWWPW",
        "WPPPPPPPPPPPPPPPPPPPW",
        "WPWWWPWWWPWPWWWPWWWPW",
        "WPWWWPWWWPWPWWWPWWWPW",
        "WPPPPPPPPPWPPPPPPPPPW",
        "WWWWWWWWWWWWWWWWWWWWW"
    };

    bool[,] ätnaPellets = new bool[21, 21];
    int poäng = 0;



    public void Visa(PacMan pacman)
    {
        Console.WriteLine($"Rader: {tiles.Length}");
        Console.WriteLine($"Kolumner: {tiles[0].Length}");

        for (int row = 0; row < tiles.Length; row++)
        {
            Console.WriteLine($"Rad {row}: {tiles[row].Length} kolumner");
        }


        for (int row = 0; row < tiles.Length; row++) //row = rad
        {
            for (int col = 0; col < tiles[row].Length; col++) //col = kolumn
            {
                if (pacman.FinnsPacMan(row, col))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(pacman.ÄndraSymbol() + " ");
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
                else
                {
                    Console.Write("  ");
                }
                
            }

            Console.WriteLine();
        }
        
        Console.ResetColor();
        Console.WriteLine($"Poäng: {poäng}");
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

    public void ÄtPellet(int row, int col)
    {
        if (tiles[row][col] == 'P' && !ätnaPellets[row, col])
        {
            ätnaPellets[row, col] = true;
            poäng++;
        }
    }
}