using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        MovableBlock();

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

}
