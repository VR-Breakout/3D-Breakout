using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehavior : MonoBehaviour
{

    public float MinSpeed = 2;
    public float MaxSpeed = 10;
    public float SlowThresholdRange = 3;
    public float constantDrag;
    public AudioSource PaddleHitSound;
    public AudioSource BlockHitSound;

    private Rigidbody rb;
    private GameObject PlayerCamera;

    private float timeElapsedPaddle = 0.0f;
    private float timeElapsedBlock = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        PlayerCamera = FindObjectOfType<Camera>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsedPaddle += Time.deltaTime;
        timeElapsedBlock += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, MaxSpeed);

        // slow the ball down when it get close to the player
        float distance = (transform.position - PlayerCamera.transform.position).magnitude;
        if (distance < SlowThresholdRange)
        {
            rb.drag = constantDrag * (0.1f + 0.8f * (SlowThresholdRange  - distance) / SlowThresholdRange);
        } else
        {
            rb.drag = 0f;
        }
        if (rb.velocity.magnitude < MinSpeed)
        {
            rb.velocity = rb.velocity.normalized * MinSpeed;
        }
        //todo min
        /*else if (rb.velocity.magnitude == MinSpeed)
        {
            rb.AddForce(new Vector3(0, 0, 0.1f));
        }*/

    }

    void OnCollisionEnter(Collision collision)
    {
        if (timeElapsedPaddle >= 0.4f && collision.gameObject.CompareTag("Paddle"))
        {
            PaddleHitSound.Play();
            timeElapsedPaddle = 0.0f;
        } else if (timeElapsedBlock >= 0.2f  && collision.gameObject.CompareTag("Block"))
        {
            BlockHitSound.Play();
            timeElapsedBlock = 0.0f;
        }
    }
}
