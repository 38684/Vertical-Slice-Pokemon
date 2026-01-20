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
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
