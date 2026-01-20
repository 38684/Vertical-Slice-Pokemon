using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    }


    public void PlayerTurn()
    {
        state = battleState.playerturn;
    }

    public void EnemyTurn()
    {
        state = battleState.enemyturn;
    }

    public void Won()
    {
        state = battleState.won;
    }

    public void Lost()
    {
        state = battleState.lost;
        SceneManager.LoadScene("WinScreen");
    }
}
