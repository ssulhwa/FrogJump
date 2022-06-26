using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    private bool eat = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            eat = true;
            GameManager.instance.AddScore(100);

            Destroy(gameObject);
        }
    }

}
