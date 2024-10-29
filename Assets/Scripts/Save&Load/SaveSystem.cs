using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveSystem 
{
    static string path = Application.persistentDataPath + "/HighScore.BulBul";
    public static void SaveHighScore(HighScoreManager highScoreManager)
    {

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create);

        HighScoreSaveData data = new HighScoreSaveData(highScoreManager);

        formatter.Serialize(stream, data);
        stream.Close();

        Debug.Log("High Score Data Saved");
    }

    public static HighScoreSaveData LoadHighScore()
    {
        if (!File.Exists(path))
        {
            Debug.Log("No Save Found");
            return null;
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Open);

        HighScoreSaveData highScoreSaveData = formatter.Deserialize(stream) as HighScoreSaveData;
        stream.Close();


        Debug.Log("High Score Data Loaded");

        return highScoreSaveData;

    }

    public static void DeleteSave()
    {
        if (!File.Exists(path)) return;
        File.Delete(path);


        Debug.Log("High Score Data Deleted");
    }
}
