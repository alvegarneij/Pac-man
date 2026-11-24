//FALL #2
// KONCEPT: Interface
// IPellet definierar ett gemensamt kontrakt för olika typer av pellets.
// Alla klasser som implementerar IPellet måste ha metoden Ät().

interface IPellet
{
    void Ät(PacMan pacman);
}