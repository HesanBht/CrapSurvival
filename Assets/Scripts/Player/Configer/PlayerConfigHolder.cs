using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "PlayerConfigHolder")]
public class PlayerConfigHolder : ScriptableObject
{
    [Header("Attack")]
    public float attackTime;
    public float attackRange;
    public int bulletDamage;
    public float bulletSpeed;
    public int totalBulletsToInstanciat;

    [Header("HP")]
    public int maxHealth;


    [Header("Movement")]
    public float moveSpeed;


    [Header("XP")]
    public int baseXP;
    public float levelUpMultiplier;


    [Header("ABILITIES")]
    [Space(10)]
    [Header("LightningStike")]
    public float lightningStikeRangeRadius;
    public float lightningStrikeCD;
    public int lightningStikeTargetsToKill;


    [Header("SroundingChain")]
    public float sroundingChainRadius;
    public int sroundingChainSlowPercentage;
    public int sroundingChainDamage;
    public float sroundingChainDamageCD;

    [Header("Shapa")]
    public float shapaSpeed = 3f;
    public float shapaLifeTime = 4f;
    public int shapaDamage = 100;
    public float shapaAbilityCD = 5f;
    public KeyCode shapaButton = KeyCode.Space;

}
