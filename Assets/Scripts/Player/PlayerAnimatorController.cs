using System;
using UnityEngine;

namespace Player
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        private Animator animator;
        private Locomotion locomotion;
        private static readonly int Movement = Animator.StringToHash("Movement");

        private void Awake()
        {
            animator = GetComponent<Animator>();
            if(animator==null) Debug.LogError("Animator missing");
            locomotion = GetComponentInParent<Locomotion>();
            if(locomotion ==null) Debug.LogError("locomotion missing");
        }

        private void OnEnable()
        {
            locomotion.OnSpeedChanged += CharacterSpeedChanged;
        }
        private void OnDisable()
        {
            locomotion.OnSpeedChanged -= CharacterSpeedChanged;
        }

        private void CharacterSpeedChanged(float newSpeed)
        {
            animator.SetFloat(Movement, newSpeed);

        }
       
    }
}
