using UnityEngine;
using TMPro;

public class HealthBarText : HealthVisualizer
{
    [SerializeField] private TMP_Text _healthBarText;

    protected override void OnHealthChanged(int health)
    {
        string healthText = $"{health} / {_health.MaxValue}";

        _healthBarText.text = healthText;
    }
}
