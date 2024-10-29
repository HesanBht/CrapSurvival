using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleAttackModifierAbility : MonoBehaviour
{
    

    PlayerAttackManager playerAttackManager;
    BulletParent bulletParent;

    [SerializeField] float baseAttackTime;
    [SerializeField] int attackTimeDecresePersentage = 10;
    [SerializeField] float attackTimeDecreseOnEachLevelup;

    [SerializeField] int baseBulletDamage;
    [SerializeField] int bulletDamageIncresePersentage = 10;
    [SerializeField] int bulletDamageIncreseOnEachLevelup;

  

    
    // Start is called before the first frame update
    void Start()
    {
        playerAttackManager = FindObjectOfType<PlayerAttackManager>();
        bulletParent = FindObjectOfType<BulletParent>();

        StartCoroutine(CalculateValues());
    }
    
    // Update is called once per frame
    void Update()
    {
       

    }

  public  void DeacreseAttackTime()
    {
        playerAttackManager.DecreseAttackTime(attackTimeDecreseOnEachLevelup);
    }
   public void IncreseDamage()
    {
        bulletParent.IncreseDamage(bulletDamageIncreseOnEachLevelup);
    }
  

    IEnumerator CalculateValues()
    {
        yield return new WaitForEndOfFrame();
      
        baseAttackTime = playerAttackManager.GetAttackTime();
        attackTimeDecreseOnEachLevelup = (baseAttackTime * attackTimeDecresePersentage) / 100;

        baseBulletDamage = bulletParent.GetBaseDamage();
        bulletDamageIncreseOnEachLevelup = ((baseBulletDamage * bulletDamageIncresePersentage) / 100);

    }

    
}
