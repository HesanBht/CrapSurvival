using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
//using TMPro.EditorUtilities;

public class PlayerBasicInfoUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI currentLvlText;

    int currentScore = 0;

    [SerializeField] GameObject ddIndicatorObject;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth.onPlayerHealthChange += SetHealthText;
        //   XpRewarder.onPlayerXpReward += SetScoreText;

        DamageRune.onDdActivated += SetDdIndicator;
        PlayerXp.onLevelup += SetCurrentLvlText;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        PlayerHealth.onPlayerHealthChange -= SetHealthText;

        DamageRune.onDdActivated -= SetDdIndicator;
        PlayerXp.onLevelup -= SetCurrentLvlText;
    }

    void SetHealthText(int health, int maxHealth)
    {
        if (healthText == null) return;

        healthText.text = "Health: " + health.ToString() + "/" + maxHealth.ToString();

    }

    void SetScoreText(int score)
    {
        currentScore += score;
        scoreText.text = "Score: " + currentScore.ToString();
    }

    void SetCurrentLvlText(int lvl)
    {
        currentLvlText.text = "Lvl: " + lvl;
    }

    void SetDdIndicator(float duration)
    {
        StartCoroutine(DdIndicatorRoutine(duration));
    }
    IEnumerator DdIndicatorRoutine(float duration)
    {
        ddIndicatorObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        ddIndicatorObject.SetActive(false);
    }
}
