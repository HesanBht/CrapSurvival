using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyAttackManager : MonoBehaviour
{
    #region Configer
    [SerializeField] EnemyConfigHolder enemyConfigHolder;
    void StartingConfigApplication()
    {
        damage = enemyConfigHolder.damage;
        attackCD = enemyConfigHolder.atackCD;
    }
    #endregion

    int damage;  
    GameObject playerObject;

    float attackCD = 1f;
    bool attackIsOnCD = false;

    // Start is called before the first frame update
    void Start()
    {
        StartingConfigApplication();

        playerObject = FindObjectOfType<Tag_player>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.GetComponent<Tag_player>()) return;
        Attack();
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.GetComponent<Tag_player>()) return;
        Attack();
    }

    void Attack()
    {
        if (CheckForCDAndTakeAction()) return; // true means attack is on CD so return and do nothing

     //   damage = gameObject.GetComponent<Damage>().GetDamage();  
        playerObject.GetComponent<PlayerHealth>().ReduceHealth(damage);

    }

    bool CheckForCDAndTakeAction()
    {
        if (attackIsOnCD) return true;
        StartCoroutine(AttackCDRoutine());
        return false; 
    }

    IEnumerator AttackCDRoutine()
    {
        attackIsOnCD = true;
        yield return new WaitForSeconds(attackCD);
        attackIsOnCD = false;
    }
}
