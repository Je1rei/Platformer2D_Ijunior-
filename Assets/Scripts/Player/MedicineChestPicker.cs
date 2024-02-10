using UnityEngine;

[RequireComponent (typeof(HealthPlayer), typeof(MedicineChest))]
public class MedicineChestPicker : MonoBehaviour
{
    [SerializeField] private MedicineChest _medicineChest;
    [SerializeField] private HealthPlayer _healthPlayer;

    private void Awake()
    {
        _healthPlayer = GetComponent<HealthPlayer>();
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
