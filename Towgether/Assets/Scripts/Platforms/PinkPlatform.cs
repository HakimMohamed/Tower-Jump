using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinkPlatform : MonoBehaviour
{
    float Jumpforce = 64f;
    GameObject player;
    player playerscript;

   
    private void Start()
    {
        player = GameObject.Find("Player");
        playerscript = player.GetComponent<player>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.relativeVelocity.y <= 0f && collision.transform.tag == "Player" && playerscript.isGrounded && playerscript.timerForPowerUp > 0)
        {
            player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * playerscript.jumpforce * 1.4f, ForceMode2D.Impulse);

            playerscript.Dust2.Play();
            SoundManager.PlaySound(SoundManager.Sound.Jump);
        }
       else if (collision.relativeVelocity.y<=0f&&collision.transform.tag=="Player")
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
