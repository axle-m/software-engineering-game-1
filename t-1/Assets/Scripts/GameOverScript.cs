using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI scoreText;
    public CountdownScript countdown;
    public TextMeshProUGUI timerText;
    public ScoreManager score;

    public void Setup() {
        gameObject.SetActive(true);
        score.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        countdown.gameObject.SetActive(false);
    }
    public void RestartButton(){
        SceneManager.LoadScene("SampleScene");

    }
    public void ExitButton(){
        SceneManager.LoadScene("StartMenu");
    }
}
