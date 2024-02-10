using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private Mover _mover;

    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private int isRunHash = Animator.StringToHash("isRun");
    private Animator _animator;

    public int Damage { get; private set; }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        Damage = _damage;
    }

    private void Update()
    {
        _mover.Move(_speed);
        TurnAnimator();
        _mover.Jump(_jumpForce);
    }

    private void TurnAnimator()
    {
        _animator.SetBool(isRunHash, _mover.IsRun);
    }
}
