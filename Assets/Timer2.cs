using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer2 : MonoBehaviour
{
    public float timeRemaining = 10;
    public bool timerIsRunning = false;
    public TextMeshPro countdownText;

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
                countdownText.text = timeRemaining.ToString();
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                SceneManager.LoadScene("Lost");
            }
        }
    }
}