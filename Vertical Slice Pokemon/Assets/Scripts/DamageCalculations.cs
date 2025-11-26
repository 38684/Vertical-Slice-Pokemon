
using UnityEngine;

public class DamageCalculations : MonoBehaviour
{
    public static int CalculateDamage(int level, int power, Stats stats, Types moveType, Types[] pokemonType)
    {
        float critical = 1f;
        float type = 1;
        
        if (Random.Range(0, 24) == 0)
            critical = 1.5f;

        if (moveType == Types.Poison)
        {
            if (pokemonType[0] == Types.Grass)
                type *= 2;

            if (pokemonType[1] == Types.Fairy)
                type *= 2;
        }

        if (moveType == Types.Electric)
        {
            if (pokemonType[0] == Types.Grass)
                type /= 2;
        }

        if (moveType == Types.Grass)
        {
            if (pokemonType[0] == Types.Poison)
                type /= 2;
        }

        /*
                  / /2 * Level     \                            \
                  | |--------- + 2 | * Power * Attack / Defense |
         Damage = | \     5        /                            | * Critical * Random * STAB (always true) * Type
                  | ------------------------------------------- |
                  \                     50                      /
         */

        float baseDamage = ((2 * level / 5 + 2) * power * stats.attack / stats.defense / 50) + 2;
        float damage = Mathf.Floor(baseDamage * critical) * Random.Range(0.85f, 1f) * 1.5f * type;

        critical = 1f;

        return Mathf.RoundToInt(damage);
    }
}
