using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 2f;  //이동속도

    void Update()
    {
        //초당 speed의 속도로 왼쪽으로 평행 이동
        transform.Translate(Vector3.left * speed * Time.deltaTime);

    }
}
