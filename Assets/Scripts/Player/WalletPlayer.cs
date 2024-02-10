using UnityEngine;

public class WalletPlayer : MonoBehaviour
{
    [SerializeField] private int _coins;

    public void IncreaseCoins(int value)
    {
        _coins += value;
    }
}
