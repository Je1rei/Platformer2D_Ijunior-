using System.Collections;
using UnityEngine;

public class SpawnerCoins : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private Transform[] _spawnPoints;

    [SerializeField] private int _delay;

    private void Awake()
    {
        ShuffleSpawnPoints();
    }

    private void Start()
    {
        StartCoroutine(SpawnCoins());
    }

    private IEnumerator SpawnCoins()
    {
        var wait = new WaitForSeconds(_delay);

        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            Spawn(i);
            yield return wait;
        }
    }

    private void Spawn(int index)
    {
        Instantiate(_coin, _spawnPoints[index].position, Quaternion.identity);
    }

    private void ShuffleSpawnPoints()
    {
        if (_spawnPoints != null)
        {
            System.Random random = new System.Random();
            int number = _spawnPoints.Length;

            while (number > 1)
            {
                int previousNumber = random.Next(number--);
                Transform tempTransform = _spawnPoints[previousNumber];
                _spawnPoints[previousNumber] = _spawnPoints[number];
                _spawnPoints[number] = tempTransform;
            }
        }
    }
}
