using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{


    
    private void OnTriggerEnter2D(Collider2D col)
    {

        Debug.Log("Arrow");
        Destroy(gameObject);
        Instantiate(GameAssets.Getinstance().Explosion, gameObject.transform.position, Quaternion.identity);
    }

}
