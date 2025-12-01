using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public GameManager gameManager;
    public void Setup() {
        gameObject.SetActive(true);
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
