using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/WeaponItem")]
public class WeaponItem : ItemObject
{
    private void Awake()
    {
        type = ItemType.Weapon;
        equipmenttype = EquipmentPart.Weapon;
    }
}
