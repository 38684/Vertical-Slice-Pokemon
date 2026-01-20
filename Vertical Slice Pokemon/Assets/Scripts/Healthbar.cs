using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] Gradient gradient;
    [SerializeField] Image fill;

    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void SetMaxDisplayHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(health);
    }

    public void SetDisplayHealth(float health)
    {
        StartCoroutine(DrainHealth(health));
    }

    IEnumerator DrainHealth(float health)
    {
        while (slider.value != health) 
        {
            slider.value = Mathf.MoveTowards(slider.value, health, 0.01f);
            fill.color = gradient.Evaluate(slider.normalizedValue);
            yield return new WaitForFixedUpdate();
        }

        yield break;
    }
}
