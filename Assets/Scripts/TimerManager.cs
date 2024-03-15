using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }
    public TextMeshProUGUI timerText;
    public float timeRemaining = 10;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        SetTimerText();
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene("Menu");
        }
    }

    void SetTimerText()
    {
        // Format the timeRemaining to two decimal places
        string formattedTime = timeRemaining.ToString("0.##");

        timerText.text = "Time remaining to get all yellows: " + formattedTime;
    }
}