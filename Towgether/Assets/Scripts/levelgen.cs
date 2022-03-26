using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelgen : MonoBehaviour
{
    Vector3 startPosition1 = new Vector3(0f, 122f, 0f);
    

    Vector3 firstPlatforms =new Vector3(0,10f,0);
   
    float Timer;
    float maxTimer;
    List<Platform> PlatformList;
    bool GameStarted;
    [SerializeField] private Transform PositionToDelete;
    [SerializeField] Transform player;
    int counter_To_Spawn_JumpPad;
    int random_num_to_spawn_ToChoose_jumppad;

    int Counter_for_platforms;
    int RandomForTypeOfPlatform;
    float yRangeRandom = 10f;
    float yRangeRandom2 = 12f;
    [SerializeField] Rigidbody2D rb;

    public enum PlatformEnum { platform,  woodPlatform, pinkplatform, OutlinePlatformPlatform, DissolvingPlatform }


    float timerForGapSize;
    
    private void Awake()
    {
        PlatformList = new List<Platform>();
        maxTimer = 0.20f;
        GameStarted = false;
        Counter_for_platforms = 0;
        RandomForTypeOfPlatform = 0;
        setPlatform(PlatformEnum.platform);
        
    }
    
   Vector2 RandomGap()
    {
        if (Counter_for_platforms > 180) return new Vector2(5.5f, 6.5f);
        if (Counter_for_platforms > 120) return new Vector2(6.5f,7f );
        if (Counter_for_platforms > 40)return new Vector2(7,8);
        

        return new Vector2(10, 11);
    }
    private void Start()
    {
        //Transform playGroundPlatform = Instantiate(GameAssets.Getinstance().platform, new Vector3(0,0,-3f), Quaternion.identity);
        //SpriteRenderer spboxColliderplayGroundPlatform = playGroundPlatform.GetComponent<SpriteRenderer>();
        //BoxCollider2D boxColliderplayGroundPlatform = playGroundPlatform.GetComponent<BoxCollider2D>();
        //spboxColliderplayGroundPlatform.size = new Vector2(7f, 1f);
        //boxColliderplayGroundPlatform.size = new Vector2(7f - 1f, 0.14f);
        //boxColliderplayGroundPlatform.offset = new Vector2(0, 0);

        for (int i = 0; i < 10; i++)
        {
            Transform platform1 = Instantiate(GameAssets.Getinstance().platform, firstPlatforms, Quaternion.identity);    
            SpriteRenderer sp = platform1.GetComponent<SpriteRenderer>();
            BoxCollider2D boxCollider2D = platform1.GetComponent<BoxCollider2D>();

            firstPlatforms.x = Random.Range(-10f,10f);         
            firstPlatforms.y += Random.Range(yRangeRandom, yRangeRandom2);
            float RandomNumber = Random.Range(10f,11f);
            sp.size = new Vector2(RandomNumber, 1f);
            boxCollider2D.size = new Vector2(RandomNumber-1f, 0.14f);
            boxCollider2D.offset = new Vector2(0, 0);

            Platform platform = new Platform(platform1);
            PlatformList.Add(platform);
            if (i <= 20)
            {
                HandleJumpPadSpawn(platform1);
            }
        }
    }

    void Update()
    {

        HandlePlatFormDeletion();
        SpawnTimer();
        RandomGap();
    }
    void HandlePlatFormDeletion()
    {
        for (int i = 0; i < PlatformList.Count; i++)
        {
            Platform platform = PlatformList[i];
                if (platform.GetYposition() < PositionToDelete.position.y)
                {
                    platform.DestroySelf();
                    PlatformList.Remove(platform);
                    i--;
                }
            
        }
       
    }
    void SpawnTimer()
    {
        if (player.position.y>15f)
        {
            GameStarted = true;
        }
        if (GameStarted)
        {
            Timer -= Time.deltaTime;
            
           if (Timer <= 0&&rb.velocity.y<120f)
            {
              
                setPlatform(GetPlatform());
                Timer += maxTimer;
            }
          else  if (rb.velocity.y > 150f)
            {
                setPlatform(GetPlatform());
            }
        }
    }
    
    void CreatePlatform(Vector3 SpawnPosition1, Transform platform1)
    {
        

         platform1 = Instantiate(platform1,SpawnPosition1, Quaternion.identity);
        SpriteRenderer sp = platform1.GetComponent<SpriteRenderer>();
        BoxCollider2D boxCollider2D = platform1.GetComponent<BoxCollider2D>();

        SpawnPosition1.x = Random.Range(-10f, 10f);       
        SpawnPosition1.y += Random.Range(yRangeRandom, yRangeRandom2);

        float RandomNumber = Random.Range(RandomGap().x,RandomGap().y);
        sp.size = new Vector2(RandomNumber, 1f);
        boxCollider2D.size = new Vector2(RandomNumber - 1f, 0.14f);
        boxCollider2D.offset = new Vector2(0, 0);

        startPosition1 = SpawnPosition1;
       
        Platform platform = new Platform(platform1);
        PlatformList.Add(platform);
        HandleJumpPadSpawn(platform1);
        Counter_for_platforms++;


    }
    void HandleJumpPadSpawn(Transform platform1)
    {
        counter_To_Spawn_JumpPad++;
        random_num_to_spawn_ToChoose_jumppad = Random.Range(1, 7);
        switch (random_num_to_spawn_ToChoose_jumppad)
        {
            case 1:
                if (counter_To_Spawn_JumpPad % 4 == 0)
                {
                   
                    //instantiate jump pad
                    Transform JumpPad = Instantiate(GameAssets.Getinstance().Jump_pad);
                    
                    JumpPad.position = platform1.position;
                    JumpPad.position += new Vector3(0, 1.15f, 0);
                    JumpPad.SetParent(platform1);
                }
                break;
            case 2:
                if (counter_To_Spawn_JumpPad % 3 == 0)
                {

                    Transform Trap = Instantiate(GameAssets.Getinstance().Trap);
                   
                    Trap.position = platform1.position;
                    Trap.position += new Vector3(1.38f, 1.77f, 0);
                    Trap.SetParent(platform1);
                }
                break;
            case 3:
                if (counter_To_Spawn_JumpPad % 5 == 0)
                {

                    Transform PowerUp = Instantiate(GameAssets.Getinstance().PowerUp);
                    
                    PowerUp.position = platform1.position;
                    PowerUp.position += new Vector3(0, 1.64f, 0);
                    PowerUp.SetParent(platform1);
                }
                break;           

        }
    }

    private void setPlatform(PlatformEnum diffculty)
    {
        switch (diffculty)
        {
            case PlatformEnum.platform:
                
                CreatePlatform(startPosition1, GameAssets.Getinstance().platform);
                break;

           

            case PlatformEnum.pinkplatform:
                
                CreatePlatform(startPosition1, GameAssets.Getinstance().WoodPlatform);
                break;

            case PlatformEnum.OutlinePlatformPlatform:
                
                CreatePlatform(startPosition1,GameAssets.Getinstance().DissolvingPlatform);
                break;
            case PlatformEnum.woodPlatform:
                
                CreatePlatform(startPosition1,  GameAssets.Getinstance().OutlinePlatformPlatform);
                break;

            case PlatformEnum.DissolvingPlatform:
                
                CreatePlatform(startPosition1, GameAssets.Getinstance().PinkPlatform);
                break;

            
        }
    }
    private PlatformEnum GetPlatform()
    {
        
        if (Counter_for_platforms%15==0)
            RandomForTypeOfPlatform = Random.Range(0,5);
        
        
            if (RandomForTypeOfPlatform == 1) return PlatformEnum.DissolvingPlatform;
            if (RandomForTypeOfPlatform == 2) return PlatformEnum.woodPlatform;
            if (RandomForTypeOfPlatform == 3) return PlatformEnum.platform;
            if (RandomForTypeOfPlatform == 4) return PlatformEnum.pinkplatform;
            

         return PlatformEnum.OutlinePlatformPlatform;
        
    }
    private class Platform
    {
        private Transform platform;
        
        public Platform(Transform platform)
        {
            this.platform = platform;
          
        }
        public float GetYposition()
        {
            return platform.position.y;
        }
        public void DestroySelf()
        {
            Destroy(platform.gameObject);
           
        }

    }

    
}
