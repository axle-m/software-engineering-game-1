using UnityEngine;
using TMPro;

public class CountdownScript : MonoBehaviour
{
    public float timeRemaining = 90f;
    public TextMeshProUGUI timerText;
    public WinScript winner;
    // Update is called once per frame
    void Update()
    {
        if(timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            DisplayTime(timeRemaining);
        }
        else
        {
            timeRemaining = 0;
            DisplayTime(timeRemaining);
            Debug.Log("win");
            winner.Setup();
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("Time Remaining: {0:00}:{1:00}", minutes, seconds);
    }
}
