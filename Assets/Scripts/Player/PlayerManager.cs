using System;
using Interactables;
using UnityEngine;

namespace Player
{
	public class PlayerManager : MonoBehaviour
	{
		private InputHandler inputHandler;
		private Camera playerCamera;
		[SerializeField] private LayerMask movementMask;
		private Locomotion locomotion;
		public static PlayerManager Instance { get; private set; }
		private Interactable currentFocus;

		private void Awake()
		{
			if (Instance == null) Instance = this;
			else Destroy(gameObject);
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
			if (inputHandler.LeftClick)
			{
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