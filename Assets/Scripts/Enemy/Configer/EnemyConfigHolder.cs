using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

[CreateAssetMenu(menuName="EnemyConfiger")]
public class EnemyConfigHolder : ScriptableObject
{
    public int health = 100;
    public int damage = 50;
    public float atackCD = 1f;
    public float defultMoveSpeed = 10f;

    [Space]
    public bool rewardOnDeath = true;
    public int rewardAmount = 50;

    [Header("Golem")]
    public int maxSplit = 2;
    public float sizeSplitAmount = 1.7f;
}
