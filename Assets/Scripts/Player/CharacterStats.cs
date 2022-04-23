using System;
using Save;
using UnityEngine;

namespace Player
{
    public class CharacterStats :  MonoBehaviour 
    {
        public string CharacterName { get; protected set; } = "NewCharacter";
        public bool IsDead { get; protected set; }
        public bool CanMove { get; private set; } = true;

        public float currentHealth { get; protected set; }= 0;
        public float maxHealth { get; protected set; }= 99;
        public event Action<float> OnHealthChanged;
 

        public event Action OnDeath;


        protected virtual void Start()
        {
            currentHealth = maxHealth;
            InvokeOnHealthChanged();
        }

        protected void InvokeOnHealthChanged()
        {
            OnHealthChanged?.Invoke(currentHealth);
        }

        public virtual void TakeDamage(float amount)
        {
            if (amount < 0) return;
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Die();
            }

            InvokeOnHealthChanged();
        }
        protected virtual void Die()
        {
            CanMove = false;
            InvokeOnDeath();
            IsDead = true;
        }

        protected void InvokeOnDeath()
        {
            OnDeath?.Invoke();
        }

        public virtual void Heal(float amount)
        {
            if (amount <= 0) return;
            currentHealth += amount;
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }

            InvokeOnHealthChanged();
        }
        public void Revive()
        {
            currentHealth = maxHealth;
            IsDead = false;
            CanMove = true;
            InvokeOnHealthChanged();
        }


      
    }
}
