using Interactables;
using UnityEngine;
using UnityEngine.AI;

namespace Player
{
	public class Locomotion : MonoBehaviour
	{
		private CharacterStats stats;
		public Transform currentTarget;
		private NavMeshAgent agent;
		[SerializeField] private float rotationSpeed = 8f;
		private void Start()
		{
			stats = GetComponent<CharacterStats>();
			if (stats == null) Debug.LogError("Camera not found");
			agent = GetComponent<NavMeshAgent>();
			if (agent == null) Debug.LogError("Nav mesh agent not found");

		}

		private void Update()
		{
			if (currentTarget == null) return;
			Move(currentTarget.transform.position);
			RotateTowardsTarget();
		}

		private void RotateTowardsTarget()
		{
			Vector3 direction = currentTarget.position - transform.position;
			direction.Normalize();
			Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0,direction.z));
			transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime* rotationSpeed);
		}


		public void Move(Vector3 targetLocation)
		{
			if (!stats.CanMove) return;
			agent.SetDestination(targetLocation);
		}

		public void SetTarget(Interactable target)
		{
			if (target == null)
			{
				currentTarget = null;
				agent.stoppingDistance = 0f;
				agent.updateRotation = true;
			}
			else
			{
				currentTarget = target.transform;
				agent.updateRotation = false;
				agent.stoppingDistance = target.GetInteractionRadius()*0.8f;
			}
			
		}
		
		
	}
}