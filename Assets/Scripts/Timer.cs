using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static Timer singleton;
    public float currTime = 0.0f;
    public float bestTime = 0.0f;

    public Text currTimeText;
    public Text timeToBeatText;

    public bool timerActive = false;

    private void Awake()
    {
        if (!(singleton is null) && singleton != this)
            Destroy(this);
        singleton = this;

    }

    void Update()
    {
        if(timerActive)
        RunTimer();
    }


    public void RunTimer()
    {
        currTime += Time.deltaTime;
        FormatTimer(currTime, currTimeText, "");

        if(currTime > bestTime && bestTime != 0)
        {
            currTimeText.color = new Color(1, 0, 0);  
        }

    }

    private void FormatTimer(float t, Text displayText, string info) 
    {
        string minutes = Mathf.Floor(t / 60).ToString("00");
        string seconds = Mathf.Floor(t % 60).ToString("00");
        string milis = Mathf.Floor((t * 10) % 10).ToString("0");
        displayText.text = info + string.Format("{0}:{1}.{2}", minutes, seconds, milis);
    }


    public void TimerFinished()
    {
       
        if (!timerActive)
            return;

        timerActive = false;

        if(currTime < bestTime || bestTime == 0)
        {
            bestTime = currTime;
            FormatTimer(bestTime, timeToBeatText, "Time To Beat: ");
        }


    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void RestartTimer()
    {
        currTime = 0;
        timerActive = false;
        FormatTimer(currTime, currTimeText, "");
        currTimeText.color = new Color(0, 1, 0);
    }
}
