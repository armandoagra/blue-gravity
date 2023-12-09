using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInventoryUI : MonoBehaviour
{
    [SerializeField] private List<InventorySlot> inventorySlotList;
    [SerializeField] private TextMeshProUGUI coinText;

    [SerializeField] private GameObject inventoryWindow;


    private void OnEnable()
    {
        PlayerInventory.OnGoldChanged += UpdateGoldUI;
        PlayerInventory.OnInventoryChanged += RefreshInventoryUI;
        PlayerActions.OnToggleInventory += ToggleInventory;
    }

    private void OnDisable()
    {
        PlayerInventory.OnGoldChanged -= UpdateGoldUI;
        PlayerInventory.OnInventoryChanged -= RefreshInventoryUI;
    }

    private void UpdateGoldUI(int newAmount)
    {
        coinText.text = newAmount.ToString();
    }

    private void ToggleInventory()
    {
        inventoryWindow.SetActive(!inventoryWindow.activeSelf);
    }

    private void RefreshInventoryUI(List<ItemSO> items)
    {
        // Assumes inventory UI slots == inventory max size
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] != null)
            {
                inventorySlotList[i].SetInventorySlotItem(items[i]);
            }
        }
    }
}
