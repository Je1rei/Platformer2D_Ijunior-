using UnityEngine;

[RequireComponent (typeof(Health), typeof(MedicineChest))]
public class MedicineChestPicker : MonoBehaviour
{
    [SerializeField] private MedicineChest _medicineChest;
    [SerializeField] private Health _healthPlayer;

    private void Awake()
    {
        _healthPlayer = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out MedicineChest medicineChest))
        {
            _healthPlayer.Heal(medicineChest.Value);
            Destroy(collision.gameObject);
        }
    }
}
