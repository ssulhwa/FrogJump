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

    public BLOCKSIZE    BlockSize    = BLOCKSIZE.Various;

    public float HeightInterval = 4f;
    public int   Floor          = 5;
    public float XInterval      = 0.5f;

    Vector3 PrevPos;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i< Floor; ++i)
        {
            BlockGenerater();

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
                while (Mathf.Abs(PrevPos.x - Block.transform.position.x) < XInterval);
            }

            PrevPos = Block.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BlockGenerater()
    {
        switch (BlockSize)
        {
            case BLOCKSIZE.Various:

                int iRandomSize = (int)Random.Range(1f, 4f);

                if(iRandomSize == 1)
                {
                    Block = Instantiate(Block_1x) as BlockController;
                }
                else if(iRandomSize == 2)
                {
                    Block = Instantiate(Block_2x) as BlockController;
                }
                else if (iRandomSize == 3)
                {
                    Block = Instantiate(Block_3x) as BlockController;
                }
                else if (iRandomSize == 4)
                {
                    Block = Instantiate(Block_4x) as BlockController;
                }

                break;

            case BLOCKSIZE._1x:
                Block = Instantiate(Block_1x) as BlockController;
                break;

            case BLOCKSIZE._2x:
                Block = Instantiate(Block_2x) as BlockController;
                break;

            case BLOCKSIZE._3x:
                Block = Instantiate(Block_3x) as BlockController;
                break;

            case BLOCKSIZE._4x:
                Block = Instantiate(Block_4x) as BlockController;
                break;
        }
    }
}
