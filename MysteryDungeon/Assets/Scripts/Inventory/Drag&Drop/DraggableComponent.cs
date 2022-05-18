using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableComponent : MonoBehaviour, IInitializePotentialDragHandler, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	public event Action<PointerEventData> OnBeginDragHandler;
	public event Action<PointerEventData> OnDragHandler;
	public event Action<PointerEventData, bool> OnEndDragHandler;

	public bool FollowCursor { get; set; } = true;
	public Vector3 StartPosition;
	public bool CanDrag { get; set; } = true;

	private RectTransform rectTransform;
	private Canvas canvas;
	public ItemObject item;

	private void Awake()
	{
		rectTransform = GetComponent<RectTransform>();
		canvas = GetComponentInParent<Canvas>();
	}

	public void OnBeginDrag(PointerEventData eventData)
	{
		if (!CanDrag)
		{
			return;
		}

		OnBeginDragHandler?.Invoke(eventData);
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (!CanDrag)
		{
			return;
		}

		OnDragHandler?.Invoke(eventData);

		if (FollowCursor)
		{
			rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
		}
	}

	public void OnEndDrag(PointerEventData eventData)
	{
		if (!CanDrag)
		{
			return;
		}

		var results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventData, results);

		DropArea dropArea = null;

		foreach (var result in results)
		{
			dropArea = result.gameObject.GetComponent<DropArea>();

			if (dropArea != null)
			{
				break;
			}
		}

		if (dropArea != null)
		{
			if(item != null)
            {
				if (dropArea.Accepts(this))
				{
					this.gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 1);
					this.gameObject.GetComponent<Image>().sprite = null;					
					dropArea.Drop(this, item);					
					OnEndDragHandler?.Invoke(eventData, true);
					rectTransform.anchoredPosition = StartPosition;
					return;
				}
			}
            /*else if(dropArea.Accepts(this))
            {
				dropArea.Drop(this, item);
				OnEndDragHandler?.Invoke(eventData, true);
				rectTransform.anchoredPosition = StartPosition;
				return;
			}*/
		}
		
		rectTransform.anchoredPosition = StartPosition;
		OnEndDragHandler?.Invoke(eventData, false);
	}

	public void OnInitializePotentialDrag(PointerEventData eventData)
	{
		StartPosition = rectTransform.anchoredPosition;
	}
}
