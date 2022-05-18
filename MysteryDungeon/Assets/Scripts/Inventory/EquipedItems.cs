using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipedItems : MonoBehaviour
{
	[SerializeField] private Transform equipedItemsContainer;
	private void Start()
	{
		InitializeItems();
	}

	private void InitializeItems()
	{
		var slots = equipedItemsContainer.GetComponentsInChildren<EquipmentSlot>();
		foreach (var slot in slots)
		{
			var item = slot.GetComponentInChildren<DraggableComponent>();
			if (item != null)
			{
				slot.Initialize(item);
			}
		}

	}
}
