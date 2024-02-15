using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    private const string _enemyLayer = "Enemy";

    [SerializeField] private float _timeAction = 6f;
    [SerializeField] private float _radiusDetected = 2f;
    [SerializeField] private float _damagePerSecond = 10f;
    [SerializeField] private Health _health;

    private Coroutine _currentCoroutine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ActivateSpell();
        }
    }

    private void ActivateSpell()
    {
        if (_currentCoroutine != null)
        {
            StopCoroutine(_currentCoroutine);
        }

        _currentCoroutine = StartCoroutine(CastLifeSteal());
    }

    private IEnumerator CastLifeSteal()
    {
        float elapsedTime = 0f;

        while (elapsedTime < _timeAction)
        {
            Collider2D closestEnemyCollider = FindClosestEnemies();

            if (closestEnemyCollider != null)
            {
                Health enemyHealth = closestEnemyCollider.GetComponent<Health>();

                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage((int)(_damagePerSecond));
                    _health.Heal((int)(_damagePerSecond));

                    yield return new WaitForSeconds(1f);
                }
            }

            elapsedTime += Time.deltaTime;

            yield return null;
        }
    }

    private Collider2D[] FindEnemies()
    {
        LayerMask enemyLayer = LayerMask.GetMask(_enemyLayer);
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, _radiusDetected, enemyLayer);

        return hitColliders;
    }

    private Collider2D FindClosestEnemies()
    {
        Collider2D[] enemies = FindEnemies();

        if (enemies.Length > 0)
        {
            Collider2D closestEnemy = null;
            float minDistance = float.MaxValue;

            foreach (Collider2D enemy in enemies)
            {
                float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

                if (distanceToEnemy < minDistance)
                {
                    minDistance = distanceToEnemy;
                    closestEnemy = enemy;
                }
            }

            return closestEnemy;
        }

        return null;
    }
}
