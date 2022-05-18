using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCanvas : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    private void Start()
    {
        inventory.InitializeInventory();
        DontDestroyOnLoadManager.DontDestroyOnLoad(this.gameObject);     
        this.gameObject.SetActive(false);
    }
}
