using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class BulletParent : MonoBehaviour
{
    #region Configer
    [SerializeField] PlayerConfigHolder playerConfigHolder;
    void StartingConfigApplication()
    {
        baseDamage = playerConfigHolder.bulletDamage;
        baseBulletSpeed = playerConfigHolder.bulletSpeed;
        totalBulletsToInstanciate = playerConfigHolder.totalBulletsToInstanciat;
    }
    #endregion

    Queue<GameObject> queuedBullets = new Queue<GameObject>();

    [SerializeField] GameObject bulletObjectPrefab;


    [SerializeField] int baseDamage;
    [SerializeField] int currentDamage;

   [SerializeField] int damageBeforeModif;

    [SerializeField] float baseBulletSpeed;
    [SerializeField] float currentBulletSpeed;

    [SerializeField] int totalBulletsToInstanciate = 100;

    // Start is called before the first frame update
    void Start()
    {
        StartingConfigApplication();

     //   baseDamage = GetComponent<Damage>().GetDamage();
        currentDamage = baseDamage;
        damageBeforeModif = currentDamage;

        currentBulletSpeed = baseBulletSpeed;
        InstanciateBullets();
    }

    // Update is called once per frame
    void Update()
    {

    }

  

    public int GetDamage()
    {
        return currentDamage;
    }
    public int GetBaseDamage()
    {
        return baseDamage;
    }
    public void SetDamage(int damage)
    {
        currentDamage = damage;
    }
    public void IncreseDamage(int amount)
    {
        damageBeforeModif += amount;
        currentDamage += amount;
    }
    public void ResetDamageToBaseDamage()
    {
        currentDamage = damageBeforeModif;
    }



    public float GetBulletSpeed()
    {
        return currentBulletSpeed;
    }
    

    void InstanciateBullets()
    {
        for (int x = 0; x < totalBulletsToInstanciate; x++)
        {
            GameObject bulletInstance = Instantiate(bulletObjectPrefab, transform);
            bulletInstance.SetActive(false);
            queuedBullets.Enqueue(bulletInstance);
        }
    }

    public GameObject GetFirstBulletInQueue()
    {
        return queuedBullets.Dequeue();
    }

    public void EnqueueBullet(GameObject bullet)
    {
        queuedBullets.Enqueue(bullet);
    }
}
