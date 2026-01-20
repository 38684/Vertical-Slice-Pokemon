using UnityEngine;
using UnityEngine.UI;
using static DamageCalculations;

public class PokemonActions : MonoBehaviour
{
    public PokemonData pokemonData;
    public PokemonData enemyData;
    [SerializeField] Healthbar enemyHealthbar;

    public TurnOrder turnOrder;
    public Moveset moves;

    private int damage;

    public void UseMove(int moveNumber)
    {
        // Calculate damage
        damage = CalculateDamage(pokemonData, enemyData, moves.moves[moveNumber]);

        // Apply damage
        enemyData.health -= damage;
        enemyData.health = Mathf.Clamp(enemyData.health, 0, enemyData.health);

        // Update health bar
        enemyHealthbar.SetDisplayHealth(enemyData.health);
        
        // Win / Lose
        if (enemyData.health <= 0)
        {
            if (CompareTag("Player"))
                turnOrder.Won();
            else
                turnOrder.Lost();
        }

        // Turn order logic
        if (CompareTag("Player"))
            turnOrder.EnemyTurn();
        else
            turnOrder.PlayerTurn();
    }
}
