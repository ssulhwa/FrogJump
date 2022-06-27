using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vAxisY = new Vector3(0f, 1f, 0f);

        transform.RotateAround(vAxisY, Vector3.up, 100 * Time.deltaTime);

        transform.right = new Vector3(1f, 0f, 0f);
        transform.up    = new Vector3(0f, 1f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.OnplayerDead();

        Destroy(gameObject);
    }
}
