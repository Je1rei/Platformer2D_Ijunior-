using UnityEngine;

public class HealthEnemy : MonoBehaviour
{
    [SerializeField] private int _health;

    public int Health { get; private set; }

    private void Awake()
    {
        Health = _health;
    }

    public int TakeDamage(int damage)
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }

        return Health -= damage;
    }
}
