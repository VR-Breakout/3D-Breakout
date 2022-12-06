using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Global : MonoBehaviour
{
    public GameObject blockFab;
    public GameObject ballFab;

    public float SPEED = 50;

    GameObject[] blocks = new GameObject[7 * 7 * 4];
    GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        if (ballFab == null || blockFab == null)
        {
            Debug.LogError("need assign fabs for ball and block");
            return;
        }

        int count = 0;
        for (int i = -3; i <= 3; ++i) {
            for (int j = -3; j <= 3; ++j) {
                for (int k = 0; k < 4; ++k)
                {
                    blocks[count++] = Instantiate(blockFab,
                        new Vector3(i * 1.3f, 0.5f + j * 1.3f, k * 1.3f),
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
