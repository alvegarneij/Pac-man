class PowerPellet : IPellet
{
    public void Ät(PacMan pacman)
    {
        pacman.ÖkaPoäng(5);
        pacman.AktiveraPowerUp();
    }
}