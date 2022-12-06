using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public GameObject blockFab;
    public GameObject ballFab;

    public float SPEED = 50;

    public int numBlocksX;
    public int numBlocksY;
    public int numBlocksZ;

    public float gapBlocksX;
    public float gapBlocksY;
    public float gapBlocksZ;

    GameObject[] blocks;
    GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        blocks = new GameObject[numBlocksX * numBlocksY * numBlocksZ];
        if (ballFab == null || blockFab == null)
        {
            Debug.LogError("need assign fabs for ball and block");
            return;
        }

        int count = 0;
        for (int i = -numBlocksX / 2; i < numBlocksX / 2; ++i) {
            for (int j = 0; j < numBlocksY; ++j) {
                for (int k = 0; k < numBlocksZ; ++k)
                {
                    blocks[count++] = Instantiate(blockFab,
                        new Vector3(i * gapBlocksX, j * gapBlocksY, k * gapBlocksZ),
                        Quaternion.identity);
                }
            }
        }
        ball = Instantiate(ballFab,
            new Vector3(0, 0.5f, -4),
            Quaternion.identity);

        Vector3 rand = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        ball.GetComponent<Rigidbody>().AddRelativeForce(SPEED * rand);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
