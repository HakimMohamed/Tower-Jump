using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolvingPlatform : MonoBehaviour
{
    SpriteRenderer sp;
    float alpha = 0.5f;
    bool IsUsed;
    private void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        alpha = 1;
        IsUsed = false;
        sp.color = new Color(1, 1, 1, 0.5f);
    }
    private void Update()
    {
        if (IsUsed)
        {
            alpha -= Time.deltaTime;
            sp.color = new Color(1, 1, 1, alpha);
        }
        if (alpha <= 0)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false; 
        }
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {

            IsUsed = true;


        }
    }
}
