using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedicineChestPicker : MonoBehaviour
{
    private const string _medicineChestTag = "MedicineChest";

    [SerializeField] private HealthPlayer _healthPlayer;

    private void Awake()
    {
        _healthPlayer = GetComponent<HealthPlayer>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == _medicineChestTag)
        {
            MedicineChest medicineChest = collision.gameObject.GetComponent<MedicineChest>();

            _healthPlayer.Heal(medicineChest.Value);
            Destroy(collision.gameObject);
        }
    }
}
