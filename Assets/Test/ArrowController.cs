using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    float fRotateSpeed = 0.7f;

    bool bRotate  = true;
    bool bStop    = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(true == bRotate && false == bStop)
        {
            transform.Rotate(0, 0, fRotateSpeed * -1);
        }
        else if(false == bRotate && false == bStop)
        {
            transform.Rotate(0, 0, fRotateSpeed);
        }

        float fAngleZ = transform.eulerAngles.z;

        if (fAngleZ >= 269f && fAngleZ <= 270f)
        {
            bRotate = false;
        }
        if(fAngleZ >= 0f && fAngleZ <= 1f)
        {
            bRotate = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            bStop = true;
        }
    }
}
