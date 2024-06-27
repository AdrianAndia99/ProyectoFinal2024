using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI objectText;
    void Start()
    {
        objectText = GetComponent<TextMeshProUGUI>();
    }
    public void UpdateDiamondText(PlayerInventory playerInventory)
    {
        objectText.text = playerInventory.NumberOfDiamonds.ToString();
    }
}