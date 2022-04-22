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
    [SerializeField] Transform HighestScore;
    [SerializeField] GameObject NewScoreText;

    int Arrows;
    int Tilt;
    int direction;
    bool iSholdingBoostButton;

    int hieghstScorePostion;
   
    private void Start()
    {
        Arrows = PlayerPrefs.GetInt("Arrows", 0);
        Tilt = PlayerPrefs.GetInt("Tilt", 0);

        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();

        NewScoreText.SetActive(false);
        BoostCapacityMax = 1f;
        BoostCapacity = 0f;
        BoostCooldownMax = 7f;
        increaseBoost = true;
        BoostCooldown += BoostCooldownMax;
        boostScript.SetMaxBoost(BoostCapacityMax);
        timerForPowerUpMax = 5f;
        SoundManager.initialize();
        boostScript.setboost(0f);
        hieghstScorePostion = PlayerPrefs.GetInt("HighScore", 0);
        Instantiate(HighestScore, new Vector2(0, hieghstScorePostion), Quaternion.identity);

        if (Arrows == 0&&Tilt==0)
        {
            Tilt = 1;
            PlayerPrefs.SetInt("Arrows", Tilt);
        }

    }
    public void HandleBoostUsage_Tilt()
    {
    
        if (Arrows == 1 && Input.touchCount == 2 && Tilt != 1 && BoostCapacity > 0 && !increaseBoost || Tilt == 1&&Input.GetMouseButton(0) && BoostCapacity > 0 && !increaseBoost&&Arrows!=1)
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


     void BoostButton()
    {
        if (Arrows == 1 && Tilt != 1 && BoostCapacity > 0 && !increaseBoost)
        {
            rb.gravityScale = 1f;
            BoostCapacity -= Time.deltaTime;
            rb.AddForce(170f * Time.deltaTime * Vector2.up, ForceMode2D.Impulse);
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
            if (BoostCapacity < BoostCapacityMax)
                BoostCapacity += Time.deltaTime;
            else if (BoostCapacity >= BoostCapacityMax)
            {
                increaseBoost = false;
            }
        }

        boostScript.setboost(BoostCapacity);
    }
    
    public void LeftArrow()
    {
        if (Input.touchCount < 2)
        {
            Vector3 v = rb.velocity;
            v.x = Vector2.left.x * 20f;
            rb.velocity = v;
        }
        if ( Input.touchCount >=2&&Arrows == 1 && Tilt != 1 && BoostCapacity > 0 && !increaseBoost)
        {
            BoostButton();
          
            
            
        }
        flip(true);
    }
    public void RightArrow()
    {
        if (Input.touchCount < 2 )
        {
            Vector3 v = rb.velocity;
            v.x = Vector2.right.x * 20f;
            rb.velocity = v;
        }
        if (Input.touchCount >= 2 &&Arrows == 1 && Tilt != 1 && BoostCapacity > 0 && !increaseBoost)
        {

            BoostButton();
           

           

        }
        flip(false);
    }

   
    public void StopMovingForLeftArrow()
    {

        rb.velocity = new Vector2(0f,rb.velocity.y);
    }
    public void StopMovingForRightArrow()
    {

        rb.velocity = new Vector2(0f, rb.velocity.y);
    }
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheckPosition.position, CheckRaidus, WhatIsGround);

       

        if (rb.velocity.y >= 120f)
        {
            rb.gravityScale += Time.deltaTime * 4444f;
        }
        else if (rb.velocity.y < 20f)
        {
            rb.gravityScale = 14f;
        }
        HandleBoostUsage_Arrows();
        timeForPowerUpHandler();
        HandleBoostUsage_Tilt();
       
    }
   void HandleBoostUsage_Arrows()
    {
        if (Tilt == 1)
        {
            movement = Input.acceleration.x * movementSpeed;
            rb.velocity = new Vector2(movement, rb.velocity.y);
            Handlingflip();
        }
        //movement = Input.GetAxisRaw("Horizontal")*movementSpeed;


        if (transform.position.y > hieghstScorePostion)
        {
            // new Score
            NewScoreText.SetActive(true);
        }
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
        if (movement <= 0)
        {
            flip(true);
           
        }
        else if(movement>0)
        {
            flip(false);
           
        }

    }
    void flip(bool IsLookingLeft)
    {

        sp.flipX = IsLookingLeft;
       
    }

    //player.GetComponent<Rigidbody2D>().AddForce(Vector2.up* playerscript.jumpforce* 1.6f, ForceMode2D.Impulse);

    //playerscript.Dust2.Play();
    //        SoundManager.PlaySound(SoundManager.Sound.Jump);
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Arrow"))
        {
           

            timerForPowerUp += timerForPowerUpMax;

            SoundManager.PlaySound(SoundManager.Sound.PowerUp);
        }
       
    }
    

}
