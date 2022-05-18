using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopList : MonoBehaviour
{
    [SerializeField] private ItemObject[] items;
    [SerializeField] private GameObject itemBox;
    [SerializeField] private GameObject itemList;
    [SerializeField] private DialogueObject noTienesDinero,graciasPorComprar;

    [SerializeField] private DialogueUI dialogueUI;
    [SerializeField] private Player player;

    [SerializeField] private OpenShop openShop;
    private void Start()   
    {
        if (items == null) return;
        if (items.Length == 0) return;

        foreach (GameObject gameObject in DontDestroyOnLoadManager._ddolObjects)
        {
            if (gameObject.tag == "Player")
            {
                player = gameObject.GetComponent<Player>();
            }
            if (gameObject.tag == "DialogueCanvas")
            {
                dialogueUI = gameObject.GetComponent<DialogueUI>();
            }
            if (gameObject.tag == "ShopCanvas")
            {
                openShop = gameObject.GetComponent<OpenShop>();
            }
        }

        foreach (ItemObject item in items)
        {
            GameObject newbox = Instantiate(itemBox);
            newbox.transform.SetParent(itemList.transform);
            newbox.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            newbox.GetComponent<RectTransform>().anchorMin = new Vector2(0,(float)0.5);
            newbox.GetComponent<RectTransform>().anchorMax = new Vector2(1, (float)0.5);
            newbox.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>().sprite = item.itemImage;
            newbox.transform.GetChild(0).transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = item.price.ToString();

            newbox.transform.GetChild(1).GetComponent<Button>().onClick.AddListener(() => configButton(item));
        }
    }

    private void configButton(ItemObject item)
    {
        if(player.Money >= item.price)
        {
            dialogueUI.ShowDialogue(graciasPorComprar);
            player.subtractMoney(item.price);
            player.AddItemToInventory(item);
            openShop.CloseShop();
        }
        else
        {
            dialogueUI.ShowDialogue(noTienesDinero);
            openShop.CloseShop();
        }
    }

}
