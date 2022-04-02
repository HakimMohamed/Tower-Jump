using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CoinsHandler : MonoBehaviour
{
    [SerializeField] Text CoinsText;
    int CurrentScore;
    private void Awake()
    {

        CurrentScore = PlayerPrefs.GetInt("CurrentScore", 0);
        CoinsText.text = CurrentScore.ToString();
    }
    

    void Update()
    {
        CurrentScore = PlayerPrefs.GetInt("CurrentScore", 0);
        CoinsText.text = CurrentScore.ToString();

    }
}
