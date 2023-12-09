using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Equipment", menuName = "Create New Equipment")]
public class EquipmentSO : ItemSO
{
    [field: SerializeField] public EquipmentType type { get; private set; }

    //Extra stuff
    [field: SerializeField] public int level {get; private set;}
    [field: SerializeField] public float strength { get; private set; }
    [field: SerializeField] public float dexterity { get; private set; }
    [field: SerializeField] public float defense { get; private set; }
    [field: SerializeField] public float health { get; private set; }

    public enum EquipmentType
    {
        HOOD,
        TORSO,
        PELVIS
    }
}
