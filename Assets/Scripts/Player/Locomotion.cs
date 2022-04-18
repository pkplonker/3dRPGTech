using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

namespace Player
{
	public class Locomotion : MonoBehaviour
	{
		private InputHandler inputHandler;
		private CharacterStats stats;
		private Camera camera;
		[SerializeField] private LayerMask movementMask;
		private NavMeshAgent agent;
		private void Start()
		{
			inputHandler = GetComponent<InputHandler>();
			if (inputHandler == null) Debug.LogError("Input Handler not found");
			camera = CameraHandler.instance.playerCamera;
			if (camera == null) Debug.LogError("Camera not found");
			stats = GetComponent<CharacterStats>();
			if (stats == null) Debug.LogError("Camera not found");
			agent = GetComponent<NavMeshAgent>();
			if (agent == null) Debug.LogError("Nav mesh agent not found");

		}

		private void Update()
		{
			if (inputHandler.leftClick )
			{
				Ray ray = camera.ScreenPointToRay(inputHandler.mousePosition);
				if (Physics.Raycast(ray, out RaycastHit hit,100, movementMask))
				{
					Interactable interactable = hit.collider.GetComponent<Interactable>();
					if (interactable)
					{
						Interact(interactable);
						return;
					}

					Move(hit.point);
					return;
				}
			}
		}

		private void Move(Vector3 targetLocation)
		{
			if (!stats.CanMove) return;
			agent.SetDestination(targetLocation);
		}

		private void  Interact(Interactable interactable)
		{
			
		}
	}
}