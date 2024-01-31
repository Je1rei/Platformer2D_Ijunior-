using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private PhysicsMovement _movement;

    [SerializeField] private int _damage;
    [SerializeField] private int _health;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private int _coins;

    private int isRunHash = Animator.StringToHash("isRun");
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _movement.Move(_speed);
        TurnAnimator();
        _movement.Jump(_jumpForce);
    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.TryGetComponent(out Enemy enemy))
        {
            TakeDamage(enemy.Damage);
        }
    }

    private void TurnAnimator()
    {
        _animator.SetBool(isRunHash, _movement.IsRun);
    }

    public void IncreaseCoins(int value)
    {
        _coins += value;
    }

    public void Healing(int healthValue)
    {
        _health += healthValue;
    }

    public int ApplyDamage() => _damage;

    public int TakeDamage(int damage) => _health -= damage;
}
