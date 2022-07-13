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
    private float fRPS         = 2f;
     
    private bool bStop = false;

    private Vector3 vPlayerPos;

    // Start is called before the first frame update
    void Start()
    {
        eState = ROTATE.ROTATE_CW;
        transform.Rotate(0, 0, 0);    
    }
    
    // Update is called once per frame
    void Update()
    {
        if(false == bStop)
        {
            fRotateSpeed = Time.deltaTime * 90 * fRPS;
            fAngleZ      = transform.eulerAngles.z;

            //ArrowBehavior_A();
            ArrowBehavior_B();
        }
    }

    public void Stop()
    {
        bStop = true;
    }

    private void ArrowBehavior_A()
    {
        switch (eState)
        {
            case ROTATE.ROTATE_CW:

                transform.Rotate(0, 0, fRotateSpeed * -1);

                if (fAngleZ >= 275f && fAngleZ <= 280f)
                {
                    eState = ROTATE.ROTATE_CCW;
                }

                break;

            case ROTATE.ROTATE_CCW:

                transform.Rotate(0, 0, fRotateSpeed);

                if (fAngleZ >= 80f && fAngleZ <= 85f)
                {
                    eState = ROTATE.ROTATE_CW;
                }

                break;
        }
    }

    private void ArrowBehavior_B()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 vMouseWorldPos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float fSize = Vector3.Magnitude(transform.position - vMouseWorldPos);

            float fNewSize = Mathf.Clamp((fSize - 10f) * 3f, 0.1f, 1.0f);

            Vector3 vDir = Vector3.Normalize(transform.position - vMouseWorldPos);

            Vector3 vLook  = new Vector3(0f, 0f, 1f);
            Vector3 vRight = Vector3.Cross(vDir, vLook);
            
            transform.up    = vDir;
            transform.right = vRight;
            
            transform.localScale = new Vector3(1f, fNewSize, 1f);
        }
    }

    public void SetPlayerPos(Vector3 playerPos)
    {
        vPlayerPos = playerPos;
    }

    public void AngleCorrection()
    {
        if (fAngleZ > 80f && fAngleZ < 280f)
        {
            transform.up = new Vector3(0f, 1f, 0f);
            transform.right = new Vector3(1f, 0f, 0f);
        }
    }
}
