using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public ItemSO item { get; private set; }
    [SerializeField] private Image slotImage;
    [SerializeField] private Button itemButton;

    public void SetInventorySlotItem(ItemSO itemSO)
    {
        item = itemSO;
        UpdateSlot();
    }

    private void UpdateSlot()
    {
        slotImage.color = Color.white;
        slotImage.sprite = item.icon;
        // Could update tooltip, quantity, name, etc. (if needed)
    }

    public void ClearSlot()
    {
        item = null;
        slotImage.sprite = null;
        slotImage.color = new Color(0, 0, 0, 0);
    }

    public void UseItem()
    {
        if (item != null && item is EquipmentSO equipmentSO)
        {
            AudioManager.Instance.PlaySFX(AudioManager.Instance.equipItemSFX);
            PlayerInventory.Instance.EquipItem(equipmentSO);
        }
    }

}
