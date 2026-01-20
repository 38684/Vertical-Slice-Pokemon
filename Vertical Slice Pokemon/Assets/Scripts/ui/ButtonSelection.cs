using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI.Table;

public class ButtonSelection : MonoBehaviour
{
    public float[] arrowCheckpoints = new float[4];
    public float[] arrowCheckpointssecond = new float[4];
    private int arrowIndex;
    private int arrowIndexsecond;
    public GameObject arrow;
    public GameObject secondarrow;
    public Button fight;
    public GameObject firstset;
    public GameObject secondset;

    private void Start()
    {
        arrowIndex = 3;
        arrow.GetComponent<RectTransform>().position = new Vector3(1427, arrowCheckpoints[arrowIndex], 0);
    }

    public void combat()
    {
        arrowIndexsecond = 3;
        secondarrow.GetComponent<RectTransform>().position = new Vector3(1168, arrowCheckpointssecond[arrowIndexsecond], 0);
    }

    private void Update()
    {
        


        if (firstset.activeSelf)
        {

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {

                arrowIndex++;
                if (arrowIndex > 3)
                {
                    arrowIndex = 3;
                }
                arrow.GetComponent<RectTransform>().position = new Vector3(1427, arrowCheckpoints[arrowIndex], 0);




            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {

                arrowIndex--;
                if (arrowIndex < 0)
                {
                    arrowIndex = 0;
                }
                arrow.GetComponent<RectTransform>().position = new Vector3(1427, arrowCheckpoints[arrowIndex], 0);




            }

        }



        if (secondset.activeSelf)
        {   

           


            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {

                arrowIndexsecond++;
                if (arrowIndexsecond > 3)
                {
                    arrowIndexsecond = 3;
                }

                secondarrow.GetComponent<RectTransform>().position =
                    new Vector3(1168, arrowCheckpointssecond[arrowIndexsecond], 0);

                Debug.Log("indexinputworking");
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                arrowIndexsecond--;
                if (arrowIndexsecond < 0)
                {
                    arrowIndexsecond = 0;
                }

                secondarrow.GetComponent<RectTransform>().position =
                    new Vector3(1168, arrowCheckpointssecond[arrowIndexsecond], 0);

                Debug.Log("indexinputworking");
            }
        }

    }
}
