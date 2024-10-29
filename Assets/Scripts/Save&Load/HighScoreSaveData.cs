using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScoreSaveData
{
    public int highScore;

    public HighScoreSaveData (HighScoreManager highScoreManager)
    {
        highScore = highScoreManager.GetHighScore();

    }

}
