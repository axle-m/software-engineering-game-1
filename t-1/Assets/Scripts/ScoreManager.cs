using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static  ScoreManager instance; 

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalText;
    public TextMeshProUGUI winScoreText;
    private int currentScore = 0;

    void Awake()
    {
        //singleton use
        if(instance == null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText();
    }

    public void IncrementScore()
    {
        currentScore++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if(scoreText != null)
        {
            scoreText.text = "Killcount: " + currentScore.ToString();
            finalText.text = "Killcount: " + currentScore.ToString();
            winScoreText.text = "Final Killcount: " + currentScore.ToString();
        }
    }
    
    public int getCurrentScore(){
        return currentScore;
    }

    public void resetScore(){   
        currentScore = 0;
        UpdateScoreText();
    }
}
