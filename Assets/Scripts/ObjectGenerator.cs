using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public BlockController Block_1x;
    public BlockController Block_2x;
    public BlockController Block_3x;
    public BlockController Block_4x;

    private BlockController Block;
    
    public enum BLOCKSIZE
    {
        Various,
        _1x,
        _2x,
        _3x,
        _4x
    }
    private enum DIR
    {
        RIGHT,
        LEFT
    }

    public BLOCKSIZE    BlockSize    = BLOCKSIZE.Various;

    public float HeightInterval = 4f;
    public int   Floor          = 5;

    BLOCKSIZE GeneratedBlockSize;
    float     PrevX;
    DIR       PrevDir;

    // Start is called before the first frame update
    void Start()
    {
        Generator_A();
        //Generator_B();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void BlockGenerator()
    {
        switch (BlockSize)
        {
            case BLOCKSIZE.Various:

                int iRandomSize = (int)Random.Range(0f, 10f);

                if (iRandomSize < 4)
                {
                    Block = Instantiate(Block_1x) as BlockController;
                    GeneratedBlockSize = BLOCKSIZE._1x;
                }
                else if (iRandomSize < 7)
                {
                    Block = Instantiate(Block_2x) as BlockController;
                    GeneratedBlockSize = BLOCKSIZE._2x;
                }
                else if (iRandomSize < 9)
                {
                    Block = Instantiate(Block_3x) as BlockController;
                    GeneratedBlockSize = BLOCKSIZE._3x;
                }
                else
                {
                    Block = Instantiate(Block_4x) as BlockController;
                    GeneratedBlockSize = BLOCKSIZE._4x;
                }

                break;

            case BLOCKSIZE._1x:
                Block = Instantiate(Block_1x) as BlockController;
                GeneratedBlockSize = BLOCKSIZE._1x;
                break;

            case BLOCKSIZE._2x:
                Block = Instantiate(Block_2x) as BlockController;
                GeneratedBlockSize = BLOCKSIZE._2x;
                break;

            case BLOCKSIZE._3x:
                Block = Instantiate(Block_3x) as BlockController;
                GeneratedBlockSize = BLOCKSIZE._3x;
                break;

            case BLOCKSIZE._4x:
                Block = Instantiate(Block_4x) as BlockController;
                GeneratedBlockSize = BLOCKSIZE._4x;
                break;
        }
    }

    void Generator_A()
    {
        for (int i = 0; i < Floor; ++i)
        {
            BlockGenerator();

            if (i == 0)
            {
                Block.transform.position = new Vector3(Random.Range(-5f, 5f), 1f + HeightInterval * i);
            }
            else
            {
                float fRandomX = 0f;

                if (PrevDir == DIR.RIGHT)
                {
                    if (GeneratedBlockSize == BLOCKSIZE._1x)
                    {
                        fRandomX = Random.Range(-5f, -0.7f);
                    }
                    else if (GeneratedBlockSize == BLOCKSIZE._2x)
                    {
                        fRandomX = Random.Range(-4.25f, -1.5f);
                    }
                    else if (GeneratedBlockSize == BLOCKSIZE._3x)
                    {
                        fRandomX = Random.Range(-3.55f, -2.10f);
                    }
                    else
                    {
                        fRandomX = -2.85f;
                    }
                }
                else
                {
                    if (GeneratedBlockSize == BLOCKSIZE._1x)
                    {
                        fRandomX = Random.Range(0.7f, 5f);
                    }
                    else if (GeneratedBlockSize == BLOCKSIZE._2x)
                    {
                        fRandomX = Random.Range(1.5f, 4.25f);
                    }
                    else if (GeneratedBlockSize == BLOCKSIZE._3x)
                    {
                        fRandomX = Random.Range(2.1f, 3.55f);
                    }
                    else
                    {
                        fRandomX = 2.85f;
                    }
                }

                Block.transform.position = new Vector3(fRandomX, 1f + HeightInterval * i);
            }

            if (Block.transform.position.x > 0)
            {
                PrevDir = DIR.RIGHT;
            }
            else
            {
                PrevDir = DIR.LEFT;
            }
        }
    }

    void Generator_B()
    {
        for (int i = 0; i < Floor; ++i)
        {
            BlockGenerator();

            if (i == 0)
            {
                Block.transform.position = new Vector3(Random.Range(-5f, 5f), 1f + HeightInterval * i);
            }
            else
            {
                do
                {
                    Block.transform.position = new Vector3(Random.Range(-5f, 5f), 1f + HeightInterval * i);
                }
                while (Mathf.Abs(PrevX - Block.transform.position.x) < 2f);
            }

            PrevX = Block.transform.position.x;
        }
    }
}
