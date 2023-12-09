using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    [SerializeField] private SpriteRenderer equipmentSpriteRenderer;
    [SerializeField] private EquipmentSO playerEquipmentSO;

    private void Awake()
    {
        equipmentSpriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetEquipmentSprite(Sprite sprite)
    {
        equipmentSpriteRenderer.sprite = sprite;
    }

    public EquipmentSO GetEquipmentSO()
    {
        return playerEquipmentSO;
    }

    public void SetEquipmentSO(EquipmentSO equipmentSO)
    {
        playerEquipmentSO = equipmentSO;
        equipmentSpriteRenderer.sprite = playerEquipmentSO.modelSprite;
    }
}
