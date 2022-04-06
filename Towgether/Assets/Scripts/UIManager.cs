using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{


    //scripts
    player PlayerScript;
    levelgen lvlgenscript;
    //GameObjects
    [SerializeField] GameObject GameOverMenu;
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject Tilt;
    [SerializeField] GameObject PauseButtonObject;
    [SerializeField] GameObject BoostBar;
    [SerializeField] GameObject pressAnyWhereToStart;
    [SerializeField] GameObject ScoreText;
    [SerializeField] GameObject Camera;
    [SerializeField] GameObject WatchAdToContinue;
    [SerializeField] AdsManager ads;
    //Transform
    Transform positionTORestart;
    Transform Player_transform;
    Rigidbody2D rb;

   public bool IsGameLost;
    bool IsGameStarted;
    bool Ispaused;
    bool AfterAdd;

  

    private void Start()
    {
        
        WatchAdToContinue.SetActive(true);
    }

    void Awake()
    {
       
        //Refrences
        PlayerScript = GameObject.Find("Player").GetComponent<player>();
        positionTORestart = GameObject.Find("PositionToRestart").transform;
        Player_transform = GameObject.Find("Player").transform;
        rb = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        lvlgenscript = GameObject.Find("LevelGenerator").GetComponent<levelgen>();
        PlayerScript.enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        GameOverMenu.SetActive(false);
        lvlgenscript.enabled = false;
        pressAnyWhereToStart.SetActive(false);
        ScoreText.SetActive(false);
        PauseMenu.SetActive(false);
        IsGameStarted = false;
        Ispaused = false;
        AfterAdd = false;
        IsGameLost = false;
    }

    void GameStartedMainCameraEvent()
    {
        BoostBar.SetActive(true);
        Tilt.SetActive(true);
        pressAnyWhereToStart.SetActive(true);
      


    }
    void Update()
    {
        Time.timeScale = 1f;
        if (Input.anyKey&& !IsGameStarted)
        {
            
            IsGameStarted=true;
        }
        if (IsGameStarted&& !Ispaused)
        {
            GameStarted();
        }
        if (Player_transform.transform.position.y < positionTORestart.position.y) 
        {
            IsGameLost = true;
            GameLost();
        }
        if (Player_transform.transform.position.y>5f)
        {
            ScoreText.SetActive(true);
            Tilt.SetActive(false);

        }


        if (AfterAdd)
        {
            Player_transform.transform.position = new Vector2(Camera.transform.position.x, Camera.transform.position.y);
            Debug.Log(AfterAdd);
             
            if(Input.anyKey)
            AfterAdd = false;
            
        }

    }
    public void WatchAddTocontinueButton()
    {
        AfterAdd = true;
        ads.PlayRewardedAd(RewardAfterAd);

    }
    void RewardAfterAd()
    {
      
            Time.timeScale = 1f;
            GameOverMenu.SetActive(false);
            PlayerScript.enabled = true;
            rb.bodyType = RigidbodyType2D.Dynamic;
            IsGameLost = false;
            PauseButtonObject.SetActive(true);
            BoostBar.SetActive(true);
       
            Debug.Log("NUll");
       

    }
    private void GameStarted()
    {
        Time.timeScale = 1f;
        rb.bodyType = RigidbodyType2D.Dynamic;
        PauseButtonObject.SetActive(true);
        lvlgenscript.enabled = true;
        
    }
   
    private void GameLost()
    {
        if (IsGameLost)
        {
            Time.timeScale = 1f;
            GameOverMenu.SetActive(true);
            PlayerScript.enabled = false;
            rb.bodyType = RigidbodyType2D.Static;
            IsGameLost = true;
            PauseButtonObject.SetActive(false);
            BoostBar.SetActive(false);
        }
       
    }

    public void PauseButton()
    {
        if (IsGameLost==false)
        {
            Ispaused=true;
            Camera.GetComponent<camera>().enabled = false;
            PlayerScript.enabled = false;
            rb.bodyType = RigidbodyType2D.Static;
            PauseMenu.SetActive(true);
            PauseButtonObject.SetActive(false);
            Debug.Log("Paused");
        }
    }
    public void ResumeButton()
    {
        Camera.GetComponent<camera>().enabled = true;
        Time.timeScale = 1f;
        PlayerScript.enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        PauseMenu.SetActive(false);
        PauseButtonObject.SetActive(true);
        Debug.Log("Pressed");
    }
    public void RestartButton()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("base");
    }
        
    public void MainMenuButton()
    {
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1f;
    }




   

    


}
