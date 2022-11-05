using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class BattleMenu : MonoBehaviour
{
    public GameObject battleMenu;
    public bool isActive;
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public Text timeText;
    public float firstNumber = 10;
    public float secondNumber = 10;


    // Start is called before the first frame update
    void Start()
    {
        battleMenu.SetActive(false);
        timerIsRunning = false;
    }
    // Update is called once per frame
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "redKid")
        {
            battleMenu.SetActive(true);
            timerIsRunning = true;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        battleMenu.SetActive(false);
        timerIsRunning = false;

    }

}
