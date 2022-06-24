using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeController : MonoBehaviour
{
    private Transform bar;

    bool bMove = false;
    bool bStop = false;

    float fMin   = 0.1f;
    float fCurrentX = 0f;

    // Start is called before the first frame update
    void Start()
    {
        bar = transform.Find("Bar");
    }

    // Update is called once per frame
    void Update()
    {
        if(false == bStop)
        {
            fCurrentX = bar.localScale.x;

            if(false == bMove)
            {
                fCurrentX += Time.deltaTime;
                bar.localScale = new Vector3(fCurrentX, 1f);
            }
            else
            {
                fCurrentX -= Time.deltaTime;
                bar.localScale = new Vector3(fCurrentX, 1f);
            }

            if (fCurrentX <= fMin && fCurrentX >= fMin - 0.1f)
            {
                bMove = false;
            }
            if (fCurrentX >= 1f && fCurrentX <= 1.1f)
            {
                bMove = true;
            }
        }
    }

    public float GetSize()
    {
        return fCurrentX;
    }

    public void Stop()
    {
        bStop = true;
    }
}
