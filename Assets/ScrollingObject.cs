using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    public float speed = 2f;  //�̵��ӵ�

    void Update()
    {
        //�ʴ� speed�� �ӵ��� �������� ���� �̵�
        transform.Translate(Vector3.left * speed * Time.deltaTime);

    }
}
