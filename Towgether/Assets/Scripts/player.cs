using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField]public ParticleSystem Dust;
    [SerializeField]public ParticleSystem Dust2;
    
    Rigidbody2D rb;
   
    SpriteRenderer sp;

    [Header("GroundCheck")]
    [SerializeField] Transform GroundCheckPosition;
    [SerializeField] LayerMask WhatIsGround;
    [SerializeField] float CheckRaidus = 1f;
    [SerializeField] public bool isGrounded;

    [Header("jumping")]
    [SerializeField] float movementSpeed = 16.8f;
    [SerializeField] float movement = 0f;
    [SerializeField] public float jumpforce = 30f;
    [SerializeField] bool Jumprequest;
   // [SerializeField] float fallmutliplier = 16.4f;
   // [SerializeField] float lowJumpMutliplier = 7.7f;

    [Header("PowerUp")]
    [SerializeField]public float timerForPowerUp;
    [SerializeField] float timerForPowerUpMax;
   


    [Header("Boost")]
    [SerializeField] public float BoostCapacity;
    [SerializeField] float BoostCapacityMax;
    [SerializeField] BoostBar boostScript;
    [SerializeField] float BoostCooldown;
    [SerializeField] float BoostCooldownMax;
    [SerializeField] bool increaseBoost ;

    int Arrows;
    int Tilt;
    int direction;



    private void Awake()
    {
        Arrows = PlayerPrefs.GetInt("Arrows", 0);
        Tilt = PlayerPrefs.GetInt("Tilt", 0);

        
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();       
        BoostCapacityMax = 1f;
        BoostCapacity= 0f;
        BoostCooldownMax = 5f;
        increaseBoost = true;
        BoostCooldown += BoostCooldownMax;
        boostScript.SetMaxBoost(BoostCapacityMax);
        timerForPowerUpMax = 5f;
        SoundManager.initialize();
        boostScript.setboost(0f);
    }

   public void HandleBoostUsage()
    {

        if (Arrows==1 && Input.touchCount==2&&Tilt != 1 && BoostCapacity>0&&!increaseBoost|| Tilt==1&&Input.GetMouseButton(0) && BoostCapacity > 0 && !increaseBoost&&Arrows!=1)
        {
            rb.gravityScale = 1f;
            BoostCapacity -= Time.deltaTime;
            rb.AddForce(170f*Time.deltaTime*Vector2.up, ForceMode2D.Impulse);
            Dust.Play();
            if (BoostCapacity <= 0)
            {
                Dust.Stop();
                rb.gravityScale = 14f;
            }
        }
        else
        {
            
             rb.gravityScale = 14f;
             Dust.Stop();
            
        }

        if (rb.velocity.y >= 150f)
        {
            rb.gravityScale += Time.deltaTime*99f;
        }
       else if(rb.velocity.y < 20f)
        {
            rb.gravityScale = 14f;
        }
        
        if (BoostCapacity < 1f)
        {
            BoostCooldown -= Time.deltaTime;
            if (BoostCooldown <= 0f)
            {
                BoostCooldown += BoostCooldownMax;
                increaseBoost = true;
            }
        }
        if (increaseBoost)
        {
            if(BoostCapacity< BoostCapacityMax)
            BoostCapacity += Time.deltaTime;
            else if(BoostCapacity>=BoostCapacityMax)
            {
                increaseBoost = false; 
            }
        }
        
        boostScript.setboost(BoostCapacity);
    }


    public void LeftArrow()
    {
        Vector3 v = rb.velocity;
        v.x = Vector2.left.x*33f;
        rb.velocity = v;


        flip(true);
    }
    public void RightArrow()
    {
        Vector3 v = rb.velocity;
        v.x = Vector2.right.x * 33f;
        rb.velocity = v;
        flip(false);
    }
    public void StopMoving()
    {

        rb.velocity = new Vector2(0.001f,rb.velocity.y);
    }
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheckPosition.position, CheckRaidus, WhatIsGround);

       
        if (Tilt == 1)
        {
            movement = Input.acceleration.x * movementSpeed;
            rb.velocity = new Vector2(movement, rb.velocity.y);
            Handlingflip();
        }

        

       
   
       

        //movement = Input.GetAxisRaw("Horizontal")*movementSpeed;
        

       




        HandleBoostUsage();
        timeForPowerUpHandler();

       
    }
   
   
    
   
   
    void timeForPowerUpHandler()
    {
        if (timerForPowerUp > 0)
        {
            timerForPowerUp -= Time.deltaTime;
        }
        if (timerForPowerUp <= 0)
        {
            timerForPowerUp = 0f;
        }
    }
    void Handlingflip()
    {
        if (movement < 0)
        {
            flip(true);
           
        }
        else
        {
            flip(false);
           
        }

    }
    void flip(bool IsLookingLeft)
    {

        sp.flipX = IsLookingLeft;
       
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Arrow"))
        {
           

            timerForPowerUp += timerForPowerUpMax;

            SoundManager.PlaySound(SoundManager.Sound.PowerUp);
        }
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }

}
