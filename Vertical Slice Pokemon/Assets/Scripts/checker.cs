using UnityEngine;

public class checker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(GetComponent<RectTransform>().position);
    }
}
