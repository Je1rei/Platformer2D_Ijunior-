using UnityEngine;
using UnityEngine.UI;

public class HealthBarSlider : HealthVisualizer
{
    [SerializeField] private Slider _healthBar;

    protected override void OnHealthChanged(int health)
    {
        _healthBar.value = health;
    }
}
