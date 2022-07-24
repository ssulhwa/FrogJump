using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private PlayerController Player;
    private bool isMoving = false;
    private bool stepped = false;

    private void OnEnable()
    {
        stepped = false;
    }

    void Start()
    {
        Player = GameObject.FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if(true == isMoving)
        {
            MovableBlock();
        }

        if(transform.position.y + 15f < UnityEngine.Camera.main.gameObject.transform.position.y)
        {
            Destroy(gameObject);
        }
    }

    void MovableBlock()
    {
        transform.RotateAround(Vector3.up, Vector3.up, 100 * Time.deltaTime);
        transform.right = Vector3.right;
    }

    public void SetMoveState()
    {
        isMoving = true;
    }
    public bool GetState()
    {
        return isMoving;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player.SetState(isMoving);

        if(gameObject.tag != "BeginGround")
        {
            if (collision.collider.tag == "Player" && !stepped)
            {
                
                if(collision.contacts[0].normal.y < -0.7f)
                {
                    stepped = true;
                    GameManager.instance.AddScore(100);
                }
            }
        }
    }
}
