using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player : MonoBehaviour
{
    [SerializeField] protected int Health = 0, AttackDamage = 0, Armor = 0, money = 50;
    [SerializeField] protected bool canMove = true;
    [SerializeField] public Inventory inventory;
    [SerializeField] protected EquipedItems equipedItems;

    public bool CanMove => canMove;
    public int Money => money;
    public IInteractable Interactable { get; set; }
    
    public int getHealth()
    {
        return gameObject.GetComponent<Mainchar_Movement>().Health;
    }
    public int getAttackDamage()
    {
        return gameObject.GetComponent<Mainchar_Movement>().AttackDamage;
    }
    public int getArmor()
    {
        return gameObject.GetComponent<Mainchar_Movement>().Armor;
    }

    public void takeDamage(int damage)
    {
        if (gameObject.GetComponent<Mainchar_Movement>().Health - damage <= 0)
        {
            gameObject.GetComponent<Mainchar_Movement>().Health = 0;
            FindObjectOfType<AudioManager>().Play("Hit");
        }        
        else
        {
            gameObject.GetComponent<Mainchar_Movement>().Health -= damage;
            FindObjectOfType<AudioManager>().Play("Hit");
        }
            
    }

    [SerializeField] private DialogueUI dialogueUI;
    [SerializeField] private OpenShop openShop;
    [SerializeField] protected GameObject panel;

    public DialogueUI DialogueUI => dialogueUI;

    public OpenShop OpenShop => openShop;


    private void Awake()
    {
        DontDestroyOnLoad(this);      
    }

    public virtual void openInventory()
    {
        if (Input.GetKeyDown(KeyCode.I) && checkOpenUI())
        {
            panel.SetActive(!panel.activeSelf);
            canMove = !canMove;
        }
    }

    public virtual void startDialogue()
    {
        if (Input.GetKeyDown(KeyCode.E) && checkOpenUI())
        {
            if (Interactable != null)
            {
                Interactable.Interact(this);
            }
        }
    }

    public virtual void SetDialogueUI(DialogueUI dialogue)
    {
        dialogueUI = dialogue;
    }

    public bool checkOpenUI()
    {
        if(dialogueUI.IsOpen == false && openShop.IsOpen == false)
        {
            return true;
        }
        return false;
    }

    public void subtractMoney(int amount)
    {
        money -= amount;
    }

    public void AddItemToInventory(ItemObject item)
    {
        for(int i = 0;i < inventory.InventoryItems.transform.childCount;i++)
        {
            if(inventory.items[i] == null)
            {
                inventory.items[i] = item;
                inventory.InventoryItems.transform.GetChild(i).GetChild(0).GetComponent<DraggableComponent>().item = item;
                inventory.InventoryItems.transform.GetChild(i).GetChild(0).GetComponent<Image>().sprite = item.itemImage;
                inventory.InventoryItems.transform.GetChild(i).GetChild(0).GetComponent<Image>().color = new Color(255,255,255,255);
                return;
            }
        }
        
    }

    public void ChangeStats(ItemObject item)
    {
        switch (item.equipmenttype)
        {
            case EquipmentPart.ChestPlate:
            case EquipmentPart.LegArmor:
                gameObject.GetComponent<Mainchar_Movement>().Health += item.value;
                break;
            case EquipmentPart.Helmet:
            case EquipmentPart.Bracelet:
            case EquipmentPart.Boots:
                gameObject.GetComponent<Mainchar_Movement>().Armor += item.value;
                break;
            case EquipmentPart.Weapon:
                gameObject.GetComponent<Mainchar_Movement>().AttackDamage += item.value;
                break;
        }
    }
}


