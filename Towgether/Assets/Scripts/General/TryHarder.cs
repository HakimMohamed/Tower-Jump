using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TryHarder : MonoBehaviour
{
   bool GameStarted;
   float timer;
   [SerializeField] Text StartText;
   [SerializeField] GameObject PressAnykeyObject;
   [SerializeField] player player;
   
    private void Start()
    {
        PressAnykeyObject.SetActive(true);
        GameStarted = false;
        timer = 0.1f;
    }
    void Update()
    {
        if (Input.anyKey) {
            GameStarted=true;
        }
        if (GameStarted)
        {
            timer-= Time.deltaTime;
        }
        
        if (timer <= 0)
        {

            PressAnykeyObject.SetActive(false);
        }
        
    }
}
