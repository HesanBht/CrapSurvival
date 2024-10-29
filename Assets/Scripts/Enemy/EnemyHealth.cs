using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    #region Configer
    [SerializeField] EnemyConfigHolder enemyConfigHolder;
    void StartingConfigApplication()
    {
        health = enemyConfigHolder.health;

    }
    #endregion

    [SerializeField] int health = 100;

    [SerializeField] bool kill = false;

    //  public static event Action<GameObject> onEnemyDeath;

    // Start is called before the first frame update
    void Start()
    {
        StartingConfigApplication();

        KillEnemyOrderEvent.onEnemyKillOrder += RecieveKillOrder;
        

    }
    private void OnDestroy()
    {
        KillEnemyOrderEvent.onEnemyKillOrder -= RecieveKillOrder;
    }

    // Update is called once per frame
    void Update()
    {
        if (kill)
        {
            kill = false;
            ReduceHealth(99999);
        }

    }
    public void ReduceHealth(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }
    public void SetHealth(int _health)
    {
        health = _health;
    }
    public int GetHealth()
    {
        return health;
    }

    public void Die()
    {
      //  onEnemyDeath?.Invoke(this.gameObject);
           
        if (GetComponent<Golem>() != null)
        {
            GetComponent<Golem>().Split();
        }

        Destroy(gameObject);
    }

    void RecieveKillOrder(GameObject enemyToDie)
    {
        // checks IDs to see if it belongs to this one and if it does, kills himslef
        if (enemyToDie.GetComponent<EnemyID>().GetId() == GetComponent<EnemyID>().GetId()) 
            Die();
    }
}
