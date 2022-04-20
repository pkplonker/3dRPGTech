using System;
using System.Collections;
using System.Collections.Generic;
using Save;
using UnityEngine;

public class DebugPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    private void Start()
    {
        
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
        SavingSystem.instance.NewGame();

    }

    public void LoadGame()
    {
        SavingSystem.instance.LoadGame();

    }
}
