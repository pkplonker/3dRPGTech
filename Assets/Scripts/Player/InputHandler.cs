using System;
using UnityEngine;

namespace Player
{
    public class InputHandler : MonoBehaviour
    {
        private InputControls inputControls;
        public float MouseScrollVector { get; private set; }
        public float CameraMove { get; private set; }

        public bool LeftClick { get; private set; }
        public bool RightClick{ get; private set; }
        public bool MiddleClick{ get; private set; }
        public bool Esc{ get; private set; }
        public bool Shift{ get; private set; }

        public Vector2 MousePosition{ get; private set; }
        private void OnEnable()
        {
            inputControls = new InputControls();
           inputControls.Enable();
           inputControls.Default.MiddleScroll.performed +=
               inputActions => MouseScrollVector = inputActions.ReadValue<float>();
           inputControls.Default.CamerMove.performed +=
               inputActions =>  CameraMove= inputActions.ReadValue<float>();
           inputControls.Default.MousePosition.performed +=
               inputActions => MousePosition = inputActions.ReadValue<Vector2>();
           inputControls.Default.LeftClick.performed += inputActions => LeftClick = true;
           inputControls.Default.RightClick.performed += inputActions => RightClick = true;
           inputControls.Default.MiddleClick.started += inputActions => MiddleClick = true;
           inputControls.Default.MiddleClick.canceled += inputActions => MiddleClick = false;
           inputControls.Default.Esc.performed += inputActions => Esc = true;
           inputControls.Default.Shift.started += inputActions => Shift = true;
           inputControls.Default.Shift.canceled += inputActions => Shift = false;
        }
        private void OnDisable()
        {
            inputControls.Disable();
        }

      

        private void LateUpdate()
        {
            ResetInputs();
        }

        private void ResetInputs()
        {
            LeftClick = false;
            RightClick = false;
        }
    }
}
