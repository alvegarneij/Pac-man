class PacMan
{
    int row = 16;
    int col = 10;
    string riktning = "Höger";
    private int poäng = 0;
    private DateTime powerUpSlut;
    private int powerUpTid = 10;
   // private HighscoreRäknare räknare; 

    // public void VisaPosition()
    // {
    //     Console.WriteLine($"Pac-Man är på rad {row}, kolumn {col}");
    // }

    public bool FinnsPacMan(int row, int col)
    {
        return this.row == row && this.col == col;
    }

    public void Flytta(int rowChange, int colChange, Maze maze)
    {
        int newRow = row + rowChange;
        int newCol = col + colChange;

        if (newRow == 10 && newCol < 0)
        {
            newCol = 20;
        }
        else if (newRow == 10 && newCol > 20)
        {
            newCol = 0;
        }

        if (maze.KanGå(newRow, newCol))
        {
            row = newRow;
            col = newCol;
            maze.ÄtPellet(row,col, this);

            if (colChange == 1)
            {
                riktning = "Höger";
            }
            else if (colChange == -1)
            {
                riktning = "Vänster";
            }
            else if (rowChange == -1)
            {
                riktning = "Upp";
            }
            else if (rowChange == 1)
            {
                riktning = "Ner";
            }
        }

    }

    public string ÄndraSymbol()
    {
        return riktning switch
        {
            "Höger" => "ᗧ",
            "Vänster" => "ᗤ",
            "Upp" => "ᗢ",
            "Ner" => "ᗣ",
            _ => "ᗧ"
        };
    }

    public void AngeMålFör(Ghost ghost, Maze maze)
    {
        int rowChange = 0;
        int colChange = 0;

        switch (riktning)
        {
            case "Upp":
                rowChange -=1;
                break;
            case "Ner":
                rowChange += 1;
                break;
            case "Vänster":
                colChange -=1;
                break;
            case "Höger":
                colChange += 1;
                break;
        }

        int targetRow = row + rowChange * 2;
        int targetCol = col + colChange * 2;

        ghost.FöljSpelare(targetRow, targetCol, maze, this);
    }

    public void ÖkaPoäng(int antal)
    {
        poäng += antal;
    }

    public void AktiveraPowerUp()
    {
        powerUpSlut = DateTime.Now.AddSeconds(powerUpTid);
    }

    public bool ÄrPowerUpAktiv()
    {
        return DateTime.Now < powerUpSlut;
    }

    public void VisaPoäng()
    {
        Console.WriteLine($"Poäng: {poäng}");
    }

    public void ÅterställPosition()
    {
        row = 16;
        col = 10;
        riktning = "Höger";
        powerUpSlut = DateTime.MinValue;
    }

    public void FörkortaPowerUp()
    {
        if (powerUpTid > 6)
        {
            powerUpTid--;
        }
    }
}