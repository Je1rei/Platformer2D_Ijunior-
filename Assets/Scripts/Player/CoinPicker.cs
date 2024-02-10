using UnityEngine;

[RequireComponent (typeof(WalletPlayer), typeof(Coin))]
public class CoinPicker : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] private WalletPlayer _wallet;

    private void Awake()
    {
        _wallet = GetComponent<WalletPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            _wallet.IncreaseCoins(coin.Value);
            Destroy(collision.gameObject);
        }
    }
}