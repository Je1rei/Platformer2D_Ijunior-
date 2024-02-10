using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent(out HealthEnemy healthEnemy))
        {
            healthEnemy.TakeDamage(_player.Damage);
        }
    }
}
