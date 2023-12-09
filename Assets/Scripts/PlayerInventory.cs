using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;

    [Header("Equipment")]
    [SerializeField] private Equipment hood; // Splitting up so it is organized at inspector
    [SerializeField] private Equipment torso, pelvis;

    [Header("Items")]
    [SerializeField] private List<ItemSO> items;
    [SerializeField] private int maxItems;

    public static Action<int> OnGoldChanged;
    public static Action<List<ItemSO>> OnInventoryChanged;

    [field: SerializeField] public int gold { get; private set; }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        items = new List<ItemSO>(maxItems);
        AddGold(0);
    }

    public void AddGold(int amount)
    {
        gold += amount;
        OnGoldChanged?.Invoke(gold);
    }

    public void SpendGold(int amount)
    {
        AudioManager.Instance.PlaySFX(AudioManager.Instance.spendCoinsSFX);
        if (amount <= gold)
        {
            gold -= amount;
        }
        OnGoldChanged?.Invoke(gold);
    }

    public bool HasOpenSlot()
    {
        return items.Count < maxItems;
    }

    private void AddItem(ItemSO itemSO)
    {
        // No need for additional checks
        items.Add(itemSO);
        OnInventoryChanged?.Invoke(items);
    }

    public void LootItem(ItemSO itemSO)
    {
        if (!HasOpenSlot()) return;
        AddItem(itemSO);
    }

    public bool BuyItem(ItemSO itemSO) // returns true if item was bought
    {
        if (!HasOpenSlot()) return false;
        if (itemSO.buyValue > gold) return false;

        SpendGold(itemSO.buyValue);
        AddItem(itemSO);
        return true;
    }

    public List<ItemSO> GetInventoryItems()
    {
        return items;
    }

    public void EquipItem(EquipmentSO equipmentSO)
    {
        // Don't like this approach but I'm running out of time :)
        EquipmentSO temp;
        switch (equipmentSO.type)
        {
            case EquipmentSO.EquipmentType.HOOD:
                temp = hood.GetEquipmentSO();
                hood.SetEquipmentSO(equipmentSO);
                ReplaceItem(equipmentSO, temp);
                break;
            case EquipmentSO.EquipmentType.TORSO:
                temp = torso.GetEquipmentSO();
                torso.SetEquipmentSO(equipmentSO);
                ReplaceItem(equipmentSO, temp);
                break;
            case EquipmentSO.EquipmentType.PELVIS:
                temp = pelvis.GetEquipmentSO();
                pelvis.SetEquipmentSO(equipmentSO);
                ReplaceItem(equipmentSO, temp);
                break;
        }
    }

    private void ReplaceItem(ItemSO oldItem, ItemSO newItem)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == oldItem)
            {
                items[i] = newItem;
                break;
            }
        }
        OnInventoryChanged?.Invoke(items);
    }


}
