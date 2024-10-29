using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerXp : MonoBehaviour
{
    #region Configer
    [SerializeField] PlayerConfigHolder playerConfigHolder;
    void StartingConfigApplication()
    {
        baseXp = playerConfigHolder.baseXP;
        levelUpMultiplier = playerConfigHolder.levelUpMultiplier;
    }
    #endregion


    [SerializeField] int currentXp = 0;

    [SerializeField] int totalXp = 0;

    [SerializeField] int currentLvl = 1;

    [SerializeField] int baseXp = 100;
    [SerializeField] float levelUpMultiplier = 1.5f;

    [SerializeField] int xpReqForNextLevel;

    public static event Action<int> onLevelup;
    // Start is called before the first frame update
    void Start()
    {
        StartingConfigApplication();

        CalculateXpReqForNextLevel();
        XpRewarder.onPlayerXpReward += AddXp;
    }

    // Update is called once per frame
    void Update()
    {
        
      
        
    }

    void CalculateXpReqForNextLevel()
    {
        xpReqForNextLevel = baseXp * (int)Mathf.Pow(levelUpMultiplier, currentLvl);
    }
     
    void AddXp(int xp)
    {
        currentXp += xp;
        TryLevelUp();
    }
    void TryLevelUp()
    {
        if (currentXp < xpReqForNextLevel) return;

        totalXp += currentXp;

        currentXp -= xpReqForNextLevel;
        totalXp -= currentXp;


        LevelUp();

        CalculateXpReqForNextLevel();

        if (currentXp >= xpReqForNextLevel) TryLevelUp();
    }
    void LevelUp()
    {
        currentLvl++;

        onLevelup?.Invoke(currentLvl);
        TimeManager.instance.PauseGame();
    }


    public void DebugerAddXp(int xp)
    {
        AddXp(xp);
    }
}
