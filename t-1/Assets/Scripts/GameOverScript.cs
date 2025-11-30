using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    public void Setup() {
        gameObject.SetActive(true);
    }
    public void RestartButton(){
        SceneManager.LoadScene("SampleScene");
    }
    public void ExitButton(){
        SceneManager.LoadScene("StartMenu");
    }
}
