using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;

    public void Setup() {
        gameObject.SetActive(true);
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
