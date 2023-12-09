using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Item", menuName ="Create New Item")]
public class ItemSO : ScriptableObject
{
    [field: SerializeField] public Sprite icon { get; private set; }
    [field: SerializeField] [field: TextArea(3, 8)] public string description { get; private set; }
    [field: SerializeField] public int buyValue { get; private set; }
    [field: SerializeField] public int sellValue { get; private set; }
}
