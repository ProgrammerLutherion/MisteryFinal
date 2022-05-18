using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemObject> items = new List<ItemObject>();

    [SerializeField] public GameObject InventoryItems;


    public void InitializeInventory()
    {
        for(int i = 0;i < InventoryItems.transform.childCount; i++)
        {
            items.Add(null);
        }
    }
}
