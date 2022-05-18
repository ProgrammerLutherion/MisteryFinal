using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public enum ItemType
{
    Potion,
    Armor,
    Weapon,
    Accesory
}

public enum EquipmentPart
{
    Helmet,
    ChestPlate,
    Bracelet,
    Boots,
    LegArmor,
    Weapon
}

public abstract class ItemObject : ScriptableObject
{
    public Sprite itemImage;
    public int price,value;
    public ItemType type;
    public EquipmentPart equipmenttype;
    [TextArea(15,20)]public string description;
}
