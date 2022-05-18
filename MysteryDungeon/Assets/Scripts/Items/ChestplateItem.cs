using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/ChestplateItem")]
public class ChestplateItem : ItemObject
{
    private void Awake()
    {
        type = ItemType.Armor;
        equipmenttype = EquipmentPart.ChestPlate;
    }
}
