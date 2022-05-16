using System;
using Interactables;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Player
{
	public class PlayerWorldClickController : MonoBehaviour
	{
		private InputHandler inputHandler;
		private Camera playerCamera;
		[SerializeField] private LayerMask movementMask;
		private Locomotion locomotion;
		private Interactable currentFocus;
		private void Awake()
		{
			inputHandler = GetComponent<InputHandler>();
			if (inputHandler == null) Debug.LogError("Input Handler not found");
			locomotion = GetComponent<Locomotion>();
			if (locomotion == null) Debug.LogError("Locomotion not found");
			playerCamera = CameraHandler.instance.playerCamera;
			CameraHandler.instance.Init(this);
			if (playerCamera == null) Debug.LogError("Camera not found");
			
		}

		private void Update()
		{
			if (!inputHandler.LeftClick || EventSystem.current.IsPointerOverGameObject()) return;
			Ray ray = playerCamera.ScreenPointToRay(inputHandler.MousePosition);
			if (!Physics.Raycast(ray, out RaycastHit hit, 100, movementMask)) return;
			Interactable interactable = hit.collider.GetComponent<Interactable>();
			if (interactable)
			{
				SetFocus(interactable);
				return;
			}

			Defocus();
			locomotion.Move(hit.point);
		}

		private void SetFocus(Interactable interactable)
		{
			Defocus();
			currentFocus = interactable;
			currentFocus.OnFocused(transform);
			UpdateTarget();
		}

		private void Defocus()
		{
			if (currentFocus == null) return;
			currentFocus.OnFocused(null);
			currentFocus = null;
			UpdateTarget();
		}

		private void UpdateTarget()
		{
			locomotion.SetTarget(currentFocus);

		}
	}
}