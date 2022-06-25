using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private enum ROTATE 
    { 
        ROTATE_CW, 
        ROTATE_CCW, 
        ROTATE_END
    }

    private ROTATE eState;

    private float fRotateSpeed = 0f;
    private float fAngleZ      = 0f;

    // 화살표 속도 : 1f ~ 3f;
    // public으로 풀면 이상해짐 이유는 몰?루
    private float fRPS         = 1.5f;
     
    private bool bStop = false;

    // Start is called before the first frame update
    void Start()
    {
        eState = ROTATE.ROTATE_CW;
        transform.Rotate(0, 0, 350);
    }
    
    // Update is called once per frame
    void Update()
    {
        if(false == bStop)
        {
            fRotateSpeed = Time.deltaTime * 90 * fRPS;
            fAngleZ      = transform.eulerAngles.z;

            ArrowBehavior();
        }
    }

    public void Stop()
    {
        bStop = true;
    }

    private void ArrowBehavior()
    {
        switch (eState)
        {
            case ROTATE.ROTATE_CW:

                transform.Rotate(0, 0, fRotateSpeed * -1);

                if(Mathf.Clamp(fAngleZ, 271f, 359f) <= 271f)
                {
                    eState = ROTATE.ROTATE_CCW;
                }

                break;

            case ROTATE.ROTATE_CCW:

                transform.Rotate(0, 0, fRotateSpeed);

                if (Mathf.Clamp(fAngleZ, 271f, 359f) >= 359f)
                {
                    eState = ROTATE.ROTATE_CW;
                }

                break;
        }
    }
}
