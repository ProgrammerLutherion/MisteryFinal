using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropArea : MonoBehaviour
{
	public List<DropCondition> DropConditions = new List<DropCondition>();
	public event Action<DraggableComponent> OnDropHandler;
	[SerializeField] private Player player;

    private Player FindPlayer()
    {
		foreach (GameObject gameObject in DontDestroyOnLoadManager._ddolObjects)
		{
			if (gameObject.tag == "Player")
			{
				return gameObject.GetComponent<Player>();
			}
		}
		return null;
	}

    public bool Accepts(DraggableComponent draggable)
	{	
		var slotEquipmentPart = this.GetComponentInParent<EquipmentSlot>().isPart;	
		return DropConditions[0].Check(draggable,slotEquipmentPart);
	}

	public void Drop(DraggableComponent draggable,ItemObject item)
	{
		this.transform.GetChild(0).GetComponent<DraggableComponent>().item = item;
		this.transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 250, 255, 255);
		this.transform.GetChild(0).GetComponent<Image>().sprite = item.itemImage;
		if (player == null)
        {
			player = FindPlayer();
			player.ChangeStats(item);
		}
        else
        {
			player.ChangeStats(item);
		}		
		draggable.item = null;
		OnDropHandler?.Invoke(draggable);
	}
}
