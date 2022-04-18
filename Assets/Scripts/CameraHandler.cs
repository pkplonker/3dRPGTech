using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using SO;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    public static CameraHandler instance;
    [HideInInspector] public Camera playerCamera { get; private set; }
    private InputHandler inputHandler;

    [Header("General")]
    [SerializeField] private Transform target;
    [SerializeField] private float pitch;
    [SerializeField] private PlayerCustomSettings playerCustomSettings;    
    [Header("Zoom")]
    [SerializeField] private Vector3 cameraOffset;
    [SerializeField] private float cameraZoomMin;
    [SerializeField] private float cameraZoomMax;

    private float currentZoomLevel;
    [Header("Movement")]
    private float currentYaw;
    
    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        playerCamera = GetComponentInChildren<Camera>();
        if(!playerCamera) Debug.LogWarning("No camera");
        inputHandler = PlayerManager.Instance.GetComponent<InputHandler>();
        if(!inputHandler) Debug.LogWarning("No input handler");

    }

    private void Update()
    {
        ChangeScroll(inputHandler.mouseScrollVector);
        HandleCameraPan();
    }

    private void HandleCameraPan()
    {
        if (inputHandler.middleClick)
        {
            currentYaw -= inputHandler.cameraMove * playerCustomSettings.cameraRotationSpeed * Time.deltaTime;
        }
    }


    private void ChangeScroll(float value)
    {
        if (value > 0) currentZoomLevel -= playerCustomSettings.cameraZoomSpeed;
        else if (value<0)currentZoomLevel+=playerCustomSettings.cameraZoomSpeed;
        if (currentZoomLevel > cameraZoomMax) currentZoomLevel = cameraZoomMax;
        if (currentZoomLevel < cameraZoomMin) currentZoomLevel = cameraZoomMin;
    }


   

    private void LateUpdate()
    {
        transform.position = target.position - cameraOffset * currentZoomLevel ;
        transform.LookAt(target.position+ Vector3.up*pitch);
        transform.RotateAround(target.position, Vector3.up, currentYaw);

    }
}
