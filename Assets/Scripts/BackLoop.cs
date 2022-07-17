using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackLoop : MonoBehaviour
{
    private float hight;


    private void Awake()
    {
        //배경의 스크롤링을 위해 박스의 가로길이를 width로 사용
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        hight = backgroundCollider.size.y;
        System.Console.WriteLine(hight);

    }

    // Update is called once per frame
    void Update()
    {

            Reposition();
    }

    public void Reposition()
    {
        Vector2 offset = new Vector2(0, hight * 2f);
        transform.position = (Vector2)transform.position + offset;
    }
}
