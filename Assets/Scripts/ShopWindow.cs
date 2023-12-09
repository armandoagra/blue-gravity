using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWindow : MonoBehaviour
{

    public static Action<bool> OnWindowOpened;

    private void Start()
    {
        OnWindowOpened?.Invoke(true);
    }

    public void CloseShop()
    {
        OnWindowOpened?.Invoke(false);
        Destroy(gameObject);
    }
}
