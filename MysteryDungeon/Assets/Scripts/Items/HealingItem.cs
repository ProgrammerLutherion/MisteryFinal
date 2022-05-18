using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/HealingItem")]
public class HealingItem : ItemObject
{
    [SerializeField] private int RestoreHealthValue;
    private void Awake()
    {
        type = ItemType.Potion;
    }
}
