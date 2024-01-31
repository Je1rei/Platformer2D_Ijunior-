using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _value;

    private void OnTriggerEnter2D(Collider2D coin)
    {
        if (coin.gameObject.TryGetComponent(out Player player))
        {
            player.IncreaseCoins(_value);
            Destroy(gameObject);
        }
    }
}