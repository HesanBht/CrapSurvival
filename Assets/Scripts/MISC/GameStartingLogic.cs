using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartingLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TimeManager.instance.ResumeGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
