using System.Linq;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    [SerializeField] private float _detectionRadius;

    [SerializeField] private Transform _player;
    [SerializeField] private Transform[] _waypoints;

    private int _currentPoint;
    private bool _isPatrol;

    private SpriteRenderer _spriteRenderer;

    public int Damage { get; private set; }

    private void Awake()
    {
        Damage = _damage;
        _isPatrol = false;

        _spriteRenderer = GetComponent<SpriteRenderer>();
        _currentPoint = 0;
    }

    private void FixedUpdate()
    {
        MoveTowardsPlayer();

        if (_isPatrol == true) 
        {
            Patrol(); 
        }
    }

    private void Patrol()
    {
        if (_waypoints.Length > 0)
        {
            Transform currentWaypoint = _waypoints[_currentPoint];
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, _speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, currentWaypoint.position) < 0.001f)
            {
                GetNextPoint();
                FlipSprite();
            }
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

    private void MoveTowardsPlayer()
    {
        if (_detectionRadius > 0)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, _player.position);

            if (distanceToPlayer < _detectionRadius)
            {
                transform.position = Vector3.MoveTowards(transform.position, _player.position, _speed * Time.deltaTime);
                _isPatrol = false;
            }
            else
            {
                _isPatrol = true;
            }
        }
    }
}
