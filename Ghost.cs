class Ghost
{
    private int row;
    private int col;
    private int startRow;
    private int startCol;
    private IGhostMovement movement;

    // FALL #1:
    // VAD: Subtypspolymorfism och beroendeinjektion.
    // HUR: Character skickar in PatrolMovement eller ChaseMovement via
    // konstruktorn. Ghost använder IGhostMovement för att anropa Flytta.
    // Patrullen provar riktningar i ordning, medan jakten beräknar ett mål
    // utifrån Pac-Mans position och rörelseriktning.
    // VARFÖR: Ghost kan använda nya rörelsealgoritmer utan att ändras.
    
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
            movement.Återställ();
            return false;
        }

        return true;
    }

    public void ÅterställPosition()
    {
        row = startRow;
        col = startCol;
        movement.Återställ();
    }

    public bool FörsökFlytta(int rowChange, int colChange, Maze maze)
    {
        int nextRow = row + rowChange;
        int nextCol = col + colChange;

        if (maze.KanGå(nextRow, nextCol))
        {
            row = nextRow;
            col = nextCol;
            return true;
        }

        return false;
    }

    public (int rowChange, int colChange) RiktningMot(int targetRow, int targetCol)
    {
        return (Math.Sign(targetRow - row), Math.Sign(targetCol - col));
    }

    public bool ÄrPacManPåNästaRuta(int rowChange, int colChange, PacMan pacman)
    {
        return pacman.FinnsPacMan(row + rowChange, col + colChange);
    }
}
