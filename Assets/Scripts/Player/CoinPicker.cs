using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPicker : MonoBehaviour
{
    private const string _coinTag = "Coin";

    [SerializeField] private WalletPlayer _wallet;

    private void Awake()
    {
        _wallet = GetComponent<WalletPlayer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == _coinTag)
        {
            Coin coin = collision.gameObject.GetComponent<Coin>();

            _wallet.IncreaseCoins(coin.Value);
            Destroy(collision.gameObject);
        }
    }
}