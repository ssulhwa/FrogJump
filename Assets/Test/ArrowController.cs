using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    // ÃÊ´ç ¿Õº¹ È½¼ö
    float fRPS = 1.5f;

    bool bRotate  = true;
    bool bStop    = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(false == bStop)
        {
            float fRotateSpeed = Time.deltaTime * 90 * fRPS;

            if (true == bRotate && false == bStop)
            {
                transform.Rotate(0, 0, fRotateSpeed * -1);
            }
            else if (false == bRotate && false == bStop)
            {
                transform.Rotate(0, 0, fRotateSpeed);
            }

            float fAngleZ = transform.eulerAngles.z;

            if (fAngleZ >= 268f && fAngleZ <= 270f)
            {
                bRotate = false;
            }
            if (fAngleZ >= 0f && fAngleZ <= 2f)
            {
                bRotate = true;
            }
        }
    }

    public void Stop()
    {
        bStop = true;
    }
}
