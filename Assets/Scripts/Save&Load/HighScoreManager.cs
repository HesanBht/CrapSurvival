using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreTmpro;
    [SerializeField] TextMeshProUGUI currentScoreTmpro;

    [SerializeField] int highScore = 0;

    [SerializeField] int currentScore = 0;

    [SerializeField] bool isOnGameScene = false;

    private void Awake()
    {
        print(Application.persistentDataPath + "/HighScore.BulBul");
        
    }

    // Start is called before the first frame update
    void Start()
    {
        HighScoreSaveData highScoreSaveData = SaveSystem.LoadHighScore();
        if (highScoreSaveData != null) highScore = highScoreSaveData.highScore;
        if (highScoreTmpro != null) highScoreTmpro.text = "High Score: " + highScore;

        if (isOnGameScene)
        {
            XpRewarder.onPlayerXpReward += SetScoreText;
            PlayerHealth.onPlayerDeath += UpdateAndSaveHighScore;
        }

    }

    // Update is called once per frame
    void Update()
    {
        

    }

    private void OnDestroy()
    {
        XpRewarder.onPlayerXpReward -= SetScoreText;
    }
    void SetScoreText(int score)
    {
        currentScore += score;

        if (currentScoreTmpro == null) return;
        currentScoreTmpro.text = "Score: " + currentScore.ToString();
    }



    public void UpdateAndSaveHighScore()
    {
        if (currentScore <= highScore) return;

        highScore = currentScore;

        SaveSystem.SaveHighScore(this);

    }





    public int GetHighScore()
    {
        return highScore;
    }

}
