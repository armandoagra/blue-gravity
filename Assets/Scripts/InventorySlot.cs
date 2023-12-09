using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public ItemSO item { get; private set; }
    [SerializeField] private Image slotImage;



    public void SetInventorySlotItem(ItemSO itemSO)
    {
        item = itemSO;
        UpdateSlot();
    }

    private void UpdateSlot()
    {
        slotImage.sprite = item.icon;
        // Could update tooltip, quantity, name, etc. (if needed)

    }

}
