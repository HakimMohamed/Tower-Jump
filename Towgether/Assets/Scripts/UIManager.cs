using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
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
    [SerializeField] GameObject FirstPlatform;
    [SerializeField] GameObject PauseButtonObject;
    //Transform
    Transform positionTORestart;
    Transform Player_transform;
    Rigidbody2D rb;

    bool IsGameLost;

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
        Tilt.SetActive(true);

    }


    void Update()
    {
        if (Input.anyKey)
        {
            GameStarted();
            lvlgenscript.enabled = true;
            Tilt.SetActive(false);
        }
        if (Player_transform.transform.position.y < positionTORestart.position.y) 
        {
             GameLost();
        }
    }
    private void GameStarted()
    {
        Debug.Log("GameStarted");
        Time.timeScale = 1f;
        rb.bodyType = RigidbodyType2D.Dynamic;
        PauseButtonObject.SetActive(true);

    }
    private void GameLost()
    {
        GameOverMenu.SetActive(true);
        Debug.Log("Lost");
        PlayerScript.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        IsGameLost = true;
        PauseButtonObject.SetActive(false);
    }
  
    public void PauseButton()
    {
        if (!IsGameLost)
        {
            Time.timeScale = 0f;
            PlayerScript.enabled = false;
            rb.bodyType = RigidbodyType2D.Static;
            PauseMenu.SetActive(true);
            PauseButtonObject.SetActive(false);

        }
    }
    public void ResumeButton()
    {
        Time.timeScale = 1f;
        PlayerScript.enabled = true;
        rb.bodyType = RigidbodyType2D.Dynamic;
        PauseMenu.SetActive(false);
        PauseButtonObject.SetActive(true);
    }
    public void RestartButton()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene("base");
    }
        
    public void MainMenuButton()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
