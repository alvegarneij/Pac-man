class Ghost
{
    private int row;
    private int col;
    private int direction = 0;

    public Ghost(int row, int col)
    {
        this.row = row;
        this.col = col;
    }

    public bool FinnsSpöke(int row, int col)
    {
        return this.row == row && this.col == col;
    }
    public bool KrockarMed(PacMan pacman)
    {
        return pacman.FinnsPacMan(row, col);
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
}