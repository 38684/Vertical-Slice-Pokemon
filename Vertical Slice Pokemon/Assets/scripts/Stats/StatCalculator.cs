using Unity.VisualScripting.Antlr3.Runtime.Misc;

public static class StatCalculator
{
    public static Stats CalculateStats(BaseStats baseStats, int level)
    {
        BaseStats b = new BaseStats();

        b.baseHealth = baseStats.baseHealth * 2 + level * 5;
        b.baseAttack = baseStats.baseAttack * 2 + level;
        b.baseDefense = baseStats.baseDefense * 2 + level;
        b.baseSpAttack = baseStats.baseSpAttack * 2 + level;
        b.baseSpDefense = baseStats.baseSpDefense * 2 + level; 
        b.baseSpeed = baseStats.baseSpeed * 2 + level;

        return b;
    }
}
