using UnityEngine;

public class MedicineChest : MonoBehaviour
{
    [SerializeField] private int _healthValue;

    private void OnTriggerEnter2D(Collider2D medicineChest)
    {
        if (medicineChest.gameObject.TryGetComponent(out Player player))
        {
            player.Healing(_healthValue);
            Destroy(gameObject);
        }
    }
}
