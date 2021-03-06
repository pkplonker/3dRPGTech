using System;
using System.Collections;
using Save;
using UnityEngine;

namespace Player
{
	public class RunManager : MonoBehaviour, ISaveLoad
	{
		public event Action<float> OnRunEnergyChanged;
		private float currentRunEnergy;
		[SerializeField] private float maxRunEnergy;
		[SerializeField] private float refreshRate = 0.3f;
		[SerializeField] float currentDrainRate = 1f;
		[SerializeField] float currentRegenRate = 1f;
		private Locomotion locomotion;
		private bool isRunning;
		private InputHandler inputHandler;
		private void Awake()
		{
			inputHandler = GetComponent<InputHandler>();
			if (inputHandler == null) Debug.LogError("Input Handler not found");
			locomotion = GetComponent<Locomotion>();
			if (locomotion == null) Debug.LogError("missing locomotion");
		}

		private void Start()
		{
			currentRunEnergy = maxRunEnergy;
			OnRunEnergyChanged?.Invoke(currentRunEnergy);
			StartCoroutine(RunningCor());
		
		}

		private void OnEnable()
		{
			locomotion.OnSpeedChanged += CharacterSpeedChanged;
		}


		private void OnDisable()
		{
			locomotion.OnSpeedChanged -= CharacterSpeedChanged;
		}

		private void Update()
		{
			RequestRun(inputHandler.Shift);
		}

		private void CharacterSpeedChanged(float speed)
		{
			if (speed <= 0.01f) SetRunning(false);
		}

		private bool HasRunEnergy()
		{
			return currentRunEnergy > 0 + Time.deltaTime;
		}


		IEnumerator RunningCor()
		{
			yield return new WaitForSeconds(refreshRate);
			if (isRunning) currentRunEnergy -= currentDrainRate * Time.deltaTime;
			else currentRunEnergy += currentRegenRate * Time.deltaTime;
			if (currentRunEnergy > maxRunEnergy) currentRunEnergy = maxRunEnergy;
			if (currentRunEnergy <= 0)
			{
				isRunning = false;
				currentRunEnergy = 0;
			}


			StartCoroutine(RunningCor());
		}


		private void SetRunning(bool isRunning)
		{
			this.isRunning = isRunning;
			locomotion.SetRun(isRunning);
		}

		public void RecoverRun(float amount)
		{
			currentRunEnergy += amount;
			if (currentRunEnergy > maxRunEnergy) currentRunEnergy = maxRunEnergy;
		}

		public void LoadState(object data)
		{
			OnRunEnergyChanged?.Invoke(currentRunEnergy);
		}

		public void RequestRun(bool isRequested)
		{
			if (HasRunEnergy() && isRequested) SetRunning(true);
			else SetRunning(false);
		}

		public object SaveState()
		{
			return new SaveData()
			{
				currentRunEnergy = currentRunEnergy,
				maxRunEnergy = maxRunEnergy
			};
		}

		[Serializable]
		private struct SaveData
		{
			public float currentRunEnergy;
			public float maxRunEnergy;
		}
	}
}