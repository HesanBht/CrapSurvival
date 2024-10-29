using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    #region Configer
    [SerializeField] PlayerConfigHolder playerConfigHolder;
    void StartingConfigApplication()
    {
        maxHealth = playerConfigHolder.maxHealth;
    }
    #endregion



    [SerializeField] int maxHealth = 100;

    [SerializeField] int health = 0;


    public static event Action<int,int> onPlayerHealthChange;

    public static event Action onPlayerDeath;


    bool doOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        StartingConfigApplication();

        health = maxHealth;

        onPlayerHealthChange?.Invoke(health, maxHealth);
        HealthRune.onHealthRunePickup += Heal;

    }

    // Update is called once per frame
    void Update()
    {
        if (!doOnce)
        {
            onPlayerHealthChange?.Invoke(health, maxHealth);
            doOnce = true;
        }
    }




    public void ReduceHealth(int amount)
    {
        health = Mathf.Clamp(health - amount, 0, maxHealth);

        onPlayerHealthChange?.Invoke(health, maxHealth);

        if (health <= 0)
        {
            Die();
        }
    }
   public void Heal(int amount)
    {
        health = Mathf.Clamp(health + amount, 0, maxHealth);

        onPlayerHealthChange?.Invoke(health, maxHealth);
    }

    void Die()
    {
        onPlayerDeath?.Invoke();

      //  Destroy(gameObject);
        // "Sishdin Gada. Oldooooooooooooooon"


    }



    public int GetMaxHealth()
    {
        return maxHealth;
    }
    public int GetHealth()
    {
        return health;
    }
}
