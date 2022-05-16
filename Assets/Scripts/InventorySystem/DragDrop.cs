using System;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InventorySystem
{
	public class DragDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
	{
		private Canvas canvas;
		private RectTransform rectTransform;
		private CanvasGroup canvasGroup;
		private Vector3 startPosition;
		private Transform startParent;
		public InventorySlotUI inventorySlotUI { get; private set; }
		private Transform objTransform;

		private void Awake()
		{
			objTransform = transform;
			rectTransform = GetComponent<RectTransform>();
			canvas = objTransform.root.root.GetComponent<Canvas>();
			canvasGroup = GetComponent<CanvasGroup>();
			inventorySlotUI = GetComponentInParent<DropReceiver>().GetComponentInChildren<InventorySlotUI>();
		}


		public void OnBeginDrag(PointerEventData eventData)
		{
			if (eventData.button != PointerEventData.InputButton.Left) return;
			canvasGroup.blocksRaycasts = false;
			canvasGroup.alpha = 0.6f;
			startPosition = objTransform.position;
			startParent = objTransform.parent;
			transform.SetParent(canvas.transform);
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			canvasGroup.blocksRaycasts = true;
			canvasGroup.alpha = 1f;
			objTransform.position = startPosition;
			objTransform.SetParent(startParent);
		}

		public void OnDrag(PointerEventData eventData)
		{
			rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
		}
	}
}