class Character
{
    public PacMan SkapaPacMan(HighscoreRäknare räknare)
    {
        return new PacMan(räknare);
    }

    public Ghost[] SkapaSpöken()
    {
        return new Ghost[]
        {
            new Ghost(10, 10, new PatrolMovement()),
            new Ghost(10, 11, new ChaseMovement(2)),
            new Ghost(10, 9, new ChaseMovement(4))
        };
    }
}