using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    private PlayerController Player;
    private GameObject       Particle;

    private bool isMoving = false;
    private bool stepped  = false;
    private int  iMySize  = 0;

    private List<GameObject> Particles;

    private void OnEnable()
    {
        stepped = false;
    }

    void Start()
    {
        Player = GameObject.FindObjectOfType<PlayerController>();

        Particles = new List<GameObject>();

        Vector3 vPos= transform.position;

        if(iMySize == 1)
        {
            for (int i = -1; i <= iMySize; i += 2)
            {
                Particle = Instantiate(Resources.Load<GameObject>("Splash" + ((int)Random.Range(1f, 5.99f)).ToString()));

                vPos.x = transform.position.x + i / 2f;
                vPos.y = transform.position.y + 1f;

                Particle.transform.position = vPos;

                Particles.Add(Particle);
            }
        }
        else if(iMySize == 2)
        {
            for(int i = -1; i < iMySize; ++i)
            {
                Particle = Instantiate(Resources.Load<GameObject>("Splash" + ((int)Random.Range(1f, 5.99f)).ToString()));

                vPos.x = transform.position.x + i;
                vPos.y = transform.position.y + 1f;

                Particle.transform.position = vPos;

                Particles.Add(Particle);
            }
        }
        else if (iMySize == 3)
        {
            for (int i = -2; i < iMySize; ++i)
            {
                Particle = Instantiate(Resources.Load<GameObject>("Splash" + ((int)Random.Range(1f, 5.99f)).ToString()));

                vPos.x = transform.position.x + i;
                vPos.y = transform.position.y + 1f;

                Particle.transform.position = vPos;

                Particles.Add(Particle);
            }
        }
    }

    void Update()
    {
        if(true == isMoving)
        {
            MovableBlock();
        }

        if(transform.position.y + 15f < UnityEngine.Camera.main.gameObject.transform.position.y)
        {
            foreach(var Particle in Particles)
            {
                Destroy(Particle);
            }

            Particles.Clear();
            
            Destroy(gameObject);
        }
    }

    void MovableBlock()
    {
        transform.RotateAround(Vector3.up, Vector3.up, 100 * Time.deltaTime);
        transform.right = Vector3.right;

        Vector3 vParticlePos = transform.position;

        vParticlePos.y = transform.position.y + 1f;

        Particle.transform.position = vParticlePos;
    }

    public void SetMoveState()
    {
        isMoving = true;
    }
    public void SetSize(int size)
    {
        iMySize = size;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player.SetState(isMoving);

        if(gameObject.tag != "BeginGround")
        {
            if (collision.collider.tag == "Player" && !stepped)
            {
                
                if(collision.contacts[0].normal.y < -0.7f)
                {
                    stepped = true;
                    GameManager.instance.AddScore(100);
                }
            }
        }
    }
}
