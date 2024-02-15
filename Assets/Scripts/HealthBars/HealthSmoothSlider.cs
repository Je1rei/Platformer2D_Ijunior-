using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthSmoothSlider : HealthVisualizer
{
    [SerializeField] private Slider _healthBar;

    [SerializeField] private float _speedFillBar = 10f;

    private Coroutine _currentCoroutine;

    private IEnumerator SmoothFillBar(int targetValue)
    {
        while (_healthBar.value != targetValue)
        {
            _healthBar.value = Mathf.MoveTowards(_healthBar.value, targetValue, _speedFillBar * Time.deltaTime);
            yield return null;
        }
    }

    protected override void OnHealthChanged(int health)
    {
        if(_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(SmoothFillBar(health));
    }
}
