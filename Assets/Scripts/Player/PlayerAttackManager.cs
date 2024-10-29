using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackManager : MonoBehaviour
{
    #region Configer
    [SerializeField] PlayerConfigHolder playerConfigHolder;
    void StartingConfigApplication()
    {
        attackTime = playerConfigHolder.attackTime;

    }
    #endregion
    // [SerializeField] GameObject bulletsParentObject;

    [Space]
    [Range(0f, 2f)]
    [SerializeField] float attackTime = 1f;

    List<GameObject> targets = new List<GameObject>();

    [SerializeField] BulletParent bulletParent;

    // Start is called before the first frame update
    void Start()
    {
        StartingConfigApplication();

        bulletParent = FindObjectOfType<BulletParent>();

        StartCoroutine(TargetAndAttackRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    public void SetTargetList(List<GameObject> targets)
    {
        this.targets = targets;
    }

    IEnumerator TargetAndAttackRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackTime);
            if (targets.Count == 0) continue;

            Attack(SetTarget());
            
        }
    }
    GameObject SetTarget()
    {

        float distance = 0;
        GameObject closestTarget = null;
        float closestTagetDistance = Mathf.Infinity;
        foreach (var target in targets)
        {
            if (target == null) continue;

            distance = Vector2.Distance(target.transform.position, transform.position);
            if (distance > closestTagetDistance) continue;
            closestTagetDistance = distance;
            closestTarget = target;
        }

        return closestTarget;
    }
    void Attack(GameObject target)
    {
        if (target == null) return;

        GameObject bullet = bulletParent.GetFirstBulletInQueue();

        bullet.SetActive(true);
        bullet.GetComponent<Bullet>().SetTarget(target);
        bullet.transform.position = transform.position;
    }


    public float GetAttackTime()
    {
        return attackTime;
    }
    public void SetAttackTime(float time)
    {
        attackTime = time;
    }
    public void DecreseAttackTime(float amount)
    {
        attackTime -= amount;
        attackTime = Mathf.Clamp(attackTime, 0, Mathf.Infinity);
    }
}
