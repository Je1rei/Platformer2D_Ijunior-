using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] private int _health;

    public int Health { get; private set; }

    private void Awake()
    {
        Health = _health;
    }

    public int TakeDamage(int damage) => Health -= damage;

    public void Heal(int value)
    {
        Health += value;
    }
}
