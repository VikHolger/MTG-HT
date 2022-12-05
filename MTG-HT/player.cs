namespace MTG_HT;

class Player
{
    int health;
    int[] commanderDamage;
    bool dead = false;

    Player (int players, int StHealth)
    {
        health = StHealth;
        commanderDamage = new int [players];
    }

    public void D (int dammage)
    {
        health -= dammage;
        if (dammage <= 0) //Checks if player is dead
            dead = true;
    }

    public void CD (int commander, int dammage)
    {
        health -= dammage;
        commanderDamage[commander] += dammage;

        //checks if player is dead
        if (commanderDamage[commander] >= 21)
            dead = true;
        else if (dammage <= 0)
            dead = true;
    }

    public bool Dead ()
    {
        return dead;
    }
}