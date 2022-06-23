using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;  //왼쪽으로 밀리는 속도

    public AudioClip deathClip;
    
    public float jumpForce = 0.2f;
    public float jumpForceX = 3000f;


    private int jumpCount = 0;       //누적 점프횟수
    private bool isGrounded = false; //땅에 붙어있는지
    private bool isDead = false;     //죽었는지

    private bool bJumping = false;

    private Rigidbody2D playerRigidbody;
    
    private Animator animator;

    private AudioSource playerAudio;

    void Start()
    {
        //초기화 작업
        //게임 오브젝트로부터 사용할 컴포넌트들을 가져와 변수에 할당
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

            playerRigidbody.velocity = Vector2.zero;    //직전 속도에 영향을 받지 않도록 함

            playerRigidbody.AddForce(new Vector3(jumpForceX,jumpForce));

            playerAudio.Play();
        }
        else if(Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)
        {
            //y값이 양수이면 속도를 절반으로 변경
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }

        //애니메이터의 Grounded 파라미터를 isGrounded 값으로 갱신
        animator.SetBool("Grounded", isGrounded); 
    }

    private void Die()
    {
        //오디오 소스에 할당된 오디오 클립을 deathClip 으로 변경
        playerAudio.clip = deathClip;

        playerAudio.Play();

        //속도를 제로로 변경
        playerRigidbody.velocity = Vector2.zero;

        //사망 상태를 true 변경
        isDead = true;

        //게임 매니저의 게임오버 처리
        GameManager.instance.OnplayerDead();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //첫번째로 충돌한 노말벡터의 y축 방향이 0.7이상일 경우(위쪽 방향일 경우)
        if(collision.contacts[0].normal.y > 0.7f)
        {
            isGrounded = true;      //땅위에 있다
            jumpCount = 0;          //초기화
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
