using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Global : MonoBehaviour
{
    public GameObject blockFab;
    public GameObject ballFab;

    public float SPEED = 50;

    public int numHits = 0;
    public int numBackwallHits = 0;


    public int score = 0;

    public int numBlocksX;
    public int numBlocksY;
    public int numBlocksZ;

    public float gapBlocksX;
    public float gapBlocksY;
    public float gapBlocksZ;

    public float blockYDist;
    public float blockZDist;

    public float initBallX;
    public float initBallY;
    public float initBallZ;

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
        for (int i = -numBlocksX / 2; i <= numBlocksX / 2; ++i) {
            for (int j = -numBlocksY / 2; j <= numBlocksY / 2; ++j) {
                for (int k = 0; k < numBlocksZ; ++k)
                {
                    blocks[count] = Instantiate(blockFab,
                        new Vector3(i * gapBlocksX, blockYDist + j * gapBlocksY, blockZDist + k * gapBlocksZ),
                        Quaternion.identity);
                    blocks[count].name = "Block " + count;
                    Color color = new Color(0.2f / numBlocksZ * (k + 1), 0.2f + 0.5f / numBlocksZ * (k + 1), 0.1f + 0.75f / numBlocksZ * (k + 1), 0.7f + 0.15f / numBlocksZ * (k + 1));
                    //blocks[count].GetComponent<Renderer>().material.SetColor("_Color", color);
                    blocks[count].GetComponent<Renderer>().material.SetColor("_EmissionColor", color);

                    ++count;
                }
            }
        }
        //ball = Instantiate(ballFab,
        //    new Vector3(initBallX, initBallY, initBallZ),
        //    Quaternion.identity);

        //Vector3 rand = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        //ball.GetComponent<Rigidbody>().AddRelativeForce(SPEED * rand);

    }

    // Update is called once per frame
    void Update()
    {
    }
}

