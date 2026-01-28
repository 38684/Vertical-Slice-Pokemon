using System.Collections;
using UnityEngine;
using static DamageCalculations;

public class PokemonActions : MonoBehaviour
{
    public PokemonData pokemonData;
    public PokemonData enemyData;
    [SerializeField] Animator animator;
    [SerializeField] Healthbar enemyHealthbar;
    [SerializeField] GameObject[] ui;
    [SerializeField] GameObject particles;
    [SerializeField] GameObject hitParticles;
    [SerializeField] BattleCamera battleCamera;
    [SerializeField] AudioSource hitSfx;

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

        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        foreach (GameObject go in ui)
        {
            go.SetActive(false);
        }
        animator.SetTrigger("Attack");
        battleCamera.isAttackCamera = false;
        yield return new WaitForSeconds(1f);
        particles.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        particles.SetActive(false);
        battleCamera.isAttackCamera = true;
        yield return new WaitForSeconds(1f);

        hitParticles.SetActive(true);
        hitSfx.Play();

        // Update health bar
        enemyHealthbar.SetDisplayHealth(enemyData.health);

        yield return new WaitForSeconds(2.5f);

        hitParticles.SetActive(false);

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
