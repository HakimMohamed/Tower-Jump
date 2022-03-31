using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkPlatform : MonoBehaviour
{
    float Jumpforce = 64f;
    GameObject player;
 

    private void Awake()
    {
        player = GameObject.Find("Player");
       
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y<=0f&&collision.transform.tag=="Player")
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
