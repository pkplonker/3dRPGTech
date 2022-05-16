using Save;
using UnityEngine;

namespace DebugScripts
{
	public class DebugPanel : MonoBehaviour
	{
		[SerializeField] private GameObject panel;

		private void Start()
		{
			SetPanelInactive();
		}

		private void SetPanelInactive()
		{
			panel.SetActive(false);
		}

		private void Update()
		{
			if (!Input.GetKeyDown(KeyCode.Escape)) return;
			if (panel.activeSelf)
			{
				SetPanelInactive();
			}
			else
			{
				SetPanelActive();
			}
		}

		private void SetPanelActive()
		{
			panel.SetActive(true);
		}

		public void SaveGame()
		{
			SavingSystem.instance.SaveGame();
		}

		public void NewGame()
		{
			SavingSystem.instance.ClearSave();
		}

		public void LoadGame()
		{
			SavingSystem.instance.LoadGame();
		}

		public void ClosePanel()
		{
			SetPanelInactive();
		}
	}
}