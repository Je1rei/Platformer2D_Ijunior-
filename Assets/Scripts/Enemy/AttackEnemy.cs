using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out HealthPlayer healthPlayer))
        {
            healthPlayer.TakeDamage(_enemy.Damage);
        }
    }
}
