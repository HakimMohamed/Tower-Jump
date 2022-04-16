using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Text HighScoreText;
    [SerializeField] UIManager manager;
    [SerializeField] Text YournewHighesetScoreText;
    [SerializeField] Text GameoverToNewHighScore;
    Text score;
    int highScore;
    int scorenum;
    string highScoreKey = "HighScore";

    int oldScore;

    int CurrentScore;
    bool newHighscore;


    float timer;
    float timermax;
    void AddScore()
    {
       
        scorenum++;
        score.text = scorenum.ToString("0").Normalize();

    }
    void AddGold()
    {
        CurrentScore += Random.Range(2,6);
        PlayerPrefs.SetInt("CurrentScore", CurrentScore);
        PlayerPrefs.Save();
        
    }
    private void Start()
    {
        //PlayerPrefs.DeleteAll();
        oldScore = PlayerPrefs.GetInt("CurrentScore", 0);
        PlayerPrefs.SetInt("oldScore", PlayerPrefs.GetInt("CurrentScore"));
        score = GetComponent<Text>();
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        HighScoreText.text = highScore.ToString();
        CurrentScore = PlayerPrefs.GetInt("CurrentScore", 0);
        InvokeRepeating(nameof(AddGold), 2.5f, 1f);
        newHighscore = false;
        timer = 0.5f;
        timermax = 0.5f;
    }
   
    void Update()
    {
       
        if (player.position.y > 0 && player.position.y > scorenum)
        {
            AddScore();                      
        }

        //If our scoree is greter than highscore, set new higscore and save.

        if (scorenum > highScore)
        {
            newHighscore = true;
            PlayerPrefs.SetInt(highScoreKey, scorenum);
            PlayerPrefs.Save();
            HighScoreText.text = scorenum.ToString();
            GameoverToNewHighScore.text = "new HighScore";
            GameoverToNewHighScore.color = Color.white;

        }
        if (newHighscore)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                YournewHighesetScoreText.color = new Color(Random.Range(0, 255), Random.Range(0, 255), Random.Range(0, 255));
                timer += timermax;
            }
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            PlayerPrefs.DeleteAll();
        }
       
        

    }
}
