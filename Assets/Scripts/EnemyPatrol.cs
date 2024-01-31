using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyPatrol : Enemy
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _detectionRadius = 10f;

    [SerializeField] private Transform _player;
    [SerializeField] private Transform[] _waypoints;

    private int _currentPoint;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        GetDamage(_damage);
        GetHealth(_health);

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _currentPoint = 0;
    }

    private void FixedUpdate()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }

        AttackSensor();
    }

    private void Patrol()
    {
        Transform currentWaypoint = _waypoints[_currentPoint];
        transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentWaypoint.position) < 0.001f)
        {
            GetNextPoint();
            FlipSprite();
        }
    }

    private Vector3 GetNextPoint()
    {
        _currentPoint = (++_currentPoint) % _waypoints.Length;

        Vector3 waypoint = _waypoints[_currentPoint].transform.position;

        return waypoint;
    }

    private void FlipSprite()
    {
        _spriteRenderer.flipX = _currentPoint % 2 == 0 ? true : false;
    }

    private void AttackSensor()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _player.position);

        if (distanceToPlayer < _detectionRadius)
        {
            MoveTowardsPlayer();
        }
        else
        {
            Patrol();
        }
    }

    private void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
    }
}
