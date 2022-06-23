using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;  //�������� �и��� �ӵ�

    public AudioClip deathClip;
    
    public float jumpForce = 0.2f;
    public float jumpForceX = 3000f;


    private int jumpCount = 0;       //���� ����Ƚ��
    private bool isGrounded = false; //���� �پ��ִ���
    private bool isDead = false;     //�׾�����

    private bool bJumping = false;

    private Rigidbody2D playerRigidbody;
    
    private Animator animator;

    private AudioSource playerAudio;

    void Start()
    {
        //�ʱ�ȭ �۾�
        //���� ������Ʈ�κ��� ����� ������Ʈ���� ������ ������ �Ҵ�
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
            return;

        if (isGrounded)
        {
            bJumping = false;
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            playerRigidbody.AddForce(transform.up * 300f);
        }

        if (Input.GetMouseButtonDown(0) && jumpCount < 1)
        {
            jumpCount++;

            playerRigidbody.velocity = Vector2.zero;    //���� �ӵ��� ������ ���� �ʵ��� ��

            playerRigidbody.AddForce(new Vector3(jumpForceX,jumpForce));

            playerAudio.Play();
        }
        else if(Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)
        {
            //y���� ����̸� �ӵ��� �������� ����
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }

        //�ִϸ������� Grounded �Ķ���͸� isGrounded ������ ����
        animator.SetBool("Grounded", isGrounded); 
    }

    private void Die()
    {
        //����� �ҽ��� �Ҵ�� ����� Ŭ���� deathClip ���� ����
        playerAudio.clip = deathClip;

        playerAudio.Play();

        //�ӵ��� ���η� ����
        playerRigidbody.velocity = Vector2.zero;

        //��� ���¸� true ����
        isDead = true;

        //���� �Ŵ����� ���ӿ��� ó��
        GameManager.instance.OnplayerDead();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //ù��°�� �浹�� �븻������ y�� ������ 0.7�̻��� ���(���� ������ ���)
        if(collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;      //������ �ִ�
            jumpCount = 0;          //�ʱ�ȭ
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dead" && !isDead)
            Die();
    }

    public bool IsJumping()
    {
        return isGrounded;
    }
    public void Jumping()
    {
        bJumping = true;
    }
}
