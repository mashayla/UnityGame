using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    
    public float timeRemaining = 60;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;

    // starts timer
    void Start()
    {
        timerIsRunning = true;
    }

    // Update is called once per frame
    void Update() // timer begins countdown
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else //transition..game over
            {
                
                Debug.Log("Time has run out...You Died"); 
                timeRemaining = 0;
                timerIsRunning = false;
                SceneManager.LoadScene("Lost Game");
            }
        }
    }

    void DisplayTime(float timeToDisplay) //converts and displays time
    {
        timeToDisplay +=1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes,seconds);
    }
}
