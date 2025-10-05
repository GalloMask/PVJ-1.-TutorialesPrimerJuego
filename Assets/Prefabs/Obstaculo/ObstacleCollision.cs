using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Está colisionando");
        
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
    }
}