using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI objectText;
    void Start()
    {
        objectText = GetComponent<TextMeshProUGUI>();
    }
    public void UpdateItemText(PlayerInventory playerInventory)
    {
        objectText.text = playerInventory.NumberOfObjects.ToString();
    }
}