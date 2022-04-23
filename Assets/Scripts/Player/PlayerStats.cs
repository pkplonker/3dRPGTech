using System;
using Save;
using UnityEngine;

namespace Player
{
    public sealed class PlayerStats : CharacterStats, ISaveLoad
    {

        public void LoadState(object data)
        {
            SaveData saveData = (SaveData) data;
            IsDead = saveData.isDead;
            currentHealth = saveData.currentHealth;
            maxHealth = saveData.maxHealth;
            InvokeOnHealthChanged();

        }


        public object SaveState()
        {
            return new SaveData()
            {
                isDead = this.IsDead,
                currentHealth = this.currentHealth,
                maxHealth = this.maxHealth
            };
        }

        [Serializable]
        private struct SaveData
        {
            public bool isDead;
            public float currentHealth;
            public float maxHealth;
        }
    }


   
}