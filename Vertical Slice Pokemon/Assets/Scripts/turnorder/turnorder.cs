
using System;
using UnityEngine;
using BattleState = DataStructures.BattleState;

public class TurnOrder : MonoBehaviour
{
    public static event Action <BattleState> OnTurnOrder;
    public BattleState state;

    private void Start()
    {
        state = BattleState.Start;
    }

    public void Menu()
    {
        state = BattleState.Menu;
    }


    public void PlayerTurn()
    {
        state = BattleState.PlayerTurn;
        OnTurnOrder.Invoke(state);
    }

    public void EnemyTurn()
    {
        state = BattleState.EnemyTurn;
        OnTurnOrder.Invoke(state);
    }

    public void Won()
    {
        state = BattleState.Won;
    }

    public void Lost()
    {
        state = BattleState.Lost;
    }


}






