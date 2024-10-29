using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System;

public class HealthRune : MonoBehaviour
{
    [Tooltip("If usePercetage is not checked, health amount will be used by Defult")]
    [SerializeField] int healthAmount = 50;

    [Space(20)]
    [SerializeField] bool usePercentage = false;
    [SerializeField] int healthPercentage = 50;



    int playerMaxHealth;
    int playerHealth;

    public static event Action<int> onHealthRunePickup;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth.onPlayerHealthChange += SetHealthAmounts;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnDestroy()
    {
        PlayerHealth.onPlayerHealthChange -= SetHealthAmounts;
    }

    void SetHealthAmounts(int health , int maxHealth)
    {
        playerMaxHealth = maxHealth;
    }

    int CalculateHealthPercantage()
    {
        int percentage = playerMaxHealth * healthPercentage / 100;


        return percentage;
    }


    void Heal()
    {
        if (usePercentage)
        {
            int amountToHeal = CalculateHealthPercantage();
            onHealthRunePickup?.Invoke(amountToHeal);
        }
        else
        {
            onHealthRunePickup?.Invoke(healthAmount);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Tag_player>() == null) return;
        Heal();
        Destroy(gameObject);
    }
}
