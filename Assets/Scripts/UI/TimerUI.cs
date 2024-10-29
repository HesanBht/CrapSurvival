using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerTmpro;

    int minutes = 0;
    int seconds = 0;

    string timeString;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeRoutine());
    }

   

    IEnumerator TimeRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            seconds++;
            TimerLogic();
        }
    }

    void TimerLogic()
    {
        string secondsString;
        string minutesString;

        if (seconds >= 60)
        {
            minutes++;
            seconds = 0;
        }

        if (seconds < 10)
            secondsString = "0" + seconds;
        else secondsString = seconds.ToString();

        if (minutes < 10)
            minutesString = "0" + minutes;
        else minutesString = minutes.ToString();

        timeString = minutesString + ":" + secondsString;
        timerTmpro.text = timeString;
    }

}
