
public static class StatCalculator
{
    public static PokemonData CalculateStats(PokemonData baseStats)
    {
        PokemonData modifiedStats = new PokemonData();

        modifiedStats.stats.health = (2 * baseStats.stats.health + baseStats.individualValues.health + (baseStats.effortValues.health / 4) * baseStats.level) / 100 + baseStats.level + 10;
        modifiedStats.stats.attack = (2 * baseStats.stats.attack + baseStats.individualValues.attack + (baseStats.effortValues.attack / 4) * baseStats.level) / 100 + 5;
        modifiedStats.stats.defense = (2 * baseStats.stats.defense + baseStats.individualValues.defense + (baseStats.effortValues.defense / 4) * baseStats.level) / 100 + 5;
        modifiedStats.stats.specialAttack = (2 * baseStats.stats.specialAttack + baseStats.individualValues.specialAttack + (baseStats.effortValues.specialAttack / 4) * baseStats.level) / 100 + 5;
        modifiedStats.stats.specialDefense = (2 * baseStats.stats.specialDefense + baseStats.individualValues.specialDefense + (baseStats.effortValues.specialDefense / 4) * baseStats.level) / 100 + 5;
        modifiedStats.stats.speed = (2 * baseStats.stats.speed + baseStats.individualValues.speed + (baseStats.effortValues.speed / 4) * baseStats.level) / 100 + 5;
        modifiedStats.health = modifiedStats.stats.health;

        return modifiedStats;
    }
}
