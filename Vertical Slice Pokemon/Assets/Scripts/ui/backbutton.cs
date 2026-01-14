using UnityEngine;

public class backbutton : MonoBehaviour
{
    public GameObject firstscreen;
    public GameObject combatscreen;
    public GameObject arrow;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            firstscreen.SetActive(true);
            combatscreen.SetActive(false);
            arrow.SetActive(true);
        }
    }

}
