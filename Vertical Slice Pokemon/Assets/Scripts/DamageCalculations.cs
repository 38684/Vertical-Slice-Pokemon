
using UnityEngine;
using static DataStructures;
using Types = DataStructures.Types;

public class DamageCalculations : ScriptableObject
{
    public static int CalculateDamage(PokemonData pokemonData, Moves move)
    {
        float critical = 1f;
        float type = 1;
        
        if (Random.Range(0, 24) == 0)
            critical = 1.5f;

        if (move.type == Types.Poison)
        {
            if (pokemonData.type[0] == Types.Grass)
                type *= 2;

            if (pokemonData.type[1] == Types.Fairy)
                type *= 2;
        }

        if (move.type == Types.Electric)
        {
            if (pokemonData.type[0] == Types.Grass)
                type /= 2;
        }

        if (move.type == Types.Grass)
        {
            if (pokemonData.type[0] == Types.Poison)
                type /= 2;
        }

        /*
                  / /2 * Level     \                            \
                  | |--------- + 2 | * Power * Attack / Defense |
         Damage = | \     5        /                            | * Critical * Random * STAB (always true) * Type
                  | ------------------------------------------- |
                  \                     50                      /
         */

        float baseDamage = ((2 * pokemonData.level / 5 + 2) * move.power * pokemonData.stats.attack / pokemonData.stats.defense / 50) + 2;
        float damage = Mathf.Floor(baseDamage * critical) * Random.Range(0.85f, 1f) * 1.5f * type;

        critical = 1f;

        return Mathf.RoundToInt(damage);
    }
}
