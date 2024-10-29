using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class LightningStrikeAbility : MonoBehaviour
{
    #region Configer
    [SerializeField] PlayerConfigHolder playerConfigHolder;
    void StartingConfigApplication()
    {
        rangeRadius = playerConfigHolder.lightningStikeRangeRadius;
        abilityCD = playerConfigHolder.lightningStrikeCD;
        targetsToKill = playerConfigHolder.lightningStikeTargetsToKill;

    }
    #endregion



    [SerializeField] float rangeRadius = 5f;
    List<GameObject> enemisInLightningAbilityRange = new List<GameObject>();

    [SerializeField] float abilityCD = 3f;
    [SerializeField] int targetsToKill = 2;

    KillEnemyOrderEvent killEnemyOrderEvent;

    [Header("Visual Effect")]
    [SerializeField] GameObject lightningEffectParticleObject;
    // Start is called before the first frame update
    void Start()
    {
        StartingConfigApplication();

        GetComponent<CircleCollider2D>().isTrigger = true;
        GetComponent<CircleCollider2D>().radius = rangeRadius;

        killEnemyOrderEvent = FindObjectOfType<KillEnemyOrderEvent>();


        StartCoroutine(AbilityWorkingRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    IEnumerator AbilityWorkingRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(abilityCD);
            KillEnemies();
        }
    }

    void KillEnemies()
    {
        for (int x = 0; x < targetsToKill; x++)
        {
            if (enemisInLightningAbilityRange.Count == 0) return;
            int _rand = Random.Range(0, enemisInLightningAbilityRange.Count);
            GameObject enemyToKill = enemisInLightningAbilityRange[_rand];
            ParticleEffectInstanciator(enemyToKill.transform.position);
            killEnemyOrderEvent.GiveEnemyKillOrder(enemyToKill);

        }
    }



    void ParticleEffectInstanciator(Vector3 pose)
    {
        Instantiate(lightningEffectParticleObject, pose, lightningEffectParticleObject.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Tag_Enemy>() == null) return;

        enemisInLightningAbilityRange.Add(collision.gameObject);

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        enemisInLightningAbilityRange.Remove(collision.gameObject);
    
    }



}
