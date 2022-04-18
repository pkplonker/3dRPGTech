using System;
using System.Collections;
using UnityEngine;

namespace Player
{
	public class RunManager : MonoBehaviour
	{
		public event Action<float> OnRunEnergyChanged;
		private float currentRunEnergy;
		[SerializeField] private float maxRunEnergy;
		[SerializeField] private float refreshRate = 0.3f;
		[SerializeField] float currentDrainRate = 1f;
		[SerializeField] float currentRegenRate = 1f;
		private Locomotion locomotion;
		public bool isRunning { get; private set; }

		private void Start()
		{
			currentRunEnergy = maxRunEnergy;
			OnRunEnergyChanged?.Invoke(currentRunEnergy);
			StartCoroutine(RunningCor());
			locomotion = GetComponent<Locomotion>();
			if(locomotion==null) Debug.LogError("missing locomotion");
		}

		public bool HasRunEnergy()
		{
			return currentRunEnergy > 0 + Time.deltaTime;
		}

	
		public void StartRunning()
		{
			isRunning = true;

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
			if(locomotion.currentMovementSpeed<=0.01f) StopRunning();
			
			StartCoroutine(RunningCor());
		}

		public void StopRunning()
		{
			isRunning = false;
		}

		public void RecoverRun(float amount)
		{
			currentRunEnergy += amount;
			if (currentRunEnergy > maxRunEnergy) currentRunEnergy = maxRunEnergy;
		}
	}
}