using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlatformJump : MonoBehaviour
{
    bool GameStarted;
    float Jumpforce = 64f;
    GameObject player;
    player playerscript;
   
    private void Start()
    {
        GameStarted = false;
        player = GameObject.Find("Player");
        playerscript = player.GetComponent<player>();
    }
    private void Update()
    {
        if (Input.anyKey)
        {
            GameStarted=true;   
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        
         if (collision.relativeVelocity.y <= 0f && collision.transform.tag == "Player"&&GameStarted)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = Jumpforce;
                rb.velocity = velocity;

                SoundManager.PlaySound(SoundManager.Sound.Jump);
            }


        }

    }

}
