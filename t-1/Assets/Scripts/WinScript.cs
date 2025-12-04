using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public ScoreManager score;

    public void Setup() {
        gameObject.SetActive(true);
        score.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
    }
    public void RestartButton(){
        SceneManager.LoadScene("SampleScene");

    }
    public void MenuButton(){
        SceneManager.LoadScene("StartMenu");
    }
}
