using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class camera : MonoBehaviour
{
   
    [SerializeField] Transform player;
    [SerializeField] Transform Position_For_Camera_To_start_Moving;

    float SmoothSpeed = .3f;
    Vector3 currentvelocity;
    bool playerStartedPlaying;
    public enum Diffculty { easy, medium, hard, impossible }
    float timer;
    float CameraMoveSpeed = 9f;

   
   
    private void Start()
    {
        playerStartedPlaying = false;
        timer = 0f;
        setDiffculty(Diffculty.easy);

    }


    void LateUpdate()
    {
        timer += Time.deltaTime;
        if (player.position.y >= Position_For_Camera_To_start_Moving.position.y)
        {
            playerStartedPlaying = true;
            if (playerStartedPlaying)
                setDiffculty(GetDiffculty());
        }
        

        UpdateCameraPosition();

        
    }
    void UpdateCameraPosition()
    {

        if (player.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, player.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, newPos, ref currentvelocity, SmoothSpeed * Time.deltaTime);
        }
    }
    
    private void setDiffculty(Diffculty diffculty)
    {
        switch (diffculty)
        {
            case Diffculty.easy:             
                 transform.position += new Vector3(0, CameraMoveSpeed, 0) * Time.deltaTime;
                
                break;

            case Diffculty.medium:           
                 transform.position += new Vector3(0, CameraMoveSpeed+2f, 0) * Time.deltaTime;
                
                break;

            case Diffculty.hard:
                transform.position += new Vector3(0, CameraMoveSpeed + 3f, 0) * Time.deltaTime;
                
                break;

            case Diffculty.impossible:               
                transform.position += new Vector3(0, CameraMoveSpeed + 5f, 0) * Time.deltaTime;
                
                break;
        }
    }
    private Diffculty GetDiffculty()
    {
        if (timer >= 44) return Diffculty.impossible;
        if (timer >= 25) return Diffculty.hard;      
        if (timer  >= 10) return Diffculty.medium;   

       return Diffculty.easy;
    }
      
}
