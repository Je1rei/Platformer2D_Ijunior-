using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Damage { get; private set; }
    public int Health { get; private set; }

    protected int TakeDamage(int damage) => Health -= damage;

    protected int GetHealth(int health) => Health = health;

    protected int GetDamage(int damage) => Damage = damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            TakeDamage(player.ApplyDamage());
        }
    }
}
