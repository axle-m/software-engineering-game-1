using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverScript : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI scoreText;

    public void Setup() {
        gameObject.SetActive(true);
        scoreText.gameObject.SetActive(false);
    }
    public void RestartButton(){
        SceneManager.LoadScene("SampleScene");
        gameManager.HealPlayer(100);

    }
    public void ExitButton(){
        SceneManager.LoadScene("StartMenu");
        gameManager.HealPlayer(100);
    }
}
