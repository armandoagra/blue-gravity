using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Instance;

    [Header("Equipment")]
    [SerializeField] private Equipment hood; // Splitting up so it is organized at inspector
    [SerializeField] private Equipment torso, shoulder, elbow, wrist, pelvis, leg, boot;

    [Header("Items")]
    [SerializeField] private List<ItemSO> items;
    [SerializeField] private int maxItems;

    public static Action<int> OnGoldChanged;

    [field:SerializeField] public int gold { get; private set; }

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
        AddGold(0);
    }

    public void AddGold(int amount)
    {
        gold += amount;
        OnGoldChanged?.Invoke(gold);
    }

    public void SpendGold(int amount)
    {
        if (amount <= gold)
        {
            gold -= amount;
        }
        OnGoldChanged?.Invoke(gold);
    }

    [ContextMenu("Use Gold")]
    public void UseGold()
    {
        SpendGold(10);
    }

    public bool HasOpenSlot()
    {
        return items.Count < maxItems;
    }

    private void AddItem(ItemSO itemSO)
    {
        // No need for additional checks
        items.Add(itemSO);
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


}
