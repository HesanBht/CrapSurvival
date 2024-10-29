using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class XpRewarder : MonoBehaviour
{

    #region Configer
    [SerializeField] EnemyConfigHolder enemyConfigHolder;
    void StartingConfigApplication()
    {
        rewardXpOnDestory = enemyConfigHolder.rewardOnDeath;
        xpRewardAmount = enemyConfigHolder.rewardAmount;


    }
    #endregion



     bool rewardXpOnDestory = true;

    

     int xpRewardAmount = 10;


    public static event Action<int> onPlayerXpReward;

  //  [SerializeField] bool Pox = false;
    // Start is called before the first frame update
    void Start()
    {
        StartingConfigApplication();
        PlayerHealth.onPlayerDeath += StopRewarding;
    }

    // Update is called once per frame
    void Update()
    {
        //    if (Pox)
        //   {
        //     Destroy(gameObject);
        // }
    }


    private void OnDestroy()
    {
        if (!rewardXpOnDestory)
        {
            PlayerHealth.onPlayerDeath -= StopRewarding;
            return;
        }
        onPlayerXpReward?.Invoke(xpRewardAmount);

    }


    void StopRewarding()
    {
        rewardXpOnDestory = false;
    }
}
