using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/HelmetItem")]
public class HelmetItem : ItemObject
{
    private void Awake()
    {
        type = ItemType.Armor;
        equipmenttype = EquipmentPart.Helmet;
    }
}
