using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowFollower : MonoBehaviour
{
    public RectTransform arrow;
    public Vector3 offset;

    private void Update()
    {
        GameObject selected = EventSystem.current.currentSelectedGameObject;

        if (selected == null)
            return;

        RectTransform target = selected.GetComponent<RectTransform>();
        if (target == null)
            return;

        arrow.position = target.position + offset;
    }
}
