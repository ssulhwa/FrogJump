using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour
{
    public ArrowController  Arrow;
    public GaugeController  Gauge;
    public PlayerController Player;

    int iClickCount = 0;

    float fTimeAcc = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Arrow.transform.position = Player.transform.position;
        Gauge.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(iClickCount == 0)
        {
            
        }
        else if(iClickCount == 1)
        {
            Arrow.Stop();
            Gauge.gameObject.SetActive(true);
            Gauge.transform.position = Player.transform.position;

            Gauge.transform.Translate(0f, -.8f, 0f);

        }
        else if(iClickCount == 2)
        {
            Gauge.Stop();

            fTimeAcc += Time.deltaTime;
        }

        if(fTimeAcc > 1f)
        {
            Gauge.gameObject.SetActive(false);
            Arrow.gameObject.SetActive(false);
            Player.Jumping();
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            ++iClickCount;
        }
    }
}
