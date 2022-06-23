using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    private bool stepped = false;


    private void OnEnable()
    {
        //발판 리셋

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //점수증가
        if (collision.collider.tag == "Player" && !stepped) //충돌한 오브젝트의 태그가 Player 이고 아직 밟지 않은 상태라면
        {
            stepped = true;
            GameManager.instance.AddScore(1);
        }
    }
}
