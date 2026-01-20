using UnityEngine;
using UnityEngine.UI;
using static DamageCalculations;

public class PokemonActions : MonoBehaviour
{
    public PokemonData pokemonData;
    public PokemonData enemyData;
    [SerializeField] Animator animator;
    [SerializeField] Healthbar enemyHealthbar;
    [SerializeField] GameObject[] UI;
    [SerializeField] BattleCamera battleCamera;

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

        foreach (GameObject go in UI) {
            go.SetActive(false);
        }
        animator.SetTrigger("Attack");
        battleCamera.attackOffset = new Vector3(0,0,0);

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
