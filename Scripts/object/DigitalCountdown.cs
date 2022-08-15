using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DigitalCountdown : MonoBehaviour
{
    public GameObject outbreak;
    private Text textClock;
    public CountdownTimer countdownTimer;
    public static DigitalCountdown instance;
    public bool outbreakactive;

    public void Awake()
    {
        textClock = GetComponent<Text>();
        countdownTimer = GetComponent<CountdownTimer>();
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
        countdownTimer.ResetTimer(10);
       outbreak.SetActive(false);
        outbreakactive = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        int timeRemaining= countdownTimer.GetSecondsRemaining();
        string message = TimerMessage(timeRemaining);
        textClock.text = message;
        ResetCountdown();
    }

    public string TimerMessage(int secondsLeft)
    {
        if(secondsLeft < 0)
        {
            return "OUTBREAK";
            
        }
        else
        {
            return "Time Remaining for OUTBREAK = " + secondsLeft;
        }
    }

    public void ResetCountdown()
    {
        if(countdownTimer.GetSecondsRemaining() < 0)
        {
            outbreak.SetActive(true);
            outbreakactive = true;
            countdownTimer.ResetTimer(20);
            
        }

        if(countdownTimer.GetSecondsRemaining() < 18)
        {
            outbreak.SetActive(false);
            outbreakactive = false;
        }

    }
}
