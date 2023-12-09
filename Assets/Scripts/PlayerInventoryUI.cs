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
        PlayerActions.OnToggleInventory -= ToggleInventory;
    }

    private void UpdateGoldUI(int newAmount)
    {
        coinText.text = newAmount.ToString();
    }

    private void ToggleInventory(List<ItemSO> items)
    {
        inventoryWindow.SetActive(!inventoryWindow.activeSelf);
        if (inventoryWindow.activeSelf) RefreshInventoryUI(items);
    }

    private void RefreshInventoryUI(List<ItemSO> items)
    {
        int lastIndex = 0;
        for (int i = 0; i < items.Count; i++)
        {
            inventorySlotList[i].SetInventorySlotItem(items[i]);
            lastIndex = i;
        }
        for (int i = lastIndex + 1; i < inventorySlotList.Count; i++)
        {
            inventorySlotList[i].ClearSlot();
        }
    }
}
