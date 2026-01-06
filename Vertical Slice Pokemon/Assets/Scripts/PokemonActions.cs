using UnityEngine;
using UnityEngine.UI;
using static StatCalculator;
using static DamageCalculations;

public class PokemonActions : MonoBehaviour
{
    public PokemonData pokemonData = new PokemonData();
    public PokemonData enemyData = new PokemonData();


    // 🟩 Health bar Image (UI → Image)
    public Image enemyHealthBar;

    public static TurnOrder turnOrder;
    public Moveset moves;

    private int damage;

    private void Start()
    {
        // Calculate stats
        pokemonData = CalculateStats(pokemonData);
        enemyData = CalculateStats(enemyData);

        // Initialize health bar
        enemyHealthBar.fillAmount = 1f;
    }

    public void UseMove(int moveNumber)
    {
        // Calculate damage
        damage = CalculateDamage(pokemonData, moves.moves[moveNumber]);

        // Apply damage
        enemyData.health -= damage;
        enemyData.health = Mathf.Clamp(enemyData.health, 0, enemyData.health);

        // Update health bar
        enemyHealthBar.fillAmount =
            (float)enemyData.health / enemyData.health;

        // Turn order logic
        if (CompareTag("Player"))
            turnOrder.EnemyTurn();
        else
            turnOrder.PlayerTurn();

        // Win / Lose
        if (enemyData.health <= 0)
        {
            if (CompareTag("Player"))
                turnOrder.Won();
            else
                turnOrder.Lost();
        }
    }
}
