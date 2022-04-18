using System;
using UnityEngine;

namespace Player
{
    public class InputHandler : MonoBehaviour
    {
        private InputControls inputControls;
        public float mouseScrollVector { get; private set; }
        public float cameraMove { get; private set; }

        public bool leftClick { get; private set; }
        public bool rightClick{ get; private set; }
        public bool middleClick{ get; private set; }
        public bool esc{ get; private set; }
        public Vector2 mousePosition{ get; private set; }
        private void OnEnable()
        {
            inputControls = new InputControls();
           inputControls.Enable();
           inputControls.Default.MiddleScroll.performed +=
               inputActions => mouseScrollVector = inputActions.ReadValue<float>();
           inputControls.Default.CamerMove.performed +=
               inputActions =>  cameraMove= inputActions.ReadValue<float>();
           inputControls.Default.MousePosition.performed +=
               inputActions => mousePosition = inputActions.ReadValue<Vector2>();
           inputControls.Default.LeftClick.performed += inputActions => leftClick = true;
           inputControls.Default.RightClick.performed += inputActions => rightClick = true;
           inputControls.Default.MiddleClick.started += inputActions => middleClick = true;
           inputControls.Default.MiddleClick.canceled += inputActions => middleClick = false;

           inputControls.Default.Esc.performed += inputActions => esc = true;

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
            leftClick = false;
            rightClick = false;
        }
    }
}
