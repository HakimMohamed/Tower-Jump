using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Text HighScoreText;
    [SerializeField] UIManager manager;
    Text score;
    int highScore;
    int scorenum;
    string highScoreKey = "HighScore";

    int oldScore;

    int CurrentScore;
    void AddScore()
    {
        scorenum++;
    }
    void AddGold()
    {
        CurrentScore += Random.Range(2,6);
        PlayerPrefs.SetInt("CurrentScore", CurrentScore);
        PlayerPrefs.Save();
        
    }
    private void Awake()
    {
        oldScore = PlayerPrefs.GetInt("CurrentScore", 0);
        PlayerPrefs.SetInt("oldScore", PlayerPrefs.GetInt("CurrentScore"));
        score = GetComponent<Text>();
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        HighScoreText.text = highScore.ToString();
        CurrentScore = PlayerPrefs.GetInt("CurrentScore", 0);
        InvokeRepeating(nameof(AddGold),2.5f,1f);
    }
    void Update()
    {
       
        if (player.position.y > 0 && player.position.y > scorenum)
        {
            AddScore();
            
            
        }

        score.text = scorenum.ToString("0").Normalize();
        //If our scoree is greter than highscore, set new higscore and save.

        if (scorenum > highScore)
        {

            PlayerPrefs.SetInt(highScoreKey, scorenum);
            PlayerPrefs.Save();
            HighScoreText.text = scorenum.ToString();
            
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            PlayerPrefs.DeleteAll();
        }
       
        

    }
}
