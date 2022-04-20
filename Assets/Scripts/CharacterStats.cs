using System;
using System.Collections;
using System.Collections.Generic;
using Save;
using UnityEngine;

public class CharacterStats : MonoBehaviour, ISaveLoadInterface
{
    public string CharacterName { get; protected set; } = "NewCharacter";
    public bool IsDead { get; protected set; }
    public bool CanMove { get; protected set; } = true;

    public float currentHealth { get; protected set; }= 0;
    public float maxHealth { get; protected set; }= 99;
    public event Action<float> OnHealthChanged;
 

    public event Action OnDeath;


    protected virtual void Start()
    {
        currentHealth = maxHealth;
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

        OnHealthChanged?.Invoke(currentHealth);
    }
    protected virtual void Die()
    {
        CanMove = false;
        OnDeath?.Invoke();
        IsDead = true;
    }
    public virtual void Heal(float amount)
    {
        if (amount <= 0) return;
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        OnHealthChanged?.Invoke(currentHealth);
    }
    public void Revive()
    {
        currentHealth = maxHealth;
        IsDead = false;
        CanMove = true;
        OnHealthChanged?.Invoke(currentHealth);
    }


    public void LoadState(GameData gameData)
    {
        IsDead = gameData.playerIsDead;
        currentHealth = gameData.playerCurrentHealth;
        maxHealth = gameData.playerMaxHealth;
    }

    public void SaveState(GameData gameData)
    {
        gameData.playerIsDead = IsDead;
        gameData.playerCurrentHealth = currentHealth;
        gameData.playerMaxHealth = maxHealth;
        
        OnHealthChanged?.Invoke(currentHealth);

    }
}
