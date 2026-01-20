
using UnityEngine;
using static DataStructures;
using Types = DataStructures.Types;
using MoveCategory = DataStructures.MoveCategory;

public class DamageCalculations : ScriptableObject
{
    public static int CalculateDamage(PokemonData pokemonData, PokemonData enemyData, Moves move)
    {
        float baseDamage;
        float critical = 1f;
        float type = 1;
        
        // Roll for a critical
        if (Random.Range(0, 24) == 0)
            critical = 1.5f;

        // Check if move will type effective or not
        if (move.type == Types.Poison)
        {
            if (enemyData.type[0] == Types.Grass)
                type *= 2;

            if (enemyData.type[1] == Types.Fairy)
                type *= 2;
        }

        if (move.type == Types.Electric)
        {
            if (enemyData.type[0] == Types.Grass)
                type /= 2;
        }

        if (move.type == Types.Grass)
        {
            if (enemyData.type[0] == Types.Poison)
                type /= 2;
        }

        /*
                  / /2 * Level     \                            \
                  | |--------- + 2 | * Power * Attack / Defense |
         Damage = | \     5        /                            | * Critical * Random * STAB (always true) * Type
                  | ------------------------------------------- |
                  \                     50                      /
         */

        // Check if move is physical
        if (move.category == MoveCategory.Physical)
            baseDamage = ((2 * pokemonData.level / 5 + 2) * move.power * pokemonData.stats.attack / enemyData.stats.defense / 50) + 2;
        else
            baseDamage = ((2 * pokemonData.level / 5 + 2) * move.power * pokemonData.stats.specialAttack / enemyData.stats.specialDefense / 50) + 2;

        float damage = Mathf.Floor(baseDamage * critical) * Random.Range(0.85f, 1f) * 1.5f * type;
        
        critical = 1f;

        return Mathf.RoundToInt(damage);
    }
}
