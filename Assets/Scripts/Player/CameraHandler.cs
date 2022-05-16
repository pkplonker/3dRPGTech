using SO;
using UnityEngine;

namespace Player
{
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
        private float currentYaw;
        private Vector3 currentTargetPosition;
    
        private void Awake()
        {
            if (instance == null) instance = this;
            else Destroy(gameObject);
            playerCamera = GetComponentInChildren<Camera>();
            if(!playerCamera) Debug.LogWarning("No camera");
            currentZoomLevel = cameraZoomMax - cameraZoomMin / 2;

        }

        public void Init(PlayerWorldClickController playerManager)
        {
            if(playerManager==null) Debug.LogError("Player manager cannot be null");
            inputHandler = playerManager.GetComponent<InputHandler>();
            if(!inputHandler) Debug.LogWarning("No input handler");
        }

        private void Update()
        {
            ChangeScroll(inputHandler.MouseScrollVector);
            HandleCameraPan();
        }

        private void HandleCameraPan()
        {
            if (inputHandler.MiddleClick)
            {
                currentYaw += inputHandler.CameraMove * playerCustomSettings.cameraRotationSpeed * Time.deltaTime;
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
            currentTargetPosition = target.position;
            transform.position = currentTargetPosition - cameraOffset * currentZoomLevel ;
            transform.LookAt(currentTargetPosition+ Vector3.up*pitch);
            transform.RotateAround(currentTargetPosition, Vector3.up, currentYaw);

        }
    }
}
