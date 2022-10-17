using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;

    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                // Subtract seconds by 1 and display time as text
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);

            }
            else
            {
                // Time set to 0, timer turned off
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        // += 1 because we are counting down (half a second left shown as 1 second to user)
        timeToDisplay += 1;
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}", seconds);
    }
}