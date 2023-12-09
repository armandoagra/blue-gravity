using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : NPC, IInteractable
{
    // Decided to make a prefab out of the whole canvas 
    // Canvases don't need any extra set up after the first configuration
    // + Unity handles multiple canvases pretty well too!
    [SerializeField] private GameObject shopWindowPrefab;
    [SerializeField] private GameObject itemBoxPrefab;
    [SerializeField] private List<ItemSO> itemList;
    private GameObject shopWindow;

    public void Interact()
    {
        shopWindow = Instantiate(shopWindowPrefab);
        FillShopItems();
    }

    private void FillShopItems()
    {
        foreach (ItemSO itemSO in itemList)
        {
            GameObject go = Instantiate(itemBoxPrefab, shopWindow.transform.GetChild(0)); // Spawns inside the Background object
            ItemUI itemUI = go.GetComponent<ItemUI>();
            itemUI.SetUpItemUI(itemSO);
        }
    }

}
