using Interactables;
using Save;
using UnityEngine;
using UnityEngine.AI;

namespace Player
{
	public class Locomotion : MonoBehaviour, ISaveLoad
	{
		private CharacterStats stats;
		public Transform currentTarget;
		private NavMeshAgent agent;
		//private RunManager runManager;
		[SerializeField] private float rotationSpeed = 8f;
		[SerializeField] private float walkSpeed = 3.5f;
		[SerializeField] private float runSpeed = 7f;
		private Vector3 lastPosition;
		public float currentSpeed { get; private set; }

		
		public float currentMovementSpeed { get; private set; }

		private void Awake()
		{
			stats = GetComponent<CharacterStats>();
			if (stats == null) Debug.LogError("Stats not found");
			agent = GetComponent<NavMeshAgent>();
			if (agent == null) Debug.LogError("Nav mesh agent not found");
			//runManager = GetComponent<RunManager>();
			//if (runManager == null) Debug.LogError("runManager not found");

		}

		private void Start()
		{
			currentSpeed = walkSpeed;
			lastPosition = transform.position;
			agent.speed = walkSpeed;
		}

		private void Update()
		{
			UpdateCurrentSpeed();
			agent.speed = currentSpeed;
			if (currentTarget == null)
			{
				SetAutomaticRotation();
				return;
			}

			Move(currentTarget.transform.position);
			RotateTowardsTarget();
		}

		

		private void UpdateCurrentSpeed()
		{
			currentMovementSpeed = Mathf.Lerp(currentMovementSpeed,
				(transform.position - lastPosition).magnitude / Time.deltaTime, 0.75f);
			lastPosition = transform.position;
		}

		private void RotateTowardsTarget()
		{
			Vector3 direction = currentTarget.position - transform.position;
			direction.Normalize();
			Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
			transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
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
				SetAutomaticRotation();
			}
			else
			{
				currentTarget = target.transform;
				SetManualRotation(target);
			}
		}

		private void SetAutomaticRotation()
		{
			agent.stoppingDistance = 0f;
			agent.updateRotation = true;
		}

		private void SetManualRotation(Interactable target)
		{
			agent.updateRotation = false;
			agent.stoppingDistance = target.GetInteractionRadius() * 0.8f;
		}

		public void SetRun(bool isRunning)
		{
			currentSpeed = isRunning ? runSpeed : walkSpeed;
			
		}

		#region SaveLoad

		
		private void UpdateTransform(object data)
		{
			SerializableVector position = (SerializableVector) data;
			transform.position = SerializableVector.GetVector(position);
			agent.SetDestination(transform.position);
		}

		#endregion

		public void LoadState(object data)
		{
			UpdateTransform(data);
		}

		public object SaveState()
		{
			return new SerializableVector(transform.position);
		}
		
		
	}
}