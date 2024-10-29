using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRangeColliderManager : MonoBehaviour
{
    #region Configer
    [SerializeField] PlayerConfigHolder playerConfigHolder;
    void StartingConfigApplication()
    {
        GetComponent<CircleCollider2D>().radius = playerConfigHolder.attackRange;
    }
    #endregion

    [SerializeField] List<GameObject> enemiesInRage;

    [SerializeField] PlayerAttackManager playerAttackManager;


    private void Start()
    {
        StartingConfigApplication();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (!collision.gameObject.TryGetComponent<Tag_Enemy>(out Tag_Enemy tag_Enemy)) return;

        enemiesInRage.Add(collision.gameObject);
        playerAttackManager.SetTargetList(enemiesInRage);
        



    }
    private void OnTriggerExit2D(Collider2D collision)
    {
            enemiesInRage.Remove(collision.gameObject);


        playerAttackManager.SetTargetList(enemiesInRage);
        
    }


    public List<GameObject> GetEnemiesInRageList()
    {
        return enemiesInRage;
    }
}
