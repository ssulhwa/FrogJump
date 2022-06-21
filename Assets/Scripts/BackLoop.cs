using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackLoop : MonoBehaviour
{
    private float width;
    private void Awake()
    {
        //배경의 스크롤링을 위해 박스의 가로길이를 width로 사용
        BoxCollider2D backgroundCollider = GetComponent<BoxCollider2D>();
        width = backgroundCollider.size.x;
        System.Console.WriteLine(width);

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <= -width)
            Reposition();
    }

    public void Reposition()
    {
        Vector2 offset = new Vector2(width * 2f, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
