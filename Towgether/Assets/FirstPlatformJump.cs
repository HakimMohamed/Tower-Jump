using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlatformJump : MonoBehaviour
{
    float Jumpforce = 64f;
    GameObject player;
    Animator anim;
    
    private void Awake()
    {
        player = GameObject.Find("Player");
        anim = player.GetComponent<Animator>();
    }
    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f && collision.transform.tag == "Player")
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = Jumpforce;
                rb.velocity = velocity;
                anim.SetTrigger("Jump");
                Destroy(gameObject, 20f);
            }


        }
    }
    
}
