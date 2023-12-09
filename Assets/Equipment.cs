using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    private SpriteRenderer equipmentSpriteRenderer;
    private EquipmentSO playerEquipmentSO;

    public void SetEquipmentSprite(Sprite sprite)
    {
        equipmentSpriteRenderer.sprite = sprite; // Not rescaling, assuming we're using proper sprites
    }

    public EquipmentSO GetEquipmentSO()
    {
        return playerEquipmentSO;
    }
}
