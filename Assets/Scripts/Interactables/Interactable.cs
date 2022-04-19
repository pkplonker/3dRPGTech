using Player;
using UnityEngine;

namespace Interactables
{
	public abstract class Interactable : MonoBehaviour
	{
		[SerializeField] protected float interactionRadius = 2f;

		[SerializeField] protected Transform interactionTransform;
		protected Transform interactor;
		private float radiusMagnitude;
		private bool hasInteracted = false;
		private void Start()
		{
			radiusMagnitude = interactionRadius * interactionRadius;
			if (interactionTransform == null) interactionTransform = transform;
		}

		private void Update()
		{
			if (interactor == null|| hasInteracted) return;
			if (Vector3.SqrMagnitude(interactionTransform.position- interactor.position)<=radiusMagnitude )
			{
				Interact(interactor.GetComponent<Inventory>());
			}
		}

		protected virtual void Interact(Inventory inventory)
		{
			hasInteracted = true;
			Debug.Log("has interacted");
		}

		public void OnFocused(Transform interactor)
		{
			this.interactor = interactor;
			hasInteracted = false;
		}
	
		public float GetInteractionRadius() => interactionRadius;
	}
}