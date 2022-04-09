using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TowegetherWord : MonoBehaviour
{
    [SerializeField] Text Tower;
    [SerializeField] Text Together;
    [SerializeField] GameObject PinkPlayer;
    float A_Tower;
    Vector4 V_Tower;
    float A_Together;
    Vector4 V_Together;

    bool FlareToStart;
    void Start()
    {
        
        FlareToStart = false;
    }

    private void Update()
    {
        if (FlareToStart)
        {
            A_Tower = Tower.color.a;
            A_Tower -= Time.deltaTime*2f;
            V_Tower = new Vector4(Tower.color.r, Tower.color.g, Tower.color.b, A_Tower);
            Tower.color = V_Tower;

            A_Together = Tower.color.a;
            A_Together -= Time.deltaTime*2f;
            V_Together = new Vector4(Together.color.r, Together.color.g, Together.color.b, A_Together);
            Together.color = V_Together;

            if (A_Tower<=0)
            {
                PinkPlayer.SetActive(false);
            }
        }
    }

    public void Towgether()
    {     
        FlareToStart = true;
    }
    
}
