using UnityEngine;
using static StatCalculator;
using static DamageCalculations;

using TMPro;

public class PokemonActions : PokemonData
{
    public PokemonData pokemonData = new PokemonData();
    public PokemonData enemyData = new PokemonData();
    public TMP_Text text;
    public static TurnOrder turnOrder;
    public Moveset moves;
    private int damage;
    
    private void Start()
    {
        text.text = text.name + ": " + enemyData.health;
        pokemonData = CalculateStats(pokemonData);
    }

    public void UseMove(int moveNumber)
    {
        damage = CalculateDamage(pokemonData, moves.moves[moveNumber]);
        enemyData.health -= damage;

        text.text = text.name + ": " + enemyData.health;

        if (gameObject.tag == "Player")
            turnOrder.EnemyTurn();
        else
            turnOrder.PlayerTurn();

        if (enemyData.health < 0)
            switch (gameObject.tag)
            {
                case "Player":
                    turnOrder.Won();
                    break;

                default:
                    turnOrder.Lost();
                    break;
            }
    }
}