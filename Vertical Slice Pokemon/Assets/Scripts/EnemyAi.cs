
using UnityEngine;
using static TurnOrder;

public class EnemyAi : MonoBehaviour
{
    PokemonActions pokemonActions;

    private void Start()
    {
        OnTurnOrder += EnemyTurn;
        pokemonActions = GetComponent<PokemonActions>();
    }

    private void EnemyTurn(DataStructures.BattleState state)
    {
        if (state == DataStructures.BattleState.EnemyTurn)
            pokemonActions.UseMove(Random.Range(0, 5));
    }
}
