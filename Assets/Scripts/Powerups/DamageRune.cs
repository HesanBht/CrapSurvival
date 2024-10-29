using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class DamageRune : MonoBehaviour
{
    [SerializeField] int damageMultiplier = 3;
    [Tooltip("In Seconds")]
    [SerializeField] float duration = 20f;

    BulletParent bulletParentSc;

    public static event Action<float> onDdActivated;
    // Start is called before the first frame update
    void Start()
    {
        bulletParentSc = FindObjectOfType<BulletParent>();

        
    }



    // Update is called once per frame
    void Update()
    {
        
    }


    int CalculateDamage()
    {
        int damage = bulletParentSc.GetDamage();
        damage *= damageMultiplier;
        return damage;
    }
    void SetDamage()
    {
        bulletParentSc.SetDamage(CalculateDamage());
    }
    void ResetDamage()
    {
        bulletParentSc.ResetDamageToBaseDamage();
    }


    IEnumerator MultiplyDamageRoutine()
    {
        onDdActivated?.Invoke(duration);
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        SetDamage();
        yield return new WaitForSeconds(duration);
        ResetDamage();
        Destroy(gameObject);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Tag_player>() == null) return;
        StartCoroutine(MultiplyDamageRoutine());
    }
}
