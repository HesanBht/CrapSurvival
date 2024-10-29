using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletSpeed = 1f;

    [SerializeField] float selfDestructTime = 10f;
    [SerializeField] GameObject target;

   [SerializeField] BulletParent bulletParent;

    Vector3 lastMoveDir = new Vector2();
    int damage = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
    
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            lastMoveDir = (target.transform.position - transform.position).normalized;
        }
        transform.position += (lastMoveDir * bulletSpeed * Time.deltaTime);


    }

    private void OnEnable()
    {
        if (bulletParent == null)
            bulletParent = GetComponentInParent<BulletParent>();

        bulletSpeed = bulletParent.GetBulletSpeed();
        damage = bulletParent.GetDamage();
    }

   

    public void SetTarget(GameObject _target)
    {
        target = _target;
        StartCoroutine(SelfDestruct());

        if (target == null)
        {
            DeActivateBullet();
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Tag_Enemy>() == null) return;
        if (collision.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
        {
            enemyHealth.ReduceHealth(damage);
        }

        DeActivateBullet();
    }


    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(selfDestructTime);
        bulletParent.EnqueueBullet(this.gameObject);
        gameObject.SetActive(false);
    }
    void DeActivateBullet()
    {
        bulletParent.EnqueueBullet(this.gameObject);
        gameObject.SetActive(false);
        StopAllCoroutines();
    }
   


    
}
