using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum battleState { start, playerturn, enemyturn, moveused, supereffective, won, lost }
public class TurnOrder : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;



    public battleState state;


    private void Start()
    {
        state = battleState.start;
        Debug.Log("I WANNA BE, THE VERY BEST :>");
    }


    public void PlayerTurn()
    {
        state = battleState.playerturn;
        Debug.Log("GO MY SLAVE :>");
    }

    public void EnemyTurn()
    {
        state = battleState.enemyturn;
        Debug.Log("NOOOOO MY ENEMY :>");
    }

    public void Won()
    {
        state = battleState.won;
        Debug.Log("you won :>");
    }

    public void Lost()
    {
        state = battleState.lost;
        Debug.Log("you lost :>");
    }


}






