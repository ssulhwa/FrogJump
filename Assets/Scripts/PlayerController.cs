using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private enum STATE 
    { 
        STATE_IDLE,
        STATE_ARROW_GENERATE,
        STATE_ARROW,
        STATE_GAUGE_GENERATE,
        STATE_GAUGE,
        STATE_JUMPING,
        STATE_FLYING,
        STATE_LANDING,
        STATE_END
    };

    private STATE eState;
    private Vector2 vDir;
    private float fPower      = 0f;
    private float fTimeAcc    = 0f;
    private int   iReflectCnt = 0;
    private bool  bStart      = false;

    public ArrowController ArrowPrefab;
    public ArrowController Arrow;

    public GaugeController GaugePrefab;
    public GaugeController Gauge;

    /////////////////////////////////////////////////////////////////

    public float speed = 2f;  //�������� �и��� �ӵ�

    private Animator    animator;
    public  AudioClip   deathClip;
    private Rigidbody2D playerRigidbody;
    private AudioSource playerAudio;

    private bool isGrounded = false; //���� �پ��ִ���
    private bool isDead     = false; //�׾�����

    void Start()
    {
        //�ʱ�ȭ �۾�
        //���� ������Ʈ�κ��� ����� ������Ʈ���� ������ ������ �Ҵ�
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator        = GetComponent<Animator>();
        playerAudio     = GetComponent<AudioSource>();

        eState = STATE.STATE_FLYING;

        bStart = true;

        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            Time.timeScale = 0;

            return;
        }

        PlayerBehavior();
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
            iReflectCnt = 0;
            eState = STATE.STATE_LANDING;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dead" && !isDead)
        {
            Die();
        }     
        if(collision.tag == "ReflectR" || collision.tag == "ReflectL")
        {
            playerAudio.Play();

            Vector3 vNormal;

            if(collision.tag == "ReflectR")
            {
                vNormal = new Vector3(-1f, 0f, 0f);
            }
            else
            {
                vNormal = new Vector3(1f, 0f, 0f);
            }

            if(iReflectCnt == 1)
            {
                vDir.y *= -1;
            }

            Vector3 vReflect = Vector3.Reflect(vDir, vNormal);

            Vector3.Normalize(vDir);

            transform.right = new Vector3(-vDir.x, 0f, 0f);

            playerRigidbody.velocity = Vector2.zero;

            playerRigidbody.AddForce(vReflect * fPower);

            vDir = vReflect;

            ++iReflectCnt;
        }
    }

    private void PlayerBehavior()
    {
        switch (eState)
        {
            case STATE.STATE_IDLE:

                fTimeAcc += Time.deltaTime;

                if(fTimeAcc > .2f)
                {
                    eState = STATE.STATE_ARROW_GENERATE;

                    fTimeAcc = 0f;
                }

                break;

            case STATE.STATE_ARROW_GENERATE:

                Arrow = Instantiate(ArrowPrefab) as ArrowController;

                Arrow.transform.position = this.transform.position;

                eState = STATE.STATE_ARROW;

                break;

            case STATE.STATE_ARROW:

                if(Input.GetKeyDown(KeyCode.Space))
                {
                    vDir = Arrow.transform.up;

                    Vector3.Normalize(vDir);

                    transform.right = new Vector3(vDir.x, 0f, 0f);

                    Arrow.Stop();

                    eState = STATE.STATE_GAUGE_GENERATE;
                }

                break;

            case STATE.STATE_GAUGE_GENERATE:

                Gauge = Instantiate(GaugePrefab) as GaugeController;

                Gauge.transform.position = this.transform.position;

                Gauge.transform.Translate(0f, -.8f, 0f);

                eState = STATE.STATE_GAUGE;

                break;

            case STATE.STATE_GAUGE:

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    fPower = Gauge.bar.transform.localScale.x * 800f;

                    Gauge.Stop();

                    eState = STATE.STATE_JUMPING;
                }

                break;

            case STATE.STATE_JUMPING:

                fTimeAcc += Time.deltaTime;

                if(fTimeAcc > .1f)
                {
                    playerRigidbody.velocity = Vector2.zero;

                    playerRigidbody.AddForce(vDir * fPower);
                    Destroy(Arrow.gameObject);  
                    Destroy(Gauge.gameObject);

                    eState = STATE.STATE_FLYING;

                    playerAudio.Play();

                    isGrounded = false;
                    animator.SetBool("Grounded", isGrounded);

                    fTimeAcc = 0f;
                }

                break;

            case STATE.STATE_FLYING:
                break;

            case STATE.STATE_LANDING:

                animator.SetBool("Grounded", isGrounded);

                playerRigidbody.velocity = Vector2.zero;

                if (true == bStart)
                {
                    Arrow = Instantiate(ArrowPrefab) as ArrowController;

                    Arrow.transform.position = this.transform.position;

                    eState = STATE.STATE_ARROW;

                    fTimeAcc = 0;

                    bStart = false;

                    break;
                }
                else
                {
                    fTimeAcc += Time.deltaTime;
                }
                if (fTimeAcc > .5f && true == isGrounded)
                {
                    eState = STATE.STATE_IDLE;

                    fTimeAcc = 0f;
                }

                break;
        }
    }
}
