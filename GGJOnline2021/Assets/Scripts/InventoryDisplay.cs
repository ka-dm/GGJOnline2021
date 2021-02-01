using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI seedNumber;
    [SerializeField] TextMeshProUGUI woolNumber;
    [SerializeField] Inventory inventory;
    // Start is called before the first frame update

    private void Update()
    {
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        seedNumber.text = string.Format("x{0}", inventory.seed);
        woolNumber.text = string.Format("x{0}", inventory.wool);
    }


}
