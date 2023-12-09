using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;
    private void OnEnable()
    {
        PlayerInventory.OnGoldChanged += UpdateGoldUI;
    }

    private void OnDisable()
    {
        PlayerInventory.OnGoldChanged -= UpdateGoldUI;
    }

    private void UpdateGoldUI(int newAmount)
    {
        coinText.text = newAmount.ToString();
    }

}
