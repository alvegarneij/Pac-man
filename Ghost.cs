using System.Data;

class Ghost
{
    private int row;
    private int col;
    private int direction = 0;
    private int previousRow = -1;
    private int previousCol = -1;
    private int startRow;
    private int startCol;
    private IGhostMovement movement;

    public Ghost(int row, int col, IGhostMovement movement)
    {
        this.row = row;
        this.col = col;
        startRow = row;
        startCol = col;
        this.movement = movement;
    }

    public bool FinnsSpöke(int row, int col)
    {
        return this.row == row && this.col == col;
    }

    public void Flytta(Maze maze, PacMan pacman)
    {
        movement.Flytta(this, maze, pacman);
    }

    public bool HanteraKollision(PacMan pacman)
    {
        if (!pacman.FinnsPacMan(row, col))
        {
            return false;
        }

        if (pacman.ÄrPowerUpAktiv())
        {
            pacman.ÖkaPoäng(20);
            row = startRow;
            col = startCol;
            previousRow = -1;
            previousCol = -1;
            direction = 0;
            return false;
        }

        return true;
    }

    public void ÅterställPosition()
    {
        row = startRow;
        col = startCol;
        previousRow = -1;
        previousCol = -1;
        direction = 0;
    }

    public void Patrullera(Maze maze)
    {
        for (int attempt = 0; attempt < 4; attempt++)
        {
            (int rowChange, int colChange) = direction switch
            {
                0 => (-1, 0), // Upp
                1 => (0, 1),  // Höger
                2 => (1, 0),  // Ner
                _ => (0, -1)  // Vänster
            };

            int nextRow = row + rowChange;
            int nextCol = col + colChange;
            if (maze.KanGå(nextRow, nextCol))
            {
                row = nextRow;
                col = nextCol;
                return;
            }

            direction = (direction + 1) % 4;
        }
    }   

    public void FöljSpelare(int targetRow, int targetCol, Maze maze, PacMan pacMan)
    {
        if (row < targetRow)
        {
            if (maze.KanGå(row + 1, col) && (!(row + 1 == previousRow && col == previousCol) || pacMan.FinnsPacMan(row + 1, col)))
            {
                previousRow = row;
                previousCol = col;
                row++;
                return;
            }
        }

        if (row > targetRow)
        {
            if (maze.KanGå(row - 1, col) && (!(row - 1 == previousRow && col == previousCol) || pacMan.FinnsPacMan(row - 1, col)))
            {
                previousRow = row;
                previousCol = col;
                row--;
                return;
            }
        }

        if (col < targetCol)
        {
            if (maze.KanGå(row, col + 1) && (!(row == previousRow && col + 1 == previousCol) || pacMan.FinnsPacMan(row, col + 1)))
            {
                previousRow = row;
                previousCol = col;
                col++;
                return;
            }
        }

        if (col > targetCol)
        {
            if (maze.KanGå(row, col - 1) && (!(row == previousRow && col - 1 == previousCol) || pacMan.FinnsPacMan(row, col - 1)))
            {
                previousRow = row;
                previousCol = col;
                col--;
                return;
            }
        }

        if (maze.KanGå(row - 1, col) && (!(row - 1 == previousRow && col == previousCol) || pacMan.FinnsPacMan(row - 1, col)))
        {
            previousRow = row;
            previousCol = col;
            row--;
            return;
        }

        if (maze.KanGå(row, col - 1) && (!(row == previousRow && col - 1 == previousCol) || pacMan.FinnsPacMan(row, col - 1)))
        {
            previousRow = row;
            previousCol = col;
            col--;
            return;
        }

        if (maze.KanGå(row + 1, col) && (!(row + 1 == previousRow && col == previousCol) || pacMan.FinnsPacMan(row + 1, col)))
        {
            previousRow = row;
            previousCol = col;
            row++;
            return;
        }

        if (maze.KanGå(row, col + 1) && (!(row == previousRow && col + 1 == previousCol) || pacMan.FinnsPacMan(row, col + 1)))
        {
            previousRow = row;
            previousCol = col;
            col++;
            return;
        }

        if (maze.KanGå(previousRow, previousCol))
        {
            int oldRow = row;
            int oldCol = col;

            row = previousRow;
            col = previousCol;

            previousRow = oldRow;
            previousCol = oldCol;
            return;
        }
    }


}