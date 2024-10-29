using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class SroundingChainAbility : MonoBehaviour
{
    #region Configer
    [SerializeField] PlayerConfigHolder playerConfigHolder;
    void StartingConfigApplication()
    {
        effectRadius = playerConfigHolder.sroundingChainRadius;
        slowPercentage = playerConfigHolder.sroundingChainSlowPercentage;
        abilityDamage = playerConfigHolder.sroundingChainDamage;
        damageCD = playerConfigHolder.sroundingChainDamageCD;
    }
    #endregion


    [SerializeField] float effectRadius = 2f;
    [SerializeField] int slowPercentage = 30;
    [SerializeField] int abilityDamage = 10;
    [SerializeField] float damageCD = 1f;

    [Header("VFX")]
    [SerializeField] float rotationSpeed = 20f;

    List<GameObject> enemiesToDmgList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        StartingConfigApplication();

        EnableAbility();
    }

    // Update is called once per frame
    void Update()
    {
        RotateEffect();


    }

    void EnableAbility()
    {
        transform.localScale = new Vector3(effectRadius, effectRadius, 1f);
        GetComponent<CircleCollider2D>().enabled = true;
        GetComponent<CircleCollider2D>().isTrigger = true;

        StartCoroutine(DamageRoutine());
    }

    IEnumerator DamageRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(damageCD);

            for (int x = 0; x < enemiesToDmgList.Count; x++)
            {
                if (enemiesToDmgList[x] == null) continue;

                enemiesToDmgList[x].GetComponent<EnemyHealth>().ReduceHealth(abilityDamage);

            }
        }
    }

    
    void RotateEffect()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * rotationSpeed);
    }

    void StartSlowingEffect(GameObject enemy)
    {
        if (enemy.GetComponent<EnemyMovement>() == null) return;
        enemy.GetComponent<EnemyMovement>().ApplySlow(slowPercentage);
    }
    void EndSlowingEffect(GameObject enemy)
    {
        if (enemy.GetComponent<EnemyMovement>() == null) return;
        enemy.GetComponent<EnemyMovement>().EndSlow();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Tag_Enemy>() == null) return;
        enemiesToDmgList.Add(collision.gameObject);

        StartSlowingEffect(collision.gameObject);
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Tag_Enemy>() == null) return;
        enemiesToDmgList.Remove(collision.gameObject);

        EndSlowingEffect(collision.gameObject);
    }
}
