class Maze
{
    char[,] tiles =
    {
        { 'W', 'W', 'W', 'W', 'W' },
        { 'W', 'P', 'P', 'P', 'W' },
        { 'W', 'P', 'W', 'P', 'W' },
        { 'W', 'P', 'P', 'P', 'W' },
        { 'W', 'W', 'W', 'W', 'W' }
    };

    public void Visa()
    {
        for (int row = 0; row < tiles.GetLength(0); row++) //row = rad
        {
            for (int col = 0; col < tiles.GetLength(1); col++) //col = kolumn
            {
                Console.Write(tiles[row, col]);
                
            }
            
            Console.WriteLine();
        }

    }
}