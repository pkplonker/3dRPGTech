using System;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;

namespace InventorySystem
{
    public class DragDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler,IEndDragHandler, IDragHandler
    {
        private Canvas canvas;
        private RectTransform rectTransform;
        private CanvasGroup canvasGroup;
        private Vector3 startPosition;
        private Transform startParent;
        public InventorySlotUI inventorySlotUI { get; private set; }
        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            canvas = transform.root.root.GetComponent<Canvas>();
            canvasGroup = GetComponent<CanvasGroup>();
            Debug.Log("test");
            inventorySlotUI= GetComponentInParent<DropReceiver>().GetComponentInChildren<InventorySlotUI>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log("Pointer down");
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            Debug.Log("Begin drag");

            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0.6f;
            startPosition = transform.position;
            startParent = transform.parent;
            transform.SetParent(canvas.transform);

        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("end drag");
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;
            transform.position= startPosition;
            transform.SetParent(startParent);

        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log("ondrag");
            rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
        }


    }
}
