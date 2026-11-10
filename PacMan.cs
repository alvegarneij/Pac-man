class PacMan
{
    int row = 16;
    int col = 10;
    string riktning = "Höger";

    public void VisaPosition()
    {
        Console.WriteLine($"Pac-Man är på rad {row}, kolumn {col}");
    }

    public bool FinnsPacMan(int row, int col)
    {
        return this.row == row && this.col == col;
    }

    public void Flytta(int rowChange, int colChange, Maze maze)
    {
        int newRow = row + rowChange;
        int newCol = col + colChange;

        if (maze.KanGå(newRow, newCol))
        {
            row = newRow;
            col = newCol;
            maze.ÄtPellet(row,col);

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
}