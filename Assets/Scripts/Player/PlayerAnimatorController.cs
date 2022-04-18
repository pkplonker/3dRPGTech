using System;
using UnityEngine;

namespace Player
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        private Animator animator;
        private Locomotion locomotion;
        
        private void Awake()
        {
            animator = GetComponent<Animator>();
            if(animator==null) Debug.LogError("Animator missing");
            locomotion = GetComponentInParent<Locomotion>();
            if(locomotion ==null) Debug.LogError("locomotion missing");
        }

        private void Update()
        {
            animator.SetFloat("Movement", locomotion.currentMovementSpeed);
        }
    }
}
