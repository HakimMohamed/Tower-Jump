using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPlatformJump : MonoBehaviour
{
    float Jumpforce = 64f;
    GameObject player;
    private static FirstPlatformJump instance;
    private void Awake()
    {
        player = GameObject.Find("Player");
      
    }
    private void Start()
    {
        
    }
    private void Update()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            DestroyImmediate(gameObject.GetComponent<FirstPlatformJump>());
        }
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
                Destroy(gameObject, 20f);
            }


        }
    }
    
}
