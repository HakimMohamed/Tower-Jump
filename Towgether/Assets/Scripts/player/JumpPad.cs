using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    Animator anim;
   
    float bounce = 120f;
   
    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            anim.SetTrigger("Jumped");
            SoundManager.PlaySound(SoundManager.Sound.JumpPad);


        }
    }
}
