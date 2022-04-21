using Interactables;
using Save;
using SO;
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
		private Vector3 lastPosition;
		[SerializeField] private float walkSpeed = 3.5f;
		[SerializeField] private float runSpeed = 7f;
		private RunManager runManager;
		public float currentMovementSpeed { get; private set; }
		private bool isRunning;

		private void Start()
		{
			stats = GetComponent<CharacterStats>();
			if (stats == null) Debug.LogError("Camera not found");
			agent = GetComponent<NavMeshAgent>();
			if (agent == null) Debug.LogError("Nav mesh agent not found");
			runManager = GetComponent<RunManager>();
			if (runManager == null) Debug.LogError("runManager not found");

			lastPosition = transform.position;
			agent.speed = walkSpeed;
		}

		private void Update()
		{
			UpdateCurrentSpeed();
			HandleRun();
			if (currentTarget == null)
			{
				SetAutomaticRotation();
				return;
			}

			Move(currentTarget.transform.position);
			RotateTowardsTarget();
		}

		private void HandleRun()
		{
			agent.speed = runManager.isRunning ? runSpeed : walkSpeed;
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

		public void SetRun(bool run)
		{
			if (runManager.HasRunEnergy() && run) runManager.StartRunning();
			else runManager.StopRunning();
		}
/*
		#region SaveLoad

		public void LoadState(GameData gameData)
		{
			UpdateTransform(gameData);
		}

		public  void SaveState(GameData gameData)
		{
			gameData.playerPosition = new SerializableVector(transform.position);
		}

		private void UpdateTransform(GameData gameData)
		{
			transform.position = gameData.playerPosition.GetVector();

			agent.SetDestination(transform.position);
		}

		#endregion
		*/
	}
}