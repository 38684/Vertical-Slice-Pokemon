using static DataStructures;

public static class StatCalculator
{
    public static Stats CalculateStats(Stats stats, IndividualValues individualValues, EffortValues effortValues, int level)
    {
        Stats modifiedStats = new Stats();

        modifiedStats.health = (2 * stats.health + individualValues.health + (effortValues.health / 4) * level) / 100 + level + 10;
        modifiedStats.attack = (2 * stats.attack + individualValues.attack + (effortValues.attack / 4) * level) / 100 + 5;
        modifiedStats.defense = (2 * stats.defense + individualValues.defense + (effortValues.defense / 4) * level) / 100 + 5;
        modifiedStats.specialAttack = (2 * stats.specialAttack + individualValues.specialAttack + (effortValues.specialAttack / 4) * level) / 100 + 5;
        modifiedStats.specialDefense = (2 * stats.specialDefense + individualValues.specialDefense + (effortValues.specialDefense / 4) * level) / 100 + 5;
        modifiedStats.speed = (2 * stats.speed + individualValues.speed + (effortValues.speed / 4) * level) / 100 + 5;

        return modifiedStats;
    }
}
