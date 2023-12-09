using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI description, cost;
    [SerializeField] private Button buyItemButton;

    public void SetUpItemUI(ItemSO itemSO)
    {
        icon.sprite = itemSO.icon;
        description.text = itemSO.description;
        cost.text = itemSO.buyValue.ToString();
        buyItemButton.onClick.AddListener(() => BuyItemButton(itemSO));
    }

    public void BuyItemButton(ItemSO itemSO)
    {
        if (PlayerInventory.Instance.BuyItem(itemSO))
        {
            buyItemButton.interactable = false;
        }
    }
}
