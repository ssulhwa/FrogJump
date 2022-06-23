using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private bool stepped = false;


    private void OnEnable()
    {
        //���� ����

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //��������
        if (collision.collider.tag == "Player" && !stepped) //�浹�� ������Ʈ�� �±װ� Player �̰� ���� ���� ���� ���¶��
        {
            stepped = true;
            GameManager.instance.AddScore(1);
        }
    }
}
