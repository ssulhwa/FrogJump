using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackLoop : MonoBehaviour
{
    private float width;
    private void Awake()
    {
        //����� ��ũ�Ѹ��� ���� �ڽ��� ���α��̸� width�� ���
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
