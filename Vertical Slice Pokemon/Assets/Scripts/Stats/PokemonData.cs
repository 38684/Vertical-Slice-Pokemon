
using UnityEngine;
using static DataStructures;
using static StatCalculator;
using Random = UnityEngine.Random;
using Types = DataStructures.Types;

public class PokemonData : MonoBehaviour
{
    public string pokemonName;
    public bool isFemale;
    public int level;
    public int health;
    public Stats stats;
    public IndividualValues individualValues;
    public EffortValues effortValues;
    public Types[] type = new Types[2];
    public bool generateEffortValues;

    private void Start()
    {
        GenerateIVs();

        if (generateEffortValues)
            GenerateEVs();
    }

    private void GenerateIVs()
    {
        individualValues.health = Random.Range(0, 32);
        individualValues.attack = Random.Range(0, 32);
        individualValues.defense = Random.Range(0, 32);
        individualValues.specialAttack = Random.Range(0, 32);
        individualValues.specialDefense = Random.Range(0, 32);
        individualValues.speed = Random.Range(0, 32);
    }

    private void GenerateEVs()
    {
        int[] effortValueArray = new int[6];
        int max = 508;

        for (int i = 0; i < effortValueArray.Length; i++)
        {
            int random;

            if (max > 252)
                random = Random.Range(0, 253);

            else
                random = Random.Range(0, max);

            max -= random;
            effortValueArray[i] = random;
            effortValueArray = Shuffle(effortValueArray);
        }

        effortValues.health = effortValueArray[0];
        effortValues.attack = effortValueArray[1];
        effortValues.defense = effortValueArray[2];
        effortValues.specialAttack = effortValueArray[3];
        effortValues.specialDefense = effortValueArray[4];
        effortValues.speed = effortValueArray[5];
    }

    private int[] Shuffle(int[] array)
    {
        int n = array.Length;

        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            int value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
        return array;
    }

    
}
